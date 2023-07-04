using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecomposeFeaturePresenter : FeaturePresentor
{
    public override void currentFeatureUIPresent(currentModelManager model, int featureId)
    {
        decomposeFeature decFeature = (decomposeFeature)model.CurrentFeatureList[featureId];
        GameObject sliderParent = Instantiate(_uiPrefab, Vector3.zero,Quaternion.identity,model.transform);
        sliderParent.transform.GetChild(0).TryGetComponent<Slider>(out Slider slider);
        slider.transform.localPosition = new Vector3(0, 140, 0);
        slider.minValue = 1;
        slider.maxValue = decFeature.maxDistance;
        for (int i = 0; i < _gameManager.currentModelObject.model.transform.childCount; i++)
        {
            decFeature.startPos.Add(_gameManager.currentModelObject.model.transform.GetChild(i).localPosition); 
        }       
        slider.onValueChanged.AddListener(delegate
        {
            decFeature.currentValue = slider.value;
            decFeature.featureRealization(model.gameObject);
        });
    }

}
