using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SetBackGrounds : MonoBehaviour
{
    List<RectTransform> panels = new List<RectTransform>(); //背景オブジェクトList
    private Vector2 restartPos;       //背景のスタート地点

    private void Start()
    {
        //初期化
        SetBackGroundsInfo();
    }

    /// <summary>
    /// 背景の初期設定関数
    /// </summary>
    private void SetBackGroundsInfo()
    {
        //初期化 nullチェック
        panels.Clear();
        Canvas canvas = this.gameObject.GetComponent<Canvas>();
        if (canvas == null) Debug.LogError("Canvas is null");
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        if (canvasRect == null) Debug.LogError("canvas's RectTransform is null");

        //自身の子オブジェクトを取得
        for (int i = 0; i < this.transform.childCount; i++)
        {
            //背景オブジェクトを探して格納する
            GameObject child = this.gameObject.transform.GetChild(i).gameObject;
            RectTransform childRect = child.GetComponent<RectTransform>();
            BackGroundMove backGroundMove = child.GetComponent<BackGroundMove>();
            if (backGroundMove != null && childRect != null)
            {
                //Debug.Log("add");
                panels.Add(childRect);      //Listに追加

                //2枚しかないので2になったらbreak
                if (panels.Count == 2) break;
            }
        }

        //背景Panelが2枚かどうかの確認
        if (panels.Count != 2)
        {
            Debug.LogError("Background panel count is not 2 !!");
            return;
        }

        //背景Panelの初期設定
        foreach (RectTransform panel in panels)
        {
            panel.anchorMin = new Vector2(0.5f, 0.5f);
            panel.anchorMax = new Vector2(0.5f, 0.5f);
            panel.pivot = new Vector2(0.5f, 0.5f);
            panel.sizeDelta = new Vector2(canvasRect.rect.width, canvasRect.rect.height);
            panel.rotation = Quaternion.identity;
        }

        //2枚を上下にずらす
        panels[0].anchoredPosition = Vector2.zero;
        panels[1].anchoredPosition = new Vector2(0, panels[0].rect.height);

        //リセット位置の設定
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
        ////デバッグ
        if (Input.GetKeyUp(KeyCode.P))
        {
            GameManager.instance.SetPause = !GameManager.instance.SetPause;
        }
    }
}
