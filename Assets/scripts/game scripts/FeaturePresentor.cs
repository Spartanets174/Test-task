using UnityEngine;

//���������� ��� ����������� ������������
public abstract class FeaturePresentor:MonoBehaviour
{
    protected GameController _gameController;
    protected GameObject _uiPrefab;
    public void Init(GameController gameController)
    {
        _gameController = gameController;
    }
    public abstract void CurrentFeatureUIPresent(Ifeature feature);
}
