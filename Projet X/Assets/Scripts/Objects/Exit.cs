using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//AUTHOR : Alexandre GAUTIER

public class Exit : MonoBehaviour
{
    public GameObject player;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag(player.tag))
        {
            Destroy(InstanciateMatrice.boardHolderBlocks.gameObject);
            Destroy(InstanciateMatrice.boardHolderOther.gameObject);
            Destroy(InstanciateMatrice.boardHolderTrap.gameObject);
            Destroy(InstanciateMatrice.boardHolderEntities.gameObject);

            InstanciateMatrice.genLevel = true;
        }
    }
}
