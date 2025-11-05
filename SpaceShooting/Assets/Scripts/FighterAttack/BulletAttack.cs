using UnityEngine;
public class BulletAttack : BaseAttack
{
    //ステータスの固定
    private static readonly AttackStatus defaultStatus = new AttackStatus
    {
        address = "bullet",
        interval = 0.2f,
        attackPower = 1,
        bulletSpeed = 5
    };

    //派生クラス(BulletAttack)コンストラクタと基底クラス(BaseAttack)コンストラクタの呼び出し
    public BulletAttack(Transform firePoint, FighterAttack fighterAttack, AttackStatus status)
    : base(firePoint, fighterAttack, status)
    { }

    protected override void Fire()
    {
        if (firePoint == null || bulletPrefab == null) return;

        //弾の生成
        GameObject bullet = GameObject.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //Debug.Log($"Bullet fired with power {status.attackPower}");
    }
}
