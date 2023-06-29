using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;
using UnityEngine.UI;


//Основной скрипт во время просмотра модели
public class gameManager : MonoBehaviour
{
    //Ссылка на объект, хранящий выбранный пользователем на сцене меню
    public allModelsObjects ModelsObject;
    //родитель куда спавнить модельку
    public Transform modelParent;
    public Text nameModel;
    public Text description;
    //Дропдаун меню для способностей
    public Dropdown featureDropdown;
    //Ссылка на объект, который хранит нужные способности на сцене
    public currentModelManager currentModelManager;
    public int currentModelId;

    //Переменная, которая сохраняет объект для удаления при переключении на следующий/предыдущий
    GameObject publicSpawnedObject;
    //Переменная нормального состояния

    void Start()
    {
        for (int i = 0; i < ModelsObject.listModelObject.Count; i++)
        {
            if (ModelsObject.listModelObject[i].modelName == ModelsObject.currentModelObject.modelName)
            {
                Debug.Log(i);
                currentModelId = i;
                break;
            }
        }
        //Запись нужных способностей
        spawnModel(ModelsObject.currentModelObject);
    }
    //Функция для создания модели и переопределения способностей у созданной модели
    public void spawnModel(modelObject obj)
    {
        //Обнуление и перезаполнение способностей для новой модели
        currentModelManager.ifeatures = null;
        currentModelManager.ifeatures = obj.CurrentFeatureList;
        //Удаление предыдущей модели
        Destroy(publicSpawnedObject); 
        
        //Заполнение интерфейса
        nameModel.text = obj.modelName;
        description.text = obj.modelDescription;

        //Спавн новой модели
        GameObject spawnedObject = Instantiate(obj.model, Vector3.zero, Quaternion.identity, modelParent);
        spawnedObject.transform.localPosition = new Vector3(0, 0, 0);
        publicSpawnedObject = spawnedObject;
        currentModelManager.model = spawnedObject;

        //Добавление нормального состояния
        List<string> DropOptions = new List<string> {"Обычное состояние"};

        featureDropdown.ClearOptions();
        featureDropdown.onValueChanged.RemoveAllListeners();
        
        //Добавление способностей в дропдаун меню для выбора
        for (int i = 0; i < obj.CurrentFeatureList.Length; i++)
        {
            DropOptions.Add(obj.CurrentFeatureList[i]?.Name);
        }
        featureDropdown.AddOptions(DropOptions);

        //Добавление ивента при переключении опций в дропдаун меню
        featureDropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(featureDropdown, obj);
        });
    }

    //Функция, которая активирует выбранную способность в зависимости от номера выбранной опции в дропдаун меню
    void DropdownValueChanged(Dropdown dropdown, modelObject model)
    {

        Destroy(currentModelManager.model);
        GameObject spawnedObject = Instantiate(ModelsObject.currentModelObject.model, Vector3.zero, Quaternion.identity, modelParent);
        spawnedObject.transform.localPosition = new Vector3(0, 0, 0);
        publicSpawnedObject = spawnedObject;
        currentModelManager.model = spawnedObject;
        if (dropdown.value != 0)
        {
            model.CurrentFeatureList[dropdown.value - 1]?.featureRealization(currentModelManager.model);
        }
    }
}

