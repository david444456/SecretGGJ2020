using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    int points;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bomb"))
        {
            Destroy(gameObject);
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
