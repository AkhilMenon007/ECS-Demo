using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using static Unity.Mathematics.math;

public class MoveToTargetSystem : JobComponentSystem
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
    struct MoveToTargetSystemJob : IJobForEach<Translation, TargetComponent, SpeedComponent>
    {
        // Add fields here that your job needs to do its work.
        // For example,
            public float deltaTime;
        public void Execute(ref Translation translation ,[ReadOnly] ref TargetComponent target,[ReadOnly] ref SpeedComponent speed)
        {
            float3 movement = target.targetPosition - translation.Value;
            float3 stepVector = normalize(movement) * speed.speed * deltaTime;
            float remainingDistance = length(movement);
            float step= length(stepVector);

            if(step < remainingDistance)
            {
                translation.Value += stepVector;
            }
            else
            {
                translation.Value = target.targetPosition;
            }
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var job = new MoveToTargetSystemJob
        {

            // Assign values to the fields on your job here, so that it has
            // everything it needs to do its work when it runs later.
            // For example,
            deltaTime = UnityEngine.Time.deltaTime
        };



        // Now that the job is set up, schedule it to be run. 
        return job.Schedule(this, inputDependencies);
    }
}