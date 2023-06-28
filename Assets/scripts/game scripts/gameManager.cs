using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{

    public allModelsObjects ModelsObject;
    public Transform modelParent;
    public Text nameModel;
    public Text description;
    public Dropdown featureDropdown;
    public currentModelManager currentModelManager;

    GameObject publicSpawnedObject;
    normal normal;

    void Start()
    {
        currentModelManager.ifeatures = ModelsObject.currentModelObject.CurrentFeatureList;
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
        currentModelManager.model = spawnedObject;

        List<string> DropOptions = new List<string>();
        normal = new normal();
        DropOptions.Add(normal.Name);

        featureDropdown.ClearOptions();
        

        for (int i = 0; i < obj.CurrentFeatureList.Length; i++)
        {
            DropOptions.Add(obj.CurrentFeatureList[i]?.Name);
        }
        featureDropdown.AddOptions(DropOptions);

        featureDropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(featureDropdown, obj);
        });
    }
    void DropdownValueChanged(Dropdown dropdown, modelObject model)
    {
        if (dropdown.value == 0)
        {
            normal.featureRealization(currentModelManager.model);
        }
        else
        {
            model.CurrentFeatureList[dropdown.value - 1]?.featureRealization(currentModelManager.model);
        }
    }
}

