using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridClick : MonoBehaviour
{
    public LayerMask gridLayer; // �N���b�N�����m���郌�C���[
    public float raycastDistance = 500f; // ���C�L���X�g�̍ő勗��

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    // �}�E�X�̈ʒu����Ray���΂�
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hitInfo;

        //    // �O���b�h���C���[��ŃN���b�N���ꂽ�����m�F
        //    if (Physics.Raycast(ray, out hitInfo, raycastDistance, gridLayer))
        //    {
        //        // �N���b�N���ꂽ�I�u�W�F�N�g�̏����擾
        //        GameObject clickedObject = hitInfo.collider.gameObject;
        //        TimetableCell timetableCell = clickedObject.GetComponent<TimetableCell>();

        //        if (timetableCell != null)
        //        {
        //            // �N���b�N���ꂽ�}�X�̈ʒu������擾���ď�������
        //            int rowIndex = timetableCell.rowIndex;
        //            int columnIndex = timetableCell.columnIndex;

        //            Debug.Log("Clicked cell at row " + rowIndex + ", column " + columnIndex);
        //        }
        //    }
        //}
    }
}
