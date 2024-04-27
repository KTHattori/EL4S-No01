using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] public string gridTag; // タグで検索する対象のタグ
    public float distanceThreshold = 4.5f; // 距離の閾値
    public Light lightComponent; // ブロックのライトコンポーネント
    bool hasSameTagBlock = false;


    void Update()
    {
        hasSameTagBlock = false;
        GameObject[] gridBlocks = GameObject.FindGameObjectsWithTag(gridTag); // タグで検索してGridタグのブロックを取得

        foreach (GameObject block in gridBlocks)
        {
            if (block != gameObject) // 自分自身は除外する
            {
                float distance = Mathf.Abs(block.transform.position.z - transform.position.z); // z座標の差を取得
                if (distance <= distanceThreshold && block.transform.position.x == transform.position.x)
                {
                    hasSameTagBlock = true;
                     lightComponent.enabled = true; // ライトを点灯させる
                    return;
                }
            }
            // ライトの点灯/消灯を制御
            if (hasSameTagBlock)
            {
                lightComponent.enabled = true; // ライトを点灯させる
            }
            else
            {
                lightComponent.enabled = false; // ライトを消灯させる
            }
        }
    }

}
