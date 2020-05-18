using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AUTHOR : Alexandre GAUTIER

public class PiegeALoup : MonoBehaviour
{
    public GameObject piegeOuvert;
    public GameObject piegeFerme;
    public GameObject player1;
    public GameObject player2;
    public AudioSource source;
    public AudioClip clip;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag(player1.tag))
        {
            //instancie le piège fermé
            GameObject piegeALoupFerme = Instantiate(piegeFerme, gameObject.transform.position, Quaternion.identity);
            piegeALoupFerme.transform.SetParent(InstanciateMatrice.boardHolderTrap);
            
            //detruit le piege ouvert
            Destroy(gameObject);
            
            //joue le son du brisage de genoux
            source = piegeALoupFerme.GetComponent<AudioSource>();
            source.volume = 0.3f;
            source.PlayOneShot(clip);
            
            //effet sur le joueur
            PlayerStat.hp -= 20;
            //Todo: rajouter les degats au joueur + effet joeuur 2
        }
    }
}
