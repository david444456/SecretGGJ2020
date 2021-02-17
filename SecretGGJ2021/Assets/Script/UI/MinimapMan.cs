using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MinimapMan : MonoBehaviour
{

    [SerializeField] UnityEvent unityEventReturntoGame;
    [SerializeField] FollowPlayer followPlayer;
    [SerializeField] GameObject PlayerGameObject;
    [SerializeField] float orthographicSizeMainCamera = 20f;
    [SerializeField] float orthographicDrawMainCamera = 15f;

    public Draw_ DrawScript;

    float TiempoTesoro = 0;
    float TiempoDibujando = 0;

    public GameObject MiniMap;
    public Camera MainCamara;
    public GameObject CameraAssit;

    public Vector3 Tesoro;
    public Vector3 MapPosition;
    public Vector3 StartingGame;

    [Header("UI")]
    [SerializeField] GameObject backGroundTextAyuda;
    [SerializeField] Text textAyuda;

    float orthographicDefaultCamera = 0;

    // Start is called before the first frame update
    void Start()
    {
        TiempoTesoro= GameManager.gameManager.dataLevel.maxTimeSeeTreasure;
        TiempoDibujando = GameManager.gameManager.dataLevel.maxTimeDraw;


        orthographicDefaultCamera = MainCamara.orthographicSize;
        StartCoroutine("MostrarTesoro");
    }

    void SeeTheMapInBig() {
        //mirar el mapa en grande
        DrawScript.enabled = false;
        PlayerGameObject.SetActive(false);

        //change text help
        textAyuda.text = GameManager.gameManager.dataLanguages.DrawTextInformation[0];

        //la distancia que mira la camara
        MainCamara.orthographicSize = orthographicSizeMainCamera;

        //change position camera
        MainCamara.transform.position = Tesoro;
    }

    void DrawInTheMap() {
        //Tiempo dibujando en el mapa//
        textAyuda.text = GameManager.gameManager.dataLanguages.DrawTextInformation[1]; //text help
        CameraAssit.SetActive(true);
        MainCamara.gameObject.SetActive(false);

        //change position camera
        MainCamara.transform.position = MapPosition;
        DrawScript.enabled = true;
    }

    void returnTheNormalGame() {
        //vuelvo a jugar
        CameraAssit.SetActive(false);
        MainCamara.gameObject.SetActive(true);

        MainCamara.orthographicSize = orthographicDefaultCamera;//default size
        DrawScript.enabled = false;
        MiniMap.SetActive(true);
        MainCamara.transform.position = StartingGame;

        //active player

        followPlayer.enabled = true;
        PlayerGameObject.SetActive(true);
        unityEventReturntoGame.Invoke();

        //ultimo text
        textAyuda.text = GameManager.gameManager.dataLanguages.DrawTextInformation[2]; 
    }

    public IEnumerator MostrarTesoro()
    {
        
        SeeTheMapInBig();
        yield return new WaitForSeconds(TiempoTesoro); //Tiempo mirando el mapa grande//


        DrawInTheMap();
        yield return new WaitForSeconds(TiempoDibujando);


        returnTheNormalGame();

        //timw wait for new text help
        yield return new WaitForSeconds(2);
        backGroundTextAyuda.SetActive(false);
    }
}
