using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    public UnityEvent IWIN;
    public static GameManager gameManager;
    public DataLevels dataLevel;
    public DataLanguages dataLanguages;

    [HideInInspector] public int valueToAddAfterExercise = 0;
    [HideInInspector] public int maxValueHealthShip;

    public GameObject playerShip;
    [SerializeField] DestroyShip destroyShip;
    
    [SerializeField] int maxErrorsByPlayer = 5;

    [Header("Exercises")]
    [SerializeField] ExerciseMath[] exerciseSum;

    [Header("UI")]
    [SerializeField] Text textCoin;
    [SerializeField] GameObject gameObjectTextWin;
    [SerializeField] Text textWin;
    [SerializeField] ActiveUIExercises activeUIExercisesScript;
    [SerializeField] Slider sliderErrorsLife = null;

    private int minimumValueCoins;
    private int coinsToWin = 20000;
    private int actualCoins = 0;

    private void Awake()
    {
        gameManager = this;

        if (CycleLifePlayer.cycleLifePlayer != null)
            dataLanguages = CycleLifePlayer.cycleLifePlayer.dataLanguages;
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
            IWIN.Invoke();
            CycleLifePlayer.cycleLifePlayer.changeMusicWin();
        }
    }

    public void AugmentLifePlayer(int valueToChangeLife) {
        destroyShip.augmentLife(valueToChangeLife);
    }

    //exercises
    public void activeExercisesSum(int valueIncrementCoins) {
        exerciseSum[0].ActiveNewMathProblem(actualCoins, valueIncrementCoins, actualCoins + valueIncrementCoins);

        Time.timeScale = 0;

    }

    public void activeExercisesRest(int valueIncrementLife) {
        int actualValueRepairShip = -destroyShip.healthShip + maxValueHealthShip;
        exerciseSum[1].ActiveNewMathProblem(actualValueRepairShip, valueIncrementLife, actualValueRepairShip - valueIncrementLife);

        Time.timeScale = 0;
    }

    public void returnTheNormalTime()
    {
        Time.timeScale = 1;
    }

    public void newErrorByPlayer() {
        maxErrorsByPlayer--;
        sliderErrorsLife.value = maxErrorsByPlayer;

        if (maxErrorsByPlayer <= 0) {
            destroyShip.LoseLevel();
            print("perder");
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
