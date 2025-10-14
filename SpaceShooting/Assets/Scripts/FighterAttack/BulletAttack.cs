using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using System.Collections.Generic;

public class BulletAttack : I_FighterAttack
{
    /// <summary>
    /// Other Scripts
    /// </summary>
    private FighterAttack fighterAttack = new FighterAttack();

    private AttackTriggerStream attackTrigger = new AttackTriggerStream();

    private List<Transform> firePoints = new List<Transform>();    //弾生成場所
    private GameObject bullet;      //弾のオブジェクト
    private const float interval = 0.2f;         //攻撃のインターバル

    public BulletAttack(List<Transform> firePoint, GameObject bulletPrefab)
    {
        this.firePoints = firePoint;
        this.bullet = bulletPrefab;
    }

    public UniTask AttackAsync(CancellationToken token)
    {
        attackTrigger.StartAttackStream(
            interval,
            () => fighterAttack.GetAttackKeyPressed(),
            FIreBullet,
            token
            );

        return UniTask.CompletedTask;
    }

    private void FIreBullet()
    {
        if (firePoints == null || bullet == null) return;

        Debug.Log("fire!");
    }
}
