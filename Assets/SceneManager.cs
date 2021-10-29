/// <summary>
/// シーン変更用クラス
/// </summary>
static public class MySceneManager
{
    // TODO: 
    // 今回は設計などないのでこちらにまとめて定義
    // 本来であれば別途定数にわけるべきそうすることで関数の使いまわし可能
    const string TITLE_SCENE_NAME    = "TitleScene";
    const string GAMEOVER_SCENE_NAME = "GameOverScene";
    const string RESULT_SCENE_NAME   = "ResultScene";
    const string PLAY_SCENE_NAME     = "PlayScene";

    static public void ChangePlayeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(PLAY_SCENE_NAME);
    }

    static public void ChangeGameOverScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(GAMEOVER_SCENE_NAME);
    }

    static public void ChangeResultScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(RESULT_SCENE_NAME);
    }

    static public void ChangeTitleScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(TITLE_SCENE_NAME);
    }
}
