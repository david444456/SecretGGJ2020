using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//this script control activated and desactive store, and call method to activated objects
[RequireComponent(typeof(CtrolObjectStore3D))]
[RequireComponent(typeof(MovementStore3D))]
public class ControlStore3D : MonoBehaviour
{
    [SerializeField] UnityEvent eventTryToShowRewardedVideo = new UnityEvent();

    [SerializeField] GameObject AllObjectStore = null;
    [SerializeField] bool isObjectSelect = true;

    [Header("UI")]
    [SerializeField] Text textSelectOrPurchasedNewItem = null;
    [SerializeField] GameObject gameObjectSelectPurchasedNewItem = null;

    private CtrolObjectStore3D ctrolObjectStore;
    private MovementStore3D movementStore3D;
    private BuyItemInfo3D buyItemInfo3D;

    private int m_indexActualPositionInStore = 0;
    private int m_objectSelectable = 0;

    private void Start()
    {
        ctrolObjectStore = GetComponent<CtrolObjectStore3D>();
        movementStore3D = GetComponent<MovementStore3D>();
        buyItemInfo3D = GetComponent<BuyItemInfo3D>();

        //load position select
        m_objectSelectable = PlayerPrefs.GetInt("Select", 0);

        //for set initial values
        newMovement_VerifyIfObjectIsPurchased();

        //for levels data
        print(ctrolObjectStore.GetObjectActualPosition(m_objectSelectable).GetComponent<ItemInfo3D>().spriteActualIbObject.name);
        ControlSpriteShip.Instance.SetSpriteShip(ctrolObjectStore.GetObjectActualPosition(m_objectSelectable).GetComponent<ItemInfo3D>().spriteActualIbObject);
    }

    public void activeOrDesactiveStore(bool changeValueBool) {
        AllObjectStore.SetActive(changeValueBool);
        ctrolObjectStore.changeActiveOrDesactiveAllObjects(changeValueBool);
    }

    public void BuyItemWithAdsRewarded() {
        if (!ctrolObjectStore.GetIfIsRewarded(m_indexActualPositionInStore)) return; //ads

        //buy
        ctrolObjectStore.BuyIndexItem(movementStore3D.GetActualIndexPosition());
        newMovement_VerifyIfObjectIsPurchased();
    
    }

    public void TryBuyActualObject() {
        //if
        //buy
        m_indexActualPositionInStore = movementStore3D.GetActualIndexPosition();

        if (IsActualSelectable()) return; //select

        if (ctrolObjectStore.GetIfIsRewarded(m_indexActualPositionInStore)) {
            eventTryToShowRewardedVideo.Invoke();
            return;

        } //ads

        if (buyItemInfo3D.IfPossibleToBuyAndDescontateCoins(ctrolObjectStore.GetObjectActualPosition(m_indexActualPositionInStore)))
        {
            ctrolObjectStore.BuyIndexItem(movementStore3D.GetActualIndexPosition());
        }
        newMovement_VerifyIfObjectIsPurchased();
    }

    public void newMovementInStore() {

        m_indexActualPositionInStore = movementStore3D.GetActualIndexPosition();
        gameObjectSelectPurchasedNewItem.SetActive(true); //select?
        newMovement_VerifyIfObjectIsPurchased();
    }

    private void newMovement_VerifyIfObjectIsPurchased() {

        if (ctrolObjectStore.GetArraySaveIfPurchased(m_indexActualPositionInStore))
        {
            if (!isObjectSelect || m_objectSelectable == m_indexActualPositionInStore) gameObjectSelectPurchasedNewItem.SetActive(false);
            else textSelectOrPurchasedNewItem.text = "SELECT";
        }
        else if (ctrolObjectStore.GetIfIsRewarded(m_indexActualPositionInStore)) {//reward video
            textSelectOrPurchasedNewItem.text = "VIDEO"; //coins
        }
        else {

            textSelectOrPurchasedNewItem.text = "BUY " + ctrolObjectStore.GetObjectActualPosition(m_indexActualPositionInStore).costItem; //coins
        }
    }

    private bool IsActualSelectable() {
        if (ctrolObjectStore.GetArraySaveIfPurchased(m_indexActualPositionInStore))
        {
            m_objectSelectable = m_indexActualPositionInStore;
            buyItemInfo3D.OnSelectObject(ctrolObjectStore.GetObjectActualPosition(m_indexActualPositionInStore));
            gameObjectSelectPurchasedNewItem.SetActive(false);

            //save
            PlayerPrefs.SetInt("Select", m_objectSelectable);
            return true;
        }
        return false;
    }



}
