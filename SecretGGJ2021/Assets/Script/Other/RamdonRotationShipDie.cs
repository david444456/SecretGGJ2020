using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamdonRotationShipDie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(new Vector3(0, 0, Random.Range(0,180)));
    }
}
