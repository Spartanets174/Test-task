using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public abstract class feature
{
    public string featureName;
    public abstract IEnumerator featureRealization(modelObject model);

    public feature(string name)
    {
        this.featureName = name;
    }

}
