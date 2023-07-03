using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//������ ��� ������������ ����� ��������
public class modelSwitcher : MonoBehaviour
{
    public gameManager manager;
    //������� ��� ������������ �� ���������
    public void nextModel()
    {
        manager.currentModelId++;
        changeCurrentModel(manager.currentModelId);
    }

    //������� ��� ������������ �� ����������
    public void prevModel()
    {
        manager.currentModelId--;
        changeCurrentModel(manager.currentModelId);
    }

    //�������� ����������� � ������� id �� �������������� � ������� ������� ������� � ����� ������ ������
    private void changeCurrentModel(int currentId)
    {
        if (currentId > manager.allModelsObject.Count - 1)
        {
            currentId = 0;
        }
        if (currentId < 0)
        {
            currentId = manager.allModelsObject.Count - 1;
        }

        manager.currentModelObject = manager.allModelsObject[currentId];
        manager.currentModelId = currentId;
        manager.spawnModel();

    }

}
