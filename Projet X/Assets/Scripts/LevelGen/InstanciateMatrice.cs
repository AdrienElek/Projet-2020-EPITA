using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using LevelGen;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class InstanciateMatrice : MonoBehaviour
{
    private Transform boardHolderBlocs; //va permettre de creer des dossiers et hierarchiser
    private Transform boardHolderEntities;
    private Transform boardHolderItems;
    
    //Blocs
    public GameObject[] wall;
    public GameObject[] ground; //sol à faire spawn
    public GameObject[] perpective;
    
    //Entitées
    public GameObject player;
    public GameObject[] enemie;
    
    //Items
    public GameObject[] chest;

    private int matrixLength = 8;
    private float distanceBtwRooms = 10; //distance entre les salles

    // Start is called before the first frame update
    void Start()
    {
        Tableau toInstanciate = new Tableau(matrixLength);
        InstanceTableau(toInstanciate);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void InstanceTableau(Tableau toInstanciate) //Todo: creer une fct qui fait apparaitre le sol pour eviter de faire 300 fct qd on fait spawn un obj sur du sol
    {
        boardHolderBlocs = new GameObject ("BoardBlocks").transform;
        boardHolderEntities = new GameObject("BoardEntities").transform;
        boardHolderItems = new GameObject("BoardItems").transform;

        void InstanciateGround()
        {
            int rand = Random.Range(0, ground.Length);
            GameObject instanceGround = Instantiate(ground[rand], transform.position, Quaternion.identity);
                                
            instanceGround.transform.SetParent(boardHolderBlocs);
        }
        
        for (int i = 0; i < toInstanciate.matrixLength; i++)
        {
            for (int j = 0; j < toInstanciate.matrixLength; j++)
            {
                for (int k = 0; k < 10; k++)
                {
                    for (int l = 0; l < 10; l++)
                    {
                        Vector2 blocPos = new Vector2(j*distanceBtwRooms + l, -i*distanceBtwRooms - k); //la matrice se lit differement que les cases du tableau, ce qui explique ces coord
                        transform.position = blocPos;

                        if (toInstanciate.matrixPattern[i,j] is Salle) //Todo: enlever cette ligne qui sert pr le test tu critical path
                        {
                            int rand;
                            switch (toInstanciate.matrixPattern[i, j].Pattern[k, l])
                            {
                                case 'n':
                                    InstanciateGround();
                                    break;
                                
                                case 'W':
                                    rand = Random.Range(0, wall.Length); //genere un nb random dans la liste des sols
                                    GameObject instanceWall = Instantiate(wall[rand], transform.position, Quaternion.identity);
                                
                                    instanceWall.transform.SetParent(boardHolderBlocs);
                                    break;
                                
                                case 'p':
                                    
                                    if (k == 9 && l == 4)
                                    {
                                        Debug.Log("CASE ACTUELLE = " + i + " : " + j + " : " + k + " : " + l + " // TYPE = " + toInstanciate.matrixPattern[i,j].Pattern[k,l]);
                                        if (i+1 < matrixLength)
                                        {
                                            Debug.Log("DESSOUS = " + toInstanciate.matrixPattern[i + 1, j].Pattern[0, l]);
                                        }
                                    }
                                    
                                    rand = Random.Range(0, perpective.Length); //genere un nb random dans la liste des sols
                                    GameObject instancePerspective = Instantiate(perpective[rand], transform.position, Quaternion.identity);
                                
                                    instancePerspective.transform.SetParent(boardHolderBlocs);
                                    break;
                                
                                case 'E':
                                    InstanciateGround();
                                    rand = Random.Range(0, enemie.Length); //genere un nb random dans la liste des sols
                                    GameObject instanceEnemie = Instantiate(enemie[rand], transform.position, Quaternion.identity);

                                    instanceEnemie.transform.SetParent(boardHolderEntities);
                                    break;
                                
                                case 'C':
                                    InstanciateGround();
                                    rand = Random.Range(0, chest.Length); //genere un nb random dans la liste des sols
                                    GameObject instanceChest = Instantiate(chest[rand], transform.position, Quaternion.identity);

                                    instanceChest.transform.SetParent(boardHolderItems);
                                    break;
                                
                                case 'S':
                                    InstanciateGround();
                                    GameObject instancePlayer = Instantiate(player, transform.position,
                                        Quaternion.identity);
                                    
                                    instancePlayer.transform.SetParent(boardHolderEntities);
                                    break;
                                
                                default:
                                    //throw new Exception("Un objets(char) du pattern d'une salle de la classe Salle existe mais n'a pas encore été défini dans InstanciateMatrice");
                                    InstanciateGround();
                                    break;

                            }
                        }
                    }
                }
            }
        }
    }
}