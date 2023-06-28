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
    public Dropdown featureDropdown;

    GameObject publicSpawnedObject;

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
        List<string> DropOptions = new List<string>();
        normal normal = new normal("Обычное состояние");
        DropOptions.Add(normal.featureName);
        for (int i = 0; i < obj.CurrentFeatureList.Count; i++)
        {
            DropOptions.Add(obj.CurrentFeatureList[i].featureName);
        }

        featureDropdown.ClearOptions();
        featureDropdown.AddOptions(DropOptions);

        featureDropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(featureDropdown);
        });
    }
    void DropdownValueChanged(Dropdown dropdown)
    {
      Debug.Log(dropdown.value);
    }
}

