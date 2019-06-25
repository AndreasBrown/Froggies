<template>
    <div :class="`cell ${cellDefaultClass} ${cellPropClass}`" @drop="onDrop" @dragover="dragOver">
        
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
        readonly currentCell!: CellType;

        @Prop()
        readonly cellClass!: string;

        @Prop()
        readonly frogClass!: string;

        @Prop()
        readonly dragOptions!: FrogDragOptions;

        onDrop(dropEvent: any) {
            if (dropEvent.toElement.childElementCount
            || dropEvent.toElement.classList.contains('frog'))
                return;

            let droppedFrogId = dropEvent.dataTransfer.getData('frog');
            
            let frogEl = document.getElementById(droppedFrogId);
            dropEvent.target.appendChild(frogEl);
        }

        dragOver(e: any) {
            e.preventDefault();
        }

        get isGreenFrog(): boolean { return this.currentCell === CellType.GreenFrog; }
        get isRedFrog(): boolean { return this.currentCell === CellType.RedFrog; }

        get cellPropClass() : string { return this.cellClass ? this.cellClass : ''; }
        get frogPropClass() : string { return this.frogClass ? this.frogClass : ''; }

        get cellDefaultClass() : string {
            switch (this.currentCell) {
                case CellType.None:
                    return 'cell--none';
                case CellType.Empty:
                    return 'cell--empty';
                default:
                    return 'cell--with-frog';
            }
        }
        
        get frogDefaultClass() : string {
            switch (this.currentCell) {
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
        @frogSize: 50px;

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
