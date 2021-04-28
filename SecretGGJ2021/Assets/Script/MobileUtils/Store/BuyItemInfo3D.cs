using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is conection between store and other scripts in esthetic projects
public class BuyItemInfo3D : MonoBehaviour
{
    public bool IfPossibleToBuyAndDescontateCoins(ItemInfo3D Item) {

        if(ControlCoin.Instance.GetActualCoinGeneral() >= Item.costItem){
            ControlCoin.Instance.changeActualCoin(-Item.costItem);
            return true;
        }
        return false;
    }
    /*
    public string GetStringUnitsWithIndex(int index) {
        return ControlCoin.Instance.GetStringValueUnitWithIndex(index);
    }*/

    public void BuyNewItem(ItemInfo3D GONewItem)
    {
        print(GONewItem.name);

    }

    public void OnSelectObject(ItemInfo3D GONewItem) {
        ControlSpriteShip.Instance.SetSpriteShip(GONewItem.spriteActualIbObject);
    }
}
