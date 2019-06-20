<template>
    <div :class="`cell ${cellDefaultClass} ${cellPropClass}`" @drop="onDrop" @dragover="allowDrop">
        
        <div v-if="isGreenFrog || isRedFrog"
            :id="cellId"
             :class="`${frogDefaultClass} ${frogPropClass}`"
             @dragstart="dragOptions.onDragStart"
             @dragend="dragOptions.onDragEnd" draggable="true" ref="frog">
        
        </div>
        
    </div>
</template>

<script lang="ts">

    import {Component, Prop, Vue} from "vue-property-decorator";
    import CellType from "../model/CellType";
    import FrogDragOptions from '../model/FrogDragOptions';

    @Component({})
    export default class Cell extends Vue {
        @Prop()
        readonly cellId!: string;

        @Prop()
        readonly CurrentCell!: CellType;

        @Prop()
        readonly cellClass!: string;

        @Prop()
        readonly frogClass!: string;

        @Prop()
        readonly dragOptions!: FrogDragOptions;

        onDrop(dropEvent: any) {
            // if (this.hasFrog)
            //     return;

            let droppedFrogId = dropEvent.dataTransfer.getData('frog');
            
            let frogEl = document.getElementById(droppedFrogId);
            dropEvent.target.appendChild(frogEl);

            console.log({dropEvent});
        }

        allowDrop(e: any) {
            e.preventDefault();
        }

        // TODO: Не обновляется при добавлении/удалении лягухи в эту клетку.
        get hasFrog(): boolean {
            return !!(<any>this.$refs.frog);
        }

        get isGreenFrog(): boolean { return this.CurrentCell === CellType.GreenFrog; }
        get isRedFrog(): boolean { return this.CurrentCell === CellType.RedFrog; }

        get cellPropClass() : string { return this.cellClass ? this.cellClass : ''; }
        get frogPropClass() : string { return this.frogClass ? this.frogClass : ''; }

        get cellDefaultClass() : string {
            switch (this.CurrentCell) {
                case CellType.None:
                    return 'cell--none';
                case CellType.Empty:
                    return 'cell--empty';
                default:
                    return 'cell--with-frog';
            }
        }
        
        get frogDefaultClass() : string {
            switch (this.CurrentCell) {
                case CellType.GreenFrog:
                    return 'frog green-frog';
                case CellType.RedFrog:
                    return 'frog red-frog';
                default:
                    return '';
            }
        }
    }
    
</script>

<style lang="less" scoped>

    .cell {
        @cellSize: 80px;

        width: @cellSize;
        height: @cellSize;

        background: #1155AA;
        border: 1px solid #ccAA99;

        display: flex;
        flex-shrink: 0;
        justify-content: center;
        align-items: center;
        
        &--none {
            
        }
    }
    
    .empty {
        &:extend(.cell);
        
        border: 4px solid #00844c;
        border-radius: 50%;
        z-index: 1;
    }

    .red-frog, .green-frog {
        @frogSize: 40px;

        width: @frogSize;
        height: @frogSize;
    }

    .red-frog {
        background-color: #cc2222
    }

    .green-frog {
        background-color: #22cc22
    }
    
</style>
