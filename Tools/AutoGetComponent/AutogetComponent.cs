using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGetComponent : Attribute
{
    public virtual void SetComponent(MonoBehaviour mb, Type componentType, Action<MonoBehaviour, object> SetVariableType)
    {

    }

}
