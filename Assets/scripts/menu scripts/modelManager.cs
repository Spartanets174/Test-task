using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�������� ������ ��� ����
public class modelManager : MonoBehaviour
{
    public MenuBootstrap menuBootstrap;
    List<modelObject> models;
    private void Start()
    {
        models = menuBootstrap.modelsObjects.listModelObject;
        //����, ��������� ������� ���������� � rect scroll
        for (int i = 0; i < models.Count; i++)
        {
            //����� ������ ���������� � ���������� ����������
            GameObject modelObject = Instantiate(menuBootstrap.modelPrefab, Vector3.zero, Quaternion.identity, menuBootstrap.parentToSpawn.transform);
            modelObject.transform.localPosition = new Vector3(0, 0, 0);
            modelObject.transform.GetComponent<modelDisplay>().modelObject = models[i];
        }
    }
}
