using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Скрипт для переключения между моделями
public class modelSwitcher : MonoBehaviour
{
    public gameManager manager;

    int  currentModelId;
    void Start()
    {
        //Сохранение id выбранной пользователем модели
        for (int i = 0; i < manager.ModelsObject.listModelObject.Count; i++)
        {
            if (manager.ModelsObject.listModelObject[i].modelName== manager.ModelsObject.currentModelObject.modelName)
            {
                currentModelId = i;
            }
        }
    }
    
    
    //Функция для переключения на следующую
    public void nextModel()
    {
        currentModelId++;
        currentModelId = makeValidId(currentModelId);
        manager.spawnModel(manager.ModelsObject.listModelObject[currentModelId]);
    }

    //Функция для переключения на предыдущую
    public void prevModel()
    {
        currentModelId--;
        currentModelId=makeValidId(currentModelId);
        manager.spawnModel(manager.ModelsObject.listModelObject[currentModelId]);
    }

    //Проверка переданного в функцию id на принадлежность к области массива моделей
    private int makeValidId(int currentId)
    {
        if (currentId >= manager.ModelsObject.listModelObject.Count)
        {
            currentId = 0;
            return currentId;
        }
        if (currentId<0)
        {
            currentId = manager.ModelsObject.listModelObject.Count-1;
            return currentId;
        }
        return currentId;
    }

}
