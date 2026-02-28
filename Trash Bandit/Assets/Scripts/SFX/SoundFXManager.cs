using UnityEngine;

public class SoundFXManager : MonoBehaviour
{

    public static SoundFXManager instance;

    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        // spawn gameObject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        // assign clip to audio source
        audioSource.clip = audioClip;

        // assign volume
        audioSource.volume = volume;

        // play clip
        audioSource.Play();

        // get length of clip
        float clipLength = audioClip.length;

        // destroy gameObject after clip length
        Destroy(audioSource.gameObject, clipLength);
    }

}
