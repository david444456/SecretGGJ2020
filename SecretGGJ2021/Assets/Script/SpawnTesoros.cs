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
    List<Transform> listTF = new List<Transform>();

    public bool start; //Starteado manual//

    public void SpawnearTesoros()
    {
        for(int j=0; j < CantidadDeTesoros; j++)
        {
            GORand = Random.Range(0, TesorosGO.Length);
            Rand = Random.Range(0, listTF.Count);

            /*while (list.Contains(Rand))
            {
                Rand = Random.Range(0, LugarTesoros.Length);
            }
            list[j] = Rand;*/

            Instantiate(TesorosGO[GORand], listTF[Rand].position, Quaternion.identity);

            listTF.RemoveAt(Rand);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform tf in LugarTesoros) {
            listTF.Add(tf);
        }

        SpawnearTesoros();

    }
}
