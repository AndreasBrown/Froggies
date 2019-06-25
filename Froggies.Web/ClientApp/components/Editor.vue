<template>
    <section>
        <div class="board" v-if="board.Cells">

            <div class="board-row" v-for="(row, i) in board.Cells" :key="'EDITOR-ROW_' + i">

                <Cell v-for='(cell, j) in row' 
                        :currentCell="cell" cellClass="board-cell"
                        :cellId="'FROG-' + cell + i + j"
                        :key="'EDITOR-CELL_' + cell + i + j"
                        :dragOptions="frogDragOptions"/>

            </div>

        </div>

    </section>
</template>

<script lang="ts">
    
    import {Component, Prop, Vue} from 'vue-property-decorator';
    import Cell from './Cell.vue';
    import Game from '../model/Game';
    import FrogDragOptions from '../model/FrogDragOptions';

    @Component({
        components: { Cell }
    })
    export default class Editor extends Vue {

        @Prop()
        readonly levelId!: number;
        
        board: Game = new Game(<any>[]);

        get frogDragOptions(): FrogDragOptions {
            return {
                dropzoneSelector: '.board-cell',

                onDrag() {},

                onDragStart(e: any) {
                    e.dataTransfer.setData('frog', e.target.id);
                    //console.log({start: e});
                },

                onDragEnd(e: any){
                    //console.log({end: e});
                }
            };
        }
        
        created() {
            fetch('/api/levels/1') // TODO: levelId.
                .then(resp => resp.json())
                .then(json => {
                    this.board = new Game(json);
                });
        }
    
    
}

</script>


<style lang="less" scoped>
    
    .board {
        display: table;

        &-row { display: table-row }
        & /deep/ &-cell { 
            display: table-cell;
            vertical-align: middle;

            .frog {
                margin: auto;
            }
        }
    }
    

    .dragover {
        background-color: #aa77FF
    }
    

</style>

