using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class FeaturePresentor:MonoBehaviour
{
    protected gameManager _gameManager;
    public GameObject _uiPrefab;
    public void Init(gameManager gameManager, GameObject uiPrefab)
    {
        _gameManager = gameManager;
        _uiPrefab= uiPrefab;
    }
    public abstract void currentFeatureUIPresent(currentModelManager model, int featureId);
}
