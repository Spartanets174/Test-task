using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class CutFeaturePresentor : FeaturePresentor
{
    //�������� ����� � ���������
    public Button on;
    public Button off;

    /*public CutFeaturePresentor( PresentorType presentorType = PresentorType.turnOnOff) : base(presentorType)
    {
    }*/

    public override void currentFeatureUIPresent(Ifeature feature)
    {

    }
}
