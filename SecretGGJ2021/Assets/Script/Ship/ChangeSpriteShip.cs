using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteShip : MonoBehaviour
{

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = ControlSpriteShip.Instance.GetSpriteShip();
    }


}
