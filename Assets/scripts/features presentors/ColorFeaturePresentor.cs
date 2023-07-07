using UnityEngine;

public class ColorFeaturePresentor : FeaturePresentor
{
    colorChange colorFeature;
    public override void CurrentFeatureUIPresent(Ifeature feature)
    {
         colorFeature = (colorChange)feature;
        _uiPrefab = _gameController.changeColorUI;
        _uiPrefab = Instantiate(_uiPrefab, Vector3.zero, Quaternion.identity, _gameController.canvas.transform);
        _uiPrefab.transform.localPosition = new Vector3(-100,-100,0);
        _uiPrefab.TryGetComponent(out CUIColorPicker ColorPicker);
        ColorPicker.applyColor.onClick.AddListener(() => 
        {
            colorFeature.colorToChange = ColorPicker.Color; 
            colorFeature.FeatureRealization();
        });
 
    }
}
