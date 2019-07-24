using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using static Unity.Mathematics.math;

public class RandomMotionSystem : JobComponentSystem
{
    // This declares a new kind of job, which is a unit of work to do.
    // The job is declared as an IJobForEach<Translation, Rotation>,
    // meaning it will process all entities in the world that have both
    // Translation and Rotation components. Change it to process the component
    // types you want.
    //
    // The job is also tagged with the BurstCompile attribute, which means
    // that the Burst compiler will optimize it for the best performance.


    [BurstCompile]
    struct RandomMotionSystemJob : IJobForEach<RandomMotionComponent, TargetComponent,Translation>
    {
        // Add fields here that your job needs to do its work.
        // For example,
        public float deltaTime;
        public Random random;
        public void Execute(ref RandomMotionComponent randomMotion, ref TargetComponent target,[ReadOnly]ref Translation position)
        {
            if (randomMotion.isMovingRandomly)
            {
                if (randomMotion.timeToNextUpdate <= 0f || (position.Value.x == target.targetPosition.x && position.Value.y == target.targetPosition.y && position.Value.z == target.targetPosition.z) )
                {
                    randomMotion.timeToNextUpdate = randomMotion.delayBetweenUpdates;
                    target.targetPosition = (normalize(random.NextFloat3() - new float3(0.5f, 0.5f, 0.5f)) * randomMotion.spread) + randomMotion.origin;
                }
                else
                {
                    randomMotion.timeToNextUpdate -= deltaTime;
                }
            }
        }


        //public void Execute(ref Translation translation, [ReadOnly] ref Rotation rotation)
        //{
        // Implement the work to perform for each entity here.
        // You should only access data that is local or that is a
        // field on this job. Note that the 'rotation' parameter is
        // marked as [ReadOnly], which means it cannot be modified,
        // but allows this job to run in parallel with other jobs
        // that want to read Rotation component data.
        // For example,
        //     translation.Value += mul(rotation.Value, new float3(0, 0, 1)) * deltaTime;


        //}
    }
    
    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        Random random = new Random(1);
        var job = new RandomMotionSystemJob
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