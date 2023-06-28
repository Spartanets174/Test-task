using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class cutFeature : feature
{
    public cutFeature(string name) : base(name)
    {
        featureName = name;
    }

    public override IEnumerator featureRealization(modelObject model)
    {
        Debug.Log("Разрез");
        yield break;
    }
}
