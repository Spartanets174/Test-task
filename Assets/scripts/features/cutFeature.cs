using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
//Способность разреза объектов
public class cutFeature : Ifeature
{
    //Указание имени самой способности
    string Name = "Разрез";
    //Передача имени в интерфейс
    string Ifeature.Name => Name;

    public PresentorType presentorType => PresentorType.turnOnOff;

    [SerializeField] List<GameObject> partsToCut;

    public void featureRealization(GameObject model)
    {
        //Каждая нечетная часть модели просто отключается
        for (int i = 0; i < partsToCut.Count; i++)
        {
            partsToCut[i].gameObject.SetActive(false); 
        }
        Debug.Log("Разрез");
    }
}
