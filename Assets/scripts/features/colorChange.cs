using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

[Serializable]
public class colorChange : Ifeature
{
    [SerializeField] CUIColorPicker ColorPicker;
    //Указание имени самой способности
    string Name = "Смена цвета";
    //Передача имени в интерфейс
    string Ifeature.Name => Name;
    
    public void featureRealization(GameObject model)
    {
        ColorPicker.gameObject.SetActive(true);
        ColorPicker.model = model;        
        Debug.Log("Смена цвета");
    }
}
