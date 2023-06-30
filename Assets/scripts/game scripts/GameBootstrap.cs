using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//������-������ �� ������, �������� ��� ������
public class GameBootstrap : MonoBehaviour
{
    public allModelsObjects ModelsObject;    

    public gameManager gameManager;

    //������������� ������ ��������� � gameManager � ����������� �������� �� �������� ������������
    void Awake()
    { 
        gameManager.allModelsObject = ModelsObject.listModelObject;
        gameManager.currentModelObject = ModelsObject.currentModelObject;
        for (int i = 0; i < ModelsObject.listModelObject.Count; i++)
        {
            if (ModelsObject.listModelObject[i].modelName == ModelsObject.currentModelObject.modelName)
            {
                gameManager.currentModelId = i;
                break;
            }
        }
    }
}
