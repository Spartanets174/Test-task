using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
//����������� ������������ ��������
public class decomposeFeature : Ifeature
{   //�������� ����� ����� �����������
    string Name = "������������";
    //�������� ����� � ���������
    string Ifeature.Name => Name;

    public void featureRealization(GameObject model)
    {
        for (int i = 0; i < model.transform.childCount; i++)
        {
            Vector3 childPos = model.transform.GetChild(i).transform.localPosition;
            childPos.x = objectMove(childPos.x);
            childPos.y = objectMove(childPos.y);
            childPos.z = objectMove(childPos.z);
            model.transform.GetChild(i).transform.localPosition = childPos;
        }
        Debug.Log("������������");
    }

    float objectMove(float coord)
    {
        return coord*4;
    }
}
