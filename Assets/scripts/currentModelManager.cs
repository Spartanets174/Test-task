using System;
using UnityEngine;

//������ ��� ������ ��������� ������ ������������ ������
public class currentModelManager : MonoBehaviour
{
    //������ ���� ������������, ������� ����� ������� ��� ������
    [SerializeReference, SubclassSelector] public Ifeature[] CurrentFeatureList = Array.Empty<Ifeature>();

}
