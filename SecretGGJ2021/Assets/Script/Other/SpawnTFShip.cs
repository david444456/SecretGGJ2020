using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTFShip : MonoBehaviour
{
    public GameObject Barco;
    public Transform[] LugarSpawneo;

    int Rand;

    public bool TrigManual = false;

    private void Start()
    {
        SpawnBarco();
    }

    public void SpawnBarco()
    {
        Rand = Random.Range(0, LugarSpawneo.Length);
        Barco.transform.position = LugarSpawneo[Rand].position;
    }
}
