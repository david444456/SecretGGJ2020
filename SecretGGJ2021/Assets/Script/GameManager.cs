using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Ship
{
    public class GameManager : MonoBehaviour
    {
        public UnityEvent IWIN;

        public static GameManager gameManager;

        [SerializeField] int minimumValueCoins;
        [SerializeField] int coinsToWin = 20000;

        [Header("UI")]
        [SerializeField] Text textCoin;
        [SerializeField] GameObject gameObjectTextWin;
        [SerializeField] Text textWin;

        private int actualCoins = 0;

        

        void Start()
        {
            gameManager = this;
        }

        public int GetMinimunValueOfRandomCoin() {
            return minimumValueCoins;
        }

        public void AugmentValueCoins(int valueCoins) {
            actualCoins += valueCoins;
            textCoin.text = actualCoins.ToString();

            //win
            if (coinsToWin < actualCoins) {
                gameObjectTextWin.SetActive(true);
                IWIN.Invoke();
            }
        }

        public void Restart() {
            SceneManager.LoadScene(1);
        }
    }
}
