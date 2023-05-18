using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _ScoreTxt = default;

    [SerializeField] Image _LivesImage = default;
    [SerializeField] Sprite[] _liveSprites = default;

    [SerializeField] float _pointageAugment = 400;


    private float _score = 0f;
    // Start is called before the first frame update
    void Start()
    {
        _score= 0f;
        Time.timeScale = 1f;
        UpdateScore();
        ChangeImageLive(0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateScore()
    {
        _ScoreTxt.text = "Pointage: " + _score.ToString();
    }

    public float getScore()
    {
        return _score;
    }

    public void PlusScore(float points)
    {
        _score += points;
        UpdateScore();
    }

    public void ChangeImageLive(int noImage)
    {
        if(noImage < 0)
        {
            noImage = 0;
        }
        _LivesImage.sprite = _liveSprites[noImage];


        //quand le joueurs na plus de vie
        if(noImage == 0)
        {
            //StartCoroutine(FinPartie())
        }
    }

    IEnumerator FinPartie()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(2);
    }
}
