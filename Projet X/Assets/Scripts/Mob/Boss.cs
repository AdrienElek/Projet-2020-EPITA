using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private void isDead()
    {
        if (!EnemySlimeController.IsAlive)
        {
            Destroy(InstanciateMatrice.boardHolderBlocks.gameObject);
            Destroy(InstanciateMatrice.boardHolderOther.gameObject);
            Destroy(InstanciateMatrice.boardHolderTrap.gameObject);
            Destroy(InstanciateMatrice.boardHolderEntities.gameObject);

            InstanciateMatrice.genLevel = true;
        }
    }

    private void Update()
    {
        isDead();
    }
}
