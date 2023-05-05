using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float _vitesse = 10;
    [SerializeField] float _jumpPower = 55;
    BoxCollider2D _collider = default;
    SpriteRenderer _playerSprtie = default;
    private GameObject attackAreaRight = default;
    private GameObject attackAreaLeft = default;
    [SerializeField] private float _lives = 3;


    private Animator _animatorPlayer;
    private Rigidbody2D _playerRb = default;
    public LayerMask groundLayer;
    private float tempsPourAttack = 0.75f;
    private float timer = 0f;
    private bool attacking = false;
    private float _jumpIni; 
    // Start is called before the first frame update
    void Start()
    {
        _playerRb= GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _animatorPlayer = GetComponent<Animator>();
        _playerSprtie= GetComponent<SpriteRenderer>();
        attackAreaRight = transform.GetChild(0).gameObject;
        attackAreaLeft = transform.GetChild(1).gameObject;
        _jumpIni= _jumpPower;
    }

    // Update is called once per frame
    void Update()
    {
        Mouvement();

        if (Input.GetKeyDown(KeyCode.X) && isGrounded())
        {
            Attack();
            _animatorPlayer.SetBool("isAttacking", true);
        }
        if (attacking)
        {
            timer += Time.deltaTime;
            if(timer >= tempsPourAttack) 
            {
                _animatorPlayer.SetBool("isAttacking", false);
                timer= 0f;
                attacking= false;
                attackAreaLeft.SetActive(attacking);
                attackAreaRight.SetActive(attacking);
                
            }
        }

        
    }

    

    private void Attack()
    {
        attacking = true;
        if(_playerSprtie.flipX == false)
        {
            attackAreaRight.SetActive(attacking);
        }
        else if(_playerSprtie.flipX == true)
        {
            attackAreaLeft.SetActive(attacking);
        }
        
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
            _playerSprtie.flipX = false;
        }
        else if(horizInput < 0) 
        {
            _animatorPlayer.SetBool("TurnRight", true);
            _playerSprtie.flipX = true;
        }
        else
        {
            _animatorPlayer.SetBool("TurnRight", false);
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

    public void PowerUpJump()
    {
        _jumpPower *= 1.25f;
        StartCoroutine(JumpCoroutine());
    }

    IEnumerator JumpCoroutine()
    {
        yield return new WaitForSeconds(5f);
        _jumpPower = _jumpIni;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "FireBall")
        {
            Destroy(gameObject);
        }
    }

    public void Dommage()
    {
        _lives--;
        _animatorPlayer.SetBool("Hurt", true);
    }

}

