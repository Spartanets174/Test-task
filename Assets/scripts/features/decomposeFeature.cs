using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
//Способность декомпозиции объектов
public class decomposeFeature : Ifeature
{
    public int maxDistance;
    public int minDistance=1;
    public float currentValue;
    public List<Vector3> startPos;
    [SerializeField] List<GameObject> partsToDecompose;
    //Указание имени самой способности
    string Name = "Декомпозиция";

    //Передача имени в интерфейс
    string Ifeature.Name => Name;
    public void featureRealization(GameObject model)
    { 
        for (int i = 0; i < partsToDecompose.Count; i++)
        {
            Vector3 childPos = partsToDecompose[i].transform.localPosition;
            childPos.x = objectMove(startPos[i].x, currentValue);
            childPos.y = objectMove(startPos[i].y, currentValue);
            childPos.z = objectMove(startPos[i].z, currentValue);
            partsToDecompose[i].transform.localPosition = childPos;
        }
        Debug.Log("Декомпозиция");
    }     
    float objectMove(float coord, float value)
    {
        if (Math.Abs(coord * value) > Math.Abs(coord * maxDistance))
        {
            return coord * maxDistance;
        }
        if (Math.Abs(coord * value) < Math.Abs(coord * minDistance))
        {
            return coord * minDistance;
        }
        return coord*value;
    }

}
