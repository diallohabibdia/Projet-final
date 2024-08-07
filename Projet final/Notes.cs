using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_final
{
    public class Notes
    {
        public int NumeroEtudiant { get; set; }
        public int NumeroCours { get; set; }
        public double Note { get; set; }

        public Notes(int numeroEtudiant, int numeroCours, double note)
        {
            this.NumeroEtudiant = numeroEtudiant;
            this.NumeroCours = numeroCours;
            this.Note = note;
        }
    }

}
