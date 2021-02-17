using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class SystemMenu : MonoBehaviour
{
    [SerializeField] UnityEvent unityEventILoadScene;
    [SerializeField] GameObject backGroundLevel;
    [SerializeField] Image[] imagesLevels = null;
    [SerializeField] Sprite spriteBackGroundUnlock;
    [SerializeField] ChangeScene changeScene;
    [SerializeField] DataGeneralLevels[] dataGeneralLevels;

    private int valueLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        valueLevel = ControlLevelData.Instance.levelActual;
    }

    public void activeLevelSelectionBackGround(bool boolBackGround) {
        backGroundLevel.SetActive(boolBackGround);

        if (boolBackGround) {
            verifyAllLevelsUnlock();
        }
    }

    public void SetLevelDifficult(int indexGeneralLevel) {
        ControlLevelData.Instance.dataGeneralLevels = dataGeneralLevels[indexGeneralLevel];
    }

    void verifyAllLevelsUnlock() {
        for (int i = 0; i <= valueLevel; i++) {
            imagesLevels[i].sprite = spriteBackGroundUnlock;
        }
    }

    public void LoadLevelParameter(int loadSceneValue) {
        if (loadSceneValue <= valueLevel) {
            unityEventILoadScene.Invoke();
            changeScene.loadSceneByNumber(loadSceneValue+2);
            print("load level");
        }
    }
}
