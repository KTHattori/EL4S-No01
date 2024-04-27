using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] public string gridTag; // �^�O�Ō�������Ώۂ̃^�O
    public float distanceThreshold = 4.5f; // ������臒l
    public Light lightComponent; // �u���b�N�̃��C�g�R���|�[�l���g
    bool hasSameTagBlock = false;


    void Update()
    {
        hasSameTagBlock = false;
        GameObject[] gridBlocks = GameObject.FindGameObjectsWithTag(gridTag); // �^�O�Ō�������Grid�^�O�̃u���b�N���擾

        foreach (GameObject block in gridBlocks)
        {
            if (block != gameObject) // �������g�͏��O����
            {
                float distance = Mathf.Abs(block.transform.position.z - transform.position.z); // z���W�̍����擾
                if (distance <= distanceThreshold && block.transform.position.x == transform.position.x)
                {
                    hasSameTagBlock = true;
                     lightComponent.enabled = true; // ���C�g��_��������
                    return;
                }
            }
            // ���C�g�̓_��/�����𐧌�
            if (hasSameTagBlock)
            {
                lightComponent.enabled = true; // ���C�g��_��������
            }
            else
            {
                lightComponent.enabled = false; // ���C�g������������
            }
        }
    }

}
