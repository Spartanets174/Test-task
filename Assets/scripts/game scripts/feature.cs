using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//���������� �������� ���� ��������� ������������
public interface Ifeature
{
    string Name { get; }
    public PresentorType presentorType { get; }
    //�������, ������� ��������� ���������� ���� ������, ������� ���� ����� ��������
    public void featureRealization(GameObject model);
}
