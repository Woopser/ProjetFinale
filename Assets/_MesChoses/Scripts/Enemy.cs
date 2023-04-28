using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _vitesse = 2f;
    private float xInitiale;
    // Update is called once per frame

    private void Start()
    {
        xInitiale = transform.position.x;
    }
    void Update()
    {
        MoveLeft();
    }

    public void MoveLeft()
    {
        float horizPos = transform.position.x;
        if(horizPos < (xInitiale - 1.88))
        {
            MoveRight();
        }
        else
        {
            transform.Translate(Vector2.left * Time.deltaTime * _vitesse);
        }
        
    }

    public void MoveRight()
    { //https://www.youtube.com/watch?v=wJMXmqxlGR4 video youtube pour faire le mouvement du slime
        float horizPos = transform.position.x;
        if (horizPos > (xInitiale + 1.92))
        {
            MoveLeft();
        }
        else
        {
            transform.Translate(Vector2.left * Time.deltaTime * _vitesse);
        }

    }
}
