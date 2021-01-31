using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTesoros : MonoBehaviour
{
    public GameObject[] TesorosGO;
 // public Vector3[] LugaresParaTesoros;
    public Transform[] LugarTesoros;
    
    int Rand;
    int GORand;

    public int CantidadDeTesoros; //Cuantos tesoros queremos en el mapa//

    List<int> list = new List<int>();

    public bool start; //Starteado manual//


    public void SpawnearTesoros()
    {
        for(int j=0; j < CantidadDeTesoros; j++)
        {
            GORand = Random.Range(0, TesorosGO.Length);
            Rand = Random.Range(0, LugarTesoros.Length);
            while (list.Contains(Rand))
            {
                Rand = Random.Range(0, LugarTesoros.Length);
            }
            list[j] = Rand;

            print("Spawn Tesoro numero " + GORand + " en pos numero " + list[j]);
            Instantiate(TesorosGO[GORand], LugarTesoros[Rand].position, LugarTesoros[Rand].rotation);
        }
    }





    // Start is called before the first frame update
    void Start()
    {
        list = new List<int>(new int[CantidadDeTesoros]);

    }

    // Update is called once per frame
    void Update()
    {
        if (start == true)
        {
            SpawnearTesoros();
            start = false;
        }   
    }
}
