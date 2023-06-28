using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
//Способность декомпозиции объектов
public class decomposeFeature : Ifeature
{   //Указание имени самой способности
    string Name = "Декомпозиция";
    //Передача имени в интерфейс
    string Ifeature.Name => Name;

    public void featureRealization(GameObject model)
    {
        Debug.Log("Декомпозиция");
    }
}
