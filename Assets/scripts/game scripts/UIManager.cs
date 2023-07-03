using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text nameModel;
    public Text description;
    public Button next;
    public Button prev;

    public Dropdown featureDropdown;
    public modelSwitcher modelSwitcher;
    public gameManager gameManager;

    private void Start()
    {
        next.onClick.AddListener(() =>
        {
            modelSwitcher.nextModel();
        });
        prev.onClick.AddListener(() =>
        {
            modelSwitcher.prevModel();
        });
    }

    public void changeUI(modelObject currentModelObject)
    {
        nameModel.text = currentModelObject.modelName;
        description.text = currentModelObject.modelDescription;
        currentModelManager currentModel = currentModelObject.model.GetComponent<currentModelManager>();

        //Добавление нормального состояния
        List<string> DropOptions = new List<string> { "Обычное состояние" };

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
            gameManager.DropdownActivateFeature(featureDropdown);
        });
    }
    
}
