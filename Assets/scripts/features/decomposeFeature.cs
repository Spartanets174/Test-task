using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class decomposeFeature : Ifeature
{
     string Name = "������������";

    string Ifeature.Name => Name;

    public void featureRealization(modelObject model)
    {
        Debug.Log("������������");
    }
}
