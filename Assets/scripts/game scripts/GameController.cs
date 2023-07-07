using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{   
    public Canvas canvas;
    public Transform modelParent;   

    public GameObject DecomposeSlider;
    public GameObject changeColorUI;

    public allModelsObjects ModelsObject;
    public GameObject changeableObject;

    public event ModelHandler OnModelChanged;

    modelObject currentModelObject;   
    List<modelObject> allModelsObject;
    int currentModelId;

    private void Start()
    {
        allModelsObject = ModelsObject.listModelObject;
        for (int i = 0; i < allModelsObject.Count; i++)
        {
            if (allModelsObject[i].isCurrentObject)
            {
                currentModelId = i;
                allModelsObject[i].isCurrentObject = false;
            }
        }
        changeCurrentModel(currentModelId);
    }

    //Функция для создания модели
    public void SpawnModel()
    {
        Destroy(changeableObject);
        GameObject spawnedObject = Instantiate(currentModelObject.model, Vector3.zero, Quaternion.identity, modelParent);
        spawnedObject.transform.localPosition = new Vector3(0, 0, 0);
        changeableObject = spawnedObject;
    }

    public void NextModel()
    {
        currentModelId++;
        changeCurrentModel(currentModelId);
    }

    public void PrevModel()
    {
        currentModelId--;
        changeCurrentModel(currentModelId);
    }
    //Проверка переданного в функцию id на принадлежность к области массива моделей и спавн нужной модели
    private void changeCurrentModel(int currentId)
    {
        if (currentId > allModelsObject.Count - 1)
        {
            currentId = 0;
        }
        if (currentId < 0)
        {
            currentId = allModelsObject.Count - 1;
        }
        
        currentModelObject = allModelsObject[currentId];
        currentModelId = currentId;
        OnModelChanged?.Invoke(currentModelObject);
        SpawnModel();
    }
}
public delegate void ModelHandler(modelObject currentModelObject);