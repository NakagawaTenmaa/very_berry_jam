/// <summary>
/// �V�[���ύX�p�N���X
/// </summary>
static public class MySceneManager
{
    // TODO: 
    // ����͐݌v�ȂǂȂ��̂ł�����ɂ܂Ƃ߂Ē�`
    // �{���ł���Εʓr�萔�ɂ킯��ׂ��������邱�ƂŊ֐��̎g���܂킵�\
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
