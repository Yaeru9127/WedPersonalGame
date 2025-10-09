using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using static System.Collections.Specialized.BitVector32;

public class AttackTriggerStream : IDisposable
{
    private IDisposable stream;

    /// <summary>
    /// 攻撃ストリームの開始
    /// </summary>
    /// <param name="interval">攻撃間隔（秒）</param>
    /// <param name="isAttackPresed">攻撃ボタンの入力監視</param>
    /// <param name="onAttack">実際の攻撃処理</param>
    /// <param name="cancellation">キャンセル用トークン</param>
    public void StartAttackStream(float interval, Func<bool> isAttackPresed, Action onAttack, CancellationToken cancellation)
    {
        /*攻撃時のポーズのチェック*/
        GameManager.instance.IsPause    //ポーズ状態の監視
            .Subscribe(pause =>
            {
                //ポーズ中は処理を止める
                //非ポーズ中は処理を再度開始
                stream?.Dispose();

                //ポーズ中でない場合
                if (!pause)
                {
                    stream = Observable.EveryUpdate()                       //イベントストリームの作成
                    .Where(_ => isAttackPresed())                           //攻撃ボタンが押されている間のみイベントを通す
                        .ThrottleFirst(TimeSpan.FromSeconds(interval))      //連射速度制限
                        .TakeUntilDestroy(GameManager.instance)             //GameManager.instanceが破棄
                        .TakeUntilDisable(GameManager.instance)             //GameManager.instanceが無効化されるまで購読を継続
                        .Subscribe(_ =>
                        {
                            if (!cancellation.IsCancellationRequested) onAttack?.Invoke();  //キャンセルトークンをチェックしつつ攻撃処理(弾の生成など)を呼ぶ
                        });
                }
            })
            .AddTo(GameManager.instance);                                   //購読を自動解除
    }

    public void Dispose()
    {
        stream?.Dispose();
    }
}
