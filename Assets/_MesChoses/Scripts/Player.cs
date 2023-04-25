using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float _vitesse = 10;
    [SerializeField] float _jumpPower = 55;

    private Rigidbody2D _playerRb = default;
    // Start is called before the first frame update
    void Start()
    {
        _playerRb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Mouvement();
    }

    private void Mouvement()
    {
        float horizInput = Input.GetAxis("Horizontal");

        Vector2 direction = new Vector2(horizInput, 0);
        _playerRb.velocity = new Vector2(horizInput * _vitesse, _playerRb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {

            _playerRb.velocity = new Vector2(0, _jumpPower * 2);

        }
    }

    private bool isGrounded()
    {
        float extraHeight = 0.2f;
        Physics2D.Raycast(BoxCollider2D.bounds.center, Vector2.down, BoxCollider2D.bounds.extents.y + extraHeight);
    }

}

