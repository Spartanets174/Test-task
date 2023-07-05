using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//словарь, который хранит нужные презенторы для каждой способности
public static class FeaturePresentorDictionary
{
    public static Dictionary<Type, Type> featurePresentorDict = new()
    {   //Ключ - тип самой способности, значение - нужный презентор
        {typeof(cutFeature), typeof(CutFeaturePresenter)},
        {typeof(decomposeFeature), typeof(DecomposeFeaturePresenter)},
        {typeof(colorChange), typeof(ColorFeaturePresentor)},
    };    
}
