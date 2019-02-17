using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Crk.Dominio;
using Crk.Aplicacao;
using System.Collections;

namespace CrkMvc.Web.ViewModels
{
    public class cdMusicasViewModel : IEnumerable<CdMusicas>
    {
        public int CdMusicasCount { get; set; }
        public List<CdMusicas> CdMusicas { get; set; }
        public Cd cd { get; set; }

        public IEnumerator<CdMusicas> GetEnumerator()
        {
            return CdMusicas.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return CdMusicas.GetEnumerator();
        }

    }
}