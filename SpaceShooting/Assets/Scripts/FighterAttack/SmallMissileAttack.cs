using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using System.Collections.Generic;

public class SmallMissileAttack : I_FighterAttack
{
    /// <summary>
    /// Other Scripts
    /// </summary>
    private FighterAttack fighterAttack = new FighterAttack();
    private AttackTriggerStream attackTrigger = new AttackTriggerStream();

    private List<Transform> firePoints = new List<Transform>();     //弾生成場所
    private GameObject smallMissile;                                //ミサイルオブジェクト
    private const float interval = 0.7f;                            //攻撃のインターバル

    public SmallMissileAttack(List<Transform> points, GameObject smallMissilePrefab)
    {
        this.firePoints = points;
        this.smallMissile = smallMissilePrefab;
    }

    public UniTask AttackAsync(CancellationToken token)
    {
        attackTrigger.StartAttackStream(
            interval,
            () => fighterAttack.GetAttackKeyPressed(),
            FireSmallMiisile,
            token
            );

        return UniTask.CompletedTask;
    }

    /// <summary>
    /// 小ミサイルを発射する関数
    /// </summary>
    private void FireSmallMiisile()
    {
        if (firePoints == null || smallMissile == null) return;

        Debug.Log("fire small missile");
    }

    public void Dispose()
    {
        attackTrigger.Dispose();
    }

}
