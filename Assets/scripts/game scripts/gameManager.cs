using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{

    public allModelsObjects ModelsObject;
    public Transform modelParent;
    public Text nameModel;
    public Text description;
    public GameObject publicSpawnedObject;

    void Start()
    {
        spawnModel(ModelsObject.currentModelObject);
    }
    public void spawnModel(modelObject obj)
    {
        Destroy(publicSpawnedObject);    
        nameModel.text = obj.modelName;
        description.text = obj.modelDescription;

        GameObject spawnedObject = Instantiate(obj.model, Vector3.zero, Quaternion.identity, modelParent);
        spawnedObject.transform.localPosition = new Vector3(0, 0, 0);
        publicSpawnedObject = spawnedObject;
    }
}
