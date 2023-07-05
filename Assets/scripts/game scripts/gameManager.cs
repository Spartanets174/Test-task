
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


//�������� ������ �� ����� ��������� ������
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
    //������� ��� �������� ������ � ������ ������� ����� ����������
    public void newModel()
    {
        UiManager.changeUI(currentModelObject);
        spawnModel();     
    }
    //�������, ������� ���������� ��������� ����������� � ����������� �� ������ ��������� ����� � �������� ����
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

    //������� ��� �������� ������
    void spawnModel()
    {
        Destroy(changeableObject);
        GameObject spawnedObject = Instantiate(currentModelObject.model, Vector3.zero, Quaternion.identity, modelParent);
        spawnedObject.transform.localPosition = new Vector3(0, 0, 0);
        changeableObject = spawnedObject;
    }

    //���������� ������� ������� ���������
    void fillFeaturePresenterData(FeaturePresentor featurePresentor, int dropdownValue)
    {
        featurePresentor.Init(this);
        featurePresentor.currentFeatureUIPresent(changeableObject.GetComponent<currentModelManager>(), dropdownValue);
    }
    

}