using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFeaturePresentor : FeaturePresentor
{
    public override void CurrentFeatureUIPresent(currentModelManager model, int featureId)
    {
        colorChange colorFeature = (colorChange)model.CurrentFeatureList[featureId];
        _uiPrefab = _gameManager.changeColorUI;
        GameObject colorUIParent = Instantiate(_uiPrefab, Vector3.zero, Quaternion.identity, model.transform);
        colorUIParent.transform.GetChild(0).TryGetComponent<CUIColorPicker>(out CUIColorPicker ColorPicker);
        ColorPicker.applyColor.onClick.AddListener(() => 
        {
            colorFeature.colorToChange = ColorPicker.Color; 
            colorFeature.FeatureRealization(model.gameObject);
        });
 
    }
}
