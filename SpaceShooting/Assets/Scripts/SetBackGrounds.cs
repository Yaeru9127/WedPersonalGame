using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SetBackGrounds : MonoBehaviour
{
    List<RectTransform> panels = new List<RectTransform>(); //�w�i�I�u�W�F�N�gList
    private Vector2 restartPos;       //�w�i�̃X�^�[�g�n�_

    private void Start()
    {
        //������
        SetBackGroundsInfo();
    }

    /// <summary>
    /// �w�i�̏����ݒ�֐�
    /// </summary>
    private void SetBackGroundsInfo()
    {
        //������ null�`�F�b�N
        panels.Clear();
        Canvas canvas = this.gameObject.GetComponent<Canvas>();
        if (canvas == null) Debug.LogError("Canvas is null");
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        if (canvasRect == null) Debug.LogError("canvas's RectTransform is null");

        //���g�̎q�I�u�W�F�N�g���擾
        for (int i = 0; i < this.transform.childCount; i++)
        {
            //�w�i�I�u�W�F�N�g��T���Ċi�[����
            GameObject child = this.gameObject.transform.GetChild(i).gameObject;
            RectTransform childRect = child.GetComponent<RectTransform>();
            BackGroundMove backGroundMove = child.GetComponent<BackGroundMove>();
            if (backGroundMove != null && childRect != null)
            {
                //Debug.Log("add");
                panels.Add(childRect);      //List�ɒǉ�

                //2�������Ȃ��̂�2�ɂȂ�����break
                if (panels.Count == 2) break;
            }
        }

        //�w�iPanel��2�����ǂ����̊m�F
        if (panels.Count != 2)
        {
            Debug.LogError("Background panel count is not 2 !!");
            return;
        }

        //�w�iPanel�̏����ݒ�
        foreach (RectTransform panel in panels)
        {
            panel.anchorMin = new Vector2(0.5f, 0.5f);
            panel.anchorMax = new Vector2(0.5f, 0.5f);
            panel.pivot = new Vector2(0.5f, 0.5f);
            panel.sizeDelta = new Vector2(canvasRect.rect.width, canvasRect.rect.height);
            panel.rotation = Quaternion.identity;
        }

        //2�����㉺�ɂ��炷
        panels[0].anchoredPosition = Vector2.zero;
        panels[1].anchoredPosition = new Vector2(0, panels[0].rect.height);

        //���Z�b�g�ʒu�̐ݒ�
        restartPos = panels[1].anchoredPosition;
        foreach (RectTransform panel in panels)
        {
            BackGroundMove backGroundMove = panel.GetComponent<BackGroundMove>();
            backGroundMove.GetStartPos(restartPos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ////�f�o�b�O
        if (Input.GetKeyUp(KeyCode.P))
        {
            GameManager.instance.SetPause = !GameManager.instance.SetPause;
        }
    }
}
