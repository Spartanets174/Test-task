
using System;
using System.Collections;
using System.Collections.Generic;
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
            switch (featureList[dropdown.value - 1].GetType().Name)
            {
                
                case nameof(cutFeature):
                    CutFeaturePresenter cutPresent = changeableObject.AddComponent(typeof(CutFeaturePresenter)) as CutFeaturePresenter;
                    fillFeaturePresenterData(cutPresent, null, dropdown.value - 1);
                    break;
                case nameof(decomposeFeature):
                    DecomposeFeaturePresenter decomposePresent = changeableObject.AddComponent(typeof(DecomposeFeaturePresenter)) as DecomposeFeaturePresenter;
                    fillFeaturePresenterData(decomposePresent, DecomposeSlider, dropdown.value - 1);
                    break;
                case nameof(colorChange):
                    ColorFeaturePresentor colorPresent = changeableObject.AddComponent(typeof(ColorFeaturePresentor)) as ColorFeaturePresentor;
                    fillFeaturePresenterData(colorPresent, changeColorUI, dropdown.value - 1);
                    break;
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
    void fillFeaturePresenterData(FeaturePresentor featurePresentor,GameObject UI, int dropdownValue)
    {
        featurePresentor.Init(this, UI);
        featurePresentor.currentFeatureUIPresent(changeableObject.GetComponent<currentModelManager>(), dropdownValue);
    }
    

}