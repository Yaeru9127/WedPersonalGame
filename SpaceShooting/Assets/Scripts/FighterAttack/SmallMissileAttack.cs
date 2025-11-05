using UnityEngine;

public class SmallMissileAttack : BaseAttack
{
    private readonly AttackStatus defaultStatus = new AttackStatus
    {
        address = "smallMissile",
        interval = 0.5f,
        attackPower = 2,
        bulletSpeed = 7
    };

    public SmallMissileAttack(Transform firePoint, FighterAttack fighterAttack, AttackStatus status)
    : base(firePoint, fighterAttack, status)
    { }

    protected override void Fire()
    {
        if (firePoint == null || bulletPrefab == null) return;

        //íeÇÃê∂ê¨
        GameObject missile = GameObject.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //Debug.Log($"Small missile fired with power {status.attackPower}");
    }
}
