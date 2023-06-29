using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;

[CreateAssetMenu(fileName = "New model object", menuName = "Model object")]
//ScriptableObject с основной информацией о модели
public class modelObject : ScriptableObject
{
    //Сама моделька
    public GameObject model;
    //Текстовое описание и имя
    public string modelName;
    public string modelDescription;
    public Sprite modelImage;
    
};    

