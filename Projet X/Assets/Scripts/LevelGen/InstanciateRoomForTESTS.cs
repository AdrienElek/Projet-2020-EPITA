using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using LevelGen;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

//AUTHOR : Alexandre GAUTIER

//Todo: Supprimer ce fichier c# en fin de projet, celui ci sert a avoir un apercu plus visuel des salles
public class InstanciateRoomForTESTS : MonoBehaviour
{
    //booleen qui indique si l'on veut generer une room de test
    public bool generateTestRoom;
    
    //boardHolders
    private Transform boardHolderBlocs; //va permettre de creer des dossiers et hierarchiser
    private Transform boardHolderEntities;
    private Transform boardHolderItems;
    
    //Blocs
    public GameObject[] wall;
    public GameObject[] ground; //sol à faire spawn

    //Entitées
    public GameObject player;
    public GameObject[] enemie;
    
    //Items
    public GameObject[] chest;
    
    void Start()
    {
        if (generateTestRoom)
        {
            Salle room = new Salle(Salle.LR3()); //CHANGER LA SALLE POUR LES TESTS
            InstanceTableau(room);
        }
    }

    //Methode qui instancie chaque bloc de la map selon le charactere aux indexes dans la matrice gameBoard
    private void InstanceTableau(Salle toInstanciate) //Todo: creer une fct qui fait apparaitre le sol pour eviter de faire 300 fct qd on fait spawn un obj sur du sol
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
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                //Position ou instancier, la matrice se lit differement que les cases du tableau, ce qui explique ces coord
                Vector2 blocPos = new Vector2(j, -i);
                transform.position = blocPos;
                
                /*On instancie le bloc selon le char dans la matrice :
                W = wall / p = persp / g = ground / C = chest / E = enemie / n = rien
                S = Spawn */
                int rand;
                switch (toInstanciate.Pattern[i,j])
                {
                    case "n":
                        InstanciateGround();
                        break;
                    
                    case "W":
                        rand = Random.Range(0, wall.Length); //genere un nb random dans la liste des sols
                        GameObject instanceWall = Instantiate(wall[rand], transform.position, Quaternion.identity);
                    
                        instanceWall.transform.SetParent(boardHolderBlocs);
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
                    
                    case "SPAWN":
                        InstanciateGround();
                        GameObject instancePlayer = Instantiate(player, transform.position, Quaternion.identity);
                        
                        instancePlayer.transform.SetParent(boardHolderEntities);
                        break;
                    
                    default:
                        throw new Exception("Un objets(char) du pattern d'une salle de la classe Salle existe mais n'a pas encore été défini dans InstanciateMatrice");
                        InstanciateGround();
                        break;
                }
            }
        }
    }
}
