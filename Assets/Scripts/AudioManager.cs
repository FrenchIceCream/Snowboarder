using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip audioClipStart;
    [SerializeField] AudioClip audioClipRepeating;

    AudioSource audioSource;
    
    void Awake()
    {
        if (FindObjectsOfType<AudioManager>().Length > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
        
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        audioSource.clip = audioClipStart;
        audioSource.Play();
        Invoke("StartNextClip", audioClipStart.length);
    }

    void StartNextClip()
    {
        audioSource.Stop();
        audioSource.clip = audioClipRepeating;
        audioSource.Play();
    }
}
