using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] GameObject gameObjectProgress;
    [SerializeField] Slider sliderProgress;


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Credits() {
        SceneManager.LoadScene(1);
    }

    public void sceneMenu() {
        ControlMusic.Instance.changeMusicPrincipalMenu();
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
            StartCoroutine(LoadAsyncScene(numberScene));

        }
    }

    public void loadNextScene() {
        changeMusicThemeByChangeScene();
        StartCoroutine(LoadAsyncScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void changeMusicThemeByChangeScene() {
        ControlMusic.Instance.changeMusicThemeMenu();
    }

    IEnumerator LoadAsyncScene(int sceneIndex) {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone) {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            gameObjectProgress.SetActive(true);
            sliderProgress.value = progress;

            yield return null;
        }


    }
}
