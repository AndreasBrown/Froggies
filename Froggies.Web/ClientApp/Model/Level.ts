import { CellType } from "./CellType";

export default class Level {
    public Cells: CellType[][];

    constructor(cellsJson: JSON) {
        this.Cells = <Array<Array<CellType>>> (<any>cellsJson);
    }
}