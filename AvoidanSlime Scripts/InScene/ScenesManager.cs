/*
* �t�@�C���FScenesManager C#
* �V�X�e���F�V�[���J�ڂ��Ǘ�����X�N���v�g
* 
* Created by ���� ��H
* 2025�N �ꕔ�ύX
*/

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ScenesManager : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------------------
    // �ϐ��錾
    //----------------------------------------------------------------------------------------------------------------------------

    // �V�[�����`����enum
    public enum Scenes
    {
        Title,
        Menu,
        Guide,
        GameOver,
        StageClear,
        GameClear,
        End,
        Stage1,
        Stage2,
        Stage3,
    }

    [SerializeField]
    Scenes scenes;                          // �ړ���̃V�[����I�����钲���p�ϐ�

    StageDataSettings m_stageData = null;   // �X�e�[�W�f�[�^�i�[�p

    //----------------------------------------------------------------------------------------------------------------------------
    // ���C���֐�
    //----------------------------------------------------------------------------------------------------------------------------

    // �C���X�^���X���ǂݍ��܂ꂽ���̏���
    private void Awake()
    {
        // �X�e�[�W�f�[�^���擾
        m_stageData = (StageDataSettings)Resources.Load("! StageData");
        //Debug.Log("Menu set StageData  " + m_stageData.name);

        // �X�e�[�W�f�[�^���Ȃ��Ȃ�
        if (m_stageData == null) 
        {
            // �G���[���O���o�� 
            Debug.LogError("Menu No StageData");
        }
    }

    //----------------------------------------------------------------------------------------------------------------------------
    // �T�u�֐�
    //----------------------------------------------------------------------------------------------------------------------------

    // �w�肳�ꂽ�V�[���ɑJ�ڂ���֐�
    private void GoScene()
    {
        switch (scenes.ToString())
        {
            case "Title":
                // �^�C�g���֑J��
                SceneManager.LoadScene("Title");
                break;

            case "Menu":
                // ���j���[�֑J��
                SceneManager.LoadScene("Menu");
                break;

            case "Guide":
                // �K�C�h�֑J��
                SceneManager.LoadScene("Guide");
                break;

            case "GameOver":
                // �Q�[���I�[�o�[�֑J��
                SceneManager.LoadScene("GameOver");
                break;

            case "StageClear":
                // �N���A�֑J��
                SceneManager.LoadScene("StageClear");
                break;

            case "GameClear":
                // �N���A�֑J��
                SceneManager.LoadScene("GameClear");
                break;

            case "End":
                // �Q�[���̋����I��
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #else
                    Application.Quit(); //�Q�[���v���C�I��
                #endif
                break;

            case "Stage1":
                // �X�e�[�W�ԍ��̐ݒ�
                m_stageData.SetStageNumber(0);
                //Debug.Log(m_stageData.GetStageNumber());

                // �X�e�[�W1�Ɉړ�
                SceneManager.LoadScene("Game");
                break;

            case "Stage2":
                // �X�e�[�W�ԍ��̐ݒ�
                m_stageData.SetStageNumber(1);
                //Debug.Log(m_stageData.GetStageNumber());

                // �X�e�[�W2�Ɉړ�
                SceneManager.LoadScene("Game");
                break;

            case "Stage3":
                // �X�e�[�W�ԍ��̐ݒ�
                m_stageData.SetStageNumber(2);
                //Debug.Log(m_stageData.GetStageNumber());

                // �X�e�[�W3�Ɉړ�
                SceneManager.LoadScene("Game");
                break;
        }
    }
    //----------------------------------------------------------------------------------------------------------------------------
    // �C�x���g�֐�
    //----------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// �V�X�e���F�C���v�b�g���͂����m����֐�
    /// ����    �F�p�b�h����FSouthButton
    ///         �F�L�[�{�[�h�}�E�X����FLeftClick
    /// �߂�l�@�F�Ȃ�
    /// </summary>
    public void IA_Select(InputAction.CallbackContext context)
    {
        // �t�F�[�Y��Canceled���̔�����s��
        // Started�APerformed���ƘA�����ăV�[�����ړ����Ă��܂�����
        if (context.phase == InputActionPhase.Canceled)
        {
            //Debug.Log("GoScene");
            GoScene();
        }
    }

    /// <summary>
    /// �V�X�e���FUnityButton�̓��͂����m����֐�
    /// ����    �F�Ȃ�
    /// �߂�l�@�F�Ȃ�
    /// </summary>
    public void Button_Select()
    {
        // �w�肵���V�[���Ɉړ�����֐����Ăяo��
        GoScene();
    }
}
