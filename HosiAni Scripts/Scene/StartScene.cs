using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �E�N���b�N������
        if (Input.GetMouseButton(0))
        {
            // �X�^�[�g����
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game_Main");
        }
    }
}
