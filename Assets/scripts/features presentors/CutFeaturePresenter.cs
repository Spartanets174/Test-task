using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutFeaturePresenter : FeaturePresentor
{
    public override void CurrentFeatureUIPresent(currentModelManager model, int featureId)
    {
        model.CurrentFeatureList[featureId].FeatureRealization(model.gameObject);
    }
}
