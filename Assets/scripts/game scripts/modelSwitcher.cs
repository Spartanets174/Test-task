using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//������ ��� ������������ ����� ��������
public class modelSwitcher : MonoBehaviour
{
    public gameManager manager;
    //������� ��� ������������ �� ���������
    public void nextModel()
    {
        manager.currentModelId++;
        spawnObject(manager.currentModelId);       
    }

    //������� ��� ������������ �� ����������
    public void prevModel()
    {
        manager.currentModelId--;
        spawnObject(manager.currentModelId);
    }
    // ���������� id ��������� ������������� ������

    //�������� ����������� � ������� id �� �������������� � ������� ������� ������� � ����� ������ ������
    private void spawnObject(int currentId)
    {
        Debug.Log(manager.currentModelId);
        if (currentId > manager.ModelsObject.listModelObject.Count-1)
        {
            currentId = 0;            
        }
        if (currentId<0)
        {
            currentId = manager.ModelsObject.listModelObject.Count-1;            
        }
        
        
        manager.spawnModel(manager.ModelsObject.listModelObject[currentId]);
        manager.ModelsObject.currentModelObject = manager.ModelsObject.listModelObject[currentId];
        manager.currentModelId = currentId;

        Debug.Log(manager.currentModelId);
    }

}
