using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
[RequiresEntityConversion]
public class RandomMotionAuthor : MonoBehaviour, IConvertGameObjectToEntity
{
    public float spread=5f;
    public bool isMovingRandomly=true;
    public float delayBetweenUpdates=1f;
    public Vector3 origin=Vector3.zero;


    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        RandomMotionComponent data = new RandomMotionComponent { isMovingRandomly = this.isMovingRandomly, delayBetweenUpdates = this.delayBetweenUpdates, timeToNextUpdate = 0f, spread = this.spread, origin = this.origin };
        dstManager.AddComponentData(entity, data);
        // Call methods on 'dstManager' to create runtime components on 'entity' here. Remember that:
        //
        // * You can add more than one component to the entity. It's also OK to not add any at all.
        //
        // * If you want to create more than one entity from the data in this class, use the 'conversionSystem'
        //   to do it, instead of adding entities through 'dstManager' directly.
        //
        // For example,
        //   dstManager.AddComponentData(entity, new Unity.Transforms.Scale { Value = scale });        
    }
}
