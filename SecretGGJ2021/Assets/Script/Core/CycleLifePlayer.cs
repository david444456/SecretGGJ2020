using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class CycleLifePlayer : MonoBehaviour
{
    
    public static CycleLifePlayer cycleLifePlayer;
    public int levelActual = 0;
    public DataLanguages dataLanguages;

    [SerializeField] float limitShipDie = 8f;
    [SerializeField] GameObject[] shipGODie;
    [SerializeField] GameObject chestPrefab;

    [Header("Audio")]
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioClip audioClipWin;
    [SerializeField] AudioClip audioClipMenu;


    [Header("Languages")]
    [SerializeField] DataLanguages spanishData;
    [SerializeField] DataLanguages englishData;

    AudioSource audioSource;
    List<Vector2> positionsDiePlayer = new List<Vector2>();

    

    private void Awake()
    {
        if (cycleLifePlayer == null)
        {
            cycleLifePlayer = this;
        }
        else Destroy(gameObject);

        //save
        levelActual = PlayerPrefs.GetInt("Level");
        print(levelActual);
    }

    // Start is called before the first frame update
    void Start()
    {
        //audio
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);

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

    public void newPositionDiePlayer(Vector2 NewgameObject) {
        if (limitShipDie > positionsDiePlayer.Count)
        {
            positionsDiePlayer.Add(NewgameObject);
        }
        else {
            positionsDiePlayer[UnityEngine.Random.Range(0, positionsDiePlayer.Count)] = NewgameObject;
        }
        
    }

    public void GenerateAllShipDie() {
        for (int i = 0; i < positionsDiePlayer.Count && i<shipGODie.Length; i++) {
            shipGODie[i].transform.position = positionsDiePlayer[i];
            shipGODie[i].SetActive(true);
        }
        if(positionsDiePlayer.Count > 0)
             Instantiate(chestPrefab, new Vector3(positionsDiePlayer[UnityEngine.Random.Range(0, positionsDiePlayer.Count)].x,
                         positionsDiePlayer[UnityEngine.Random.Range(0, positionsDiePlayer.Count)].y, 0), Quaternion.identity);
    }

    public void newLanguages(string newLanguagesString) {
        changeDataLanguages(newLanguagesString);
        print(newLanguagesString);
    }



    //music and sounds
    public void changeMusicPrincipalMenu() {
        audioSource.Stop();
        audioSource.clip = audioClipMenu;
        audioSource.Play();
    }

    public void changeMusicThemeMenu() {
        //game
        for (int i = 0; i < shipGODie.Length; i++)
        {
            shipGODie[i].SetActive(false);
        }


        //music
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void changeMusicWin() {
        if (levelActual < (SceneManager.GetActiveScene().buildIndex - 1)) {
            levelActual = SceneManager.GetActiveScene().buildIndex - 1;
        }

        audioSource.clip = audioClipWin;
        audioSource.Play();
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
