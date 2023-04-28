using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _prefabPlat = default; //Changer pour un tableau quand on a plus que une platforme
    [SerializeField] private GameObject _prefabSpawn = default;

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
            Vector3 posSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 7f, 0f);
            GameObject newPlat = Instantiate(_prefabPlat, posSpawn, Quaternion.identity);
            newPlat.transform.parent = _prefabSpawn.transform;
            yield return new WaitForSeconds(_delai);
        }
    }
}
