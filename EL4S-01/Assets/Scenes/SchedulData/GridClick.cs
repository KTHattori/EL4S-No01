using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridClick : MonoBehaviour
{
    public LayerMask gridLayer; // クリックを検知するレイヤー
    public float raycastDistance = 500f; // レイキャストの最大距離

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    // マウスの位置からRayを飛ばす
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hitInfo;

        //    // グリッドレイヤー上でクリックされたかを確認
        //    if (Physics.Raycast(ray, out hitInfo, raycastDistance, gridLayer))
        //    {
        //        // クリックされたオブジェクトの情報を取得
        //        GameObject clickedObject = hitInfo.collider.gameObject;
        //        TimetableCell timetableCell = clickedObject.GetComponent<TimetableCell>();

        //        if (timetableCell != null)
        //        {
        //            // クリックされたマスの位置や情報を取得して処理する
        //            int rowIndex = timetableCell.rowIndex;
        //            int columnIndex = timetableCell.columnIndex;

        //            Debug.Log("Clicked cell at row " + rowIndex + ", column " + columnIndex);
        //        }
        //    }
        //}
    }
}
