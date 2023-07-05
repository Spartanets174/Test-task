
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
    public  modelObject currentModelObject;
    public int currentModelId;

    public GameObject DecomposeSlider;
    public GameObject changeColorUI;

    public List<modelObject> allModelsObject;

    GameObject changeableObject;
    
    private void Start()
    {
        newModel();    
    }    
    //Функция для создания модели и вызова функции смены интерфейса
    public void newModel()
    {
        UiManager.changeUI(currentModelObject);
        spawnModel();     
    }
    //Функция, которая активирует выбранную способность в зависимости от номера выбранной опции в дропдаун меню
    public void DropdownActivateFeature(Dropdown dropdown)
    {       
        spawnModel();
        if (dropdown.value != 0)
        {
            Ifeature[] featureList = changeableObject.GetComponent<currentModelManager>().CurrentFeatureList;
            foreach (var presenterType in FeaturePresentorDictionary.featurePresentorDict)
            {
                if (featureList[dropdown.value - 1].GetType().Name == presenterType.Key.Name)
                {
                    FeaturePresentor featurePresentor = changeableObject.AddComponent(presenterType.Value) as FeaturePresentor;
                    fillFeaturePresenterData(featurePresentor, dropdown.value - 1);
                }
            }
        }
    }

    //Функция для создания модели
    void spawnModel()
    {
        Destroy(changeableObject);
        GameObject spawnedObject = Instantiate(currentModelObject.model, Vector3.zero, Quaternion.identity, modelParent);
        spawnedObject.transform.localPosition = new Vector3(0, 0, 0);
        changeableObject = spawnedObject;
    }

    //Заполнения нужными данными презентор
    void fillFeaturePresenterData(FeaturePresentor featurePresentor, int dropdownValue)
    {
        featurePresentor.Init(this);
        featurePresentor.currentFeatureUIPresent(changeableObject.GetComponent<currentModelManager>(), dropdownValue);
    }
    

}