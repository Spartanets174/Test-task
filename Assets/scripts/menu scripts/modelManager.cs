using System.Collections.Generic;
using UnityEngine;

//�������� ������ ��� ����
public class modelManager : MonoBehaviour
{
    public MenuBootstrap menuBootstrap;
    public menuScript menu;
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
            modelObject.transform.GetComponent<modelDisplay>().manager = this;
        }
    }
     
    public void clickOnModel(modelObject modelObject)
    {
        /*menuBootstrap.modelsObjects.currentModelObject = modelObject;*/
        menu.toGame();
    }
}
