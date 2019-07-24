using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveToTarget : MonoBehaviour
{
    public Transform targetTransform = null;
    public float speed = 10f;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, speed * Time.deltaTime);
    }
}
