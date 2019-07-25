using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class InstantiateOnStart : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab = null;
    [SerializeField]
    private int count = 1000;

    public int currentCount = 0;
    void Awake()
    {
        //Create(count);
        //10k for simple cube
        //30k for invisible cube
    }
    public void Create(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(prefab,transform.position,transform.rotation,transform);
        }
        currentCount += count;

    }
}
