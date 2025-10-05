using System.Collections.Generic;
using UnityEngine;

public class SetBackGrounds : GameManager
{
    private RectTransform startRectTransform;       //�w�i�̃X�^�[�g�n�_

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //������
        SetBackGroundsInfo();
    }

    /// <summary>
    /// �w�i�̏����ݒ�֐�
    /// </summary>
    private void SetBackGroundsInfo()
    {
        Canvas canvas = this.gameObject.GetComponent<Canvas>();
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();

        //null�`�F�b�N
        if (canvas == null || canvasRect == null)
        {
            Debug.LogError("RectTransform is null");
            return;
        }

        /*�����ݒ�*/
        List<RectTransform> panels = new List<RectTransform>(); //�w�i�I�u�W�F�N�gList

        //���g�̎q�I�u�W�F�N�g���擾
        for (int i = 0; i < this.transform.childCount; i++)
        {
            //�擾
            GameObject child = this.transform.GetChild(i).gameObject;

            //�w�i�I�u�W�F�N�g��T���Ċi�[����
            RectTransform childRect = child.GetComponent<RectTransform>();
            if (child.GetComponent<BackGroundMove>() != null && childRect != null)
            {
                //Debug.Log("add");
                panels.Add(childRect);      //List�ɒǉ�

                //2�������Ȃ��̂�2�ɂȂ�����break
                if (panels.Count == 2) break;
            }
        }

        if (panels.Count != 2)
        {
            Debug.LogError("back ground panel's count is not 2 !!");
            return;
        }

        foreach (RectTransform panel in panels)
        {
            panel.anchorMin = new Vector2(0.5f, 0.5f);
            panel.anchorMax = new Vector2(0.5f, 0.5f);
            panel.pivot = new Vector2(0.5f, 0.5f);
            panel.sizeDelta = new Vector2(canvasRect.rect.width, canvasRect.rect.height);
            panel.rotation = Quaternion.identity;
        }

        panels[0].anchoredPosition = Vector2.zero;
        panels[1].anchoredPosition = new Vector2(0, panels[0].rect.height);

        //���Z�b�g�ʒu�̐ݒ�
        startRectTransform = panels[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
