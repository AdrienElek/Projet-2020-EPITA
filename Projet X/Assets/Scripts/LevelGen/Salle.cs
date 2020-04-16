using System;
using System.Diagnostics;
using Random = System.Random;

namespace LevelGen
{
    public class Salle
    {
        private int type;
        private char[,] pattern;
        
        //Génération d'aléatoire dans les salles
        private static Random rnd = new Random();

        private static char RandomObjectGen(char[] objectList)
        {
            int length = objectList.Length;
            int rndIndex = rnd.Next(0, length);
            
            return objectList[rndIndex];
        }

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public char[,] Pattern
        {
            get { return pattern; }
            set
            {
                pattern = value;
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
            }
        }

        public Salle(char[,] pattern)
        {
            this.pattern = pattern;
            
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
        }

        //Prefab de Room
        //W = wall / p = persp / g = ground / C = chest / E = enemie / n = rien
        //S = Spawn
        //################ Empty ######################
        public static char[,] EMPTY =
            {{'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n'},
            {'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n'},
            {'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n'},
            {'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n'},
            {'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n'},
            {'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n'},
            {'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n'},
            {'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n'},
            {'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n'},
            {'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n'}};
        
        //################ Spawn Room #################
        
        public static char[,] SPW0 =
            {{'W','W','W','W','W','W','W','W','W','W'}, 
            {'W','n','n','n','n','n','n','n','n','W'},
            {'W','n','n','n','n','n','n','n','n','W'},
            {'W','n','n','n','n','n','n','n','n','W'},
            {'n','n','n','n','S','n','n','n','n','n'},
            {'n','n','n','n','n','n','n','n','n','n'},
            {'W','n','n','n','n','n','n','n','n','W'},
            {'W','n','n','n','n','n','n','n','n','W'},
            {'W','n','n','n','n','n','n','n','n','W'},
            {'W','W','W','W','n','n','W','W','W','W'}};

        //##################### LR ####################
        
        public static char[,] LR0 =
            {{'W','W','W','W','W','W','W','W','W','W'}, 
            {'n','n','n','n','n','n','n','n','n','n'},
            {'n','n',RandomObjectGen(new []{'E', 'n'}),'n','n','n','n','n','n','n'},
            {'n','n','n','n','n','W','n','n','n','n'},
            {'n','n','n','n','W','W','n','n','n','n'},
            {'n','n','n',RandomObjectGen(new []{'W','n'}),'W','W',RandomObjectGen(new []{'W','n'}),'n','n','n'},
            {'n','n','n',RandomObjectGen(new []{'w','n'}),'w','w',RandomObjectGen(new []{'w','n'}),'n','n','n'},
            {'n','n','n','n','W','W','n','n','n','n'},
            {'n','n','n','n','n','n','n','n','n','w'},
            {'W','W','W','W','W','W','W','W','W','W'}};
        public static char[,] LR1 = 
            {{'W','W','W','W','W','W','W','W','W','W'}, 
            {'n','W','W','W','W','W','W','W','W','n'},
            {'n','n','W','W','W','W','W','W','n','n'},
            {'n','n','n','n','n','n','n','n','n','n'},
            {'n','n',RandomObjectGen(new []{'E', 'n'}),'n','n','n','n',RandomObjectGen(new []{'E', 'n'}),'n','n'},
            {'n','n',RandomObjectGen(new []{'E', 'n'}),'n','n','n','n',RandomObjectGen(new []{'E', 'n'}),'n','n'},
            {'n','n','n','n','n','n','n','n','n','n'},
            {'n','n','W','W','W','W','W','W','n','n'},
            {'n','W','W','W','W','W','W','W','W','n'},
            {'W','W','W','W','W','W','W','W','W','W'}};
        public static char[,] LR2 =
            {{'W','W','W','W','W','W','W','W','W','W'}, 
            {'n','n','n','n','n','n','n','n','n','W'},
            {'n','n',RandomObjectGen(new []{'w','n'}),'n','n','n','n','n','n','n'},
            {'n','n',RandomObjectGen(new []{'w','n'}),RandomObjectGen(new []{'w','n'}),'n','n','n','n','n','n'},
            {'n','n','W','W','W',RandomObjectGen(new []{'w','n'}),'n','n','n','n'},
            {'n','n','n','n','W','n','n','n','n','n'},
            {'n','n','n','n','n','n','n','n','n','n'},
            {'W','n','n','n','n','n','n','n','n','W'},
            {'W','n','n','n','n','n','n','n','n','n'},
            {'W','W','W','n','n','n','n','n','W','W'}};

        //##################### LRB ####################
        
        public static char[,] LRB0 =
            {{'W','W','W','W','W','W','W','W','W','W'}, 
            {'n','n','n','n','n','n','n','n','n','W'},
            {'n','n',RandomObjectGen(new []{'E', 'n'}),'n','n','n','n',RandomObjectGen(new []{'E', 'n'}),'n','n'},
            {'n','n','n','n','n','n','n','n','n','n'},
            {'n','n','n','n','n','n','n','n','n','n'},
            {'W','W','W','W','n','n','W','W','W','W'},
            {'W','n','n','n','n','n','n','n','n','W'},
            {'W','n',RandomObjectGen(new []{'E', 'n'}),'n','n','n','n','n','n','W'},
            {'W','n','n','n','n','n','n','n','n','W'},
            {'W','W','W','n','n','n','n','W','W','W'}};
        public static char[,] LRB1 =
            {{'W','W','W','W','W','W','W','W','W','W'}, 
            {'n','n','n','n','n','n','n','n','n','n'},
            {'n','n','W','W','W','W','W','W','n','n'},
            {'n','n','n','n','n','n','n','n','n','n'},
            {'n','n','n','n','n','n','n','n','n','n'},
            {'n','n','n',RandomObjectGen(new []{'E', 'n'}),'n','n','n','n','n','n'},
            {'n','n','n','n','n','n','n','n','n','n'},
            {'n','n','n','n','n','n','n','n','W','W'},
            {'W','W','W','n','n','n','n','n','W','W'},
            {'W','W','W','n','n','n','n','n','W','W'}};
        public static char[,] LRB2 =
            {{'W','W','W','W','W','W','W','W','W','W'}, 
            {'W','n','n','n','n','n','n','n','n','n'},
            {'n','n','n','W','W','W','W','W','n','n'},
            {'n','n','n','n','n','n','n','n',RandomObjectGen(new []{'E', 'n'}),'n'},
            {'n',RandomObjectGen(new []{'E', 'n'}),'n','n','n','n','n','n','n','n'},
            {'n','n','n','n','n','n','n','n','n','n'},
            {'n','n','W','W','W','W','n','n','n','n'},
            {'n','n','W','n','n','n','n','n','n','n'},
            {'n','n','n',RandomObjectGen(new []{'C', 'n', 'n'}),'n','n','n','n','n','W'},
            {'W','W','W','n','n','n','n','W','W','W'}};
        
        //######################### LRT #################
        
        public static char[,] LRT0 =
            {{'n','n','n','n','n','n','n','n','n','W'}, 
            {'n','n','n','n','n',RandomObjectGen(new []{'W','n'}),'n','n','n','n'},
            {'n','n','n','n',RandomObjectGen(new []{'W','n'}),RandomObjectGen(new []{'W','n'}),RandomObjectGen(new []{'W','n'}),'W','n','n'},
            {'n','n','W','n',RandomObjectGen(new []{'W','n'}),'n','n','n','n','n'},
            {'n','n','n','n','n','n','n',RandomObjectGen(new []{'W','n'}),'n','n'},
            {'n',RandomObjectGen(new []{'E', 'n'}),'n','n','n','n',RandomObjectGen(new []{'W','n'}),RandomObjectGen(new []{'W','n'}),'n','n'},
            {'n','n',RandomObjectGen(new []{'E', 'n'}),'n','n','n','W',RandomObjectGen(new []{'W','n'}),'n','n'},
            {'n','n','W','n','n','n','n','n','n','n'},
            {'W','n','n','n','n','n','n','n','n','W'},
            {'W','W','W','W','W','W','W','W','W','W'}};
        public static char[,] LRT1 =
            {{'W','W','W','n','n','n','n','W','W','W'}, 
            {'W','n','n','n','n','n','n','n','n','n'},
            {'n','n','n','n',RandomObjectGen(new []{'W','n'}),'n','n','n','n','n'},
            {'n','n','n','n','W',RandomObjectGen(new []{'W','n'}),RandomObjectGen(new []{'W','n'}),'n','n','n'},
            {'n','n','n','W','W','W',RandomObjectGen(new []{'W','n'}),'n','n','n'},
            {'n','n',RandomObjectGen(new []{'W','n'}),'W','W','W',RandomObjectGen(new []{'W','n'}),'n','n','n'},
            {'n','n','n','n','W','W',RandomObjectGen(new []{'W','n'}),'n','n','n'},
            {'W','n','n','n',RandomObjectGen(new []{'W','n'}),'n','n','n','n','W'},
            {'W','n','n','n','n','n','n','n','n','W'},
            {'W','W','W','W','W','W','W','W','W','W'}};
        public static char[,] LRT2 =
            {{'W','W','W','n','n','n','n','W','W','W'}, 
            {'W','n','n','n','n','n','n','n','n','W'},
            {'W','n','n','n','n','W','W','W','n','W'},
            {'n','n','n','n','n','W','n','n','n','n'},
            {'n','n',RandomObjectGen(new []{'E', 'n'}),'n','n','n','n','n','n','n'},
            {'n','n','n','n','n','n','n','n','n','n'},
            {'W','W','W','W','W','n','n','n','n','n'},
            {'W','n','n','n','n','n','n','n','n','n'},
            {'W',RandomObjectGen(new []{'C', 'n', 'n'}),'n','n','n','n','n','n','n','W'},
            {'W','W','W','W','W','W','W','W','W','W'}};
        
        //######################## LRBT ##################

        public static char[,] LRBT0 =
            {{'W','W','W','n','n','n','n','W','W','W'}, 
            {'W','n','n','n','n','n','n','n','n','n'},
            {'n','n','n','n','n',RandomObjectGen(new []{'W','n'}),'n','n','n','n'},
            {'n','n','n','n','n','W','n','n','n','n'},
            {'n','n','W','W','W','W','n','n','n','n'},
            {'n','n','n','n','W','W','W',RandomObjectGen(new []{'W','n'}),'n','n'},
            {'n','n','n','n','W','n','n','n','n','n'},
            {'n','n','n','n','n','n','n','n','n','n'},
            {'n','n','n','n','n','n','n','n','n','W'},
            {'W','W','W','n','n','n','n','W','W','W'}};
        public static char[,] LRBT1 =
            {{'W','W','W','n','n','n','n','W','W','W'}, 
            {'W','W','W','n','n','n','n','W','W','W'},
            {'W','W','W','n','n','n','n','W','W','W'},
            {'W','W','W','n','n','n','n','n','n','n'},
            {'n','n','n','n','n','n','n','n','n','n'},
            {'n',RandomObjectGen(new []{'E', 'n'}),'n','n','n','n',RandomObjectGen(new []{'E', 'n'}),'n','n','n'},
            {'n','n','n','n','n','n','n','W','W','W'},
            {'W','W','n','n','n','n','n','W','W','W'},
            {'W','W','W','n','n','n','n','W','W','W'},
            {'W','W','W','n','n','n','n','W','W','W'}};
        public static char[,] LRBT2 =
            {{'W','n','n','n','n','n',RandomObjectGen(new []{'E', 'n'}),'n','n','W'}, 
            {'n','n','n','n','n','n','n','n','n','n'},
            {'n','n','W','W','W','W','W','W','n','n'},
            {'n','n','W','n','n','n','n','W','n','n'},
            {'n','n','W','n','E','n','n','W','n','n'},
            {'n','n','W','n','n','n','n','W','n','n'},
            {'n','n','W','n','n','n','n','W','n','n'},
            {'n','n','W','W','W','W','W','W','n','n'},
            {'n','n','n','n','n','n','n','n','n','n'},
            {'W','n','n','n','n','n','n','n','n','W'}};
        
        //Type de Salle : 0 = LR / 1 = LRB / 2 = LRT / 3 = LRBT
        public static char[][,] list_SPW = {SPW0};
        public static char[][,] list_LR = {LR0, LR1, LR2};
        public static char[][,] list_LRB = {LRB0, LRB1, LRB2};
        public static char[][,] list_LRT = {LRT0, LRT1, LRT2};
        public static char[][,] list_LRBT = {LRBT0, LRBT1, LRBT2};

        public static char[][][,] list_AllRoom = {list_LR, list_LRB, list_LRT, list_LRBT};
        public static int nbOfRoomTypes = list_AllRoom.Length;
    }
}