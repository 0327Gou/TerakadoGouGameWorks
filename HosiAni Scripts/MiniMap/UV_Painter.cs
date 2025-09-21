using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UV_Painter : MonoBehaviour
{
    [SerializeField]
    private Brush _brush;

    [SerializeField]
    private GameObject _brushObj;

    [SerializeField]
    private GameObject _paintObj;

    private Texture2D _Copytex;
    private Texture _maintex;
    private Texture _patternTex;
    private Material Map_material;


    void Start()
    {
        // データの保存
        Map_material = _paintObj.GetComponent<Renderer>().material;
        _maintex = Map_material.GetTexture("_MainTex");
        _patternTex = Map_material.GetTexture("_PatternTex");


        // テクスチャをコピーしてパターンテクスチャに代入
        _Copytex = new Texture2D(_patternTex.width, _patternTex.height);
        Graphics.CopyTexture(_patternTex, 0, 0, _Copytex, 0, 0);
     
        _brush.UpdateBrushColor();
    }

    void Update()
    {
        //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);   //クリック位置からレイと飛ばす場合
        var ray = new Ray(_brushObj.transform.position, new Vector3(0, 0, 20));    //オブジェクトからレイを飛ばす場合
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit)) return;

        if (Physics.Raycast(ray, out hit))
        {
            Renderer renderer = hit.collider.gameObject.GetComponent<Renderer>();
            MeshCollider meshCollider = hit.collider as MeshCollider;

            if (renderer == null || renderer.sharedMaterial == null || renderer.sharedMaterial.mainTexture == null || meshCollider == null)
            {
                Debug.Log("NULL");
                return;
            }

            Vector2 pixelUV = hit.textureCoord;
            pixelUV.x *= _Copytex.width;
            pixelUV.y *= _Copytex.height;
            // Debug.Log("pixelUV:::" + (int)pixelUV.x + " , " + (int)pixelUV.y);


            Color[] col = new Color[_brush.colors.Length];
            col = _Copytex.GetPixels((int)pixelUV.x - _brush.brushWidth / 2, (int)pixelUV.y - _brush.brushHeight / 2, _brush.brushWidth, _brush.brushHeight);
            _brush.UpdateBrushColor(col);
            _Copytex.SetPixels((int)pixelUV.x - _brush.brushWidth / 2, (int)pixelUV.y - _brush.brushHeight / 2, _brush.brushWidth, _brush.brushHeight, _brush.colors);
            _Copytex.Apply();
            Map_material.SetTexture("_PatternTex", _Copytex);
        }
    }
}