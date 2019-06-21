<template>
    <section>
        <h1> EDITOR </h1>

        <div class="board" v-if="board.Cells">

            <div class="board-row" v-for="(row, i) in board.Cells" v-bind:key="'EDITOR-ROW_' + i">

                <Cell v-for='(cell, j) in row' 
                        :CurrentCell="cell" :cellClass="'board-cell'"
                        :cellId="'FROG-' + cell + i + j"
                        v-bind:key="'EDITOR-CELL_' + cell + i + j"
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
            const options = new FrogDragOptions();

            options.onDragStart = (e: any) => {
                e.dataTransfer.setData('frog', e.target.id);
                // TODO: .setData('fromCell', ...)
                console.log({start: e});
            }
            options.onDragEnd = (e: any) => console.log({end: e});

            // TODO: почему ts не видит стринг проп.
            (options as any).dropzoneSelector = '.board-cell';
            

            return options;
        }
        
        created() {
            console.log({opt: this.frogDragOptions});

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
        & /deep/ &-cell { display: table-cell }
    }
    

    .dragover {
        background-color: #aa77FF
    }
    

</style>

