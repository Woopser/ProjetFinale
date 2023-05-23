using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musique : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        int nbMusiquedeFond = FindObjectsOfType<Musique>().Length;
        if (nbMusiquedeFond > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
