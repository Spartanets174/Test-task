using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Абстракция для презенторов способностей
public abstract class FeaturePresentor:MonoBehaviour
{
    protected gameManager _gameManager;
    public GameObject _uiPrefab;
    public void Init(gameManager gameManager)
    {
        _gameManager = gameManager;
    }
    public abstract void CurrentFeatureUIPresent(currentModelManager model, int featureId);
}
