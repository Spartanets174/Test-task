using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Скрипт для переключения между моделями
public class modelSwitcher : MonoBehaviour
{
    public gameManager manager;
    //Функция для переключения на следующую
    public void nextModel()
    {
        manager.currentModelId++;
        changeCurrentModel(manager.currentModelId);
    }

    //Функция для переключения на предыдущую
    public void prevModel()
    {
        manager.currentModelId--;
        changeCurrentModel(manager.currentModelId);
    }

    //Проверка переданного в функцию id на принадлежность к области массива моделей и спавн нужной модели
    private void changeCurrentModel(int currentId)
    {
        if (currentId > manager.allModelsObject.Count - 1)
        {
            currentId = 0;
        }
        if (currentId < 0)
        {
            currentId = manager.allModelsObject.Count - 1;
        }

        manager.currentModelObject = manager.allModelsObject[currentId];
        manager.currentModelId = currentId;
        manager.spawnModel();

    }

}
