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
            PlayAudioClip();
            
            GameObject piegeALoupFerme = Instantiate(piegeFerme, gameObject.transform.position, Quaternion.identity);
            piegeALoupFerme.transform.SetParent(InstanciateMatrice.boardHolderTrap);
            
            //Destroy(gameObject);
            
            //Todo: rajouter les degats au joueur + effet joeuur 2
        }
    }

    private void PlayAudioClip()
    {
        source = gameObject.GetComponent<AudioSource>();
        source.volume = 1f;
        source.PlayOneShot(clip);
    }

}
