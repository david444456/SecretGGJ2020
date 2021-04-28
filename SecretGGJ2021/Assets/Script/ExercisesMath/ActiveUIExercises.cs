using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveUIExercises : MonoBehaviour
{
    [SerializeField] GameObject gameObjectUiExercises;

    ExercisesMathManager exercisesMathManager;

    // Start is called before the first frame update
    void Start()
    {
        exercisesMathManager = GetComponent<ExercisesMathManager>();
    }

    public void activeUIexerciseMethod() {
        //exercisesMathManager.activeTypeExercise(addCoins, actualCoins, lifePlayer, typeExercise);
        gameObjectUiExercises.SetActive(true);
    }

    public void ExitUIExercises() {
        gameObjectUiExercises.SetActive(false);

        ControlExerciseShip.Instance.returnTheNormalTime();

        //
        exercisesMathManager.checkSolutionActualExercise();
    }
}
