using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class modelDisplay : MonoBehaviour
{
    public modelObject modelObject;
    public Text modelName;
    public allModelsObjects ModelsObject;

    private void Start()
    {
        modelName.text = modelObject.modelName;
    }
    public void onCick()
    {
        ModelsObject.currentModelObject = modelObject;
    }
}
