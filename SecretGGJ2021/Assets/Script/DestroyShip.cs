using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShip : MonoBehaviour
{
    public bool Dead = false;

    [SerializeField] GameObject UIRestart;
    [SerializeField] ParticleSystem particleSystemDead;
    [SerializeField] ParticleSystem particleSystemWater;
    [SerializeField] ParticleSystem particleSystemFire;
    [SerializeField] AudioSource audioSource;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.tag == "Enemy" || other.gameObject.tag == "Build") && !Dead)
        {
            Dead = true;

            particleSystemDead.Play();

            //elegir random un efecto de sonido
            GetComponent<RandomSound>().changeSoundRandom();

            StartCoroutine(FinishLevelDie());

            CycleLifePlayer.cycleLifePlayer.newPositionDiePlayer(transform.position);

            GetComponent<Animator>().SetBool("Die", true);
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
