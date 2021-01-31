using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RandomSound))]
public class SoundGruntTime : MonoBehaviour
{
    [SerializeField] float timeRepeatGrunt = 5;

    RandomSound randomSound;

    // Start is called before the first frame update
    void Start()
    {
        randomSound = GetComponent<RandomSound>();
    }

    IEnumerator repeatSoundEverySecond() {
        yield return new WaitForSeconds(timeRepeatGrunt);
        randomSound.changeSoundRandom();
    }
}
