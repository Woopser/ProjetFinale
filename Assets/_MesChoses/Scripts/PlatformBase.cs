using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBase : MonoBehaviour
{
    [SerializeField] float _vitesse = 0.3f;
    [SerializeField] float _augmentation = 1.3f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _vitesse);
    }


    private void Die()
    {
        Destroy(gameObject);
    }

    public void AugmentDifficult()
    {
        _vitesse = _vitesse * _augmentation;
    }
}
