using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Crk.Dominio;
using Crk.Aplicacao;

namespace CrkMvc.Web.ViewModels
{
    public class cdViewModel : IEnumerable<Cd>
    {
        public int CdCount { get; set; }
        public List<Cd> Cd { get; set; }



        public IEnumerator<Cd> GetEnumerator()
        {
            return Cd.GetEnumerator();
        }




        IEnumerator IEnumerable.GetEnumerator()
        {
            return Cd.GetEnumerator();
        }
    }
}