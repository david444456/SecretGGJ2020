using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyJoystick;

[RequireComponent(typeof( Rigidbody2D))]
public class PlayerMovementShip : MonoBehaviour
{
    [SerializeField] float velocityForwardShip = 5;
    [SerializeField] float rotateVelocityShip = 0.5f;
    [SerializeField] float oppositeForceOfWater = 5;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject CanvasGameObject; //health, options and more

    [Header("Input")]
    [SerializeField] Joystick joystick;
    [SerializeField] bool moveWithArrow;
    [SerializeField] float minimunValueMoveWithJoystick = .3f; 

    Rigidbody2D rb2D;
    Vector2 force;
    bool cantMove = false;
    bool inputRotationBool = false;
    RectTransform rectTransformInput;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rectTransformInput = joystick.GetComponent<RectTransform>();


        CanvasGameObject.SetActive(true);

        //load 
        float newValueRotation = PlayerPrefs.GetFloat("Rotation");
        if (newValueRotation != 0) rotateVelocityShip = newValueRotation;

        //GENERATE
        CycleLifePlayer.cycleLifePlayer.GenerateAllShipDie();
    }

    void Update()
    {
        //stop
        float velocityStop = Time.deltaTime * oppositeForceOfWater;

        bool betweenValuesInputJoystick = joystick.Vertical() < minimunValueMoveWithJoystick && joystick.Vertical() > -minimunValueMoveWithJoystick;

        if (rb2D.velocity.x > 0 && betweenValuesInputJoystick)
        {
            rb2D.velocity += new Vector2(-velocityStop, 0);
        }
        else if (rb2D.velocity.x < 0 && betweenValuesInputJoystick)
        {
            rb2D.velocity += new Vector2(velocityStop, 0);
        }

        if (rb2D.velocity.y > 0 && betweenValuesInputJoystick)
        {
            rb2D.velocity += new Vector2(0,-velocityStop);
        } else if (rb2D.velocity.y < 0 && betweenValuesInputJoystick)
        {
            rb2D.velocity += new Vector2(0, velocityStop);
        }

    }

    private void FixedUpdate()
    {
        if (cantMove) return;

        //move
        if (Input.GetKey(KeyCode.W) || joystick.Vertical() > minimunValueMoveWithJoystick)
        {
            force = transform.up * velocityForwardShip * Time.deltaTime;
            rb2D.angularVelocity = 0;

            rb2D.velocity += force;
            audioSource.volume = 0.8f;

        }
        else if (Input.GetKey(KeyCode.S) || joystick.Vertical() < -minimunValueMoveWithJoystick)
        {
            Vector2 forceNegative = transform.up;
            rb2D.AddForce(-forceNegative);
        }

        //rotate
        if (Input.GetKey(KeyCode.D) || joystick.Horizontal() > minimunValueMoveWithJoystick)
        {
            transform.Rotate(new Vector3(0, 0, -rotateVelocityShip));
            if(inputRotationBool) rectTransformInput.rotation = transform.rotation;
        }
        else if (Input.GetKey(KeyCode.A) || joystick.Horizontal() < -minimunValueMoveWithJoystick)
        {
            transform.Rotate(new Vector3(0, 0, rotateVelocityShip));
            if (inputRotationBool) rectTransformInput.rotation = transform.rotation;
        }

        //volume
        if (audioSource.volume > 0)
        {
            audioSource.volume -= 0.1f;
        }

    }

    public void changeInputRotatiosn(bool newbool ) {
        if(rectTransformInput != null) rectTransformInput.rotation = Quaternion.Euler(0,0,0);
        inputRotationBool = newbool;
    }

    public void changeMove() {
        cantMove = true;
    }

    public void changeValueRotation(float newValueRotate) {
        rotateVelocityShip = newValueRotate;
        PlayerPrefs.SetFloat("Rotation", rotateVelocityShip);
    }

    public float GetValueRotation() {
        return rotateVelocityShip;
    }
}
