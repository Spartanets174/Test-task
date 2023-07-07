using UnityEngine;

//Абстракция для презенторов способностей
public abstract class FeaturePresentor:MonoBehaviour
{
    protected GameController _gameController;
    protected GameObject _uiPrefab;
    public void Init(GameController gameController)
    {
        _gameController = gameController;
    }
    private void OnDestroy()
    {
        Destroy(_uiPrefab);
    }
    public abstract void CurrentFeatureUIPresent(Ifeature feature);
}
