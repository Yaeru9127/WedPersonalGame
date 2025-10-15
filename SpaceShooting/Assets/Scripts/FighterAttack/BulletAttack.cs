using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using System.Collections.Generic;
using System.Net;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Threading.Tasks;

public class BulletAttack : I_FighterAttack
{
    /// <summary>
    /// Other Scripts
    /// </summary>
    private FighterAttack fighterAttack = new FighterAttack();
    private AttackTriggerStream attackTrigger = new AttackTriggerStream();

    private Transform firePoint;     //弾生成場所
    private GameObject bullet;                                      //弾のオブジェクト
    private const float interval = 0.2f;                            //攻撃のインターバル

    public BulletAttack(Transform firePoint)
    {
        this.firePoint = firePoint;
        SetBulletPrefab().Forget();
    }

    private async UniTask SetBulletPrefab()
    {
        //アドレスから取得
        AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>("bullet");
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

        this.bullet = prefab;
    }

    public UniTask AttackAsync(CancellationToken token)
    {
        attackTrigger.StartAttackStream(
            interval,
            () => fighterAttack.GetAttackKeyPressed(),
            () => FireBullet().Forget(),
            token
            );

        return UniTask.CompletedTask;
    }

    /// <summary>
    /// 弾を発射する関数
    /// </summary>
    private async UniTask FireBullet()
    {
        if (firePoint == null || bullet == null) return;

        Debug.Log("bullet fire!");

        
    }

    public void Dispose()
    {
        attackTrigger.Dispose();
    }
}
