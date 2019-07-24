using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using static Unity.Mathematics.math;

public class RandomRotationSystem : JobComponentSystem
{

    //This uses a tag for fetching entities with randomrotationcomponent
    [BurstCompile]
    [RequireComponentTag(typeof(RandomRotationComponent))]
    struct RandomRotationSystemJob : IJobForEach<Rotation>
    {
        // Add fields here that your job needs to do its work.
        // For example,
        public float deltaTime;
        public Random random;

        public void Execute(ref Rotation rotation)
        {
            quaternion randomRot = Unity.Mathematics.quaternion.EulerXYZ(random.NextFloat3() * PI * 2);
            rotation.Value = slerp(rotation.Value, randomRot, deltaTime);
        }
    }
    
    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        Random random = new Random(1);
        var job = new RandomRotationSystemJob
        {

            // Assign values to the fields on your job here, so that it has
            // everything it needs to do its work when it runs later.
            // For example,
            random = random,
            deltaTime = UnityEngine.Time.deltaTime
        };



        // Now that the job is set up, schedule it to be run. 
        return job.Schedule(this, inputDependencies);
    }
}