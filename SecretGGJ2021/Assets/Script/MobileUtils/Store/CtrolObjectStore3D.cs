using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Events;

public class CtrolObjectStore3D : MonoBehaviour
{
    [SerializeField] EBuyNewItem buyNewItem;

    [Header("GO in store")]
    [SerializeField] ItemInfo3D[] gameObjectInStore = null;

    [SerializeField] private bool[] arrayThatSaveWhoIsPurchased;

    string nameDataSave;

    [System.Serializable]
    public class EBuyNewItem : UnityEvent<ItemInfo3D>
    {

    }

    private void Awake()
    {

        if (buyNewItem == null)
            buyNewItem = new EBuyNewItem();

        //load
        nameDataSave = Application.persistentDataPath + "/datos.dat";
        LoadDataValueBool();
    }

    public ItemInfo3D GetObjectActualPosition(int index) {
        return gameObjectInStore[index];
    }

    public ItemInfo3D[] GetObjectsItems()
    {
        return gameObjectInStore;
    }

    public int GetMaxCountOfGameObjectsInStore()
    {
        return gameObjectInStore.Length;
    }

    public void changeActiveOrDesactiveAllObjects(bool activeOrDesactive)
    {
        for (int i =0; i< gameObjectInStore.Length; i++)
        {
            gameObjectInStore[i].gameObject.SetActive(activeOrDesactive);
        }
    }

    public bool GetArraySaveIfPurchased(int index) {
        return arrayThatSaveWhoIsPurchased[index];
    }

    public bool GetIfIsRewarded(int index)
    {
        return gameObjectInStore[index].IsOnlyRewarded;
    }

    public void BuyIndexItem(int index) {
        if (index >= GetMaxCountOfGameObjectsInStore()) return;
        if (arrayThatSaveWhoIsPurchased[index]) return; //change select

        //buy
        arrayThatSaveWhoIsPurchased[index] = true;
        buyNewItem.Invoke(gameObjectInStore[index]);
        print("buy");


        //save
        saveValueBoolItems_IfPurchased();
    }

    private void saveValueBoolItems_IfPurchased()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(nameDataSave);

        bf.Serialize(file, arrayThatSaveWhoIsPurchased);
        file.Close();

    }

    void LoadDataValueBool()
    {
        if (File.Exists(nameDataSave))
        {
            print(nameDataSave);

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(nameDataSave, FileMode.Open);

            arrayThatSaveWhoIsPurchased = (bool[])bf.Deserialize(file);

            file.Close();
        }
        else
        {
            print("No data");

        }


    }
}
