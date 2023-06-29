using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBootstrap : MonoBehaviour
{
    //Префаб части интерфейса для спавна в rect scroll
    public GameObject modelPrefab;
    //Родитель куда его спавнить
    public GameObject parentToSpawn;
    //Ссылка на scriptable object со всеми моделями и моделей, выюранной пользователем
    public allModelsObjects modelsObjects;
}
