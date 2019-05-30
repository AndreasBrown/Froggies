<template>
    <section>
        <h1> EDITOR </h1>
        
        <table class='board' v-if="board.Cells">
            <tr v-for='row in board.Cells'>

                <td v-for='cell in row'>
                    <Draggable @start="dragOptions.onDragStart" @end="dragOptions.onDragEnd">  
                        <Cell :CurrentCell="cell" />
                    </Draggable>
                </td>

            </tr>
        </table>

    </section>
</template>

<script lang="ts">
    
    import {Component, Prop, Vue} from 'vue-property-decorator';
    import Level from '../model/Level';
    import Cell from "./Cell.vue";
    const Draggable: any = require('vuedraggable');

    @Component({
        components: { Cell, Draggable }
    })
    export default class Editor extends Vue {

        @Prop()
        readonly levelId!: number;
        
        board: Level = new Level(<any>[]);

        get dragOptions(): any {
            return {
                dropzoneSelector: ".cell--empty",
                draggableSelector: ".frog",
                onDragStart: function(e: any) { console.log(e); },
                onDragEnd: function(e: any) { console.log(e); },
                
            };
        }
        
        created() {
            fetch('/api/levels/1') // TODO: levelId.
                .then(resp => resp.json())
                .then(json => {
                    this.board = new Level(json);
                });
        }
    
    
}

</script>


<style lang="less" scoped>
    
    .board {
        
    }
    

    .dragover {
        background-color: #aa77FF
    }
    

</style>

