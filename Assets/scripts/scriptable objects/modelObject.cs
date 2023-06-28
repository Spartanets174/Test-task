using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;

[CreateAssetMenu(fileName = "New model object", menuName = "Model object")]
public class modelObject : ScriptableObject
{
    public GameObject model;
    public string modelName;
    public string modelDescription;
    [SerializeReference, SubclassSelector] public Ifeature[] CurrentFeatureList = Array.Empty<Ifeature>();
};    

