import { Cell } from './Cell';

export class Level {
    public Cells: Cell[][];

    constructor(cellsJson: JSON) {
        this.Cells = <Array<Array<Cell>>> (<any>cellsJson);
    }
}