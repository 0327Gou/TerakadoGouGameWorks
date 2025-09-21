// 背景を更新する処理

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackGroundMng : MonoBehaviour
{
    // カメラの情報
    [SerializeField]
    Camera m_cam;
    public GameObject bgObj;
    public float scrollspeed;

    [SerializeField]
    int m_OiL;

    GameObject[] bg;

    // 背景の横サイズを入れる変数
    float m_fSidesize;

    // Start is called before the first frame update
    void Start()
    {
        // 背景の横サイズを取得
        m_fSidesize = bgObj.GetComponent<SpriteRenderer>().bounds.size.x;

        bg = new GameObject[3];

        // 背景格納
        for(int i = 0; i < bg.Length; ++i)
        {
            // プレハブから言配列にインスタンス化
            bg[i] = Instantiate(bgObj, new Vector3((float)(i - 1) * m_fSidesize, transform.position.y, transform.position.z),Quaternion.identity);

            // 親を「BG」にする
            bg[i].transform.SetParent(transform);
            bg[i].GetComponent<SpriteRenderer>().sortingOrder = m_OiL;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // スクロール処理
        this.transform.position = new Vector2(m_cam.transform.position.x * scrollspeed, m_cam.transform.position.y);

        // 更新後のX座標
        float fPosX;

        for (int i = 0; i < bg.Length; ++i)
        {

            if (bg[i].transform.position.x < m_cam.transform.position.x - 30f)
            {
                fPosX = bg[i].transform.localPosition.x + m_fSidesize * 3.0f;
            }
            else if (bg[i].transform.position.x > m_cam.transform.position.x + 30f)
            {
                fPosX = bg[i].transform.localPosition.x - m_fSidesize * 3.0f;
            }
            else
            {
                fPosX = bg[i].transform.localPosition.x;
            }

            // 更新を反映
            bg[i].transform.localPosition = new Vector2(fPosX, 0.0f);
        }
    }
}
