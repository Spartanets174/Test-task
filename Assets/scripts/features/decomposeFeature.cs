using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class decomposeFeature : feature
{
    public decomposeFeature(string name) : base(name)
    {
        featureName = name;
    }
    public override IEnumerator featureRealization(modelObject model)
    {
        Debug.Log("Декомпозиция");
        yield break;
    }
}
