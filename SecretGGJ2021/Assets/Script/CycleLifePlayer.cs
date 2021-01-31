using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CycleLifePlayer : MonoBehaviour
{
    
    public static CycleLifePlayer cycleLifePlayer;

    [SerializeField] float limitShipDie = 8f;
    [SerializeField] GameObject shipPrefabDie;
    [SerializeField] GameObject chestPrefab;
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioClip audioClipWin;

    List<Vector2> positionsDiePlayer = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        cycleLifePlayer = this;
        DontDestroyOnLoad(gameObject);
    }

    public void newPositionDiePlayer(Vector2 NewgameObject) {
        if (limitShipDie > positionsDiePlayer.Count)
        {
            positionsDiePlayer.Add(NewgameObject);
        }
        else {
            positionsDiePlayer[UnityEngine.Random.Range(0, positionsDiePlayer.Count)] = NewgameObject;
        }
        
    }

    public void GenerateAllShipDie() {
        for (int i = 0; i < positionsDiePlayer.Count; i++) {
            Instantiate(shipPrefabDie, new Vector3(positionsDiePlayer[i].x, positionsDiePlayer[i].y, 0), Quaternion.identity);
        }
        if(positionsDiePlayer.Count > 0)
             Instantiate(chestPrefab, new Vector3(positionsDiePlayer[UnityEngine.Random.Range(0, positionsDiePlayer.Count)].x,
                         positionsDiePlayer[UnityEngine.Random.Range(0, positionsDiePlayer.Count)].y, 0), Quaternion.identity);
    }

    public void changeMusicThemeMenu() {
        GetComponent<AudioSource>().clip = audioClip;
        GetComponent<AudioSource>().Play();
    }

    public void changeMusicWin() {
        GetComponent<AudioSource>().clip = audioClipWin;
        GetComponent<AudioSource>().Play();
    }
}
