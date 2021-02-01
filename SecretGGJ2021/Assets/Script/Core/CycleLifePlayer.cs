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

    AudioSource audioSource;
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
        audioSource = GetComponent<AudioSource>();
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
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void changeMusicWin() {
        audioSource.clip = audioClipWin;
        audioSource.Play();
    }
}
