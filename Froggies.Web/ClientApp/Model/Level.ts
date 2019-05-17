import { Cell } from './Cell';
export class Level {
    public Cells: Cell[][];

    constructor(cellsJson: JSON) {
        // TODO: Здесь десериализовать JSON вида [["E","G"],["R","N"]] приходящие из базы прямо в this.Cells.

        this.Cells = new Array<Array<Cell>>();
    }
}