using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkullEnemy : MonoBehaviour
{
    private float xInitiale;
    private SpriteRenderer _sprite = default;
    [SerializeField] GameObject _projectile = default;
    // Start is called before the first frame update
    void Start()
    {
        xInitiale = transform.position.x;
        _sprite = GetComponent<SpriteRenderer>();
        
        if(xInitiale > 0)
        {
            _sprite.flipX = true;
        }
        StartCoroutine(Feu());
    }

    IEnumerator Feu()
    {
        while (true)
        {
            GameObject Fire = Instantiate(_projectile, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }
        
        

    }

}
