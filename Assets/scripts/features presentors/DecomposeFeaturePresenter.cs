using UnityEngine;
using UnityEngine.UI;

public class DecomposeFeaturePresenter : FeaturePresentor
{
    decomposeFeature decFeature;
    public override void CurrentFeatureUIPresent(Ifeature feature)
    {
        decFeature = (decomposeFeature)feature;
        _uiPrefab = _gameController.DecomposeSlider;        
        _uiPrefab = Instantiate(_uiPrefab ,_gameController.canvas.transform);
        _uiPrefab.transform.localPosition = new Vector3(_gameController.canvas.transform.position.x - 136, 0, 0);
        _uiPrefab.TryGetComponent(out Slider slider);
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
