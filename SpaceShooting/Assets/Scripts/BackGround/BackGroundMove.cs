using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    private GameManager manager;    //Other Script
    private RectTransform rect;     //My Component

    private RectTransform pairBackPanel;    //もう一枚の背景
    private float speed; //背景の移動速度

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //初期化
        manager = GameManager.instance;
        rect = this.gameObject.GetComponent<RectTransform>();
        speed = manager.publicBackGroundSpeed;

        //デバッグ
        //if (rect == null) Debug.LogError("error");
        //else if (rect != null) Debug.Log("not null");
    }

    /// <summary>
    /// もう一枚の背景を外部から設定する関数
    /// </summary>
    /// <param name="pair"></param>
    public void SetPairBackGroundPanel(RectTransform pair)
    {
        pairBackPanel = pair;
    }

    /// <summary>
    /// 背景移動関数
    /// </summary>
    private void MoveBackGround()
    {
        //ポーズ中は動かないようにする
        if (manager == null || manager.SetPause) return;

        //背景の移動
        rect.anchoredPosition += Vector2.down.normalized * speed * Time.deltaTime;

        //画面外になったらリセットポジションに移動
        if (rect.anchoredPosition.y <= -rect.rect.height)
        {
            //X座標は変えず、Y座標は(現在の高さ + 背景の高さ -1)で隙間を防ぐ
            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, 
                pairBackPanel.anchoredPosition.y + rect.rect.height - 1);
        }
    }

    private void Update()
    {
        MoveBackGround();
    }
}
