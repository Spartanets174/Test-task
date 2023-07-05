using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class colorChange : Ifeature
{
    public Color colorToChange;
    //�������� ����� ����� �����������
    readonly string Name = "����� �����";
    //�������� ����� � ���������
    string Ifeature.Name => Name;

    public void FeatureRealization(GameObject model)
    {
        ChangeColor(model, colorToChange);
        Debug.Log("����� �����");
    }
    public void ChangeColor(GameObject model, Color color)
    {
        //��� ����� ���������������
        for (int i = 0; i < model.transform.childCount; i++)
        {
            if (model.transform.GetChild(i).TryGetComponent<MeshRenderer>(out MeshRenderer mesh))
            {
                mesh.materials[0].color = color;
            }
        }
    }
}
