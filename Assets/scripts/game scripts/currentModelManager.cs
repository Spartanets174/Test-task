using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;

//Скрипт для выбора настройки нужных способностей модели
public class currentModelManager : MonoBehaviour
{
    //Список всех способностей, которые можно выбрать для модели
    [SerializeReference, SubclassSelector] public Ifeature[] CurrentFeatureList = Array.Empty<Ifeature>();
}
