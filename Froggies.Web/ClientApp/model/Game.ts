import CellType from './CellType';

export default class Game {
    public Cells: CellType[][];

    constructor(cellsJson: JSON | CellType[][]) {
        this.Cells = cellsJson as CellType[][];
    }
}