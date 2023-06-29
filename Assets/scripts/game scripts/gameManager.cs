using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;
using UnityEngine.UI;


//�������� ������ �� ����� ��������� ������
public class gameManager : MonoBehaviour
{
    //������ �� ������, �������� ��������� ������������� �� ����� ����
    public allModelsObjects ModelsObject;
    //�������� ���� �������� ��������
    public Transform modelParent;
    public Text nameModel;
    public Text description;
    //�������� ���� ��� ������������
    public Dropdown featureDropdown;
    //������ �� ������, ������� ������ ������ ����������� �� �����
    public currentModelManager currentModelManager;
    public int currentModelId;

    //����������, ������� ��������� ������ ��� �������� ��� ������������ �� ���������/����������
    GameObject publicSpawnedObject;
    //���������� ����������� ���������

    void Start()
    {
        for (int i = 0; i < ModelsObject.listModelObject.Count; i++)
        {
            if (ModelsObject.listModelObject[i].modelName == ModelsObject.currentModelObject.modelName)
            {
                Debug.Log(i);
                currentModelId = i;
                break;
            }
        }
        //������ ������ ������������
        spawnModel(ModelsObject.currentModelObject);
    }
    //������� ��� �������� ������ � ��������������� ������������ � ��������� ������
    public void spawnModel(modelObject obj)
    {
        //��������� � �������������� ������������ ��� ����� ������
        currentModelManager.ifeatures = null;
        currentModelManager.ifeatures = obj.CurrentFeatureList;
        //�������� ���������� ������
        Destroy(publicSpawnedObject); 
        
        //���������� ����������
        nameModel.text = obj.modelName;
        description.text = obj.modelDescription;

        //����� ����� ������
        GameObject spawnedObject = Instantiate(obj.model, Vector3.zero, Quaternion.identity, modelParent);
        spawnedObject.transform.localPosition = new Vector3(0, 0, 0);
        publicSpawnedObject = spawnedObject;
        currentModelManager.model = spawnedObject;

        //���������� ����������� ���������
        List<string> DropOptions = new List<string> {"������� ���������"};

        featureDropdown.ClearOptions();
        featureDropdown.onValueChanged.RemoveAllListeners();
        
        //���������� ������������ � �������� ���� ��� ������
        for (int i = 0; i < obj.CurrentFeatureList.Length; i++)
        {
            DropOptions.Add(obj.CurrentFeatureList[i]?.Name);
        }
        featureDropdown.AddOptions(DropOptions);

        //���������� ������ ��� ������������ ����� � �������� ����
        featureDropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(featureDropdown, obj);
        });
    }

    //�������, ������� ���������� ��������� ����������� � ����������� �� ������ ��������� ����� � �������� ����
    void DropdownValueChanged(Dropdown dropdown, modelObject model)
    {

        Destroy(currentModelManager.model);
        GameObject spawnedObject = Instantiate(ModelsObject.currentModelObject.model, Vector3.zero, Quaternion.identity, modelParent);
        spawnedObject.transform.localPosition = new Vector3(0, 0, 0);
        publicSpawnedObject = spawnedObject;
        currentModelManager.model = spawnedObject;
        if (dropdown.value != 0)
        {
            model.CurrentFeatureList[dropdown.value - 1]?.featureRealization(currentModelManager.model);
        }
    }
}

