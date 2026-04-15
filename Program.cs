using System;

namespace JeuDuPendu
{
    class Program
    {
        static void Main(string[] args)
        {
            // --- 1. INITIALISATION DU JEU ---
            
            // Liste de mots possibles
            string[] mots = { "PROGRAMMATION", "ORDINATEUR", "CLAVIER", "ECRAN", "SOURIS", "DEVELOPPEUR" };
            
            // Choisir un mot au hasard dans la liste
            Random random = new Random();
            int indexAleatoire = random.Next(mots.Length);
            string motSecret = mots[indexAleatoire];

            // Créer le mot caché rempli de tirets du bas '_'
            char[] motCache = new char[motSecret.Length];
            for (int i = 0; i < motSecret.Length; i++)
            {
                motCache[i] = '_';
            }

            // Variables pour suivre l'état de la partie
            int essaisRestants = 7;
            string lettresTestees = ""; // Stocke les lettres déjà essayées
            bool motTrouve = false;

            Console.WriteLine("Bienvenue dans le jeu du Pendu !");

            // --- 2. BOUCLE PRINCIPALE DU JEU ---
            
            // Le jeu continue tant qu'il reste des essais ET que le mot n'est pas trouvé
            while (essaisRestants > 0 && !motTrouve)
            {
                // Afficher les informations au joueur
                Console.WriteLine("\nMot à deviner : " + new string(motCache));
                Console.WriteLine($"Essais restants : {essaisRestants}");
                Console.Write("Entrez une lettre : ");

                // Lire ce que le joueur tape et le mettre en majuscule
                string saisie = Console.ReadLine().ToUpper();

                // Sécurité : vérifier que le joueur a bien tapé une seule lettre
                if (saisie.Length != 1)
                {
                    Console.WriteLine("Veuillez entrer une seule lettre.");
                    continue; // Recommence le début de la boucle while
                }

                // Récupérer le premier (et unique) caractère tapé
                char lettre = saisie[0];

                // Vérifier si la lettre a déjà été jouée
                if (lettresTestees.Contains(lettre))
                {
                    Console.WriteLine("Vous avez déjà testé cette lettre !");
                    continue;
                }

                // Ajouter la lettre à la liste des lettres testées
                lettresTestees += lettre; 

                // --- 3. VÉRIFICATION DE LA LETTRE ---
                
                bool lettreTrouvee = false;

                // Parcourir chaque lettre du mot secret pour voir si ça correspond
                for (int i = 0; i < motSecret.Length; i++)
                {
                    if (motSecret[i] == lettre)
                    {
                        motCache[i] = lettre; // Remplacer le tiret par la lettre
                        lettreTrouvee = true;
                    }
                }

                // Si la lettre n'était pas dans le mot, on perd un essai
                if (!lettreTrouvee)
                {
                    essaisRestants--;
                    Console.WriteLine("Lettre incorrecte !");
                }
                else
                {
                    Console.WriteLine("Bonne lettre !");
                }

                // --- 4. VÉRIFICATION DE LA VICTOIRE ---
                
                // Si le mot caché est redevenu identique au mot secret, c'est gagné
                if (new string(motCache) == motSecret)
                {
                    motTrouve = true;
                }
            }

            // --- 5. FIN DE LA PARTIE ---
            
            Console.WriteLine("\n------------------------------");
            if (motTrouve)
            {
                Console.WriteLine($"Félicitations ! Vous avez gagné. Le mot était bien : {motSecret}");
            }
            else
            {
                Console.WriteLine($"Dommage... Vous avez perdu. Le mot secret était : {motSecret}");
            }

            // Empêcher la console de se fermer toute seule à la fin
            Console.WriteLine("\nAppuyez sur une touche pour quitter...");
            Console.ReadKey();
        }
    }
}