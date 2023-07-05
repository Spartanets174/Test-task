
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


//Основной скрипт во время просмотра модели
public class gameManager : MonoBehaviour
{
    public UIManager UiManager;

    public Transform modelParent;

    public List<modelObject> allModelsObject;
    public  modelObject currentModelObject;
    public int currentModelId;

    public GameObject DecomposeSlider;
    public GameObject changeColorUI;

    GameObject changeableObject;
    
    private void Start()
    {
        NewModel();    
    }    
    //Функция для создания модели и вызова функции смены интерфейса
    public void NewModel()
    {
        UiManager.ChangeUI(currentModelObject);
        SpawnModel();     
    }
    //Функция, которая активирует нужный презентор способности в зависимости от номера выбранной опции в дропдаун меню
    public void DropdownActivateFeature(Dropdown dropdown)
    {       
        SpawnModel();
        if (dropdown.value != 0)
        {
            Ifeature[] featureList = changeableObject.GetComponent<currentModelManager>().CurrentFeatureList;
            //Перебор словаря, который хранит нужные презенторы для каждой способности
            foreach (KeyValuePair<Type,Type> presenterType in FeaturePresentorDictionary.featurePresentorDict)
            {
                if (featureList[dropdown.value - 1].GetType().Name == presenterType.Key.Name)
                {
                    FeaturePresentor featurePresentor = changeableObject.AddComponent(presenterType.Value) as FeaturePresentor;
                    //Заполнения нужными данными презентор
                    featurePresentor.Init(this);
                    featurePresentor.CurrentFeatureUIPresent(changeableObject.GetComponent<currentModelManager>(), dropdown.value - 1);
                }
            }
        }
    }

    //Функция для создания модели
    void SpawnModel()
    {
        Destroy(changeableObject);
        GameObject spawnedObject = Instantiate(currentModelObject.model, Vector3.zero, Quaternion.identity, modelParent);
        spawnedObject.transform.localPosition = new Vector3(0, 0, 0);
        changeableObject = spawnedObject;
    }
}