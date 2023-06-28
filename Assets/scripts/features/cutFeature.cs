using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class cutFeature : Ifeature
{
    public string Name = "Разрез";

    string Ifeature.Name => Name;

    public void featureRealization(modelObject model)
    {
        Debug.Log("Разрез");;
    }
}
