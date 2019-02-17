using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crk.Dominio
{
    [Table("cd", Schema = "public")]
    public class Cd
    {
        [Key]
        public int cd_id { get; set; }

        [Required(ErrorMessage = "Título do CD requirido.")]
        [MaxLength(100)]
        [Display(Name = "Título")]
        public string titulo { get; set; }

        [Display(Name = "Artista")]
        public int? artista_id { get; set; }
        public virtual Artista Artista { get; set; }

        [Display(Name = "Genero Musical")]
        public int? generomusical_id { get; set; }
        public virtual GeneroMusical GeneroMusical { get; set; }

        public virtual ICollection<CdMusicas> CdMusicas { get; set; }
         
    }
}
