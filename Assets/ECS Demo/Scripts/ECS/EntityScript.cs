using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Collections;
using Unity.Transforms;
public class EntityScript : MonoBehaviour
{
    public GameObject entityPrefab;
    public int count = 10;
    public int currentCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        //InstantiateMore(count);
    }

    public void InstantiateMore(int count)
    {
        EntityManager a = World.Active.EntityManager;

        Entity entity = GameObjectConversionUtility.ConvertGameObjectHierarchy(entityPrefab, World.Active);
        for (int i = 0; i < count; i++)
        {
            Entity e = a.Instantiate(entity);
            a.SetComponentData(e, new Translation { Value = transform.position });
        }
        currentCount += count;
    }
}
