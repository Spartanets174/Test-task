using UnityEngine;

public class ColorFeaturePresentor : FeaturePresentor
{
    colorChange colorFeature;
    public override void CurrentFeatureUIPresent(Ifeature feature)
    {
        _uiPrefab = _gameController.changeColorUI;
        GameObject colorUIParent = Instantiate(_uiPrefab, Vector3.zero, Quaternion.identity, _gameController.canvas.transform);
        colorUIParent.transform.GetChild(0).TryGetComponent(out CUIColorPicker ColorPicker);
        ColorPicker.applyColor.onClick.AddListener(() => 
        {
            colorFeature.colorToChange = ColorPicker.Color; 
            colorFeature.FeatureRealization();
        });
 
    }
}
