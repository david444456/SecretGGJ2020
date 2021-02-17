using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RandomSound))]
public class SoundGruntTime : MonoBehaviour
{
    [SerializeField] float timeRepeatGrunt = 12;

    RandomSound randomSound;

    // Start is called before the first frame update
    void Start()
    {
        randomSound = GetComponent<RandomSound>();
        StartCoroutine(repeatSoundEverySecond());
    }

    IEnumerator repeatSoundEverySecond() {
        yield return new WaitForSeconds(timeRepeatGrunt);
        randomSound.changeSoundRandom();

        //repeat cycle
        StartCoroutine(repeatSoundEverySecond());
    }
}
