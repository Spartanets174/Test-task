using RotaryHeart.Lib.SerializableDictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ControllerPresenter : MonoBehaviour
{
    public Canvas canvas;

    public MyDictioanary dict;
    public List<GameObject> ViewList;

    public GameObject DecomposeView;
    public GameObject changeColorView;
    public GameObject cutView;

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
            FeaturePresentor featurePresentor = null;
       /*     for (int i = 0; i < ViewList.Count; i++)
            {
                if (featureList[value].Equals(ViewList[i].))
                {

                }
            }*/
           
            if (featureList[value].Name == "Декомпозиция")
            {
                spawnedUI = Instantiate(DecomposeView,Vector3.zero,Quaternion.identity, canvas.transform);
               featurePresentor = spawnedUI.GetComponent<DecomposeFeaturePresenter>();
            }
            if (featureList[value].Name == "Смена цвета")
            {
                spawnedUI = Instantiate(changeColorView, Vector3.zero, Quaternion.identity, canvas.transform);
                featurePresentor = spawnedUI.GetComponent<ColorFeaturePresentor>();
            }
            if (featureList[value].Name == "Разрез")
            {
                spawnedUI = Instantiate(cutView, Vector3.zero, Quaternion.identity, canvas.transform);
                featurePresentor = spawnedUI.GetComponent<CutFeaturePresenter>();
            }
            spawnedUI.transform.localPosition = Vector3.zero;
            //Заполнения нужными данными презентор
            featurePresentor.Init(GameController);
            featurePresentor.CurrentFeatureUIPresent(featureList[value]);
        }
    }
}
[Serializable]
public class MyDictioanary : SerializableDictionaryBase<string, string> { }