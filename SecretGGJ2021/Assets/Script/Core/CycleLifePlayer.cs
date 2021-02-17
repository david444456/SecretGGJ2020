using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class CycleLifePlayer : MonoBehaviour
{
    
    public static CycleLifePlayer cycleLifePlayer;

    [SerializeField] float limitShipDie = 8f;
    [SerializeField] GameObject[] shipGODie;
    [SerializeField] GameObject chestPrefab;

    [Space(3)]
    [Header("Rate app")]
    [SerializeField] RateMore rateMore;

    List<Vector2> positionsDiePlayer = new List<Vector2>();

    private void Awake()
    {
        if (cycleLifePlayer == null)
        {
            cycleLifePlayer = this;
        }
        else Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void newPositionDiePlayer(Vector2 NewgameObject) {
        //rate app
        rateMore.NewChangeScene();

        //new position

        if (limitShipDie > positionsDiePlayer.Count)
        {
            positionsDiePlayer.Add(NewgameObject);
        }
        else {
            positionsDiePlayer[UnityEngine.Random.Range(0, positionsDiePlayer.Count)] = NewgameObject;
        } 
    }

    public void GenerateAllShipDie() {
        for (int i = 0; i < positionsDiePlayer.Count && i<shipGODie.Length; i++) {
            shipGODie[i].transform.position = positionsDiePlayer[i];
            shipGODie[i].SetActive(true);
        }
        if(positionsDiePlayer.Count > 0)
             Instantiate(chestPrefab, new Vector3(positionsDiePlayer[UnityEngine.Random.Range(0, positionsDiePlayer.Count)].x,
                         positionsDiePlayer[UnityEngine.Random.Range(0, positionsDiePlayer.Count)].y, 0), Quaternion.identity);
    }

    public void desactiveAllShips() {
        //game
        for (int i = 0; i < shipGODie.Length; i++)
        {
            shipGODie[i].SetActive(false);
        }
    }

    public void rateAppNewCount() {
        //rate
        rateMore.NewChangeScene();
    }
}
