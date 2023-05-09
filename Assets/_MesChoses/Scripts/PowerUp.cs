using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    // _powerUpID  0=Jump   1=knife   2=?
    [SerializeField] private int _powerUpID = default;
    //[SerializeField] private AudioClip _powerUpSound = default;
    Player _playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        _playerPrefab = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -5.0f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            Destroy(this.gameObject);
            if (player != null)
            {
                switch (_powerUpID)
                {
                    case 0:
                        player.PowerUpJump();
                        break;
                    case 1:
                        player.PowerUpKnife();
                        break;

                }
            }

        }
    }
}
