using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class normal : Ifeature
{
    public string Name = "������� ���������";

    string Ifeature.Name => Name;

    public void featureRealization(modelObject model)
    {
        Debug.Log("�����");
    }
}
