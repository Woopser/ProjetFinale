using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _ScoreTxt = default;
    [SerializeField] PlatformBase platforme = default;

    [SerializeField] Image _LivesImage = default;
    [SerializeField] Sprite[] _liveSprites = default;
    [SerializeField] TextMeshProUGUI _Temps = default;

    [SerializeField] float _pointageAugment = 400;
    float time;

    private float _score = 0f;
    // Start is called before the first frame update
    void Start()
    {
        _score= 0f;
        UpdateScore();
        ChangeImageLive(3);

    }

    // Update is called once per frame
    void Update()
    {
        time= Time.time;
        _Temps.text = "Temps : " + time.ToString("f2");
    }

    private void UpdateScore()
    {
        _ScoreTxt.text = "Pointage: " + _score.ToString();
        if(_score > _pointageAugment)
        {
            platforme.AugmentDifficult();
        }
    }

    public float getScore()
    {
        return _score;
    }

    public void PlusScore(float points)
    {
        Debug.Log("Score ajout");
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

    public float getTIme() { return time; }
}
