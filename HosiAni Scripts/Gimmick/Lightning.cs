using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    [SerializeField]
    GameObject s;
    [SerializeField]
    GameObject e;
    [SerializeField]
    GameObject e2;

    [SerializeField]
    bool chageflg;

    SpriteRenderer m_sr;

    // Start is called before the first frame update
    void Start()
    {
        m_sr = this.GetComponent<SpriteRenderer>();
        m_sr.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        var spos = s.transform.position;
        var epos1 = e.transform.position;
        var epos2 = e2.transform.position;
        var EPOS = epos1;
        if (chageflg)
        {
            EPOS = epos2;
        }

        // スタートからエンドの方向を取得
        var lookDir = spos - EPOS;
        // 座標を二点の中心に
        transform.position = Vector3.Lerp(spos, EPOS, 0.5f);
        // サイズを二点の距離と同じに
        m_sr.size = new Vector2(Vector2.Distance(spos, EPOS), m_sr.size.y);
        // 向きを二点の角度と同じに
        transform.rotation = Quaternion.FromToRotation(Vector3.right, lookDir);

    }
}
