using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class normal : Ifeature
{
    public string Name = "Обычное состояние";

    string Ifeature.Name => Name;

    public void featureRealization(GameObject model)
    {
        for (int i = 0; i < model.transform.childCount; i++)
        {
           model.transform.GetChild(i).gameObject.SetActive(true);
        }
        Debug.Log("Норма");
    }
}
