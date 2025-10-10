using UnityEngine;

public class FighterType
{
    //�퓬�@�̎��
    [HideInInspector]
    public enum TypeOfFighter
    {
        FighterExcalibur,  //�t�@�C�^�[�G�N�X�J���o�[
        FrigateCorsair,   //�t���Q�[�g�̓R���Z�A
        DestroyerPhoenix    //�쒀�̓t�F�j�b�N�X
    }
    private TypeOfFighter fighterType;

    /// <summary>
    /// �퓬�@�̎�ނ̐ݒ�֐�
    /// </summary>
    /// <param name="i"></param>
    public void SetFighterType(TypeOfFighter t)
    {
        fighterType = t;
    }

    /// <summary>
    /// �퓬�@�̎�ނ̐ݒ�֐�
    /// </summary>
    /// <returns></returns>
    public TypeOfFighter GetFighterType()
    {
        return fighterType;
    }
}
