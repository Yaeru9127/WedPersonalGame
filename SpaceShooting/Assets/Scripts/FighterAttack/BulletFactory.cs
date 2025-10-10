using UnityEditor;
using UnityEngine;
using static FighterType;

/*íeÇÃê∂ê¨ÉNÉâÉX*/
public class BulletFactory
{
    public void CreateBullet(TypeOfFighter type, int l)
    {
        switch (type)
        {
            case TypeOfFighter.FighterExcalibur:
                FighterExcaliburBullet(l);
                break;
            case TypeOfFighter.FrigateCorsair:
                FrigateCorsairBullet(l);
                break;
            case TypeOfFighter.DestroyerPhoenix:
                DestroyerPhoenix(l);
                break;
            default:
                Debug.LogError("this type is none");
                break;
        }
    }

    public void FighterExcaliburBullet(int l)
    {
        switch (l)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                Debug.LogError("this level is out of fighter's level");
                break;
        }
    }

    public void FrigateCorsairBullet(int l)
    {
        switch (l)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                Debug.LogError("level is out of fighter's level");
                break;
        }
    }

    public void DestroyerPhoenix(int l)
    {
        switch (l)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                Debug.LogError("level is out of fighter's level");
                break;
        }
    }
}
