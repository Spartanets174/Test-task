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

    modelObject currentModelObject;   
    List<modelObject> allModelsObject;
    int currentModelId;

    private void Start()
    {
        currentModelObject = ModelsObject.listModelObject[0];
        allModelsObject = ModelsObject.listModelObject;
        CreateNewModel();
    }
    //������� ��� �������� ������ � ������ ������� ����� ����������
    public void CreateNewModel()
    {
        /*UiManager.ChangeUI(currentModelObject);*/
        SpawnModel();
    }

    //������� ��� �������� ������
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
    //�������� ����������� � ������� id �� �������������� � ������� ������� ������� � ����� ������ ������
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
        CreateNewModel();
    }
}
