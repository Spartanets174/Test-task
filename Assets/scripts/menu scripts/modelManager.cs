using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�������� ������ ��� ����
public class modelManager : MonoBehaviour
{
    //������ ����� ���������� ��� ������ � rect scroll
    public GameObject modelPrefab;
    //�������� ���� ��� ��������
    public GameObject parentToSpawn;
    //������ �� scriptable object �� ����� �������� � �������, ��������� �������������
    public allModelsObjects modelsObjects;


    List<modelObject> models;

    private void Start()
    {
        models = modelsObjects.listModelObject;
        //����, ��������� ������� ���������� � rect scroll
        for (int i = 0; i < models.Count; i++)
        {
            //����� ������ ���������� � ���������� ����������
            GameObject modelObject = Instantiate(modelPrefab, Vector3.zero, Quaternion.identity, parentToSpawn.transform);
            modelObject.transform.localPosition = new Vector3(0, 0, 0);
            modelObject.transform.GetComponent<modelDisplay>().modelObject = models[i];

            //����� 3d ������ �� ���������
            GameObject model = Instantiate(models[i].model, Vector3.zero, Quaternion.identity, modelObject.transform.GetChild(1).transform);
            model.transform.localPosition = new Vector3(0, 0, 0);

            //������ ������ ��� ������ ��������� ��� ����������� �����������
            model.transform.localScale = new Vector3(100, 100, 100);
            model.layer = 5;
            for (int j = 0; j < model.transform.childCount; j++)
            {
                model.transform.GetChild(j).gameObject.layer = 5;
            }
        }
    }
}
