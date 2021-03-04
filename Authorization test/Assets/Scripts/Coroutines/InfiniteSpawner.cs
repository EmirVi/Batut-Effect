using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteSpawner : MonoBehaviour
{
    public GameObject CubePrefab;
    public float delay = 0.5f;

    private void Start()
    {
        StartCoroutine(Spawner(CubePrefab));
    }

    IEnumerator Spawner(GameObject cubeObj)
    {
        while(true)
        {
            var tmpCube = Instantiate(cubeObj);

            tmpCube.transform.position = transform.position;

            yield return new WaitForSeconds(delay);
        }
    }
}
