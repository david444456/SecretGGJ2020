using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BombManager : MonoBehaviour
{
    [SerializeField] UnityEvent CollisionPlayer;
    [SerializeField] int damagePlayer = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<DestroyShip>().TakeDamage(damagePlayer);
            CollisionPlayer.Invoke();
        }
    }
}
