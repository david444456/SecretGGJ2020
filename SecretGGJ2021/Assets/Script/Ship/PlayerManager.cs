using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    int points;

    //[SerializeField]
    //private UnityEngine.Object explosionRef;

    public GameObject explosion;

    void Start()
    {
        //explosionRef = Resources.Load("Explosion");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bomb"))
        {
            GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
            Destroy(expl, 3);
        }
        else if (collision.CompareTag("Island"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Chest"))
        {
            points++;
        }
    }
}
