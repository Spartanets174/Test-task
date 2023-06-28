using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class decomposeFeature : Ifeature
{
     string Name = "Декомпозиция";

    string Ifeature.Name => Name;

    public void featureRealization(GameObject model)
    {
        Debug.Log("Декомпозиция");
    }
}
