using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlRewardCoins : MonoBehaviour
{
    [SerializeField] Text textCoinPrincipalMenu = null;

    private void Start()
    {
        changeValueInTheText();
    }

    private void Update()
    {
        changeValueInTheText();
    }

    public void SetCoinsToControlCoin(int multiplicator) {
        ControlCoin.Instance.changeActualCoin(CoinsManager.Instance.dataLevel.coinsToReward*multiplicator);
        changeValueInTheText();
    }

    private void changeValueInTheText() {

        if (textCoinPrincipalMenu != null)
        {
            textCoinPrincipalMenu.text = ControlCoin.Instance.GetActualCoinGeneral().ToString();
        }
    }
}
