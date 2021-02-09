using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] bool activeScriptStartGame = true;
    [SerializeField] bool oneUsedForLevel = false;
    [SerializeField] GameObject[] gameObjectsTutorial;
    [SerializeField] float[] timeWaitBetweenGOTuto;

    bool IsUsed = false;
    int indexGOTuto = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (oneUsedForLevel && IsUsed) return;

       if (activeScriptStartGame)  stopTimeAndShowTutorial();
        else StartCoroutine(activeNextTutorialGameObject());
    }

    public void ContinueTimeAndGame() {
        Time.timeScale = 1;
        gameObjectsTutorial[indexGOTuto].SetActive(false);
        indexGOTuto++;

        StartCoroutine(activeNextTutorialGameObject());
    }

    IEnumerator activeNextTutorialGameObject() {
        if (gameObjectsTutorial.Length - 1 < indexGOTuto) {
            IsUsed = true;
            yield break;
            
        }
        yield return new WaitForSeconds(timeWaitBetweenGOTuto[indexGOTuto]);
        stopTimeAndShowTutorial();
    }

    void stopTimeAndShowTutorial() {
        gameObjectsTutorial[indexGOTuto].SetActive(true);
        Time.timeScale = 0;
    }
}
