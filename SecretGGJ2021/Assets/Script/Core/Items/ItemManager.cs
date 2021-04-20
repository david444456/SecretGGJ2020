using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemManager : MonoBehaviour
{
    [SerializeField] public int maxValueRandomIntByItem = 0;
    [SerializeField] ParticleSystem particleSystemItem;

    Animator animator;
    bool IsRecleimed;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !IsRecleimed && !collision.GetComponent<DestroyShip>().Dead)
        {
            int randomValueForExercises = Random.Range(CoinsManager.Instance.GetMinimunValueOfRandomCoin(), maxValueRandomIntByItem);

            playerGetItem(randomValueForExercises, collision.gameObject);
        }
    }

    public virtual void playerGetItem(int randomValue, GameObject playerShip) {
        //generar un efecto de particulas al agarrar el cofre
        if (particleSystemItem != null) particleSystemItem.Play();

        //random sound
        GetComponent<RandomSound>().changeSoundRandom();

        //only one use
        IsRecleimed = true;
        animator.SetBool("Die", true);
    }
}
