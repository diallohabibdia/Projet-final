using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_final
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Etudiant> etudiants = new List<Etudiant>();
            List<Cours> cours = new List<Cours>();
            List<Notes> notes = new List<Notes>();

            // Ajouter des étudiants
            etudiants.Add(new Etudiant(2721248, "Diallo", "Habib"));
            etudiants.Add(new Etudiant(2721249, "Ly", "Malick"));

            // Ajouter des cours
            cours.Add(new Cours(1, "IFM25914", "Assurance de qualité logicielle"));
            cours.Add(new Cours(2, "IFM25915", "Développement d'applications mobiles pour Android"));
            cours.Add(new Cours(3, "IFM26978", "Programmation orientée objet en C#"));
            cours.Add(new Cours(4, "IFM259", "Introduction à la programmation Web client"));
            cours.Add(new Cours(5, "IFM25906", "Introduction aux bases de données"));

            // Ajouter des notes
            // Notes de l'etudiant Habib Diallo
            notes.Add(new Notes(2721248, 1, 17.5));
            notes.Add(new Notes(2721248, 2, 17.0));
            notes.Add(new Notes(2721248, 3, 18.0));
            notes.Add(new Notes(2721248, 4, 19.5));
            notes.Add(new Notes(2721248, 5, 13.0));
            // Notes de l'etudiant Malick Ly
            notes.Add(new Notes(2721249, 1, 16.0));
            notes.Add(new Notes(2721249, 2, 16.5));
            notes.Add(new Notes(2721249, 3, 17.5));
            notes.Add(new Notes(2721249, 4, 18.0));
            notes.Add(new Notes(2721249, 5, 15.5));

            // Enregistrer les données dans des fichiers texte
            EnregistrerDonnees(etudiants, cours, notes);

            // Afficher le relevé de notes en temps réel
            AfficherReleveNotes();
        }

        static void EnregistrerDonnees(List<Etudiant> etudiants, List<Cours> cours, List<Notes> notes)
        {
            foreach (var etudiant in etudiants)
            {
                string fileName = $"Etudiant_{etudiant.NumeroEtudiant}.txt";
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.WriteLine($"Numéro d'étudiant : {etudiant.NumeroEtudiant}");
                    writer.WriteLine($"Nom : {etudiant.Nom}");
                    writer.WriteLine($"Prénom : {etudiant.Prenom}");
                    writer.WriteLine("Notes de l'etudiant par cours :");
                    foreach (var note in notes)
                    {
                        if (note.NumeroEtudiant == etudiant.NumeroEtudiant)
                        {
                            var coursAssocie = cours.Find(c => c.NumeroCours == note.NumeroCours);
                            if (coursAssocie != null)
                            {
                                writer.WriteLine($"{coursAssocie.Titre} ({coursAssocie.Code}) : {note.Note}");
                            }
                        }
                    }
                }
            }
        }

        static void AfficherReleveNotes()
        {
            Console.Write("Entrez le numéro de l'étudiant pour voir le relevé de notes : ");
            if (int.TryParse(Console.ReadLine(), out int numeroEtudiantRecherche))
            {
                string fileNameRecherche = $"Etudiant_{numeroEtudiantRecherche}.txt";
                if (File.Exists(fileNameRecherche))
                {
                    string contenu = File.ReadAllText(fileNameRecherche);
                    Console.WriteLine(contenu);
                }
                else
                {
                    Console.WriteLine("Étudiant non trouvé.");
                }
            }
            else
            {
                Console.WriteLine("Numéro d'étudiant invalide.");
            }
        }
    }
}