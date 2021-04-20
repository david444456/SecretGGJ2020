using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSpriteShip : SingletonInInspector<ControlSpriteShip>
{
    [SerializeField] Sprite spriteShip;

    void Start()
    {
        //load?
    }

    public void SetSpriteShip(Sprite NewSpriteShip) {
        spriteShip = NewSpriteShip;
    }

    public Sprite GetSpriteShip() {
        return spriteShip;
    }
}
