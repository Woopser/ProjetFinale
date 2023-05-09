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
            if(_sprite.flipX == true)
            {
                Vector3 left = new Vector3(-1, 0,0);
                Vector3 pos = transform.position + left;
                GameObject Fire1 = Instantiate(_projectile, pos, Quaternion.identity);
            }
            else if (_sprite.flipX == false)
            {
                Vector3 right = new Vector3(1, 0, 0);
                Vector3 pos = transform.position + right;
                GameObject Fire1 = Instantiate(_projectile, pos, Quaternion.identity);
            }

            yield return new WaitForSeconds(3f);
        }
        
        

    }

}
