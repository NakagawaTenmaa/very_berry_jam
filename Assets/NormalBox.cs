using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBox : BoxBase
{
    public int point = 100;

    public override bool gimmick()
    {
        return true;
    }

    public override int addPoint()
    {
        throw new System.NotImplementedException();
    }
}
