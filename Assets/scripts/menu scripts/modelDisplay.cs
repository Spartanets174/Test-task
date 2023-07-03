using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//������ ��� ����������� ���������� � ������ � ���������
public class modelDisplay : MonoBehaviour
{
    public modelManager manager;
    public modelObject modelObject;
    public Text modelName;
    public Image modelImage;

    private void Start()
    {
        modelName.text = modelObject.modelName;
        modelImage.sprite = modelObject.modelImage;
        this.GetComponent<Button>().onClick.AddListener(delegate {
            manager.clickOnModel(modelObject);
        });       
    }

    //������ � scriptable object ��������� ������������� ������
    
}
