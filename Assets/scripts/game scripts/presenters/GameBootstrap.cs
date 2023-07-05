using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Скрипт-ссылка на объект, хранящий все модели
public class GameBootstrap : MonoBehaviour
{
    public allModelsObjects ModelsObject;
    public GameObject changeColorUI;
    public GameObject DecomposeSlider;
    public gameManager gameManager;

    //Устанавливает нужные перменные в gameManager в определённые значения от действий пользователя
    void Awake()
    { 
        gameManager.allModelsObject = ModelsObject.listModelObject;
        gameManager.currentModelObject = ModelsObject.currentModelObject;
        gameManager.DecomposeSlider = DecomposeSlider;
        gameManager.changeColorUI = changeColorUI;
        for (int i = 0; i < ModelsObject.listModelObject.Count; i++)
        {
            if (ModelsObject.listModelObject[i].modelName == ModelsObject.currentModelObject.modelName)
            {
                gameManager.currentModelId = i;
                break;
            }
        }
    }
}
