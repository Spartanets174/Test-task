using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutFeaturePresenter : FeaturePresentor
{
    public override void currentFeatureUIPresent(currentModelManager model, int featureId)
    {
        model.CurrentFeatureList[featureId].featureRealization(model.gameObject);
    }
}
