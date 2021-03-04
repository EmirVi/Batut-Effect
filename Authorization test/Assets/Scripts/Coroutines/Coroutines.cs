using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutines : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 4.5f;

    private void Start()
    {
        StartCoroutine(One(waypoints));
        Two();
    }

    IEnumerator One(Transform[] paths)
    {
        for (int i = 0; i < paths.Length; i++)
        {
            yield return StartCoroutine(MoveTo(paths[i].position, speed));
        }
    }

    IEnumerator MoveTo(Vector3 finalPosition, float speed)
    {
        //Wait until the game object is not on the final position
        while (transform.position != finalPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, finalPosition, speed * Time.deltaTime);
            yield return null;
        }
    }

    void Two()
    {
        Debug.Log("two called");
    }
}
