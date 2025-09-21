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
        // 右クリックしたら
        if (Input.GetMouseButton(0))
        {
            // スタートする
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game_Main");
        }
    }
}
