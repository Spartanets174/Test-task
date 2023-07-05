using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
//����������� ������� ��������
public class cutFeature : Ifeature
{
    //�������� ����� ����� �����������
    readonly string Name = "������";
    //�������� ����� � ���������
    string Ifeature.Name => Name;

    [SerializeField] List<GameObject> partsToCut;

    public void FeatureRealization(GameObject model)
    {
        //������ �������� ����� ������ ������ �����������
        for (int i = 0; i < partsToCut.Count; i++)
        {
            partsToCut[i].gameObject.SetActive(false); 
        }
        Debug.Log("������");
    }
}
