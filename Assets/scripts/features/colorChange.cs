using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

[Serializable]
public class colorChange : Ifeature
{
    [SerializeField] CUIColorPicker ColorPicker;
    //�������� ����� ����� �����������
    string Name = "����� �����";
    //�������� ����� � ���������
    string Ifeature.Name => Name;
    
    public void featureRealization(GameObject model)
    {
        ColorPicker.gameObject.SetActive(true);
        ColorPicker.model = model;        
        Debug.Log("����� �����");
    }
}
