using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//Скрипт для отображения информации о модели в интерфейс
public class modelDisplay : MonoBehaviour
{
    public modelObject modelObject;
    public Text modelName;
    public allModelsObjects ModelsObject;

    private void Start()
    {
        modelName.text = modelObject.modelName;
    }

    //Запись в scriptable object выбранной пользователем модели
    public void onCick()
    {
        ModelsObject.currentModelObject = modelObject;
    }
}
