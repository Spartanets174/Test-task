using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//������ ��� ����������� ���������� � ������ � ���������
public class modelDisplay : MonoBehaviour
{
    public modelObject modelObject;
    public Text modelName;
    public Image modelImage;
    public allModelsObjects ModelsObject;

    private void Start()
    {
        modelName.text = modelObject.modelName;
        modelImage.sprite = modelObject.modelImage;
    }

    //������ � scriptable object ��������� ������������� ������
    public void onCick()
    {
        ModelsObject.currentModelObject = modelObject;
    }
}
