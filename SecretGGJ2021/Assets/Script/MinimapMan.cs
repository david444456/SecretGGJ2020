using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapMan : MonoBehaviour
{


    [SerializeField] FollowPlayer followPlayer;
    [SerializeField] GameObject PlayerGameObject;
    [SerializeField] float orthographicSizeMainCamera = 20f;
    [SerializeField] float orthographicDrawMainCamera = 15f;

    public Draw_ DrawScript;

    public float TiempoTesoro;
    public float TiempoDibujando;

    public GameObject MiniMap;
    public Camera MainCamara;

    public Vector3 Tesoro;
    public Vector3 MapPosition;
    public Vector3 StartingGame;

    [Header("UI")]
    [SerializeField] GameObject backGroundTextAyuda;
    [SerializeField] Text textAyuda;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("MostrarTesoro");
    }
    public IEnumerator MostrarTesoro()
    {

        DrawScript.enabled = false;
        PlayerGameObject.SetActive(false);
        textAyuda.text = " Recorda todo rápido!! ";

        //la distancia que mira la camara
        float orthographicDefaultCamera = MainCamara.orthographicSize;
        MainCamara.orthographicSize = orthographicSizeMainCamera; 

        //Tiempo mirando el tesoro//

        MainCamara.transform.position = Tesoro;
        yield return new WaitForSeconds(TiempoTesoro);

        //Tiempo dibujando en el mapa//
        textAyuda.text = " Dibuja todo lo que te acuerdes!! ";
        MainCamara.orthographicSize = orthographicDrawMainCamera; 

        MainCamara.transform.position = MapPosition;
        DrawScript.enabled = true;
        yield return new WaitForSeconds(TiempoDibujando);

        //vuelvo a jugar
        MainCamara.orthographicSize = orthographicDefaultCamera;//default size
        DrawScript.enabled = false;
        MiniMap.SetActive(true);
        MainCamara.transform.position = StartingGame;

        //active player
        
        followPlayer.enabled = true;
        PlayerGameObject.SetActive(true);


        //ultimo text
        textAyuda.text = " Suerte!!!! ";
        yield return new WaitForSeconds(2);
        backGroundTextAyuda.SetActive(false);
    }
}
