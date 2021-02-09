using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExerciseMath : MonoBehaviour, IExerciseMath
{
    [SerializeField] MyEventActivateMathProblem myEventActivateMathProblem;
    [SerializeField] InfoExercises infoExercises;

    public void ActiveNewMathProblem(int firstValue, int secondValue, int finalValue)
        => myEventActivateMathProblem.Invoke(firstValue, secondValue, finalValue, infoExercises);
}

[System.Serializable]
public class MyEventActivateMathProblem : UnityEvent<int, int, int, InfoExercises> {

}
