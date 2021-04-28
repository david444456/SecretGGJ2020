using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//control coin between scenes
public class ControlCoin : SingletonInInspector<ControlCoin>
{
    private int actualCoins = 0;

    // Start is called before the first frame update
    public override void Awake()
    {
        base.Awake();

        actualCoins = PlayerPrefs.GetInt("coinGeneral");
    }

    public int GetActualCoinGeneral() {
        return actualCoins;
    }

    public void changeActualCoin(int countCoinToAugment) {
        actualCoins += countCoinToAugment;
        SaveDataCoin();
    }

    private void SaveDataCoin()
    {
        PlayerPrefs.SetInt("coinGeneral", actualCoins);
    }
}
