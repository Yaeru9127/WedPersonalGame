using System.Collections.Generic;
using UnityEngine;

public class AttackSpawnPoints
{
    private List<I_FighterAttack> level1 = new List<I_FighterAttack>();
    private List<I_FighterAttack> level2 = new List<I_FighterAttack>();
    private List<I_FighterAttack> level3 = new List<I_FighterAttack>();

    /// <summary>
    /// 攻撃のスポーン地点の親オブジェクトを取得する関数
    /// </summary>
    /// <param name="player"></param>
    public void GetAtackSpwanPoints(GameObject player)
    {
        //プレイヤーの子オブジェクトを参照
        int count = player.transform.childCount;
        List<GameObject> parents = new List<GameObject>(count);
        for (int i = 0; i < count; i++)
        {
            //オブジェクトの名前の数字判定
            Transform child = player.transform.GetChild(i);
            bool isNumber = int.TryParse(child.name, out _);
            int num = int.Parse(child.name);
            if (num >= 1 && num <= 3)
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
                list.Add(new BulletAttack(obj));
                break;
            case "SmallMissile":
                list.Add(new SmallMissileAttack(obj));
                break;
            case "MediumMissile":
                //list.Add(new MediumMissileAttack());
                break;
        }
    }
}
