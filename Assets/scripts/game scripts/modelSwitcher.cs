using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modelSwitcher : MonoBehaviour
{
    public gameManager manager;

    int  currentModelId;
    void Start()
    {
        for (int i = 0; i < manager.ModelsObject.listModelObject.Count; i++)
        {
            if (manager.ModelsObject.listModelObject[i].modelName== manager.ModelsObject.currentModelObject.modelName)
            {
                currentModelId = i;
            }
        }
    }
    
    

    public void nextModel()
    {
        currentModelId++;
        currentModelId = makeValidId(currentModelId);
        manager.spawnModel(manager.ModelsObject.listModelObject[currentModelId]);
    }
    public void prevModel()
    {
        currentModelId--;
        currentModelId=makeValidId(currentModelId);
        manager.spawnModel(manager.ModelsObject.listModelObject[currentModelId]);
    }

    private int makeValidId(int currentId)
    {
        if (currentId >= manager.ModelsObject.listModelObject.Count)
        {
            currentId = 0;
            return currentId;
        }
        if (currentId<0)
        {
            currentId = manager.ModelsObject.listModelObject.Count-1;
            return currentId;
        }
        return currentId;
    }

}
