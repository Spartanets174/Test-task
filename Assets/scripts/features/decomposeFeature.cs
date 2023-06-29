using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
//����������� ������������ ��������
public class decomposeFeature : Ifeature
{   //�������� ����� ����� �����������
    string Name = "������������";
    public int maxDistance;
    [SerializeField] Slider decomposeSlider;
    //�������� ����� � ���������
    string Ifeature.Name => Name;

    List<Vector3> startPos = new List<Vector3>();
    

    public void featureRealization(GameObject model)
    { 
        decomposeSlider.gameObject.SetActive(true);
        decomposeSlider.transform.localPosition = new Vector3(0, 140, 0);
        decomposeSlider.maxValue = maxDistance;
        decomposeSlider.minValue = 1;
        for (int i = 0; i < model.transform.childCount; i++)
        {
            startPos.Add(model.transform.GetChild(i).transform.localPosition);
        }
        decomposeSlider.onValueChanged.AddListener(delegate
        {
            changePos(model, decomposeSlider.value);
        });

        Debug.Log("������������");
    }

    void changePos(GameObject model, float value)
    {
        for (int i = 0; i < model.transform.childCount; i++)
        {
            Vector3 childPos = model.transform.GetChild(i).transform.localPosition;
            childPos.x = objectMove(startPos[i].x, value);
            childPos.y = objectMove(startPos[i].y, value);
            childPos.z = objectMove(startPos[i].z, value);
            model.transform.GetChild(i).transform.localPosition = childPos;
        }
    }
    float objectMove(float coord, float value)
    {
        return coord * value;
    }
}
