using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Credits() {
        SceneManager.LoadScene(1);
    }

    public void sceneMenu() {
        CycleLifePlayer.cycleLifePlayer.changeMusicPrincipalMenu();
        SceneManager.LoadScene(0);
    }

    public void loadSceneByNumber(int numberScene) {
        if (numberScene == 0)
        {
            sceneMenu();
        }
        else
        {
            changeMusicThemeByChangeScene();
            SceneManager.LoadScene(numberScene);

        }
    }

    public void loadNextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void changeMusicThemeByChangeScene() {
        CycleLifePlayer.cycleLifePlayer.changeMusicThemeMenu();
    }
}
