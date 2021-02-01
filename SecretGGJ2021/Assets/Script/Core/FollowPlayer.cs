using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform tranformPlayerShip;

    // Update is called once per frame
    void Update()
    {
        if(tranformPlayerShip != null)
         transform.position = new Vector3 (tranformPlayerShip.position.x, tranformPlayerShip.position.y, transform.position.z);
    }
}
