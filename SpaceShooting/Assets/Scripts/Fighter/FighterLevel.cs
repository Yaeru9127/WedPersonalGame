using UnityEngine;

/*レベル管理*/
public class FighterLevel
{
    private int level = 1;

    /// <summary>
    /// レベルアップ関数(仮)
    /// </summary>
    public void LevelUp()
    {
        level++;
    }

    /// <summary>
    /// レベルの設定関数
    /// </summary>
    /// <param name="level"></param>
    public void SetLevel(int level)
    {
        this.level = level;
    }
}
