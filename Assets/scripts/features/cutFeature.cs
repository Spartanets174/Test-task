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

    public PresentorType presentorType => PresentorType.turnOnOff;

    [SerializeField] List<GameObject> partsToCut;

    public void featureRealization(GameObject model)
    {
        //������ �������� ����� ������ ������ �����������
        for (int i = 0; i < partsToCut.Count; i++)
        {
            partsToCut[i].gameObject.SetActive(false); 
        }
        Debug.Log("������");
    }
}
