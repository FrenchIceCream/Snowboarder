using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSound;
    bool hasCrashed = false;

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.collider.CompareTag("Ground") && !hasCrashed)
        {
            hasCrashed = true;
            crashEffect.Play();
            GetComponentInParent<AudioSource>().PlayOneShot(crashSound, 0.5f);
            GetComponentInParent<PlayerController>().DisableControls();
            Invoke("ReloadScene", delay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
