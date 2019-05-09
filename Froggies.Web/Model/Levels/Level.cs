using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Froggies.Web.Model.Levels
{
    public class Level : Entity
    {
        private Cell[][] _cells { get; set; }

        [NotMapped]
        public Cell[][] Cells
        {
            get
            {
                return this._cells ?? (this._cells = JsonConvert.DeserializeObject<Cell[][]>(this.CellsJson));
            }
            set
            {
                this._cells = value;
                this.CellsJson = JsonConvert.SerializeObject(value);
            }
        }

        [Required]
        [Column("Cells")]
        public string CellsJson { get; set; }

        public Cell[] this[int row] => this.Cells[row];
    }
}
