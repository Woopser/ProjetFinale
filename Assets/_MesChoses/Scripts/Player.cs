using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float _vitesse = 10;
    [SerializeField] float _jumpPower = 55;
    BoxCollider2D _collider = default;
    SpriteRenderer _playerSprtie = default;


    private Animator _animatorPlayer;
    private Rigidbody2D _playerRb = default;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        _playerRb= GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _animatorPlayer = GetComponent<Animator>();
        _playerSprtie= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Mouvement();
    }

    private void Mouvement()
    {
        float horizInput = Input.GetAxis("Horizontal");
        if (!isGrounded())
        {
            _animatorPlayer.SetBool("inAir", true);
        }
        else
        {
            _animatorPlayer.SetBool("inAir", false);
        }
        Vector2 direction = new Vector2(horizInput, 0);
        _playerRb.velocity = new Vector2(horizInput * _vitesse, _playerRb.velocity.y);
        //Gestion animation
        if(horizInput > 0)
        {
            _animatorPlayer.SetBool("TurnRight", true);
            //_animatorPlayer.SetBool("TurnLeft", false);
            _playerSprtie.flipX = false;
        }
        else if(horizInput < 0) 
        {
            //_animatorPlayer.SetBool("TurnRight", false);
            //_animatorPlayer.SetBool("TurnLeft", true);
            _playerSprtie.flipX = true;
        }
        else
        {
            _animatorPlayer.SetBool("TurnRight", false);
            //_animatorPlayer.SetBool("TurnLeft", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            _animatorPlayer.SetBool("inAir", true);
            _playerRb.velocity = new Vector2(0, _jumpPower * 2);

        }
    }

    private bool isGrounded()
    {
        float extraHeight = 0.5f;
        RaycastHit2D hit = Physics2D.Raycast(_collider.bounds.center, Vector2.down, _collider.bounds.extents.y + extraHeight, groundLayer);
         if (hit.collider != null)
         {
            return true;
         }
         else
         {
            return false;
         }
    }

}

