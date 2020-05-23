using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private void isDead() //TODO : completer qd les slimes pourront mourir
    {
        if (gameObject)
        {
            Destroy(InstanciateMatrice.boardHolderBlocks.gameObject);
            Destroy(InstanciateMatrice.boardHolderOther.gameObject);
            Destroy(InstanciateMatrice.boardHolderTrap.gameObject);
            Destroy(InstanciateMatrice.boardHolderEntities.gameObject);

            InstanciateMatrice.genLevel = true;
        }
    }
}
