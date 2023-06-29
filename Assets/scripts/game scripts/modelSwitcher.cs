using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Скрипт для переключения между моделями
public class modelSwitcher : MonoBehaviour
{
    public gameManager manager;
    //Функция для переключения на следующую
    public void nextModel()
    {
        manager.currentModelId++;
        spawnObject(manager.currentModelId);       
    }

    //Функция для переключения на предыдущую
    public void prevModel()
    {
        manager.currentModelId--;
        spawnObject(manager.currentModelId);
    }
    // Сохранение id выбранной пользователем модели

    //Проверка переданного в функцию id на принадлежность к области массива моделей и спавн нужной модели
    private void spawnObject(int currentId)
    {
        Debug.Log(manager.currentModelId);
        if (currentId > manager.ModelsObject.listModelObject.Count-1)
        {
            currentId = 0;            
        }
        if (currentId<0)
        {
            currentId = manager.ModelsObject.listModelObject.Count-1;            
        }
        
        
        manager.spawnModel(manager.ModelsObject.listModelObject[currentId]);
        manager.ModelsObject.currentModelObject = manager.ModelsObject.listModelObject[currentId];
        manager.currentModelId = currentId;

        Debug.Log(manager.currentModelId);
    }

}
