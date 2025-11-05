using System.Collections.Generic;
using UnityEngine;

public class AttackSpawnPoints
{
    private List<I_FighterAttack> level1 = new List<I_FighterAttack>();
    private List<I_FighterAttack> level2 = new List<I_FighterAttack>();
    private List<I_FighterAttack> level3 = new List<I_FighterAttack>();

    private FighterAttack fighterAttack;
    private AttackStatus status;

    public AttackSpawnPoints(FighterAttack fighterAttack)
    {
        this.fighterAttack = fighterAttack;
        this.status = new AttackStatus();
    }

    /// <summary>
    /// 攻撃のスポーン地点の親オブジェクトを取得する関数
    /// </summary>
    /// <param name="player"></param>
    public void GetAttackSpawnPoints(GameObject player)
    {
        //プレイヤーの子オブジェクトを参照
        int count = player.transform.childCount;

        for (int i = 0; i < count; i++)
        {
            //オブジェクトの名前の数字判定
            Transform child = player.transform.GetChild(i);
            if (int.TryParse(child.name, out int num) && num >= 1 && num <= 3)
            {
                //レベル別で取得
                switch (num)
                {
                    case 1:
                        SetI_FighterAttack(level1, child);
                        break;
                    case 2:
                        SetI_FighterAttack(level2, child);
                        break;
                    case 3:
                        SetI_FighterAttack(level3, child);
                        break;
                    default:
                        Debug.LogError("level is none");
                        break;
                }
            }
        }
    }

    /// <summary>
    /// レベル別に攻撃パターンを設定する関数
    /// </summary>
    /// <param name="list"></param>
    /// <param name="obj"></param>
    private void SetI_FighterAttack(List<I_FighterAttack> list, Transform obj)
    {
        string name = obj.gameObject.name;

        switch (name)
        {
            case "Bullet":
                list.Add(new BulletAttack(obj, fighterAttack, status));
                break;
            case "SmallMissile":
                list.Add(new SmallMissileAttack(obj, fighterAttack, status));
                break;
            case "MediumMissile":
                //list.Add(new MediumMissileAttack());
                break;
            default:
                Debug.LogWarning("Unknown " + name);
                break;
        }
    }

    /// <summary>
    /// レベル別リスト取得関数
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public List<I_FighterAttack> GetLevelAttacks(int level)
    {
        return level switch
        {
            1 => level1,
            2 => level2,
            3 => level3,
            _ => new List<I_FighterAttack>(),
        };
    }
}
