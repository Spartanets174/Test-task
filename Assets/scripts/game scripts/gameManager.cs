
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


//Основной скрипт во время просмотра модели
public class gameManager : MonoBehaviour
{
    public UIManager UiManager;

    public Dictionary<Ifeature, FeaturePresentor> Presentors = new Dictionary<Ifeature, FeaturePresentor>();
    [SerializeReference, SubclassSelector] FeaturePresentor[] CurrentFeaturePresentorList = Array.Empty<FeaturePresentor>();
    [SerializeReference, SubclassSelector] Ifeature[] List = Array.Empty<Ifeature>();
    public Transform modelParent;

    public  List<modelObject> allModelsObject;

    public  modelObject currentModelObject;
    public int currentModelId;

    GameObject changeableObject;
    
    private void Start()
    {
       

         List<FeaturePresentor> list =  GetAll().ToList();
        Debug.Log(list[0]);

        /*  Presentors.Add(List[0],CurrentFeaturePresentorList[0]);*/
        spawnModel();
    }
    IEnumerable<FeaturePresentor> GetAll()
    {
        return AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.IsSubclassOf(typeof(FeaturePresentor)))
            .Select(type => Activator.CreateInstance(type) as FeaturePresentor);
    }
    //Функция для создания модели и переопределения способностей у созданной модели
    public void spawnModel()
    {
        UiManager.changeUI(currentModelObject);
        Destroy(changeableObject);
        GameObject spawnedObject = Instantiate(currentModelObject.model, Vector3.zero, Quaternion.identity, modelParent);
        spawnedObject.transform.localPosition = new Vector3(0, 0, 0);
        changeableObject = spawnedObject;       
    }
    //Функция, которая активирует выбранную способность в зависимости от номера выбранной опции в дропдаун меню
    public void DropdownActivateFeature(Dropdown dropdown)
    {
        Destroy(changeableObject);
        GameObject spawnedObject = Instantiate(currentModelObject.model, Vector3.zero, Quaternion.identity, modelParent);
        spawnedObject.transform.localPosition = new Vector3(0, 0, 0);
        changeableObject = spawnedObject;
        if (dropdown.value != 0)
        {
            spawnedObject.GetComponent<currentModelManager>().CurrentFeatureList[dropdown.value - 1]?.featureRealization(spawnedObject); 
        }
    }

}

/*[Serializable]
public class MyDictioanary : SerializableDictionaryBase<PresentorType, > { }
*/
public enum PresentorType
{
    turnOnOff,
    valueChange,
    changeProperty
}