using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRepairShip : ItemManager
{
    private void Start()
    {
        maxValueRandomIntByItem = GameManager.gameManager.dataLevel.maxPointsRepairShip;
    }

    public override void playerGetItem(int randomValue, GameObject playerShip) {
        base.playerGetItem(randomValue, playerShip);

        //repair
        if ((playerShip.GetComponent<DestroyShip>().healthShip) >= GameManager.gameManager.maxValueHealthShip)
        {
            return;
        }
        else if ((playerShip.GetComponent<DestroyShip>().healthShip + randomValue) > GameManager.gameManager.maxValueHealthShip)
        {
            randomValue = -(playerShip.GetComponent<DestroyShip>().healthShip + randomValue - GameManager.gameManager.maxValueHealthShip) + randomValue;
        }

        //gamemanager
        GameManager.gameManager.activeExercisesRest(randomValue);

    }
}
