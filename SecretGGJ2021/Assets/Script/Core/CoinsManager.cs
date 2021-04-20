using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

//control coins in game
public class CoinsManager : SingletonInInspector<CoinsManager>
{
    public UnityEvent IWIN;
    public static CoinsManager gameManager;

    [Header("Data")]
    public DataLevels dataLevel;
    public DataLanguages dataLanguages;

    [Header("Var in game")]
    [HideInInspector] public int valueToAddAfterExercise = 0;
    [HideInInspector] public int maxValueHealthShip;
    public GameObject playerShip;
    [SerializeField] DestroyShip destroyShip;
    [SerializeField] int maxErrorsByPlayer = 5;

    [Header("UI")]
    [SerializeField] Text textCoin;
    [SerializeField] GameObject gameObjectTextWin;
    [SerializeField] Text textWin;
    [SerializeField] Text textWinCoinsReward;
    [SerializeField] ActiveUIExercises activeUIExercisesScript;
    [SerializeField] Slider sliderErrorsLife = null;

    private int minimumValueCoins;
    private int coinsToWin = 20000;
    private int actualCoins = 0;

    public override void Awake()
    {
        base.Awake();

        gameManager = this;

        if (ControlLevelData.Instance != null)
        {
            dataLevel = ControlLevelData.Instance.dataGeneralLevels.dataLevels[SceneManager.GetActiveScene().buildIndex - 2];
            dataLanguages = ControlLevelData.Instance.dataLanguages;
        }
    }

    void Start()
    { 
        //health ship
        destroyShip.changeDataShip(dataLevel.lifeShip, dataLevel.hitShip);
        maxValueHealthShip = dataLevel.lifeShip;

        //coinsToWin
        coinsToWin = dataLevel.coinsToWin;
        minimumValueCoins = dataLevel.minimunAddCoinsOrLife;

        //text coins
        textCoin.text = actualCoins.ToString() + "/" + coinsToWin.ToString();
        sliderErrorsLife.maxValue = maxErrorsByPlayer;
    }

    public int actualCoinsMethod()
    {
        return actualCoins;
    }

    public int sumValueActualCoinsAndAddCoins()
    {
        return actualCoins + valueToAddAfterExercise;
    }

    public int GetMinimunValueOfRandomCoin()
    {
        return minimumValueCoins;
    }

    public void AugmentValueCoins(int valueCoins)
    {
        actualCoins += valueCoins;
        textCoin.text = actualCoins.ToString() + "/" + coinsToWin.ToString();

        //win
        if (coinsToWin <= actualCoins)
        {
            gameObjectTextWin.SetActive(true);
            textWinCoinsReward.text = dataLevel.coinsToReward.ToString();
            IWIN.Invoke();
            ControlMusic.Instance.changeMusicWin();
        }
    }

    public void AugmentLifePlayer(int valueToChangeLife) {
        destroyShip.augmentLife(valueToChangeLife);
    }

    public void newErrorByPlayer() {
        maxErrorsByPlayer--;
        sliderErrorsLife.value = maxErrorsByPlayer;

        if (maxErrorsByPlayer <= 0) {
            destroyShip.LoseLevel();
            print("perder");
        }
    }
}
