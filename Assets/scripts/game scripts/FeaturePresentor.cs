using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class FeaturePresentor
{
 /*   protected gameManager _gameManager;
    public PresentorType presentorType;
    public FeaturePresentor(PresentorType presentorType)
    {
        this.presentorType = presentorType;
    }*/


  /*  public void Init(gameManager gameManager)
    {
        _gameManager = gameManager;
    }*/

    public abstract void currentFeatureUIPresent(Ifeature feature);
}
