using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MoveToRandomPoisition),typeof(MoveToTarget))]
public class BeetleBehaviour : MonoBehaviour
{

    private MoveToTarget moveToTarget;
    private MoveToRandomPoisition moveToRandomPoisition;

    public bool foundTarget = false;
    public float visionRadius = 5f;

    public float beetleRadius = 0.5f;

    private Target target = null;

    private void Awake()
    {
        moveToRandomPoisition = GetComponent<MoveToRandomPoisition>();
        moveToTarget = GetComponent<MoveToTarget>();
    }

    private void OnEnable()
    {
        foundTarget = false;
        target = null;
    }

    private void Update()
    {
        if (!foundTarget)
        {
            moveToTarget.enabled = false;
            moveToRandomPoisition.enabled = true;
            foreach (Target target in TargetManager.targets)
            {
                //Move to first seen target
                if ((target.transform.position - transform.position).magnitude < visionRadius)
                {
                    foundTarget = true;
                    moveToTarget.targetTransform = target.transform;
                    moveToTarget.enabled = true;
                    moveToRandomPoisition.enabled = false;
                    this.target = target;
                    break;
                }
            }
        }
        if (foundTarget && target != null)
        {
            if ((transform.position - target.transform.position).magnitude < beetleRadius)
            {
                target.TakeDamage();
                gameObject.SetActive(false);
            }
        }
    }


}
