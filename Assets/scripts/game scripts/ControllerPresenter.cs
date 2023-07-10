using RotaryHeart.Lib.SerializableDictionary;
using System;
using System.Collections.Generic;
using TypeReferences;
using UnityEngine;
using UnityEngine.UI;

public class ControllerPresenter : MonoBehaviour
{
    public Canvas canvas;

    public MyDictioanary TypePresenterDict;

    public Text nameModel;
    public Text description;
    public Button next;
    public Button prev;
    public Dropdown featureDropdown;

    public GameController GameController;

    GameObject spawnedUI;

    private void Awake()
    {
        GameController.OnModelChanged += ChangeUI;
        GameController.OnModelChanged += DestroyUI;
        next.onClick.AddListener(() =>
        {
            GameController.NextModel();
        });
        prev.onClick.AddListener(() =>
        {
            GameController.PrevModel();
        });
    }

    public void ChangeUI(modelObject currentModelObject)
    {
        nameModel.text = currentModelObject.modelName;
        description.text = currentModelObject.modelDescription;
        currentModelManager currentModel = currentModelObject.model.GetComponent<currentModelManager>();

        //Добавление нормального состояния
        List<string> DropOptions = new() { "Обычное состояние" };

        featureDropdown.ClearOptions();
        featureDropdown.onValueChanged.RemoveAllListeners();

        //Добавление способностей в дропдаун меню для выбора
        for (int i = 0; i < currentModel.CurrentFeatureList.Length; i++)
        {
            DropOptions.Add(currentModel.CurrentFeatureList[i]?.Name);
        }
        featureDropdown.AddOptions(DropOptions);

        //Добавление функции в Dropdown по клику на элемент
        featureDropdown.onValueChanged.AddListener(ActivateFeature);
    }

    //Функция, которая активирует нужный презентор способности в зависимости от номера выбранной опции в дропдаун меню
    public void ActivateFeature(int value)
    {
        Destroy(spawnedUI);
        value--;
        GameController.SpawnModel();
        if (value >= 0)
        {           
            Ifeature[] featureList = GameController.changeableObject.GetComponent<currentModelManager>().CurrentFeatureList;
            
            foreach (var (key, item) in TypePresenterDict)
            {
                if (featureList[value].ToString() == item.featureType.ToString())
                {
                    spawnedUI = Instantiate(key, Vector3.zero, Quaternion.identity, canvas.transform);
                    FeaturePresentor featurePresentor = spawnedUI.GetComponent<FeaturePresentor>();
                    spawnedUI.transform.localPosition = Vector3.zero;
                    //Заполнения нужными данными презентор
                    featurePresentor.Init(GameController);
                    featurePresentor.CurrentFeatureUIPresent(featureList[value]);
                }
            }                    
        }
    }

    private void DestroyUI(modelObject currentModelObject)
    {
        Destroy(spawnedUI);
    }
}


[Serializable]
public class MyDictioanary : SerializableDictionaryBase<GameObject, FeatureType> { }

[Serializable]
public class FeatureType 
{
    [Inherits(typeof(Ifeature), ShortName = true)] public TypeReference featureType;
}
