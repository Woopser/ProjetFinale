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
        Move();
    }

    public void Move()
    {
        if(xInitiale< 0)
        {
            transform.Translate(Vector2.right * Time.deltaTime * _vitesse);
        }
        else if(xInitiale > 0) 
        {
            transform.Translate(Vector2.left * Time.deltaTime * _vitesse);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.Dommage();
        }
    }

}
