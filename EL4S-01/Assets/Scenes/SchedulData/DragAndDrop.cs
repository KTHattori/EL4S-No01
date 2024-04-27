using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    private bool isDragging = false; // ドラッグ中かどうかのフラグ
    private GameObject nearestBlock; // 一番近いブロック
    private bool canDrop = true; // ドロップ可能かどうかのフラグ

    void OnMouseDown()
    {
        isDragging = true; // ドラッグを開始する
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        canDrop = true; // ドロップ可能として初期化
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;

            FindNearestBlock(); // 一番近いブロックを探す
        }
    }

    void OnMouseUp()
    {
        if (isDragging && nearestBlock != null && canDrop)
        {
            // 一番近いブロックの位置に移動する（y座標は+1にする）
            Vector3 newPosition = nearestBlock.transform.position + Vector3.up;
            transform.position = newPosition;

            isDragging = false; // ドラッグ終了
        }
    }

    void FindNearestBlock()
    {
        GameObject[] gridBlocks = GameObject.FindGameObjectsWithTag("Grid"); // Gridタグのブロックを取得
        float minDistance = Mathf.Infinity;
        nearestBlock = null;

        foreach (GameObject gridBlock in gridBlocks)
        {
            if (gridBlock != gameObject) // 自分自身は除外する
            {
                float distance = Vector3.Distance(transform.position, gridBlock.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestBlock = gridBlock;

                    // ブロックがGridの上にある場合はドロップできない
                    if (Mathf.Approximately(distance, 0f))
                    {
                        canDrop = false;
                    }
                    else
                    {
                        canDrop = true;
                    }
                }
            }
        }
    }
}
