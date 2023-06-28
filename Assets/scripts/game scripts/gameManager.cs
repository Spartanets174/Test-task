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

    //Переменная, которая сохраняет объект для удаления при переключении на следующий/предыдущий
    GameObject publicSpawnedObject;
    //Переменная нормального состояния
    normal normal;

    void Start()
    {
        //Запись нужных способностей
        currentModelManager.ifeatures = ModelsObject.currentModelObject.CurrentFeatureList;
        spawnModel(ModelsObject.currentModelObject);
    }
    //Функция для создания модели и переопределения способностей у созданной модели
    public void spawnModel(modelObject obj)
    {
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
        List<string> DropOptions = new List<string>();
        normal = new normal();
        DropOptions.Add(normal.Name);

        featureDropdown.ClearOptions();
        
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
        if (dropdown.value == 0)
        {
            normal.featureRealization(currentModelManager.model);
        }
        else
        {
            model.CurrentFeatureList[dropdown.value - 1]?.featureRealization(currentModelManager.model);
        }
    }
}

