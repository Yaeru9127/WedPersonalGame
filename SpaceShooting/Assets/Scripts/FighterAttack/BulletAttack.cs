using Cysharp.Threading.Tasks;
using System.Threading;
using System;
using UnityEngine;

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

    public BulletAttack(Transform firePoint, GameObject bulletPrefab)
    {
        this.firePoint = firePoint;
        this.bullet = bulletPrefab;
    }

    public async UniTask AttackAsync(CancellationToken token)
    {
        attackTrigger.StartAttackStream(
            interval,
            () => fighterAttack.GetAttackKeyPressed(),
            FIreBullet,
            token
            );
    }

    private void FIreBullet()
    {
        if (firePoints == null || bullet == null) return;

        Debug.Log("fire!");
    }
}
