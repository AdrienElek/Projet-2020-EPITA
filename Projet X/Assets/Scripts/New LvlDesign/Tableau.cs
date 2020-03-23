using System;
using Random = System.Random;

namespace New_LvlDesign
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

        //methodes
        
        public void MatrixGeneration()
        {
            //selectionne position de depart rdm parmis pos les plus en haut
            int startingPos = rnd.Next(0, matrixLength);

            //Place le spawn
            int rand = rnd.Next(0, Salle.list_SPW.Length);
            matrixPattern[matrixLength - 1, startingPos] = new Salle(Salle.list_SPW[rand]);
            
            /* direction dans laquelle gen les salles :
            - 1 et 2 -> spawn a droite
            - 2 et 3 -> spawn a gauche
            - 5 -> bouge en bas
            ----> plus de chance que la room spawn sur un coté */
            int direction = rnd.Next(1, 6);
            
            //appelle la fct qui va creer le critical path
            CriticalPathGen(direction, matrixLength - 1, startingPos, matrixLength - 1, startingPos, 0);
        }

        private void CriticalPathGen(int direction, int i, int j, int precI, int precJ, int downCounter)
        {
            if (i <= 0) //TODO: cehck si c'est <= ou <
            {
                CompleteMatrix();
            }

            else if (direction == 1 || direction == 2) //bouge à droite
            {
                if (j < matrixLength - 1 )
                {
                    int randTypeRoom = rnd.Next(0, Salle.nbOfRoomTypes);
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

                    CriticalPathGen(direction, i, j + 1, i, j, 0);
                }
                else
                {
                    CriticalPathGen(5, i-1, j, i, j, 0);
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

                    CriticalPathGen(direction, i, j - 1, i, j, 0);
                }
                else //si la prochaine pos et collé à Xmin on est obligé de descendre pour rester dans les limites
                {
                    CriticalPathGen(5, i-1, j, i, j, 0);
                }
            }
            else if (direction == 5) //bouge en bas
            {
                
                if (matrixPattern[precI,precJ].Type != 1 && matrixPattern[precI,precJ].Type != 3)
                {
                    if (downCounter >= 2)
                    {
                        matrixPattern[precI,precJ] = new Salle(Salle.list_LRBT[rnd.Next(0, Salle.list_LRBT.Length)]);
                    }
                    else
                    {
                        int randBottomOpeningRoom = rnd.Next(1,Salle.nbOfRoomTypes);
                        if (randBottomOpeningRoom == 2)
                        {
                            randBottomOpeningRoom = 1;
                        }
                        matrixPattern[precI,precJ] = new Salle(Salle.list_AllRoom[randBottomOpeningRoom][rnd.Next(0, Salle.list_AllRoom[randBottomOpeningRoom].Length)]);
                    }
                }
                    
                int randTypeRoom = rnd.Next(2, Salle.nbOfRoomTypes);
                int randRoomInThisType = rnd.Next(0, Salle.list_AllRoom[randTypeRoom].Length);
                matrixPattern[i-1, j] = new Salle(Salle.list_AllRoom[randTypeRoom][randRoomInThisType]);

                direction = rnd.Next(1, 6);
                CriticalPathGen(direction, i-1, j, i, j, downCounter+1);
            }
        }
        

        private void CompleteMatrix()
        {
            for (int i = 0; i < matrixLength; i++)
            {
                for (int j = 0; j < matrixLength; j++)
                {
                    if (i == matrixLength - 1 && j == matrixLength - 1)
                    {
                        if (matrixPattern[i,j] == null)
                        {
                            int randTypeRoom = rnd.Next(0, Salle.nbOfRoomTypes);
                            int randRoomInThisType = rnd.Next(0, Salle.list_AllRoom[randTypeRoom].Length);
                            matrixPattern[i, j] = new Salle(Salle.list_AllRoom[randTypeRoom][randRoomInThisType]);
                        }
                        SpawnPerspective();
                    }
                    else if (matrixPattern[i,j] == null)
                    {
                        int randTypeRoom = rnd.Next(0, Salle.nbOfRoomTypes);
                        int randRoomInThisType = rnd.Next(0, Salle.list_AllRoom[randTypeRoom].Length);
                        matrixPattern[i, j] = new Salle(Salle.list_AllRoom[randTypeRoom][randRoomInThisType]);
                    }
                }
            }
        }
        

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
                            //on fixe des nouvelles variables pr pas modif les anciennes
                            int i2 = i;
                            int j2 = j;
                            int k2 = k;
                            int l2 = l;
                            bool isBlockBeneath = true;
                            
                            
                            if (matrixPattern[i2,j2].Pattern[k2,l2] == 'W') //si le bloc aux indexes est un mur
                            {
                                if (k2-1 < 0) //si le bloc du dessous est pas ds la salle
                                {
                                    if (i2-1 >= 0)//si il y a une salle en dessous
                                    {
                                        i2 -= 1;
                                        k2 = 9;
                                    } 
                                    //sinon on dit que y'a pas de bloc en dessous
                                    isBlockBeneath = false;
                                }
                                else //si bloc du dessous ds la salle 
                                {
                                    k2 -= 1;
                                }
                                
                                while (isBlockBeneath && matrixPattern[i2,j2].Pattern[k2-1,l2] == 'W') //tant que le bloc du dessous est un mur
                                {
                                    if (k2-1 < 0)
                                    {
                                        if (i2-1 >= 0)
                                        {
                                            i2 -= 1;
                                            k2 = 9;
                                        }

                                        isBlockBeneath = false;
                                    }
                                    else
                                    {
                                        k2 -= 1;
                                    }

                                    if (isBlockBeneath)
                                    {
                                        matrixPattern[i2, j2].Pattern[k2, l2] = 'p';
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}