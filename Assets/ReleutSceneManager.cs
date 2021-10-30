using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleutSceneManager : MonoBehaviour
{
    public void ChengeToTitle()
    {
        MySceneManager.ChangeTitleScene();
    }

    public void ChengeToPlay()
    {
        MySceneManager.ChangePlayeScene();
    }
}
