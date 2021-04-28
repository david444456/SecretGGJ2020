using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlExerciseShip : SingletonInInspector<ControlExerciseShip>
{
    [Header("Exercises")]
    [SerializeField] ExerciseMath[] exerciseSum;

    [SerializeField] DestroyShip destroyShip;

    private int actualCoins = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //exercises
    public void activeExercisesSum(int valueIncrementCoins)
    {
        actualCoins = CoinsManager.Instance.actualCoinsMethod();

        exerciseSum[0].ActiveNewMathProblem(actualCoins, valueIncrementCoins, actualCoins + valueIncrementCoins);

        Time.timeScale = 0;

    }

    public void activeExercisesRest(int valueIncrementLife)
    {
        int actualValueRepairShip = -destroyShip.healthShip + CoinsManager.Instance.maxValueHealthShip;
        exerciseSum[1].ActiveNewMathProblem(actualValueRepairShip, valueIncrementLife, actualValueRepairShip - valueIncrementLife);

        Time.timeScale = 0;
    }

    public void returnTheNormalTime()
    {
        Time.timeScale = 1;
    }
}
