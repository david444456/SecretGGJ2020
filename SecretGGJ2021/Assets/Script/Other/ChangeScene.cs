using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Credits() {
        SceneManager.LoadScene(2);
    }

    public void sceneMenu() {
        SceneManager.LoadScene(0);
    }
}
