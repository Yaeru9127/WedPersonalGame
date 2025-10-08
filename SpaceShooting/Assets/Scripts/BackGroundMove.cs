using UnityEditor;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    private GameManager manager;
    private RectTransform rect;

    private Vector3 startPos;                   //背景のリセットポジション
    private Vector2 moveDirection = new Vector2(0, -1);
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

    public void GetStartPos(Vector3 pos)
    {
        startPos = pos;
    }

    /// <summary>
    /// 背景移動関数
    /// </summary>
    private void MoveBackGround()
    {
        if (manager == null || manager.SetPause) return;

        //背景の移動
        Vector2 move = moveDirection.normalized * speed * Time.deltaTime;
        rect.anchoredPosition += move;

        //画面外になったらリセットポジションに移動
        if (rect.anchoredPosition.y <= -450)
        {
            rect.anchoredPosition = startPos;
        }
    }

    private void Update()
    {
        MoveBackGround();
    }
}
