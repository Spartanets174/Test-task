using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
//����������� ������� ��������
public class cutFeature : Ifeature
{
    //�������� ����� ����� �����������
    string Name = "������";
    //�������� ����� � ���������
    string Ifeature.Name => Name;

    public void featureRealization(GameObject model)
    {
        //������ �������� ����� ������ ������ �����������
        for (int i = 0; i < model.transform.childCount; i++)
        {
            if (i%2==1)
            {
                model.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        Debug.Log("������");;
    }
}
