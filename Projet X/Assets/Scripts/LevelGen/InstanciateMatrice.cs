using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using LevelGen;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

//AUTHOR : Alexandre GAUTIER

public class InstanciateMatrice : MonoBehaviour
{
    public bool generateMatrix;
    
    //boardHolders
    private Transform boardHolderBlocs; //va permettre de creer des dossiers et hierarchiser
    private Transform boardHolderEntities;
    private Transform boardHolderItems;
    
    //Blocs
    public GameObject[] wall;
    public GameObject[] ground; //sol à faire spawn
    public GameObject[] perpective;
    
    //Entitées
    public GameObject player1;
    public GameObject player2;
    public GameObject[] enemie;
    
    //Items
    public GameObject[] chest;

    //Constantes
    private int matrixLength = 8;
    private float distanceBtwRooms = 10;
    
    //Execute quand play est cliqué
    void Start()
    {
        if (generateMatrix) //Todo: Supprimer ce bool qui sert uniquement pour decider si on veut gen une salleTest ou le tableau de jeu
        {
            Tableau gameBoard = new Tableau(matrixLength);
            InstanceTableau(gameBoard);
        }
    }

    //Methode qui instancie chaque bloc de la map selon le charactere aux indexes dans la matrice gameBoard
    private void InstanceTableau(Tableau toInstanciate)
    {
        //Listes boardHolder
        boardHolderBlocs = new GameObject ("BoardBlocks").transform;
        boardHolderEntities = new GameObject("BoardEntities").transform;
        boardHolderItems = new GameObject("BoardItems").transform;
        
        //Instancie Le sol (Methode mise a l'ecart pour plus de clarte)
        void InstanciateGround()
        {
            int rand = Random.Range(0, ground.Length);
            GameObject instanceGround = Instantiate(ground[rand], transform.position, Quaternion.identity);
                                
            instanceGround.transform.SetParent(boardHolderBlocs);
        }
        
        //Instanciation des blocs
        for (int i = 0; i < toInstanciate.matrixLength; i++)
        {
            for (int j = 0; j < toInstanciate.matrixLength; j++)
            {
                for (int k = 0; k < 10; k++)
                {
                    for (int l = 0; l < 10; l++)
                    {
                        //Position ou instancier, la matrice se lit differement que les cases du tableau, ce qui explique ces coord
                        Vector2 blocPos = new Vector2(j*distanceBtwRooms + l, -i*distanceBtwRooms - k);
                        transform.position = blocPos;
                        
                        /*On instancie le bloc selon le char dans la matrice :
                        W = wall / p = persp / g = ground / C = chest / E = enemie / n = rien
                        S = Spawn */
                        int rand;
                        switch (toInstanciate.matrixPattern[i, j].Pattern[k, l])
                        {
                            case "n":
                                InstanciateGround();
                                break;
                            
                            case "W":
                                rand = Random.Range(0, wall.Length); //genere un nb random dans la liste des sols
                                GameObject instanceWall = Instantiate(wall[rand], transform.position, Quaternion.identity);
                            
                                instanceWall.transform.SetParent(boardHolderBlocs);
                                break;
                            
                            case "p":
                                rand = Random.Range(0, perpective.Length); //genere un nb random dans la liste des sols
                                GameObject instancePerspective = Instantiate(perpective[rand], transform.position, Quaternion.identity);
                            
                                instancePerspective.transform.SetParent(boardHolderBlocs);
                                break;
                            
                            case "E":
                                InstanciateGround();
                                rand = Random.Range(0, enemie.Length); //genere un nb random dans la liste des sols
                                GameObject instanceEnemie = Instantiate(enemie[rand], transform.position, Quaternion.identity);

                                instanceEnemie.transform.SetParent(boardHolderEntities);
                                break;
                            
                            case "C":
                                InstanciateGround();
                                rand = Random.Range(0, chest.Length); //genere un nb random dans la liste des sols
                                GameObject instanceChest = Instantiate(chest[rand], transform.position, Quaternion.identity);

                                instanceChest.transform.SetParent(boardHolderItems);
                                break;
                            
                            case "SpawnP1":
                                InstanciateGround();
                                GameObject instancePlayer1 = Instantiate(player1, transform.position, Quaternion.identity);
                                
                                instancePlayer1.transform.SetParent(boardHolderEntities);
                                break;
                            
                            case "SpawnP2":
                                InstanciateGround();
                                GameObject instancePlayer2 = Instantiate(player2, transform.position, Quaternion.identity);
                                
                                instancePlayer2.transform.SetParent(boardHolderEntities);
                                break;
                            
                            default:
                                Debug.Log(toInstanciate.matrixPattern[i, j].Pattern[k, l] + " // " + toInstanciate.matrixPattern[i,j].Type);
                                throw new Exception("Un objets(char) du pattern d'une salle de la classe Salle existe mais n'a pas encore été défini dans InstanciateMatrice" +
                                                    " OU un objet du GameObject levelGeneration de la scène est  manquant");
                                InstanciateGround();
                                break;
                        }
                    }
                }
            }
        }
    }
}