using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;

//Скрипт для отображения способностей выбранной модели во время работы программы
public class currentModelManager : MonoBehaviour
{
   public GameObject model;
    //Список всех способностей, которые можно выбрать для модели
    [SerializeReference, SubclassSelector] public Ifeature[] CurrentFeatureList = Array.Empty<Ifeature>();
}
