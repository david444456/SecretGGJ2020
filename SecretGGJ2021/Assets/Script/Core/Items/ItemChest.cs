using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChest : ItemManager
{
    private void Start()
    {
        maxValueRandomIntByItem = CoinsManager.Instance.dataLevel.maxCoinsTreasure;
    }

    public override void playerGetItem(int randomValue, GameObject playerShip)
    {
        base.playerGetItem(randomValue, playerShip);

        //gamemanager
        ControlExerciseShip.Instance.activeExercisesSum(randomValue);
    }
}
