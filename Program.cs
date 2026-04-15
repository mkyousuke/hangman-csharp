using System;

namespace HuitMille
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Les seules variables dont on a besoin
            string[] mots = { "RENDRE", "ARGENT", "REMBOURSEMENT", "DÉPOUILLER", "MERGUEZ" };
            
            // On choisit un mot au hasard dans ta liste pour créer le mot secret
            Random generateur = new Random();
            string motSecret = mots[generateur.Next(mots.Length)]; 
            
            string lettresTestees = ""; // Va stocker toutes les lettres qu'on tape
            int vies = 6;

            // La boucle qui tourne tant qu'on a des vies
            while (vies > 0)
            {
                // Affichage du mot
                string affichage = ""; 
                
                // On regarde chaque lettre du mot secret une par une
                foreach (char lettre in motSecret)
                {
                    // Si on a déjà tapé cette lettre, on l'affiche, sinon on met un tiret
                    if (lettresTestees.Contains(lettre))
                    {
                        affichage += lettre;
                    }
                    else
                    {
                        affichage += "_";
                    }
                }

                Console.WriteLine("\nMot : " + affichage);
                Console.WriteLine("Vies restantes : " + vies);

                // Si y'a plus de tirets dans l'affichage on a gagné
                if (!affichage.Contains("_"))
                {
                    Console.WriteLine("Bravo, tu as gagné !");
                    return;
                }

                // Demander une lettre
                Console.Write("Tape une lettre : ");
                string saisie = Console.ReadLine().ToUpper();
                
                // Petite sécurité pour éviter un crash si on appuie juste sur "Entrée"
                if (saisie.Length == 0) continue; 
                
                char lettreJoueur = saisie[0]; // On prend la première lettre tapée
                lettresTestees += lettreJoueur; // On la mémorise

                // Si la lettre n'est pas dans le mot secret on perd une vie
                if (!motSecret.Contains(lettreJoueur))
                {
                    vies--;
                }
            }

            // Si la boucle se termine donc qu'on a plus de vies la boucle s'arrête
            Console.WriteLine("\nPerdu ! Le mot était : " + motSecret);
            
            Console.ReadLine(); // Pause pour voir le résultat
        }
    }
}