using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FeaturePresentorDictionary
{
    public static Dictionary<Type, Type> featurePresentorDict = new()
    {
        {  typeof(cutFeature),typeof(CutFeaturePresenter)},
        {  typeof(decomposeFeature),typeof(DecomposeFeaturePresenter)},
         {  typeof(colorChange),typeof(ColorFeaturePresentor)},
    };    
}
