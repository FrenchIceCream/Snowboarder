using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem finishEffect;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            FindFirstObjectByType<TimerSaver>().StopTimer(SceneManager.GetActiveScene().buildIndex - 2);
            Invoke("LoadNextScene", delay);
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
