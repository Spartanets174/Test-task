
using System;
using System.Collections;
using System.Collections.Generic;
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

    //������� ��� �������� ������
    void spawnModel()
    {
        Destroy(changeableObject);
        GameObject spawnedObject = Instantiate(currentModelObject.model, Vector3.zero, Quaternion.identity, modelParent);
        spawnedObject.transform.localPosition = new Vector3(0, 0, 0);
        changeableObject = spawnedObject;
    }

    //���������� ������� ������� ���������
    void fillFeaturePresenterData(FeaturePresentor featurePresentor,GameObject UI, int dropdownValue)
    {
        featurePresentor.Init(this, UI);
        featurePresentor.currentFeatureUIPresent(changeableObject.GetComponent<currentModelManager>(), dropdownValue);
    }
    

}