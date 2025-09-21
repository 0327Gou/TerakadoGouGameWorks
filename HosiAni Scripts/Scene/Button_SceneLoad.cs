using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadButton : MonoBehaviour
{
    public void RoadScene(string _sSceneName = null)
    {
        // ���O�������ĂȂ��Ȃ�X�L�b�v
        if (_sSceneName == null) { return; }

        // �w��̃V�[�������[�h����
        SceneManager.LoadScene(_sSceneName);
    }

    public void FlagDown()
    {
        SceneController.SeaClear = false;
        SceneController.TreeClear = false;
        SceneController.FireClear = false;
    }
}
