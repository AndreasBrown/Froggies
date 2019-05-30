<template>
    <div :class="'cell ' + cellClass">
        
        <div v-if="isGreenFrog || isRedFrog"
             :class="frogClass">
        
        </div>
        
    </div>
</template>

<script lang="ts">

    import {Component, Prop, Vue} from "vue-property-decorator";
    import {CellType} from "../model/CellType";

    @Component({})
    export default class Cell extends Vue {
        @Prop()
        readonly CurrentCell!: CellType;

        get isGreenFrog(): boolean {
            return this.CurrentCell === CellType.GreenFrog;
        }

        get isRedFrog(): boolean {
            return this.CurrentCell === CellType.RedFrog;
        }

        get cellClass() : string {
            switch (this.CurrentCell) {
                case CellType.None:
                    return 'cell--none';
                case CellType.Empty:
                    return 'cell--empty';
                default:
                    return 'cell--with-frog';
            }
        }
        
        get frogClass() : string {
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
