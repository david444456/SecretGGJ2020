using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Info", menuName = "Data/ New data level information", order = 0)]
public class DataLevels : ScriptableObject
{
    [SerializeField] public int coinsToWin = 0;
    [SerializeField] public int lifeShip = 0;
    [SerializeField] public int hitShip = 0;
    [SerializeField] public int minimunAddCoinsOrLife = 0;
    [SerializeField] public int maxCoinsTreasure = 0;
    [SerializeField] public int maxPointsRepairShip = 0;
    public float maxTimeSeeTreasure = 0;
    public float maxTimeDraw = 0;
    
}
