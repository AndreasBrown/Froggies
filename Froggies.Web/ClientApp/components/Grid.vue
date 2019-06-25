<template>
    <div class="board">

        <div class="board-row" v-for="(row, y) in grid" :key="'ROW-' + y">

            <Cell v-for='(cell, x) in row' :key="'CELL-' + cell + y + x"
                    cellClass="board-cell"
                    :currentCell="cell"
                    :position="{ X: x, Y: y}"
                    :dragOptions="frogDragOptions"
                    @drop="frogDragOptions.onDragEnd"/>

        </div>
    </div>
</template>

<script lang="ts">
    import { Component, Prop, Vue } from 'vue-property-decorator';
    import Game from '../model/Game';
    import CellType from '../model/CellType';
    import Point from '../model/Point';
    import FrogDragOptions from '../model/FrogDragOptions';
    import Cell from './Cell.vue';
    import { setTimeout } from 'timers';

    @Component({
        components: { Cell }
    })
    export default class Grid extends Vue {

        @Prop({required: true})
        game!: Game;

        get grid(): CellType[][] {
            return this.game.Cells;
        }

        get frogDragOptions(): FrogDragOptions {
            return {
                dropzoneSelector: '.board-cell',

                onDrag() {},

                onDragStart(e: any) {
                    e.dataTransfer.setData('frog', e.target.id);
                    //console.log({start: e});
                },

                onDragEnd: (e: any) => {
                    console.log({end: e});
                    const pos: string = e.droppedFrogId.substring(e.droppedFrogId.length-2);
                    const from: Point = { X: Number(pos[1]), Y: Number(pos[0]) } 
                    this.move(from, e.position);
                }
            };
        }

        getCell(pos: Point): CellType {
            return this.grid[pos.Y][pos.X];
        }

        setCell(pos: Point, frog: CellType) {
            this.grid[pos.Y][pos.X] = frog;
        }

        move(from: Point, to: Point) {
            const movedFrog = this.getCell(from);

            const distance: Point = {
                X: Math.abs(to.X - from.X),
                Y: Math.abs(to.Y - from.Y)
            }

            if (!(
                    (distance.X == 4 && distance.Y == 0)
                 || (distance.X == 0 && distance.Y == 4)
                 || (distance.X == 2 && distance.X == 2))
                )
                    return;

            if (this.getCell(to) !== CellType.Empty)
                return;

            const eat: Point = {
                X: (from.X + to.X) / 2,
                Y: (from.Y + to.Y) / 2
            }

            if (this.getCell(eat) !== CellType.GreenFrog)
                return;

            this.setCell(from, CellType.Empty);
            this.setCell(eat, CellType.Empty); 
            this.setCell(to, movedFrog);

            this.game.Cells = [...this.grid]; // хак прикол
        }

    }

</script>
