using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.AddressableAssets;

public abstract class BaseAttack : I_FighterAttack
{
    protected FighterAttack fighterAttack;
    protected AttackTriggerStream attackTrigger = new AttackTriggerStream();
    protected Transform firePoint;
    protected GameObject bulletPrefab;
    protected AttackStatus status;

    public BaseAttack(Transform firePoint, FighterAttack fighterAttack, AttackStatus status)
    {
        this.firePoint = firePoint;
        this.fighterAttack = fighterAttack;
        this.status = status;

        LoadBulletPrefab().Forget();
    }

    /// <summary>
    /// 弾オブジェクトの生成関数
    /// </summary>
    /// <returns></returns>
    private async UniTask LoadBulletPrefab()
    {
        if (string.IsNullOrEmpty(status.address)) return;

        var handle = Addressables.LoadAssetAsync<GameObject>(status.address);
        try
        {
            bulletPrefab = await handle.ToUniTask();
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed {ex}");
        }
        finally
        {
            //リリース
            Addressables.Release(handle);
        }
    }

    public virtual UniTask AttackAsync(CancellationToken token)
    {
        attackTrigger.StartAttackStream
            (
                status.interval,
                () => fighterAttack.GetAttackKeyPressed(),
                Fire,
                token
            );

        return UniTask.CompletedTask;
    }

    protected abstract void Fire();

    public virtual void Dispose()
    {
        attackTrigger.Dispose();
    }
}
