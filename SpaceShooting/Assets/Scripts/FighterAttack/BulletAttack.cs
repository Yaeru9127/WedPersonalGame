using Cysharp.Threading.Tasks;
using System.Threading;
using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;

/*通常攻撃*/
public class BulletAttack : I_FighterAttack, IDisposable
{
    //攻撃ストリーム管理
    private AttackTriggerStream attackStream = new AttackTriggerStream();

    private FighterAttack fighterAttack = new FighterAttack();

    private List<Transform> firePoints = new List<Transform>();     //弾生成場所配列
    private GameObject bulletPrefab;                                //弾のオブジェクト
    private const float interval = 0.2f;                            //攻撃のインターバル

    private BulletAttack()
    {

    }

    public BulletAttack(List<Transform> points, GameObject bulletPrefab)
    {
        this.firePoints = points;
        this.bulletPrefab = bulletPrefab;
    }

    public UniTask AttackAsync(CancellationToken token)
    {
        attackStream.StartAttackStream(
            interval,                                       //連射時間のインターバル
            () => fighterAttack.GetActionKeyPressed(),      //攻撃ボタンの判定取得
            FireBullet,                                     //実際の攻撃処理
            token
            );

        return UniTask.CompletedTask;
    }

    private void FireBullet()
    {
        if (firePoints == null || bulletPrefab == null) return;

        Debug.Log("fire!");

        //弾の生成
        //GameObject bullet = GameObject.Instantiate(bulletPrefab, firePoint.position, bulletPrefab.transform.rotation);
        //弾に速度を与えるなどの処理
    }

    public void Dispose()
    {
        attackStream?.Dispose();
    }
}
