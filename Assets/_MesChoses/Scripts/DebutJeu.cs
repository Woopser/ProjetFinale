using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebutJeu : MonoBehaviour
{

    private Musique speaker;
    private AudioSource sons;

    private void Start()
    {
        speaker = FindObjectOfType<Musique>();
        sons = speaker.GetComponent<AudioSource>();
    }
    public void Mute()
    {
        if (sons.mute == true)
        {
            sons.mute = false;
        }
        else if (sons.mute == false)
        {
            sons.mute = true;
        }
    }
    public void Quitter()
    {
        Application.Quit();
    }

    public void ChangerScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }
}
