using System;
using Random = System.Random;

//AUTHOR : Alexandre GAUTIER

namespace LevelGen
{
    public class Tableau
    {
        private static Random rnd = new Random();
        
        //attributs
        public int matrixLength;
        public Salle[,] matrixPattern;
        
        //constructeur
        public Tableau(int matrixLength)
        {
            this.matrixLength = matrixLength;
            matrixPattern = new Salle[this.matrixLength,this.matrixLength];
            MatrixGeneration();
        }

        //Methodes
        
        //creer le spawn et lance la generation du critical path
        public void MatrixGeneration()
        {
            /*selectionne position de depart rdm parmis pos les plus en haut,
            on enleve les extrémités pour par que la direction devienne 5 (en bas) et remplace le spawn*/
            int startingPos = rnd.Next(1, matrixLength-1);

            //Place le spawn
            int rand = rnd.Next(0, Salle.list_SPW.Length);
            matrixPattern[0, startingPos] = new Salle(Salle.list_SPW[rand]);
            
            /* direction dans laquelle gen les salles :
            - 1 et 2 -> spawn a droite
            - 3 et 4 -> spawn a gauche
            - 5 -> bouge en bas
            ----> plus de chance que la room spawn sur un coté */
            int direction = rnd.Next(1, 5); //de 1 a 4 pour ne pas aller en bas et remplacer le spawn

            //appelle la fct qui va creer le critical path
            CriticalPathGen(direction, 0, startingPos, 0);
        }
        
        //génère le critical path et appel la completion de la matrice
        private void CriticalPathGen(int direction, int i, int j, int downCounter)
        {
            if (i >= matrixLength - 1)
            {
                CompleteMatrix();
            }
            else if (direction == 1 || direction == 2) //bouge à droite
            {
                if (j < matrixLength - 1) //si on n'est pas sur le bord
                {
                    int randTypeRoom = rnd.Next(0, Salle.nbOfRoomTypes-1);
                    int randRoomInThisType = rnd.Next(0, Salle.list_AllRoom[randTypeRoom].Length);
                    matrixPattern[i, j + 1] = new Salle(Salle.list_AllRoom[randTypeRoom][randRoomInThisType]);
                    
                    direction = rnd.Next(1,6);
                    //si le prochaine direction est gauche, conflit! La gen ferai droite gauche et stackerai 2 salles
                    if (direction == 3) //si 3 on bouge droite
                    {
                        direction = 2;
                    }
                    else if (direction == 4) //si 4 on bouge en bas
                    {
                        direction = 5;
                    }

                    CriticalPathGen(direction, i, j + 1, 0);
                }
                else //si la prochaine pos et collé à Xmax on est obligé de descendre
                {
                    CriticalPathGen(5, i, j, downCounter);
                }
            }
            else if (direction == 3 || direction == 4) //bouge à gauche
            {
                if (j > 0)
                {
                    int randTypeRoom = rnd.Next(0, Salle.nbOfRoomTypes);
                    int randRoomInThisType = rnd.Next(0, Salle.list_AllRoom[randTypeRoom].Length);
                    matrixPattern[i, j - 1] = new Salle(Salle.list_AllRoom[randTypeRoom][randRoomInThisType]);

                    direction = rnd.Next(3, 6);

                    CriticalPathGen(direction, i, j - 1, 0);
                }
                else //si la prochaine pos et collé à Xmin on est obligé de descendre pour rester dans les limites
                {
                    CriticalPathGen(5, i, j, downCounter);
                }
            }
            else if (direction == 5) //bouge en bas
            {
                //verification et modification de la salle du dessus pour eviter les deads ends
                if (matrixPattern[i,j].Type != 1 && matrixPattern[i,j].Type != 3)
                {
                    if (downCounter >= 1)
                    {
                        matrixPattern[i, j].Pattern = Salle.list_LRBT[rnd.Next(0, Salle.list_LRBT.Length)];
                    }
                    else
                    {
                        int randBottomOpeningRoom = rnd.Next(1,Salle.nbOfRoomTypes);
                        if (randBottomOpeningRoom == 2)
                        {
                            randBottomOpeningRoom = 1;
                        }
                        matrixPattern[i,j].Pattern = Salle.list_AllRoom[randBottomOpeningRoom][rnd.Next(0, Salle.list_AllRoom[randBottomOpeningRoom].Length)];
                    }
                }
                
                //Creation de la salle du dessous
                int randTypeRoom = rnd.Next(2, Salle.nbOfRoomTypes);
                int randRoomInThisType = rnd.Next(0, Salle.list_AllRoom[randTypeRoom].Length);
                matrixPattern[i+1, j] = new Salle(Salle.list_AllRoom[randTypeRoom][randRoomInThisType]);

                direction = rnd.Next(1, 6);
                CriticalPathGen(direction, i+1, j, downCounter+1);
            }
        }
        
        
        //Complete la matrice avec des salles aleatoires et appel la creation des murs persp
        private void CompleteMatrix()
        {
            for (int i = 0; i < matrixLength; i++)
            {
                for (int j = 0; j < matrixLength; j++)
                {
                    if (matrixPattern[i, j] is null)
                    {
                        int randTypeRoom = rnd.Next(0, Salle.nbOfRoomTypes);
                        int randRoomInThisType = rnd.Next(0, Salle.list_AllRoom[randTypeRoom].Length);
                        matrixPattern[i, j] = new Salle(Salle.list_AllRoom[randTypeRoom][randRoomInThisType]);
                    }
                }
            }
            
            SpawnPerspective();
        }

        //Place les murs perspectives BUG: else
        private void SpawnPerspective()
        {
            for (int i = 0; i < matrixLength; i++)
            {
                for (int j = 0; j < matrixLength; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        for (int l = 0; l < 10; l++)
                        {
                            if (matrixPattern[i,j].Pattern[k,l] == "W")
                            {
                                if (k < 9) // dans la salle
                                {
                                    if (matrixPattern[i,j].Pattern[k+1,l] != "W")
                                    {
                                        matrixPattern[i, j].Pattern[k + 1, l] = "p";
                                    }
                                }
                                /*else if (i+1 < matrixLength) // gen salle d'en dessous Todo: Demander de l'aide sur ce else au comportement TREEEEEEES etrange
                                {
                                    if (matrixPattern[i+1,j].Pattern[0,l] != "W")
                                    {
                                        matrixPattern[i + 1, j].Pattern[0, l] = "p";
                                    }
                                }*/
                            }
                        }
                    }
                }
            }
        }
    }
}