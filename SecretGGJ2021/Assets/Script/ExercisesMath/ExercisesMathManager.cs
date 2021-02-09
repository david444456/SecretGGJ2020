using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ExercisesMathManager : MonoBehaviour
{
    [SerializeField] DestroyShip destroyShip;

    [Header("Event")]
    [SerializeField] UnityEvent EventActiveExerciseMath;
    [SerializeField] GameObject[] gameObjectExercisesTypes = null;
    [SerializeField] Text[] textsNumberExercises;

    [Header("UI")]
    [SerializeField] Text textInfoUIExercises = null;
    [SerializeField] Text textInfoFinalResult = null;
    [SerializeField] GameObject gameObjectFinalResultBackGround = null;
    [SerializeField] GameObject textActualCoins = null; //delete in new version

    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clipWin;
    [SerializeField] AudioClip clipLose;

    int indexTypeExercises = 0;
    int solutionActualProblem = 0;
    int solutionActualPlayer = 0;

    int maxHealthPlayer = 0;
    int secondValueExercise = 0;
    typeExercise actualTypeExercise;
    InfoExercises dataExercise;

    private void Start()
    {
        maxHealthPlayer = destroyShip.healthShip;
    }

    public void activeTypeExercise(int newFirstValueHealth, int newSecondValue, int finalValue, InfoExercises infoExercises) {
        //select one type of math ui and desactive other
        foreach (GameObject go in gameObjectExercisesTypes) {
            go.SetActive(false);
        }


        //indextypeexercises is a index for the new type (input location)
        indexTypeExercises = Random.Range(0, gameObjectExercisesTypes.Length);
        gameObjectExercisesTypes[indexTypeExercises].SetActive(true);


        //text exercises
        secondValueExercise = newSecondValue;
        actualTypeExercise = infoExercises.typeExercise;
        dataExercise = infoExercises;

        //event
        EventActiveExerciseMath.Invoke();

        //principal fuction    
        GenerateMathProblem(newFirstValueHealth, finalValue , infoExercises);

    }

    public void checkSolutionActualExercise() {
        gameObjectFinalResultBackGround.SetActive(true);

        if (solutionActualProblem == solutionActualPlayer && actualTypeExercise == typeExercise.sum)
        {
            //audio
            audioSource.PlayOneShot(clipWin);

            //gm
            GameManager.gameManager.AugmentValueCoins(secondValueExercise);

            //ui
            textInfoFinalResult.text = dataExercise.Data.textAfterWin[0];
            print(solutionActualPlayer);
        }
        else if (solutionActualProblem == solutionActualPlayer && actualTypeExercise == typeExercise.rest)
        {
            //audio
            audioSource.PlayOneShot(clipWin);

            //gm //augment life
            GameManager.gameManager.AugmentLifePlayer(secondValueExercise);

            //
            textInfoFinalResult.text = dataExercise.Data.textAfterWin[1];
            print(solutionActualPlayer);
        }
        else {
            int halfPrize = secondValueExercise / 2;

            //audio lose
            audioSource.PlayOneShot(clipLose);

            //prize
            textInfoFinalResult.text = dataExercise.Data.textAfterLose[0] + solutionActualProblem.ToString() + dataExercise.Data.textAfterLose[1] +
                dataExercise.Data.textAfterLose[2] + halfPrize + dataExercise.Data.textAfterLose[3];
            if(actualTypeExercise == typeExercise.sum)
                GameManager.gameManager.AugmentValueCoins(halfPrize);
            else if (actualTypeExercise == typeExercise.rest)
                GameManager.gameManager.AugmentLifePlayer(halfPrize);


            //erros lose
            GameManager.gameManager.newErrorByPlayer();
        }

        //active ui coinsactual
        textActualCoins.SetActive(true);

        StartCoroutine(desactiveBackGroundInfoFinalResult());
    }

    /// <summary>
    /// receive data for input field, only call for this
    /// </summary>
    /// <param name="textField">New input value</param>
    public void reciveStringInputField(string textField)
    {
        solutionActualPlayer = int.Parse(textField);
    }

    void GenerateMathProblem(int firstValue, int finalValue, InfoExercises data)
    {
        string newProblemString = "";

        switch (indexTypeExercises)
        {
            case 0:
                //values problem
                newProblemString = data.Data.newProblemStringFirst[indexTypeExercises] + secondValueExercise +
                                    data.Data.newProblemStringSecond[indexTypeExercises] + finalValue;

                changeDataInUIExercises(firstValue, finalValue, newProblemString, data, secondValueExercise.ToString(), finalValue.ToString());


                //desactive coins actual (no trap)
                textActualCoins.SetActive(false);
                break;
            case 1:
                newProblemString = firstValue + data.Data.newProblemStringFirst[indexTypeExercises] + 
                                    data.Data.newProblemStringSecond[indexTypeExercises] + finalValue;

                changeDataInUIExercises(firstValue, finalValue, newProblemString, data, firstValue.ToString(), finalValue.ToString());

                break;
            case 2:
                newProblemString = firstValue + data.Data.newProblemStringFirst[indexTypeExercises] + 
                                    secondValueExercise + data.Data.newProblemStringSecond[indexTypeExercises];

                changeDataInUIExercises(firstValue, finalValue, newProblemString, data, firstValue.ToString(), secondValueExercise.ToString());

                break;
        }

        print(newProblemString + " " + solutionActualProblem);
    }

    void changeDataInUIExercises(int firstValue, int finalValue, string newProblemString, InfoExercises data, string firstValueInUI, string secondValueInUI) {
        solutionActualProblem = data.solutionActualProblemExercise(firstValue, secondValueExercise, finalValue, indexTypeExercises);

        //UI
        textsNumberExercises[indexTypeExercises].text = newProblemString;
        textInfoUIExercises.text = data.Data.textInfoUIExercisesFirst[indexTypeExercises] + firstValueInUI +
            data.Data.textInfoUIExercisesSecond[indexTypeExercises] + secondValueInUI +
            data.Data.textInfoUIExercisesThird[indexTypeExercises];

    }

    /*
    void GenerateMathSumProblem(int actualValueInGame) {
        string newProblemString = "";

        int sumValueActualCoinsAndAddCoins = secondValueExercise + actualValueInGame;

        switch (indexTypeExercises) {
            case 0:
                //values problem
                newProblemString = "   + " + secondValueExercise + " = " + sumValueActualCoinsAndAddCoins;
                solutionActualProblem = sumValueActualCoinsAndAddCoins - secondValueExercise;
                //ui
                textsNumberExercises[indexTypeExercises].text = newProblemString;
                textInfoUIExercises.text = "SI RECIBÍ " + secondValueExercise + " Y EL RESULTADO ME QUEDA: " + sumValueActualCoinsAndAddCoins +
                    ", ¿CUÁNTAS MONEDAS TENÍA?";

                //desactive coins actual (no trap)
                textActualCoins.SetActive(false);
                break;
            case 1:
                newProblemString = actualValueInGame + " +   " + " = " + sumValueActualCoinsAndAddCoins;
                solutionActualProblem = sumValueActualCoinsAndAddCoins - actualValueInGame;

                //ui
                textsNumberExercises[indexTypeExercises].text = newProblemString;
                textInfoUIExercises.text = "SI TENÍA " + actualValueInGame + " Y EL RESULTADO ME QUEDA: " + sumValueActualCoinsAndAddCoins +
                    ", ¿CUÁNTAS MONEDAS RECIBÍ?";
                break;
            case 2:
                newProblemString = actualValueInGame + " + " + secondValueExercise + " =   ";
                solutionActualProblem =actualValueInGame +secondValueExercise;
                //ui
                textsNumberExercises[indexTypeExercises].text = newProblemString;
                textInfoUIExercises.text = "SI TENÍA " + actualValueInGame + " Y ME DIERON " + secondValueExercise +
                    ", ¿CUÁNTAS MONEDAS VOY A TENER?";
                break;
        }

        print(newProblemString + " " + solutionActualProblem);
    }

    void GenerateMathRestProblem(int actualValueInGame)
    {
        //repair - add = totalvalue
        string newProblemString = "";

        int sumValueActualValueToChangeAndValueInGame = -secondValueExercise + actualValueInGame;

        switch (indexTypeExercises)
        {
            case 0:
                //values problem
                newProblemString = "   - " + secondValueExercise + " = " + sumValueActualValueToChangeAndValueInGame;
                solutionActualProblem = sumValueActualValueToChangeAndValueInGame + secondValueExercise;
                //ui
                textsNumberExercises[indexTypeExercises].text = newProblemString;
                textInfoUIExercises.text = "REPARASTE " + secondValueExercise + " DE DAÑO, ENTONCES QUEDA: " + sumValueActualValueToChangeAndValueInGame +
                    ", ¿CUÁNTO DAÑO TENIA MI BARCO?";

                //desactive coins actual (no trap)
                textActualCoins.SetActive(false);
                break;
            case 1:
                newProblemString = actualValueInGame + " -   " + " = " + sumValueActualValueToChangeAndValueInGame;
                solutionActualProblem = -sumValueActualValueToChangeAndValueInGame + actualValueInGame;

                //ui
                textsNumberExercises[indexTypeExercises].text = newProblemString;
                textInfoUIExercises.text = "SI TENÍA " + actualValueInGame + " DE DAÑO Y LO QUE ME QUEDA REPARAR ES: " 
                    + sumValueActualValueToChangeAndValueInGame + ", ¿CUÁNTO ARREGLE DEL BARCO?";
                break;
            case 2:
                newProblemString = actualValueInGame + " - " + secondValueExercise + " =   ";
                solutionActualProblem = actualValueInGame - secondValueExercise;
                //ui
                textsNumberExercises[indexTypeExercises].text = newProblemString;
                textInfoUIExercises.text = "SI TENÍA " + actualValueInGame + " DE DAÑO Y REPARE " + secondValueExercise +
                    ", ¿CUÁNTO ES LO QUE ME FALTA REPARAR?";
                break;
        }

        print(newProblemString + " " + solutionActualProblem);
    }
    */

    IEnumerator desactiveBackGroundInfoFinalResult() {
        yield return new WaitForSeconds(5);
        gameObjectFinalResultBackGround.SetActive(false);
    }
}
public enum typeExercise {
    sum,
    rest
}

