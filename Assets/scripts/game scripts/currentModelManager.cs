using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;

//������ ��� ����������� ������������ ��������� ������ �� ����� ������ ���������
public class currentModelManager : MonoBehaviour
{
   public GameObject model;
    //������ ���� ������������, ������� ����� ������� ��� ������
    [SerializeReference, SubclassSelector] public Ifeature[] CurrentFeatureList = Array.Empty<Ifeature>();
}
