using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShip : MonoBehaviour
{

    [SerializeField] ParticleSystem particleSystemDead;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Build")
        {
            particleSystemDead.Play();
            Destroy(gameObject, 0.3f);
        }
    }
}
