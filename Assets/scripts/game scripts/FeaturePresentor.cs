using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FeaturePresentor : MonoBehaviour
{
    protected gameManager _gameManager;

    public void Init(gameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public abstract void currentFeatureUIPresent();
}
