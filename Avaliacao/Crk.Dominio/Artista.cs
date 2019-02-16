using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crk.Dominio
{
    [Table("artista", Schema = "public")]
    public class Artista : IComparable<Artista>
    {
        [Key]
        public int artista_id { get; set; }

        [Required(ErrorMessage = "Nome do artista requirido.")]
        [MaxLength(100)]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        public int CompareTo(Artista other)
        {
            return System.String.Compare(this.nome, other.nome, System.StringComparison.Ordinal);
        }
    }
}
