using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Health))]
public class ImpactAudio : MonoBehaviour
{
    [SerializeField] private SimpleAudioEvent audioEvent;
    
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GetComponent<Health>().OnTookHit += HitHandler;
    }

    private void HitHandler()
    {
        audioEvent.Play(audioSource);
    }
}
