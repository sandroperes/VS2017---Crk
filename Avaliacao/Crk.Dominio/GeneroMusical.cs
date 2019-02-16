using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crk.Dominio
{
    [Table("generomusical", Schema = "public")]
    class GeneroMusical : IComparable<GeneroMusical>
    {
        [Key]
        public int generomusical_id { get; set; }

        [Required(ErrorMessage = "Descrição do Gênero Musical requirido.")]
        [MaxLength(100)]
        [Display(Name = "Gênero")]
        public string descricao { get; set; }

        public int CompareTo(GeneroMusical other)
        {
            return System.String.Compare(this.descricao, other.descricao, System.StringComparison.Ordinal);
        }


    }
}
