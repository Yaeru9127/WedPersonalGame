using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SmallMissileAttack : I_FighterAttack
{
    /// <summary>
    /// Other Scripts
    /// </summary>
    private FighterAttack fighterAttack = new FighterAttack();
    private AttackTriggerStream attackTrigger = new AttackTriggerStream();

    private Transform firePoint;     //弾生成場所
    private GameObject smallMissile;                                //ミサイルオブジェクト
    private const float interval = 0.7f;                            //攻撃のインターバル

    public SmallMissileAttack(Transform point)
    {
        this.firePoint = point;
        SetSmallMissilePrefab().Forget();
    }

    private async UniTask SetSmallMissilePrefab()
    {
        //アドレスから取得
        AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>("smallMissile");
        GameObject prefab;

        try
        {
            prefab = await handle.ToUniTask();
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Asset loading failed" + ex);
            return;
        }
        finally
        {
            //リリース
            Addressables.Release(handle);
        }

        this.smallMissile = prefab;
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
        if (firePoint == null || smallMissile == null) return;

        Debug.Log("fire small missile");
    }

    public void Dispose()
    {
        attackTrigger.Dispose();
    }

}
