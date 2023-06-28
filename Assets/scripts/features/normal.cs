using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class normal : feature
{
    public normal(string name) : base(name)
    {
        featureName = name;
    }

    public override IEnumerator featureRealization(modelObject model)
    {
        Debug.Log("Норма");
        yield break;
    }
}
