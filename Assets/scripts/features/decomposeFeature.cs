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
    public int currentValue;
    public List<Transform> startPos;
    [SerializeField] List<GameObject> partsToDecompose;
    //Указание имени самой способности
    string Name = "Декомпозиция";
    //Передача имени в интерфейс
    string Ifeature.Name => Name;
    public void featureRealization(GameObject model)
    { 
       /* //Добавление стартовых позиций дочерних объектов
        for (int i = 0; i < partsToDecompose.Count; i++)
        {
            startPos.Add(partsToDecompose[i].transform.localPosition);
        }*/
        for (int i = 0; i < partsToDecompose.Count; i++)
        {
            Vector3 childPos = partsToDecompose[i].transform.localPosition;
            childPos.x = objectMove(startPos[i].position.x, currentValue);
            childPos.y = objectMove(startPos[i].position.y, currentValue);
            childPos.z = objectMove(startPos[i].position.z, currentValue);
            partsToDecompose[i].transform.localPosition = childPos;
        }
        Debug.Log("Декомпозиция");
    }     
    float objectMove(float coord, float value)
    {
        return coord * value>coord*maxDistance? coord : coord*value;
    }

}
