using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerPresenter : MonoBehaviour
{
    public Text nameModel;
    public Text description;
    public Button next;
    public Button prev;
    public Dropdown featureDropdown;

    public GameController GameController;

    private void Awake()
    {
        GameController.OnModelChanged += ChangeUI;
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
        featureDropdown.onValueChanged.AddListener(delegate {
            DropdownActivateFeature(featureDropdown.value-1);
        });
    }

    //Функция, которая активирует нужный презентор способности в зависимости от номера выбранной опции в дропдаун меню
    public void DropdownActivateFeature(int value)
    {
        GameController.SpawnModel();
        if (value >= 0)
        {           
            Ifeature[] featureList = GameController.changeableObject.GetComponent<currentModelManager>().CurrentFeatureList;
            Type featureType = FeaturePresentorDictionary.featurePresenterDict[featureList[value].GetType()];
            FeaturePresentor featurePresentor = GameController.changeableObject.AddComponent(featureType) as FeaturePresentor;
            //Заполнения нужными данными презентор
            featurePresentor.Init(GameController);
            featurePresentor.CurrentFeatureUIPresent(featureList[value]);
        }
    }
}
