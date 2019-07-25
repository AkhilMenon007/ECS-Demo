using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EntityScript),typeof(InstantiateOnStart))]
public class SimpleSpawner : MonoBehaviour
{
    EntityScript entitySpawner = null;
    InstantiateOnStart gameObjectSpawner = null;

    public int spawnAmount = 20;

    private void Awake()
    {
        entitySpawner = GetComponent<EntityScript>();
        gameObjectSpawner = GetComponent<InstantiateOnStart>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObjectSpawner.Create(spawnAmount);
        }
        if (Input.GetMouseButtonDown(1))
        {
            entitySpawner.InstantiateMore(spawnAmount);
        }
    }
}
