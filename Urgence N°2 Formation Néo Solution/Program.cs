using System;

namespace Urgence_N_2_Formation_Néo_Solution
{
    class Program
    {
        /* Bien joué Recrues ! Maintenant que notre système informatique est réparé et sécurisé,
         * vous allez devoir réparer le programme de géolocalisation du QG pour retrouver
         * les différents héros en missions à travers le monde. 
         * 
         * Vous n'avez pas le droit de modifier le Main... A vous de remplir les fonctions
         * qui vous sont données et d'en créer de nouvelles!
        */

        static void Main(string[] args)
        {
            // Nous allons imaginer qu'une grille de 100 cases par 100 représente la Terre
            // Un héro est placé aléatoirement sur cette grille, ses coordonnées varient donc
            // entre (0, 0) et (99, 99).
            // La première coordonnée est sur l'axe Nord-Sud (Nord = 0, Sud = 99), la seconde sur l'axe Est-Ouest (Est = 0, Ouest = 99)
            // Votre mission est de demander à l'utilisateur une série de coordonnées,
            // puis de lui annoncer si le héro est plus au Nord, à l'Est, au Sud ou à l'Ouest.
            // Quand une coordonnée est bonne, il faut aussi le lui annoncer.
            // Quand une coordonnée n'est pas bonne, il faut donner un indice à l'utilisateur sur la distance
            // qui le sépare du héro (vous ne devez donner aucune valeur numérique à l'utilisateur).
            // Quand l'utilisateur trouve les deux coordonnées, il faut lui annoncer qu'il à 
            // trouvé un héro!
            //
            // Compléter les fonctions CoordonneesExactes et Radar pour trouver le héro!
            // Pour cela, vous devrez créer des fonctions pour verifier les coordonnées sur les deux axes,
            // et creer une fonction pour donner un indice sur la distance du héro à l'utilisateur.

            var rnd = new Random();
            int heroCoordX = rnd.Next(0, 99); // nombre aléatoire entre 0 et 99
            int heroCoordY = rnd.Next(0, 99);

            // Ligne pour tester les coordonnées
            //Console.WriteLine("Debug en (" + heroCoordX + ", " + heroCoordY + ")");

            int userCoordX = 0;
            int userCoordY = 0;
            bool enRecherche = true;

            Console.WriteLine("Recherche d'un héro... [LOADING]...");
            while (enRecherche)
            {
                Console.WriteLine('\n' + "Coordonnée en X: ");
                int.TryParse(Console.ReadLine(), out userCoordX);
                Console.WriteLine("Coordonnée en Y: ");
                int.TryParse(Console.ReadLine(), out userCoordY);

                Console.WriteLine("Recherche en (" + userCoordX + ", " + userCoordY + ")");

                if (CoordonneesExactes(userCoordX, userCoordY, heroCoordX, heroCoordY))
                {
                    enRecherche = false; // On arrète la recherche, on a trouvé
                    Console.WriteLine('\n' + "Héro correctement localisé.");
                }
                else
                {
                    Radar(userCoordX, userCoordY, heroCoordX, heroCoordY);
                }
            }
        }

        static bool CoordonneesExactes(int userCoordX, int userCoordY, int heroCoordX, int heroCoordY)
        {
            // Retourne true si les coordonnées entrés par l'utilisateur sont celles du héro
            return ((userCoordX == heroCoordX) && (userCoordY == heroCoordY));
        }

        static void Radar(int userCoordX, int userCoordY, int heroCoordX, int heroCoordY)
        {
            // Tests sur la première valeur (X)
            TestXCoord(userCoordX, heroCoordX);

            // Tests sur la seconde valeur (Y)
            TestYCoord(userCoordY, heroCoordY);
        }

        static void TestXCoord(int userX, int heroX)
        {
            if (userX == heroX)
                Console.WriteLine("Coordonnée Nord-Sud correcte");
            else if (userX > heroX)
            {
                Console.Write("Plus au Nord! ");
                Indice(userX, heroX); // Valeur la plus grande en premier
            }
            else // (userX < heroX)
            {
                Console.Write("Plus au Sud! ");
                Indice(heroX, userX); // Valeur la plus grande en premier
            }
        }

        static void TestYCoord(int userY, int heroY)
        {
            if (userY == heroY)
                Console.WriteLine("Coordonnée Est-Ouest correcte");
            else if (userY > heroY)
            {
                Console.Write("Plus a l'Est! ");
                Indice(userY, heroY); // Valeur la plus grande en premier
            }
            else // (userY < heroY)
            {
                Console.Write("Plus a l'Ouest! ");
                Indice(heroY, userY); // Valeur la plus grande en premier
            }
        }

        static void Indice(int val1, int val2)
        {
            int ecart = val1 - val2; // valeur positive comprise entre 0 (valeurs identiques) et 99
            if (ecart > 30)
            {
                Console.WriteLine("Le héro est sur un autre continent!");
            }
            else if (10 < ecart && ecart <= 30)
            {
                Console.WriteLine("Le héro est dans un autre pays!");
            }
            else
            {
                Console.WriteLine("Le héro est proche!");
            }
        }
    }
}
