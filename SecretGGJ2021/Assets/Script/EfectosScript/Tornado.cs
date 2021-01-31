using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    [SerializeField] float rotatePlayer;
    [SerializeField] float velocityChangePlayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !other.GetComponent<DestroyShip>().Dead) {
            other.transform.Rotate(new Vector3(0,0, Random.Range(45, rotatePlayer)));
            velocityChangePlayer = Random.Range(velocityChangePlayer / 5, velocityChangePlayer * 5);
            other.GetComponent<Rigidbody2D>().velocity += new Vector2(velocityChangePlayer, velocityChangePlayer);
        }
    }
}
