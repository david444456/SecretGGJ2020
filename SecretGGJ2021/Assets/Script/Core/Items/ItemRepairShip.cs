using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRepairShip : ItemManager
{
    private void Start()
    {
        maxValueRandomIntByItem = CoinsManager.Instance.dataLevel.maxPointsRepairShip;
    }

    public override void playerGetItem(int randomValue, GameObject playerShip) {
        base.playerGetItem(randomValue, playerShip);

        //repair
        if ((playerShip.GetComponent<DestroyShip>().healthShip) >= CoinsManager.Instance.maxValueHealthShip)
        {
            return;
        }
        else if ((playerShip.GetComponent<DestroyShip>().healthShip + randomValue) > CoinsManager.Instance.maxValueHealthShip)
        {
            randomValue = -(playerShip.GetComponent<DestroyShip>().healthShip + randomValue - CoinsManager.Instance.maxValueHealthShip) + randomValue;
        }

        //gamemanager
        ControlExerciseShip.Instance.activeExercisesRest(randomValue);

    }
}
