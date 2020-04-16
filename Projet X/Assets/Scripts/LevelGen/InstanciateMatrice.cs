using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using LevelGen;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class InstanciateMatrice : MonoBehaviour
{
    public Transform boardHolder; //va permettre de creer des dossiers et hierarchiser
    
    public GameObject[] wall;
    public GameObject[] ground; //sol à faire spawn
    public GameObject[] perpective;

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

    private void InstanceTableau(Tableau toInstanciate)
    {
        boardHolder = new GameObject ("BoardObjects").transform;
        
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
                                case 'W':
                                    rand = Random.Range(0, wall.Length); //genere un nb random dans la liste des sols
                                    GameObject instanceWall = Instantiate(wall[rand], transform.position, Quaternion.identity);
                                
                                    instanceWall.transform.SetParent(boardHolder);
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
                                
                                    instancePerspective.transform.SetParent(boardHolder);
                                    break;
                                default:
                                    rand = Random.Range(0, ground.Length); //genere un nb random dans la liste des sols
                                    GameObject instanceGround = Instantiate(ground[rand], transform.position, Quaternion.identity);
                                
                                    instanceGround.transform.SetParent(boardHolder);
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}