using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo3D : MonoBehaviour
{
    public int costItem = 10;
    public bool IsOnlyRewarded = false;
    public Sprite spriteActualIbObject;

    private void Awake()
    {
        spriteActualIbObject = GetComponent<SpriteRenderer>().sprite;
    }
}
