using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSceneManager : MonoBehaviour
{
    public void ChengrToPlayScene()
    {
        MySceneManager.ChangePlayeScene();
    }

    public void ChengeToTitle()
    {
        MySceneManager.ChangeTitleScene();
    }
}
