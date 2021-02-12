using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Info", menuName = "Language/ New data language", order = 1)]
public class DataLanguages : ScriptableObject
{
    [Header("Sum, rest, multi, div")]
    [SerializeField] InfoExercises[] infoExercises;
    public string[] DrawTextInformation = null;

    public InfoExercises InfoExercises(typeExercise typeExercise) {
        switch (typeExercise) {
            case typeExercise.sum:
                return infoExercises[0];
            case typeExercise.rest:
                return infoExercises[1];
            default:
                return infoExercises[0];
        }

    }
}

[System.Serializable]
public class TutorialTraslator
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
