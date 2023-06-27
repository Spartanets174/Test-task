using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New model object", menuName = "Model object")]
public class modelObject : ScriptableObject
{
    public GameObject model;
    public string modelName;
    public string modelDescription;
    public List<GameObject> cutList;
    public GameObject decomposeCenter;
    public List<GameObject> decomposeList;
    
}
