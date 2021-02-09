using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Info", menuName = "Exercise/ New exercise information", order = 0)]
public class InfoExercises : ScriptableObject
{
    [SerializeField] public DataExercises Data;
    [SerializeField] public typeExercise typeExercise;

    public int solutionActualProblemExercise(int firstValue, int secondValue, int finalValue,int index) {
        switch (typeExercise)
        {
            case typeExercise.sum:
                switch (index)
                {
                    case 0:
                        return finalValue - secondValue;
                    case 1:
                        return finalValue - firstValue;
                    case 2:
                        return firstValue + secondValue;
                }
                break;
            case typeExercise.rest:
                switch (index)
                {
                    case 0:
                        return finalValue + secondValue;
                    case 1:
                        return -finalValue + firstValue;
                    case 2:
                        return firstValue - secondValue;
                }
                break;
            default:
                return 0;
        }
        return 0;
    }
}

[System.Serializable]
public class DataExercises
{
    [Header("Win or lose")]
    public string[] textAfterWin;
    public string[] textAfterLose;

    [Header("Input")]
    public string[] newProblemStringFirst;
    public string[] newProblemStringSecond;
    public string[] textInfoUIExercisesFirst;
    public string[] textInfoUIExercisesSecond;
    public string[] textInfoUIExercisesThird;
}
