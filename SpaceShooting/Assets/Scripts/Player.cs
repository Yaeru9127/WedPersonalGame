using UnityEngine;
using UniRx;
using System;

public class Player : MonoBehaviour
{
    private InputSystem_Actions action;

    private float bulletInterval;
    private IDisposable shootStream;

    private void OnDestroy()
    {
        shootStream?.Dispose();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //InputSystem
        action = InputSystemManager.instance.GetActions();
        InputSystemManager.instance.PlayerOn();

        bulletInterval = 0.2f;
        GameManager.instance.IsPause
            .Subscribe(pause =>
            {
                /*攻撃時のポーズのチェック*/
                //ポーズOn
                if (pause)
                {
                    //連射処理の購読解除
                    shootStream?.Dispose();
                    shootStream = null;     //状態のクリア
                }
                //ポーズOff
                else if (!pause)
                {
                    shootStream = Observable.EveryUpdate()                      //イベントストリームの作成
                        .Where(_ => action.Player.Attack.IsPressed())           //攻撃ボタンが押されている間のみイベントを通す
                        .ThrottleFirst(TimeSpan.FromSeconds(bulletInterval))    //連射速度制限
                        .Subscribe(_ => Fire())                                 //弾の発射関数を呼び出す
                        .AddTo(this);                                           //自動的に購読解除
                }
            })
            .AddTo(this);
    }

    private void Fire()
    {
        Debug.Log("fire");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
