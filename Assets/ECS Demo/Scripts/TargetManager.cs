using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TargetManager
{
    public static HashSet<Target> targets;
    public static void RegisterTarget(Target target)
    {
        CheckTargets();
        if (!targets.Contains(target))
        {
            targets.Add(target);
        }
    }
    public static void UnRegisterTarget(Target target)
    {
        CheckTargets();
        if (targets.Contains(target))
        {
            targets.Remove(target);
        }
    }

    private static void CheckTargets()
    {
        if (targets == null)
        {
            targets = new HashSet<Target>();
        }
    }
}
