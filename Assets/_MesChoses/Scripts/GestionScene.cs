using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GestionScene : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreTxt = default;
    [SerializeField] TextMeshProUGUI _TempsTxt = default;
    private Musique speaker;
    private AudioSource sons;
    // Start is called before the first frame update
    void Start()
    {
        float temps = PlayerPrefs.GetFloat("Temps");
        _scoreTxt.text = PlayerPrefs.GetFloat("Score") + "pts";
        _TempsTxt.text = temps.ToString("f2") + "s";
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
