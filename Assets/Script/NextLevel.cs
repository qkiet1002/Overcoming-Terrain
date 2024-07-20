using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private AudioSource winnerSound;
    private bool levelCompleted = false;
    void Update()
    {
        winnerSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted) 
        {
            winnerSound.Play();
    
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
