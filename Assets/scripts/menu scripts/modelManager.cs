using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Основной скрипт для меню
public class modelManager : MonoBehaviour
{
    //Префаб части интерфейса для спавна в rect scroll
    public GameObject modelPrefab;
    //Родитель куда его спавнить
    public GameObject parentToSpawn;
    //Ссылка на scriptable object со всеми моделями и моделей, выюранной пользователем
    public allModelsObjects modelsObjects;


    List<modelObject> models;

    private void Start()
    {
        models = modelsObjects.listModelObject;
        //Цикл, спавнящий объекты интерфейса в rect scroll
        for (int i = 0; i < models.Count; i++)
        {
            //Спавн самого интерфейса и заполнение интерфейса
            GameObject modelObject = Instantiate(modelPrefab, Vector3.zero, Quaternion.identity, parentToSpawn.transform);
            modelObject.transform.localPosition = new Vector3(0, 0, 0);
            modelObject.transform.GetComponent<modelDisplay>().modelObject = models[i];

            //Спавн 3d модели на интерфейс
            GameObject model = Instantiate(models[i].model, Vector3.zero, Quaternion.identity, modelObject.transform.GetChild(1).transform);
            model.transform.localPosition = new Vector3(0, 0, 0);

            //Подгон модели под нужные параметры для правильного отображеиня
            model.transform.localScale = new Vector3(100, 100, 100);
            model.layer = 5;
            for (int j = 0; j < model.transform.childCount; j++)
            {
                model.transform.GetChild(j).gameObject.layer = 5;
            }
        }
    }
}
