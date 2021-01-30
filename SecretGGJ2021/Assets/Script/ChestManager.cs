using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ship;

public class ChestManager : MonoBehaviour
{
    [SerializeField] int maxValueRandomValueCoin = 0;

    private UnityEngine.Object chestRef;

    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        chestRef = Resources.Load("Chest");
    }

    /* Estaba antes
    private void OnTriggerEnter2D  (Collider2D other)
    {
        if (other.tag == "Player") {
            //un valor aleatorio entre el minimo del game manager y el maximo dado en el cofre
            GameManager.gameManager.AugmentValueCoins(Random.Range(GameManager.gameManager.GetMinimunValueOfRandomCoin(), maxValueRandomValueCoin));

            //generar un efecto de particulas al agarrar el cofre

            Destroy(gameObject, 0.5f);
        }
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Island"))
        {
            Respawn();
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            Respawn();
            Destroy(gameObject);
        }
    }

    void Respawn()
    {
        GameObject newChest = (GameObject)Instantiate(chestRef);
        newChest.transform.position = new Vector3(UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(0, 10));
    }
}
