using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public void OnEnable()
    {
        TargetManager.RegisterTarget(this);
    }


    public void TakeDamage()
    {
        //Do stuff here
        gameObject.SetActive(false);
    }
    public void OnDisable()
    {
        TargetManager.UnRegisterTarget(this);
    }
}
