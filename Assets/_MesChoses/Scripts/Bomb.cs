using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    private GameObject Radius = default;
    private CircleCollider2D colluder = default;
    [SerializeField] float detonation = 0.15f;
    // Start is called before the first frame update
    void Start()
    {
        colluder= GetComponent<CircleCollider2D>();
        Radius = transform.GetChild(0).gameObject;
        StartCoroutine(boom());
        
    }

    IEnumerator boom()
    {
        yield return new WaitForSeconds(3f);
        Radius.SetActive(true);
        colluder.enabled = false;
        yield return new WaitForSeconds(detonation);
        Destroy(gameObject);
    }

    

}
