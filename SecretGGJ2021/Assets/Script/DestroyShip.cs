using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyShip : MonoBehaviour
{
    public bool Dead = false;

    public int healthShip = 100;

    [SerializeField] int valueHit = 30;
    [SerializeField] GameObject UIRestart;
    [SerializeField] ParticleSystem particleSystemDead;
    [SerializeField] ParticleSystem particleSystemWater;
    [SerializeField] ParticleSystem particleSystemFire;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioHit;
    [SerializeField] Slider sliderHealth;

    float lastTime = 0;

    private void Start()
    {
        sliderHealth.maxValue = healthShip;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.tag == "Enemy" || other.gameObject.tag == "Build") && !Dead && healthShip > 0 && lastTime < (Time.time-2.2f))
        {
            lastTime = Time.time;
            healthShip -= valueHit;

            sliderHealth.value = healthShip;

            if (healthShip <= 0)
            {
                Dead = true;

                particleSystemDead.Play();

                //elegir random un efecto de sonido
                GetComponent<RandomSound>().changeSoundRandom();

                StartCoroutine(FinishLevelDie());

                CycleLifePlayer.cycleLifePlayer.newPositionDiePlayer(transform.position);

                GetComponent<Animator>().SetBool("Die", true);
            }
            else {
                //audio hit
                audioSource.clip = audioHit;
                audioSource.Play();
            }
        }
    }

    IEnumerator FinishLevelDie() {
        yield return new WaitForSeconds(0.3f);
        UIRestart.SetActive(true);

        particleSystemFire.Play();
        particleSystemWater.Stop();

        //change 
        GetComponent<PlayerMovementShip>().changeMove();
        GetComponent<Rigidbody2D>().angularVelocity = 0;
    }
}
