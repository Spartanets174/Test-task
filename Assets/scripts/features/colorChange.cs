using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class colorChange : Ifeature
{
    //�������� ����� ����� �����������
    string Name = "����� �����";
    //�������� ����� � ���������
    string Ifeature.Name => Name;

    public void featureRealization(GameObject model)
    {
        //��� ����� ���������������
        for (int i = 0; i < model.transform.childCount; i++)
        {
            model.transform.GetChild(i).GetComponent<MeshRenderer>().materials[0].color = new Color(UnityEngine.Random.Range(0, 255) / 100, UnityEngine.Random.Range(0, 255) / 100, UnityEngine.Random.Range(0, 255) / 100, 1);
        }
        Debug.Log("����� �����"); ;
    }
}
