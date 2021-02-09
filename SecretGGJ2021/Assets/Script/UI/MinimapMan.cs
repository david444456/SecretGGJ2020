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


    // Start is called before the first frame update
    void Start()
    {
        TiempoTesoro= GameManager.gameManager.dataLevel.maxTimeSeeTreasure;
        TiempoDibujando = GameManager.gameManager.dataLevel.maxTimeDraw;

        StartCoroutine("MostrarTesoro");
    }

    public IEnumerator MostrarTesoro()
    {
        //mirar el mapa en grande
        DrawScript.enabled = false;
        PlayerGameObject.SetActive(false);
        textAyuda.text = GameManager.gameManager.dataLevel.DrawTextInformation[0];

        //la distancia que mira la camara
        float orthographicDefaultCamera = MainCamara.orthographicSize;
        MainCamara.orthographicSize = orthographicSizeMainCamera; 

        //Tiempo mirando el mapa grande//
        MainCamara.transform.position = Tesoro;
        yield return new WaitForSeconds(TiempoTesoro);

        //Tiempo dibujando en el mapa//
        textAyuda.text = GameManager.gameManager.dataLevel.DrawTextInformation[1];
        CameraAssit.SetActive(true);
        MainCamara.gameObject.SetActive(false);
        //MainCamara.orthographicSize = orthographicDrawMainCamera; 

        MainCamara.transform.position = MapPosition;
        DrawScript.enabled = true;
        yield return new WaitForSeconds(TiempoDibujando);

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
        textAyuda.text = GameManager.gameManager.dataLevel.DrawTextInformation[2];
        yield return new WaitForSeconds(2);
        backGroundTextAyuda.SetActive(false);
    }
}
