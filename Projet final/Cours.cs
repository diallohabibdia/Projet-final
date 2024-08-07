using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_final
{
    public class Cours
    {
        public int NumeroCours { get; set; }
        public string Code { get; set; }
        public string Titre { get; set; }

        public Cours(int numeroCours, string code, string titre)
        {
            this.NumeroCours = numeroCours;
            this.Code = code;
            this.Titre = titre;
        }
    }

}
