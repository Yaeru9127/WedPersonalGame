using UnityEngine;

/*���x���Ǘ�*/
public class FighterLevel
{
    private int level = 1;

    /// <summary>
    /// ���x���A�b�v�֐�(��)
    /// </summary>
    public void LevelUp()
    {
        level++;
    }

    /// <summary>
    /// ���x���̐ݒ�֐�
    /// </summary>
    /// <param name="level"></param>
    public void SetLevel(int level)
    {
        this.level = level;
    }
}
