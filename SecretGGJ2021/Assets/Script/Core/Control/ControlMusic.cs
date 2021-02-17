using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMusic : SingletonInInspector<ControlMusic>
{
    [Header("Audio")]
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioClip audioClipWin;
    [SerializeField] AudioClip audioClipMenu;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //audio
        audioSource = GetComponent<AudioSource>();
    }

    //music and sounds
    public void changeMusicPrincipalMenu()
    {
        audioSource.Stop();
        audioSource.clip = audioClipMenu;
        audioSource.Play();
    }

    public void changeMusicThemeMenu()
    {
        //desactive ship, in game
        CycleLifePlayer.cycleLifePlayer.desactiveAllShips();

        //music
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void changeMusicWin()
    {
        ControlLevelData.Instance.conditionWinLevelSaveData();

        //music
        audioSource.clip = audioClipWin;
        audioSource.Play();
    }
}
