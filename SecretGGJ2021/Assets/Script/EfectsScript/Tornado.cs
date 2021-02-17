using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    [SerializeField] float rotatePlayer;
    [SerializeField] float maxVelocityChangePlayer;
    [SerializeField] RandomSound randomSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !other.GetComponent<DestroyShip>().Dead) {
            //var
            maxVelocityChangePlayer = Random.Range(maxVelocityChangePlayer / 5, maxVelocityChangePlayer);

            //change player
            other.transform.Rotate(new Vector3(0, 0, Random.Range(45, rotatePlayer)));
            other.GetComponent<Rigidbody2D>().velocity += new Vector2(maxVelocityChangePlayer, maxVelocityChangePlayer);

            //sound
            randomSound.changeSoundRandom();
        }
    }
}
