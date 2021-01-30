using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof( Rigidbody2D))]
public class PlayerMovementShip : MonoBehaviour
{
    [SerializeField] float velocityForwardShip = 5;
    [SerializeField] float rotateVelocityShip = 0.5f;

    Rigidbody2D rb2D;
    Vector2 force;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //move
        if (Input.GetKey(KeyCode.W)) {

            force = transform.up * velocityForwardShip * Time.deltaTime;
            rb2D.angularVelocity = 0;

            rb2D.velocity += force;


        } else if (Input.GetKey(KeyCode.S)) {
            Vector2 forceNegative = transform.up;
            rb2D.AddForce(-forceNegative);
        }

        //rotate
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0, rotateVelocityShip));
        } else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 0, -rotateVelocityShip));
        }

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
}
