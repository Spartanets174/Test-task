using UnityEngine;
using UnityEngine.UI;

public class DecomposeFeaturePresenter : FeaturePresentor
{
    decomposeFeature decFeature;
    public override void CurrentFeatureUIPresent(Ifeature feature)
    {
        _uiPrefab = _gameController.DecomposeSlider;
        GameObject sliderParent = Instantiate(_uiPrefab, Vector3.zero,Quaternion.identity, _gameController.canvas.transform);
        sliderParent.transform.GetChild(0).TryGetComponent(out Slider slider);
        slider.minValue = decFeature.minDistance;
        slider.maxValue = decFeature.maxDistance;
        for (int i = 0; i < feature.Model.transform.childCount; i++)
        {
            decFeature.startPos.Add(feature.Model.transform.GetChild(i).localPosition); 
        }       
        slider.onValueChanged.AddListener(delegate
        {
            decFeature.currentValue = slider.value;
            decFeature.FeatureRealization();
        });
    }

}
