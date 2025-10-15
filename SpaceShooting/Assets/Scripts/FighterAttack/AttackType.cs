using UnityEngine;

public class AttackType
{
    public enum TypeOfAttack
    {
        Bullet,
        SmallMissile,
        MediumMissile
    }
    private TypeOfAttack attackType;

    /// <summary>
    /// UŒ‚‚Ìí—Ş‚ğæ“¾‚·‚éŠÖ”
    /// </summary>
    /// <returns></returns>
    public TypeOfAttack GetAttackType()
    {
        return attackType;
    }
}
