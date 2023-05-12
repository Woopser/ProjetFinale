using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private float xInitiale;
    private SpriteRenderer _sprite = default;
    private Player _player = default;
    private GameObject _self = default;
    private SpriteRenderer _playerSp = default;
    // Start is called before the first frame update
    void Start()
    {
        _player= FindObjectOfType<Player>();
        _playerSp= FindObjectOfType<SpriteRenderer>();
        
        _sprite = GetComponent<SpriteRenderer>();
        _self= GetComponent<GameObject>();
        if(this.transform.parent == null)
        {
            xInitiale = transform.position.x; 
            if (xInitiale > 0)
            {
                _sprite.flipX = true;
            } 
        }
        
    }

    // Update is called once per frame
    void Update()
    {

            if(_sprite.flipX == true)
            {
                transform.Translate(Vector2.left * Time.deltaTime * 3f);
            }
            else
            {
                transform.Translate(Vector2.right * Time.deltaTime * 3f);
            }
        

        if(transform.position.x > 9.5) 
        { 
            Destroy(gameObject);
        }
        if (transform.position.x < -9.5)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && tag == "FireBall")
        {
            _player.Dommage();
            Destroy(gameObject);
        }
        
    }
}
