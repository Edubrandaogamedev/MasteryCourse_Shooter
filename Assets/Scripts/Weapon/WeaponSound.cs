using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WeaponSound : WeaponComponent
{
    [SerializeField] private SimpleAudioEvent _audioEvent;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    protected override void WeaponFired()
    {
        _audioEvent.Play(audioSource);
    }
}
