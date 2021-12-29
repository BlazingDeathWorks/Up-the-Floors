using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip clip = null;
    private AudioSource mySource = null;

    private void Awake()
    {
        mySource = GetComponent<AudioSource>();
    }

    public void PlaySFX()
    {
        if (clip == null || mySource == null) return;
        mySource.PlayOneShot(clip);
    }
}
