using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBox : BoxBase
{
    public int point = 100;

    bool open_flag = false;

    public override bool gimmick()
    {
        return true;
    }

    public override int addPoint()
    {
        if (open_flag) return 0;
        open_flag = true;
        return point;
    }
}
