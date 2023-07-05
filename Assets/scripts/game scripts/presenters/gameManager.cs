
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
    //������� ��� �������� ������ � ������ ������� ����� ����������
    public void NewModel()
    {
        UiManager.ChangeUI(currentModelObject);
        SpawnModel();     
    }
    //�������, ������� ���������� ������ ��������� ����������� � ����������� �� ������ ��������� ����� � �������� ����
    public void DropdownActivateFeature(Dropdown dropdown)
    {       
        SpawnModel();
        if (dropdown.value != 0)
        {
            Ifeature[] featureList = changeableObject.GetComponent<currentModelManager>().CurrentFeatureList;
            //������� �������, ������� ������ ������ ���������� ��� ������ �����������
            foreach (KeyValuePair<Type,Type> presenterType in FeaturePresentorDictionary.featurePresentorDict)
            {
                if (featureList[dropdown.value - 1].GetType().Name == presenterType.Key.Name)
                {
                    FeaturePresentor featurePresentor = changeableObject.AddComponent(presenterType.Value) as FeaturePresentor;
                    //���������� ������� ������� ���������
                    featurePresentor.Init(this);
                    featurePresentor.CurrentFeatureUIPresent(changeableObject.GetComponent<currentModelManager>(), dropdown.value - 1);
                }
            }
        }
    }

    //������� ��� �������� ������
    void SpawnModel()
    {
        Destroy(changeableObject);
        GameObject spawnedObject = Instantiate(currentModelObject.model, Vector3.zero, Quaternion.identity, modelParent);
        spawnedObject.transform.localPosition = new Vector3(0, 0, 0);
        changeableObject = spawnedObject;
    }
}