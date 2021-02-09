using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundNear : MonoBehaviour
{
    public AudioSource RuidoFuego;

    [SerializeField] public GameObject Fuego;
    [HideInInspector] GameObject Barco;

    float DistanciaXY = 0;
    float VariableDeSonido = 0;

    public float EmpiezaElFuego = 15;

    private void Start()
    {
       Barco = FindObjectOfType<PlayerMovementShip>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Barco == null) { Barco = GameManager.gameManager.playerShip;
            return;
        }

        DistanciaXY = Vector3.Distance(Fuego.transform.position, Barco.transform.position);
        VariableDeSonido = (DistanciaXY / EmpiezaElFuego);

        if (DistanciaXY < EmpiezaElFuego)
        {
            RuidoFuego.volume = 1 - VariableDeSonido;
        }
        else
        {
            RuidoFuego.volume = 0;
        }
    }
}
