using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    Vector2 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = GetStartPosition();
    }

    /// <summary>
    /// 背景画像のリセットポジション設定関数
    /// </summary>
    /// <returns></returns>
    private Vector2 GetStartPosition()
    {
        //nullチェック
        if (this.gameObject.transform.parent == null) Debug.LogError("this object's parent is null");

        //Panelなので、親であるCanvasの中心座標を取得
        GameObject parent = this.gameObject.transform.parent.gameObject;
        RectTransform canvasRect = parent.GetComponent<RectTransform>();

        return canvasRect.rect.center;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
