using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text nameModel;
    public Text description;
    //Дропдаун меню для способностей
    public Dropdown featureDropdown;

    public void changeUI(modelObject currentModelObject)
    {
        nameModel.text = currentModelObject.modelName;
        description.text = currentModelObject.modelDescription;

        //Добавление нормального состояния
        List<string> DropOptions = new List<string> { "Обычное состояние" };

        featureDropdown.ClearOptions();
        featureDropdown.onValueChanged.RemoveAllListeners();

        currentModelManager currentModel = currentModelObject.model.GetComponent<currentModelManager>();
        //Добавление способностей в дропдаун меню для выбора
        for (int i = 0; i < currentModel.CurrentFeatureList.Length; i++)
        {
            DropOptions.Add(currentModel.CurrentFeatureList[i]?.Name);
        }
        featureDropdown.AddOptions(DropOptions);

    }
}
