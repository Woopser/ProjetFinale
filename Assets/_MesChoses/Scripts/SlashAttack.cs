using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAttack : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Kamikaze")
        {
            Destroy(collision.gameObject);
        }
        
    }
}