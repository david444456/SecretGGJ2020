using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlLevelData : SingletonInInspector<ControlLevelData>
{
    public int levelActual = 0;
    public DataLanguages dataLanguages;

    [Header("Data, Languages")]
    [HideInInspector] public DataGeneralLevels dataGeneralLevels;
    [SerializeField] DataLanguages spanishData;
    [SerializeField] DataLanguages englishData;

    public override void Awake()
    {
        base.Awake();

        //save
        levelActual = PlayerPrefs.GetInt("Level");
        print(levelActual);
    }

    // Start is called before the first frame update
    void Start()
    {
        //languages
        string lang = GameMultiLang.Instance.GetLang();
        changeDataLanguages(lang);
    }


#if UNITY_ANDROID
    private void OnApplicationPause(bool newBoolApp)
    {
        PlayerPrefs.SetInt("Level", levelActual);
    }
#endif

#if UNITY_EDITOR || UNITY_STANDALONE_WIN
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Level", levelActual);
    }
#endif

    public void newLanguages(string newLanguagesString)
    {
        changeDataLanguages(newLanguagesString);
        print(newLanguagesString);
    }

    public void conditionWinLevelSaveData()
    {
        if (levelActual < (SceneManager.GetActiveScene().buildIndex - 1))
        {
            levelActual = SceneManager.GetActiveScene().buildIndex - 1;
        }

        CycleLifePlayer.cycleLifePlayer.rateAppNewCount();
    }

    private void changeDataLanguages(string lang)
    {
        if (lang == "en")
        {
            dataLanguages = englishData;
        }
        else if (lang == "sp")
        {
            dataLanguages = spanishData;
        }
    }
}
