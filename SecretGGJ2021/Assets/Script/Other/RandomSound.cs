using UnityEngine;

public class RandomSound : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] AudioSource audioSource;

    public void changeSoundRandom()
    {
        int i = Random.Range(0, audioClips.Length);
        audioSource.clip = audioClips[i];
        audioSource.Play();
    }
}
