using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Player _player = default;
    private void Start()
    {
        _player= FindObjectOfType<Player>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            Destroy(collision.gameObject);
        }
        else if(collision.tag == "Player")
        {
            _player.Dommage();
        }

    }
}
