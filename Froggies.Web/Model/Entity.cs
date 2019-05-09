using System.ComponentModel.DataAnnotations;

namespace Froggies.Web.Model
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
