using System;
using System.Diagnostics;
using Random = System.Random;

//AUTHOR : Alexandre GAUTIER

namespace LevelGen
{
    public class Salle
    {
        //Propriétés
        private int type;
        private string[,] pattern;
        
        //Get/Set
        public int Type
        {
            get { return type; }
        }

        public string[,] Pattern
        {
            get { return pattern; }
            set
            {
                pattern = (string[,]) value.Clone();
                if (pattern == LR0 || pattern == LR1 || pattern == LR2)
                {
                    type = 0;
                }
                else if (pattern == LRB0 || pattern == LRB1 || pattern == LRB2)
                {
                    type = 1;
                }
                else if (pattern == LRT0 || pattern == LRT1 || pattern == LRT2)
                {
                    type = 2;
                }
                else if (pattern == LRBT0 || pattern == LRBT1 || pattern == LRBT2)
                {
                    type = 3;
                }
                else if (pattern == SPW0 || pattern == BTQ0 || pattern == EXIT0)
                {
                    type = 4;
                }
            }
        }

        
        //Outils pour la génération aléatoire dans les salles
        private static Random rnd = new Random();

        private static string RandomObjectGen(string[] objectList)
        {
            int length = objectList.Length;
            int rndIndex = rnd.Next(0, length);

            return objectList[rndIndex];
        }
        
        
        //Constructeur
        public Salle(string[,] pattern)
        {
            this.pattern = (string[,]) pattern.Clone();

            if (pattern == LR0 || pattern == LR1 || pattern == LR2)
            {
                type = 0;
            }
            else if (pattern == LRB0 || pattern == LRB1 || pattern == LRB2)
            {
                type = 1;
            }
            else if (pattern == LRT0 || pattern == LRT1 || pattern == LRT2)
            {
                type = 2;
            }
            else if (pattern == LRBT0 || pattern == LRBT1 || pattern == LRBT2)
            {
                type = 3;
            }
            else if (pattern == SPW0 || pattern == BTQ0 || pattern == EXIT0)
            {
                type = 4;
            }
        }

        
        //Prefab de Room
        //W = wall / p = persp / n = ground / SEBlocks = spawn room ground blocks / WoodG = Wood Ground
        //SpawnP1 = spawn player 1 / SpawnP2 = spawn player 2 / E = enemie / BOSS = boss
        //C = chest / T = trap / EXIT = exit
        //

        //################ SPECIAL ROOMS ######################
        //Empty
        public static string[,] EMPTY =
            {{"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"}};

        //Spawn Room
        public static string[,] SPW0 =
            {{"W", "W", "W", "W", "W", "W", "W", "W", "W", "W"},
            {"W", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "W"},
            {"W", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "W"},
            {"W", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "W"},
            {"SEBlocks", "SEBlocks", "SEBlocks", "SpawnP1", "SEBlocks", "SpawnP2", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks"},
            {"SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks"},
            {"W", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "W"},
            {"W", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "W"},
            {"W", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "W"},
            {"W", "W", "W", "W", "SEBlocks", "SEBlocks", "W", "W", "W", "W"}};
        
        //Exit Room
        public static string[,] EXIT0 =
            {{"W", "W", "W", "W", "SEBlocks", "SEBlocks", "W", "W", "W", "W"},
            {"W", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "W"},
            {"W", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "W"},
            {"W", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "W"},
            {"SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "C", "C", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks"},
            {"SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks"},
            {"W", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "W"},
            {"W", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "EXIT", "SEBlocks", "SEBlocks", "SEBlocks", "W"},
            {"W", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "SEBlocks", "W"},
            {"W", "W", "W", "W", "W", "W", "W", "W", "W", "W"}};
        
        //Boutique
        public static string[,] BTQ0 = //Todo: editer la boutique
            {{"W", "W", "W", "WoodG", "WoodG", "WoodG", "WoodG", "W", "W", "W"},
            {"W", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "W"},
            {"W", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "W"},
            {"WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG"},
            {"WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG"},
            {"WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG"},
            {"WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG"},
            {"W", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "W"},
            {"W", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "WoodG", "W"},
            {"W", "W", "W", "WoodG", "WoodG", "WoodG", "WoodG", "W", "W", "W"}};

        //##################### LR ####################

        public static string[,] LR0 =
            {{"W", "W", "W", "W", "W", "W", "W", "W", "W", "W"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", RandomObjectGen(new[] {"E", "n"}), "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "W", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "W", "W", "n", "n", "n", "n"},
            {"n", "n", "n", RandomObjectGen(new[] {"W", "n"}), "W", "W", RandomObjectGen(new[] {"W", "n"}), "n", "n", "n"},
            {"n", "n", "n", RandomObjectGen(new[] {"W", "n"}), "w", "w", RandomObjectGen(new[] {"W", "n"}), "n", "n", "n"},
            {"n", "n", "n", "n", "W", "W", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "W"},
            {"W", "W", "W", "W", "W", "W", "W", "W", "W", "W"}};

        public static string[,] LR1 =
            {{"W", "W", "W", "W", "W", "W", "W", "W", "W", "W"},
            {"n", "W", "W", "W", "W", "W", "W", "W", "W", "n"},
            {"n", "n", "W", "W", "W", "W", "W", "W", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", RandomObjectGen(new[] {"E", "n"}), "n", "n", "n", "n", RandomObjectGen(new[] {"E", "n"}), "n", "n"},
            {"n", "n", RandomObjectGen(new[] {"E", "n"}), "n", "n", "n", "n", RandomObjectGen(new[] {"E", "n"}), "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "W", "W", "W", "W", "W", "W", "n", "n"},
            {"n", "W", "W", "W", "W", "W", "W", "W", "W", "n"},
            {"W", "W", "W", "W", "W", "W", "W", "W", "W", "W"}};

        public static string[,] LR2 =
            {{"W", "W", "W", "W", "W", "W", "W", "W", "W", "W"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "W"},
            {"n", "n", RandomObjectGen(new[] {"W", "n"}), "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", RandomObjectGen(new[] {"W", "n"}), RandomObjectGen(new[] {"W", "n"}), "n", "n", "n", "n", "n", "n"},
            {"n", "n", "W", "W", "W", RandomObjectGen(new[] {"W", "n"}), "n", "n", "n", "n"},
            {"n", "n", "n", "n", "W", "n", "n", "n", "n", "n"},
            {"n", "n", "T", "n", "n", "n", "n", "n", "n", "n"},
            {"W", "n", "n", "n", "n", "n", "n", "n", "n", "W"},
            {"W", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"W", "W", "W", "n", "n", "n", "n", "n", "W", "W"}};

        public static string[,] LR3 =
            {{"W", "W", "W", "W", "W", "W", "W", "W", "W", "W"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "W", "n", "n", "n", "n"},
            {"n", "n", RandomObjectGen(new[] {"W", "n"}), "n", "n", "W", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", RandomObjectGen(new[] {"W", "n"}), "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "W", "n", "n", RandomObjectGen(new[] {"W", "n"}), "n"},
            {"n", "n", RandomObjectGen(new[] {"W", "n"}), "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"W", "W", "W", "W", "W", "W", "W", "W", "W", "W"}};

        //##################### LRB ####################

        public static string[,] LRB0 =
            {{"W", "W", "W", "W", "W", "W", "W", "W", "W", "W"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "W"},
            {"n", "n", RandomObjectGen(new[] {"E", "n"}), "n", "n", "n", "n", RandomObjectGen(new[] {"E", "n"}), "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"W", "W", "W", "W", "n", "n", "W", "W", "W", "W"},
            {"W", "n", "n", "n", "n", "n", "n", "n", "n", "W"},
            {"W", "n", RandomObjectGen(new[] {"E", "n"}), "n", "n", "n", "n", "n", "n", "W"},
            {"W", "n", "n", "n", "n", "n", "n", "n", "n", "W"},
            {"W", "W", "W", "n", "n", "n", "n", "W", "W", "W"}};

        public static string[,] LRB1 =
        {
            {"W", "W", "W", "W", "W", "W", "W", "W", "W", "W"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "W", "W", "W", "W", "W", "W", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", RandomObjectGen(new[] {"E", "n"}), "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "T", "n", "n", "n", "W", "W"},
            {"W", "W", "W", "n", "n", "n", "n", "n", "W", "W"},
            {"W", "W", "W", "n", "n", "n", "n", "n", "W", "W"}};

        public static string[,] LRB2 =
            {{"W", "W", "W", "W", "W", "W", "W", "W", "W", "W"},
            {"W", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "W", "W", "W", "W", "W", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", RandomObjectGen(new[] {"E", "n"}), "n"},
            {"n", RandomObjectGen(new[] {"E", "n"}), "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "W", "W", "W", "W", "n", "n", "n", "n"},
            {"n", "n", "W", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", RandomObjectGen(new[] {"C", "n", "n", "n", "n"}), "n", "n", "n", "n", "n", "W"},
            {"W", "W", "W", "n", "n", "n", "n", "W", "W", "W"}};

        public static string[,] LRB3 =
            {{"W", "W", "W", "W", "W", "W", "W", "W", "W", "W"},
            {"n", "n", "n", "n", "n", "n", "n", RandomObjectGen(new[] {"C", "W", "W", "W", "n", "n", "n"}), "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", RandomObjectGen(new[] {"W", "n"}), RandomObjectGen(new[] {"W", "n"}), "n", "n", "n", "n"},
            {"n", "n", "n", "n", RandomObjectGen(new[] {"W", "n"}), RandomObjectGen(new[] {"W", "n"}), "n", "n", "n", "n"},
            {"n", "n", "T", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"W", "n", "n", "n", "n", "n", "n", "n", "n", "W"},
            {"W", "W", "n", "n", "n", "n", "n", "n", "W", "W"}};


        //######################### LRT #################

        public static string[,] LRT0 =
        {
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "W"},
            {"n", "n", "n", "n", "n", RandomObjectGen(new[] {"W", "n"}), "n", "n", "n", "n"},
            {"n", "T", "n", "n", RandomObjectGen(new[] {"W", "n"}), RandomObjectGen(new[] {"W", "n"}), RandomObjectGen(new[] {"W", "n"}), "W", "n", "n"},
            {"n", "n", "W", "n", RandomObjectGen(new[] {"W", "n"}), "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", RandomObjectGen(new[] {"W", "n"}), "n", "n"},
            {"n", RandomObjectGen(new[] {"E", "n"}), "n", "n", "n", "n", RandomObjectGen(new[] {"W", "n"}), RandomObjectGen(new[] {"W", "n"}), "n", "n"},
            {"n", "n", RandomObjectGen(new[] {"E", "n"}), "n", "n", "n", "W", RandomObjectGen(new[] {"W", "n"}), "n", "n"},
            {"n", "n", "W", "n", "n", "n", "n", "n", "n", "n"},
            {"W", "n", "n", "n", "n", "n", "n", "n", "n", "W"},
            {"W", "W", "W", "W", "W", "W", "W", "W", "W", "W"}};

        public static string[,] LRT1 =
            {{"W", "W", "W", "n", "n", "n", "n", "W", "W", "W"},
            {"W", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", RandomObjectGen(new[] {"W", "n"}), "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "W", RandomObjectGen(new[] {"W", "n"}), RandomObjectGen(new[] {"W", "n"}), "n", "n", "n"},
            {"n", "n", "n", "W", "W", "W", RandomObjectGen(new[] {"W", "n"}), "n", "n", "n"},
            {"n", "n", RandomObjectGen(new[] {"W", "n"}), "W", "W", "W", RandomObjectGen(new[] {"W", "n"}), "n", "n", "n"},
            {"n", "n", "n", "n", "W", "W", RandomObjectGen(new[] {"W", "n"}), "n", "n", "n"},
            {"W", "n", "n", "n", RandomObjectGen(new[] {"W", "n"}), "n", "n", "n", "n", "W"},
            {"W", "n", "n", "n", "n", "n", "n", "n", "n", "W"},
            {"W", "W", "W", "W", "W", "W", "W", "W", "W", "W"}};

        public static string[,] LRT2 =
            {{"W", "W", "W", "n", "n", "n", "n", "W", "W", "W"},
            {"W", "n", "n", "n", "n", "n", "n", "n", "n", "W"},
            {"W", "n", "n", "n", "n", "W", "W", "W", "n", "W"},
            {"n", "n", "n", "n", "n", "W", "n", "n", "n", "n"},
            {"n", "n", RandomObjectGen(new[] {"E", "n"}), "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "T", "n", "n"},
            {"W", "W", "W", "W", "W", "n", "n", "n", "n", "n"},
            {"W", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"W", RandomObjectGen(new[] {"C", "n", "n", "n", "n", "n"}), "n", "n", "n", "n", "n", "n", "n", "W"},
            {"W", "W", "W", "W", "W", "W", "W", "W", "W", "W"}};

        public static string[,] LRT3 =
            {{"W", "n", "n", "n", "n", "n", "n", "n", "W", "W"},
            {"W", "W", "n", "n", "n", "n", "n", "n", "n", "W"},
            {"n", RandomObjectGen(new[] {"E", "n", "n"}), "n", "n", "n", "n", RandomObjectGen(new[] {"E", "n", "n"}), "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", RandomObjectGen(new[] {"E", "n", "n"}), "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "W", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"W", "W", "W", "W", "W", "W", "W", "W", "W", "W"}};

        //######################## LRBT ##################

        public static string[,] LRBT0 =
            {{"W", "W", "W", "n", "n", "n", "n", "W", "W", "W"},
            {"W", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", RandomObjectGen(new[] {"W", "n"}), "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "W", "n", "n", "n", "n"},
            {"n", "n", "W", "W", "W", "W", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "W", "W", "W", RandomObjectGen(new[] {"W", "n"}), "n", "n"},
            {"n", "n", "T", "n", "W", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "W"},
            {"W", "W", "W", "n", "n", "n", "n", "W", "W", "W"}};

        public static string[,] LRBT1 =
            {{"W", "W", "W", "n", "n", "n", "n", "W", "W", "W"},
            {"W", "W", "W", "n", "n", "n", "n", "W", "W", "W"},
            {"W", "W", "W", "n", "n", "n", "n", "W", "W", "W"},
            {"W", "W", "W", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", RandomObjectGen(new[] {"E", "n"}), "n", "n", "n", "n", RandomObjectGen(new[] {"E", "n"}), "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "W", "W", "W"},
            {"W", "W", "n", "n", "n", "n", "n", "W", "W", "W"},
            {"W", "W", "W", "n", "n", "n", "n", "W", "W", "W"},
            {"W", "W", "W", "n", "n", "n", "n", "W", "W", "W"}};

        public static string[,] LRBT2 =
            {{"W", "n", "n", "n", "n", "n", RandomObjectGen(new[] {"E", "n"}), "n", "n", "W"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "W", "W", "W", "W", "W", "W", "n", "n"},
            {"n", "n", "W", "n", "n", "n", "n", "W", "n", "n"},
            {"n", "n", "W", "n", "C", "C", "n", "W", "n", "n"},
            {"n", "n", "W", "E", "E", "E", "E", "W", "n", "n"},
            {"n", "n", "W", "n", "n", "n", "n", "W", "n", "n"},
            {"n", "n", "W", "W", RandomObjectGen(new[] {"W", "W", "W", "n"}), "W", "W", "W", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"W", "n", "n", "n", "n", "n", "n", "n", "n", "W"}};
        
        public static string[,] LRBT3 =
            {{"n", "n", "n", "n", "n", RandomObjectGen(new[] {"W", "n", "n"}), "n", "n", "n", "n"},
            {RandomObjectGen(new[] {"W", "n", "n"}), "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {"n", "n", "W", "n", "n", "n", RandomObjectGen(new[] {"W", "n", "n"}), "n", "n", "n"},
            {"n", "n", RandomObjectGen(new[] {"W", "n", "n"}), "n", "n", "n", RandomObjectGen(new[] {"W", "n", "n"}), "n", "n", "n"},
            {RandomObjectGen(new[] {"W", "n"}), "n", "W", "n", "E", "n", "n", "n", "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "W", "n", "n"},
            {"n", "n", "n", RandomObjectGen(new[] {"W", "n", "n"}), "n", "n", "n", RandomObjectGen(new[] {"W", "n", "n"}), "n", "n"},
            {"n", RandomObjectGen(new[] {"W", "n"}), "n", "n", "n", "n", "n", RandomObjectGen(new[] {"W", "n", "n"}), "n", "n"},
            {"n", "n", "n", "n", "n", "n", "n", "n", "n", "n"},
            {RandomObjectGen(new[] {"W", "n", "n"}), "n", "n", "n", "n", "n", "n", "n", "n", RandomObjectGen(new[] {"W", "n", "n"})
            }};

        //Type de Salle : 0 = LR / 1 = LRB / 2 = LRT / 3 = LRBT / 4 = Special rooms
        public static string[][,] list_SPW = {SPW0};
        public static string[][,] list_EXIT = {EXIT0};
        public static string[][,] list_BTQ = {BTQ0};
        public static string[][,] list_LR = {LR0, LR1, LR2, LR3};
        public static string[][,] list_LRB = {LRB0, LRB1, LRB2, LRB3};
        public static string[][,] list_LRT = {LRT0, LRT1, LRT2, LRT3};
        public static string[][,] list_LRBT = {LRBT0, LRBT0, LRBT1, LRBT1, LRBT2, LRBT2, LRBT3};

        public static string[][][,] list_AllRoom = {list_LR, list_LRB, list_LRT, list_LRBT};
        public static int nbOfRoomTypes = list_AllRoom.Length;
    }
}