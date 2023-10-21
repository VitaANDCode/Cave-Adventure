using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public void PlaySound(AudioClip audio)
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();

        audioSource.PlayOneShot(audio);
    }
}