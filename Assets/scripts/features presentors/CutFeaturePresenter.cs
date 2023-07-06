public class CutFeaturePresenter : FeaturePresentor
{
    public override void CurrentFeatureUIPresent(Ifeature feature)
    {
        feature.FeatureRealization();
    }
}
