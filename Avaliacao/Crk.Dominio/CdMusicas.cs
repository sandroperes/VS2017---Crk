using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crk.Dominio
{
    [Table("cdmusicas", Schema = "public")]
    public class CdMusicas
    {
        [Key]
        public int cdmusicas_id { get; set; }

        [Required(ErrorMessage = "Nome da música requirido.")]
        [MaxLength(100)]
        [Display(Name = "Música")]
        public string nomeMusica { get; set; }

        [Display(Name = "Duração")]
        public int duracao { get; set; }

        [Display(Name = "CD")]
        public int? cd_id { get; set; }
        public virtual Cd Cd { get; set; }

    }
}
