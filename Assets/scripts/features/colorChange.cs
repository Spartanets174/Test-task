using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class colorChange : Ifeature
{
    public Color colorToChange;
    //Указание имени самой способности
    readonly string Name = "Смена цвета";
    //Передача имени в интерфейс
    string Ifeature.Name => Name;
    public GameObject Model { get ; set ; }

    public void FeatureRealization()
    {
        ChangeColor(colorToChange);
        Debug.Log("Смена цвета");
    }
    public void ChangeColor(Color color)
    {
        //Все части перекрашиваются
        for (int i = 0; i < Model.transform.childCount; i++)
        {
            if (Model.transform.GetChild(i).TryGetComponent<MeshRenderer>(out MeshRenderer mesh))
            {
                mesh.materials[0].color = color;
            }
        }
    }
}
