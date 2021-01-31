using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        if (audioSource == null) GetComponent<AudioSource>();
    }

    public void changeSoundRandom()
    {
        int i = Random.Range(0, audioClips.Length);
        audioSource.clip = audioClips[i];
        audioSource.Play();
    }
}
