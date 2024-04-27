using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    private bool isDragging = false; // �h���b�O�����ǂ����̃t���O
    private GameObject nearestBlock; // ��ԋ߂��u���b�N
    private bool canDrop = true; // �h���b�v�\���ǂ����̃t���O

    void OnMouseDown()
    {
        isDragging = true; // �h���b�O���J�n����
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        canDrop = true; // �h���b�v�\�Ƃ��ď�����
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;

            FindNearestBlock(); // ��ԋ߂��u���b�N��T��
        }
    }

    void OnMouseUp()
    {
        if (isDragging && nearestBlock != null && canDrop)
        {
            // ��ԋ߂��u���b�N�̈ʒu�Ɉړ�����iy���W��+1�ɂ���j
            Vector3 newPosition = nearestBlock.transform.position + Vector3.up;
            transform.position = newPosition;

            isDragging = false; // �h���b�O�I��
        }
    }

    void FindNearestBlock()
    {
        GameObject[] gridBlocks = GameObject.FindGameObjectsWithTag("Grid"); // Grid�^�O�̃u���b�N���擾
        float minDistance = Mathf.Infinity;
        nearestBlock = null;

        foreach (GameObject gridBlock in gridBlocks)
        {
            if (gridBlock != gameObject) // �������g�͏��O����
            {
                float distance = Vector3.Distance(transform.position, gridBlock.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestBlock = gridBlock;

                    // �u���b�N��Grid�̏�ɂ���ꍇ�̓h���b�v�ł��Ȃ�
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
