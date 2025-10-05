using System.Collections.Generic;
using UnityEngine;

public class SetBackGrounds : GameManager
{
    private RectTransform startRectTransform;       //背景のスタート地点

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //初期化
        SetBackGroundsInfo();
    }

    /// <summary>
    /// 背景の初期設定関数
    /// </summary>
    private void SetBackGroundsInfo()
    {
        Canvas canvas = this.gameObject.GetComponent<Canvas>();
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();

        //nullチェック
        if (canvas == null || canvasRect == null)
        {
            Debug.LogError("RectTransform is null");
            return;
        }

        /*初期設定*/
        List<RectTransform> panels = new List<RectTransform>(); //背景オブジェクトList

        //自身の子オブジェクトを取得
        for (int i = 0; i < this.transform.childCount; i++)
        {
            //取得
            GameObject child = this.transform.GetChild(i).gameObject;

            //背景オブジェクトを探して格納する
            RectTransform childRect = child.GetComponent<RectTransform>();
            if (child.GetComponent<BackGroundMove>() != null && childRect != null)
            {
                //Debug.Log("add");
                panels.Add(childRect);      //Listに追加

                //2枚しかないので2になったらbreak
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

        //リセット位置の設定
        startRectTransform = panels[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
