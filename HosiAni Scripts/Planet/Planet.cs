using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Planet : MonoBehaviour
{
    [Header("èoÇ∑êØÇÃÇ©ÇØÇÁ")][SerializeField] 
    private GameObject oShardPrefab;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            Instantiate(oShardPrefab, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
