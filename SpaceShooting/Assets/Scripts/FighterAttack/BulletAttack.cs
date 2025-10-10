using Cysharp.Threading.Tasks;
using System.Threading;
using System;
using UnityEngine;

public class BulletAttack : I_FighterAttack
{
    private Transform firePoint;    //弾生成場所
    private GameObject bullet;      //弾のオブジェクト
    private const float interval = 0.2f;         //攻撃のインターバル

    public BulletAttack(Transform firePoint, GameObject bulletPrefab)
    {
        this.firePoint = firePoint;
        this.bullet = bulletPrefab;
    }

    public async UniTask AttackAsync(CancellationToken token)
    {
        try
        {
            //キャンセル要求が来るまでループを継続
            while (!token.IsCancellationRequested)
            {
                /*攻撃処理*/
                //発射間隔のインターバル
                await UniTask.Delay((int)(interval * 1000f), cancellationToken: token);

                /*ここに実際の攻撃処理（弾の生成、発射など）*/
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"AttackAsync error: {ex}");
        }
    }
}
