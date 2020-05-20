using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AUTHOR : Alexandre GAUTIER

public class Piege : MonoBehaviour
{
    public GameObject piegeApres;
    public GameObject player1;
    public GameObject player2;
    public AudioSource source;
    public AudioClip clip;
    public bool isPoisonous;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag(player1.tag))
        {
            PlayTrap();
            
            //effet sur le joueur 1
            if (!isPoisonous)
            {
                PlayerStat.TakeDamage(20);
            }
            else
            {
                //Todo: modif ca, la le player est malade pendant tout le reste de la partie
                //InvokeRepeating("Player1Sick", 1.0f, 1.0f);
            }
        }
        else if (coll.gameObject.CompareTag(player2.tag))
        {
            PlayTrap();
            
            //effet sur le joueur 2
            if (!isPoisonous)
            {
                multistat.TakeDamage(20);
            }
            else
            {
                //Todo: modif ca, la le player est malade pendant tout le reste de la partie
                //InvokeRepeating("Player1Sick", 1.0f, 1.0f);
            }
        }
    }

    void Player1Sick()
    {
        PlayerStat.hp -= 5;
    }

    void Player2Sick()
    {
        //todo: faire baisser les stats du p2
    }

    void PlayTrap()
    { 
        //instancie le piège fermé
        GameObject piegeEnclenche = Instantiate(piegeApres, gameObject.transform.position, Quaternion.identity);
        piegeEnclenche.transform.SetParent(InstanciateMatrice.boardHolderTrap);
            
        //detruit le piege ouvert
        Destroy(gameObject);
            
        //joue le son du brisage de genoux
        source = piegeEnclenche.GetComponent<AudioSource>();
        source.volume = 0.3f;
        source.PlayOneShot(clip);
    }
}
