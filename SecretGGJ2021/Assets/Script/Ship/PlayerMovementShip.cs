using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof( Rigidbody2D))]
public class PlayerMovementShip : MonoBehaviour
{
    [SerializeField] float velocityForwardShip = 5;
    [SerializeField] float rotateVelocityShip = 0.5f;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject CanvasGameObject; //health, options and more

    Rigidbody2D rb2D;
    Vector2 force;
    bool cantMove = false;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        CycleLifePlayer.cycleLifePlayer.GenerateAllShipDie();

        CanvasGameObject.SetActive(true);
    }

    void Update()
    {
        //stop
        float velocityStop = Time.deltaTime * (velocityForwardShip / 10);

        if (rb2D.velocity.x > 0)
        {
            rb2D.velocity += new Vector2(-velocityStop, 0);
        }
        else if (rb2D.velocity.x < 0)
        {
            rb2D.velocity += new Vector2(velocityStop, 0);
        }

        if (rb2D.velocity.y > 0)
        {
            rb2D.velocity += new Vector2(0,-velocityStop);
        } else if (rb2D.velocity.y < 0)
        {
            rb2D.velocity += new Vector2(0, velocityStop);
        }

    }

    private void FixedUpdate()
    {
        if (cantMove) return;
        //move
        if (Input.GetKey(KeyCode.W))
        {
            force = transform.up * velocityForwardShip * Time.deltaTime;
            rb2D.angularVelocity = 0;

            rb2D.velocity += force;
            audioSource.volume = 0.8f;

        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector2 forceNegative = transform.up;
            rb2D.AddForce(-forceNegative);
        }

        //rotate
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0, rotateVelocityShip));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 0, -rotateVelocityShip));
        }

        //volume
        if (audioSource.volume > 0)
        {
            audioSource.volume -= 0.1f;
        }
    }

    public void changeMove() {
        cantMove = true;
    }

    public void changeValueRotation(float newValueRotate) {
        rotateVelocityShip = newValueRotate;
    }
}
