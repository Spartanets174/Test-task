using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;
using UnityEngine.UI;


//Основной скрипт во время просмотра модели
public class gameManager : MonoBehaviour
{
    public UIManager UiManager;

    public Transform modelParent;

    public  List<modelObject> allModelsObject;

    public  modelObject currentModelObject;
    public int currentModelId;

    GameObject changeableObject;
    
    private void Start()
    {
        spawnModel();
    }

    //Функция для создания модели и переопределения способностей у созданной модели
    public void spawnModel()
    {
        UiManager.changeUI(currentModelObject);
        Destroy(changeableObject);
        GameObject spawnedObject = Instantiate(currentModelObject.model, Vector3.zero, Quaternion.identity, modelParent);
        spawnedObject.transform.localPosition = new Vector3(0, 0, 0);
        changeableObject = spawnedObject;

        //Добавление функции в Dropdown по клику на элемент
        UiManager.featureDropdown.onValueChanged.AddListener(delegate {
            DropdownActivateFeature(UiManager.featureDropdown, changeableObject);
        });
    }

    //Функция, которая активирует выбранную способность в зависимости от номера выбранной опции в дропдаун меню
    void DropdownActivateFeature(Dropdown dropdown, GameObject model)
    {
        Destroy(model);
        GameObject spawnedObject = Instantiate(currentModelObject.model, Vector3.zero, Quaternion.identity, modelParent);
        spawnedObject.transform.localPosition = new Vector3(0, 0, 0);
        changeableObject = spawnedObject;
        if (dropdown.value != 0)
        {
            spawnedObject.GetComponent<currentModelManager>().CurrentFeatureList[dropdown.value - 1]?.featureRealization(spawnedObject);
        }
    }
}

