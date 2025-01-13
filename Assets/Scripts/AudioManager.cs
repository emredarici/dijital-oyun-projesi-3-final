using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameEvent hitEvent;
    public AudioClip hitSound;

    private AudioSource audioSource;

    private void OnEnable()
    {
        hitEvent.OnEventRaised += PlayHitSound;
    }

    private void OnDisable()
    {
        hitEvent.OnEventRaised -= PlayHitSound;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void PlayHitSound()
    {
        audioSource.PlayOneShot(hitSound);
    }
}
