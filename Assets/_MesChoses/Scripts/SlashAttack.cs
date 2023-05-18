using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAttack : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (collision.GetComponent<SkullEnemy>() != null)
            {
                SkullEnemy enemy = collision.GetComponent<SkullEnemy>();
                enemy.Dead();
            }
            else if (collision.GetComponent<Enemy>() != null)
            {
                Enemy enemy = collision.GetComponent<Enemy>();
                enemy.Dead();
            }
        }


    }
}
