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
    //Parametres
    [Header("PARAMETRES")]
    public int AverageMatrixLength; //la taille de matrice ne DOIT PAS être inferieur à 3
    private int matrixLength() //Genere une map de taille +- 1 par rapport à Averagematrixlength
    {
        int rand = Random.Range(AverageMatrixLength-1, AverageMatrixLength+2);
        return rand;
    }
    private float distanceBtwRooms = 10;
    private int level = 1;
    public static bool genLevel; //permet de generer un nouveau niveau quand le joueur touche la sortie

    //boardHolders
    public static Transform boardHolderBlocks;
    public static Transform boardHolderEntities;
    public static Transform boardHolderOther;
    public static Transform boardHolderTrap;
    
    //Blocs
    [Header("BLOCS")]
    public GameObject[] wall;
    public GameObject[] woodground;
    public GameObject[] ground;
    public GameObject[] perpective;
    public GameObject[] seGround;
    
    //Entitées
    [Header("ENTITEES")]
    public GameObject player1;
    public GameObject player2;
    public GameObject[] enemie;
    public GameObject[] boss;

    //Traps
    [Header("PIEGES")]
    public GameObject[] trap;

    //Chest
    [Header("AUTRES")] 
    public GameObject exit;
    public GameObject[] chest;

    
    void Start()
    {
        GenerateLevels();
    }

    private void Update()
    {
        if (genLevel)
        {
            GenerateLevels();
        }
    }

    //Choisi le Spawn d'un niveau Normal Ou niveau Boss
    public void GenerateLevels()
    {
        
        if (level % 3 == 0)
        {
            GenerateBossRoom();
        }
        else
        {
            GenerateNormalLevel();
        }

        genLevel = false;
        level += 1;
    }

    //Preset pour les niveaux normaux et Boss
    public void GenerateBossRoom()
    {
        Tableau bossLvl = new Tableau(4, true);
        GameBoardGeneration(bossLvl);
    }
    public void GenerateNormalLevel()
    {
        Tableau gameBoard = new Tableau(matrixLength(), false);
        GameBoardGeneration(gameBoard);
    }
    

    //Methode qui instancie chaque bloc de la map selon le charactere aux indexes dans la matrice gameBoard
    private void GameBoardGeneration(Tableau toInstanciate)
    {
        //Listes boardHolder
        boardHolderBlocks = new GameObject ("BoardBlocks").transform;
        boardHolderEntities = new GameObject("BoardEntities").transform;
        boardHolderOther = new GameObject("BoardOther").transform;
        boardHolderTrap = new GameObject("BoardTrap").transform;

        //Methode qui instancie des blocs souvent instanciés -> evite les répétitions de code
        void InstanciateWall()
        {
            int rand = Random.Range(0, wall.Length); //genere un nb random dans la liste des sols
            GameObject instanceWall = Instantiate(wall[rand], transform.position, Quaternion.identity);
                            
            instanceWall.transform.SetParent(boardHolderBlocks);
        }
        
        void InstanciateGround()
        {
            int rand = Random.Range(0, ground.Length);
            GameObject instanceGround = Instantiate(ground[rand], transform.position, Quaternion.identity);
                                
            instanceGround.transform.SetParent(boardHolderBlocks);
        }
        
        void InstanciateSeGround()
        {
            int rand = Random.Range(0, seGround.Length);
            GameObject instanceSpawnGround = Instantiate(seGround[rand], transform.position, Quaternion.identity);
            
            instanceSpawnGround.transform.SetParent(boardHolderBlocks);
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
                        //Position ou instancier, la matrice se lit differement que les cases du tableau, ce qui explique ces coordonnées
                        Vector2 blocPos = new Vector2(j*distanceBtwRooms + l, -i*distanceBtwRooms - k);
                        transform.position = blocPos;
                        
                        //On instancie le bloc selon les string de la matrice de matrice:
                        int rand;
                        switch (toInstanciate.matrixPattern[i, j].Pattern[k, l])
                        {
                            case "n":
                                InstanciateGround();
                                break;
                            
                            case "W":
                                InstanciateWall();
                                break;
                            
                            case "p":
                                rand = Random.Range(0, perpective.Length); //genere un nb random dans la liste des sols
                                GameObject instancePerspective = Instantiate(perpective[rand], transform.position, Quaternion.identity);
                            
                                instancePerspective.transform.SetParent(boardHolderBlocks);
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

                                instanceChest.transform.SetParent(boardHolderOther);
                                break;
                            
                            case "T":
                                rand = Random.Range(0, trap.Length);
                                if (rand == 1) //TODO : Modifier cette ligne si on rajoute d'autres type de pièges
                                {
                                    GameObject instanceTrap = Instantiate(trap[rand], transform.position, Quaternion.identity);
                                
                                    instanceTrap.transform.SetParent(boardHolderTrap);
                                }
                                else
                                {
                                    InstanciateGround();
                                    GameObject instanceTrap = Instantiate(trap[rand], transform.position, Quaternion.identity);
                                
                                    instanceTrap.transform.SetParent(boardHolderTrap);
                                }
                                break;
                            
                            case "WoodG":
                                rand = Random.Range(0, woodground.Length); //genere un nb random dans la liste des sols
                                GameObject instanceWoodGround = Instantiate(woodground[rand], transform.position, Quaternion.identity);
                            
                                instanceWoodGround.transform.SetParent(boardHolderBlocks);
                                break;

                            case "SpawnP1":
                                InstanciateSeGround();
                                GameObject instancePlayer1 = Instantiate(player1, transform.position, Quaternion.identity);
                                
                                instancePlayer1.transform.SetParent(boardHolderEntities);
                                break;
                            
                            case "SpawnP2":
                                InstanciateSeGround();
                                GameObject instancePlayer2 = Instantiate(player2, transform.position, Quaternion.identity);
                                
                                instancePlayer2.transform.SetParent(boardHolderEntities);
                                break;
                            
                            case "SEBlocks":
                                InstanciateSeGround();
                                break;
                            
                            case "EXIT":
                                InstanciateSeGround();
                                GameObject instanceExit = Instantiate(exit, transform.position, Quaternion.identity);
                                
                                instanceExit.transform.SetParent(boardHolderOther);
                                break;
                            
                            case "BOSS":
                                InstanciateGround();
                                rand = Random.Range(0, boss.Length);
                                GameObject instanceBoss = Instantiate(boss[rand], transform.position, Quaternion.identity);
                                
                                instanceBoss.transform.SetParent(boardHolderEntities);
                                break;
                            default:
                                Debug.Log(toInstanciate.matrixPattern[i, j].Pattern[k, l] + " // " + toInstanciate.matrixPattern[i,j].Type);
                                throw new Exception(
                                    "Un objets(char) du pattern d'une salle de la classe Salle existe mais n'a pas encore été défini dans InstanciateMatrice" +
                                    " OU un objet du GameObject levelGeneration de la scène est  manquant");
                        }
                    }
                }
            }
        }
        
        //Genere les bordures du niveau
        //TODO : optimiser cette merde
        for (int i = 0; i < toInstanciate.matrixLength*10; i++)
        {
            Vector2 blocPos1 = new Vector2(-1, -i);
            transform.position = blocPos1;
            InstanciateWall();

            Vector2 blocPos2 = new Vector2(toInstanciate.matrixLength * 10, -i);
            transform.position = blocPos2;
            InstanciateWall();
        }
            
        for (int j = -1; j < toInstanciate.matrixLength*10+1; j++)
        {
            Vector2 blocPos1 = new Vector2(j, 1);
            transform.position = blocPos1;
            InstanciateWall();
                
            Vector2 blocPos2 = new Vector2(j, -toInstanciate.matrixLength*10);
            transform.position = blocPos2;
            InstanciateWall();
        }
    }
}