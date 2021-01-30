using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ship;

public class ChestManager : MonoBehaviour
{
    [SerializeField] int maxValueRandomValueCoin = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D  (Collider2D other)
    {
        if (other.tag == "Player") {
            //un valor aleatorio entre el minimo del game manager y el maximo dado en el cofre
            GameManager.gameManager.AugmentValueCoins(Random.Range(GameManager.gameManager.GetMinimunValueOfRandomCoin(), maxValueRandomValueCoin));

            //generar un efecto de particulas al agarrar el cofre

            Destroy(gameObject, 0.5f);
        }
    }
}
