using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _prefabSpawn = default;
    [SerializeField] private GameObject[] _listePlatform = default;

    [SerializeField] private float _delai = 2f;
    private bool _stopSpawn = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPlatFormRoutine());
    }

    IEnumerator SpawnPlatFormRoutine()
    {
        yield return new WaitForSeconds(_delai);

        while (!_stopSpawn)
        {
            int randomPlat = Random.Range(0, _listePlatform.Length);
            Vector3 posSpawn1 = new Vector3(Random.Range(-8.0f, 0.0f), 7f, 0f);
            GameObject newPlat1 = Instantiate(_listePlatform[randomPlat], posSpawn1, Quaternion.identity);
            newPlat1.transform.parent = _prefabSpawn.transform;

            int randomPlat2 = Random.Range(0, _listePlatform.Length);
            Vector3 posSpawn2 = new Vector3(Random.Range(0.0f, 8.0f), 7f, 0f);
            GameObject newPlat2 = Instantiate(_listePlatform[randomPlat2], posSpawn2, Quaternion.identity);
            newPlat2.transform.parent = _prefabSpawn.transform;
            yield return new WaitForSeconds(_delai);
        }
    }
}
