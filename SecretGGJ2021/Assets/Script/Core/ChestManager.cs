using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ship;

public class ChestManager : MonoBehaviour
{
    [SerializeField] int maxValueRandomValueCoin = 0;
    [SerializeField] ParticleSystem particleSystemCoin;

    Animator animator;
    bool reclaimedChest;

    private UnityEngine.Object chestRef;

    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        startPos = transform.position;
        chestRef = Resources.Load("Chest");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !reclaimedChest && !collision.GetComponent<DestroyShip>().Dead)
        {
            //un valor aleatorio entre el minimo del game manager y el maximo dado en el cofre
            GameManager.gameManager.AugmentValueCoins(Random.Range(GameManager.gameManager.GetMinimunValueOfRandomCoin(), maxValueRandomValueCoin));

            //generar un efecto de particulas al agarrar el cofre
            particleSystemCoin.Play();
            GetComponent<RandomSound>().changeSoundRandom();
            reclaimedChest = true;

            animator.SetBool("Die", true);

        }

        if (collision.CompareTag("Island"))
        {
            Respawn();
            Destroy(gameObject);
        }
        /*else if (collision.CompareTag("Player"))
        {
            Respawn();
            Destroy(gameObject);
        }*/
    }

    void Respawn()
    {
        GameObject newChest = (GameObject)Instantiate(chestRef);
        newChest.transform.position = new Vector3(UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(0, 10));
    }
}
