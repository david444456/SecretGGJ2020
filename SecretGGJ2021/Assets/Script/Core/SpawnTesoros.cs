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

    List<GameObject> listTreasures = new List<GameObject>();
    List<Transform> listTF = new List<Transform>();

    public bool start; //Starteado manual//

    public void SpawnearTesoros()
    {
        for(int j=0; j < CantidadDeTesoros; j++)
        {
            GORand = Random.Range(0, listTreasures.Count);
            Rand = Random.Range(0, listTF.Count);

            /*while (list.Contains(Rand))
            {
                Rand = Random.Range(0, LugarTesoros.Length);
            }
            list[j] = Rand;*/

            listTreasures[GORand].transform.position = listTF[Rand].position;

            listTF.RemoveAt(Rand);
            listTreasures.RemoveAt(GORand);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform tf in LugarTesoros) {
            listTF.Add(tf);
        }

        foreach (GameObject treasure in TesorosGO)
        {
            listTreasures.Add(treasure);
        }
        

        SpawnearTesoros();

    }
}
