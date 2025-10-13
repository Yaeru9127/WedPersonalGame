using UnityEngine;

public class FighterType
{
    //戦闘機の種類
    [HideInInspector]
    public enum TypeOfFighter
    {
        FighterExcalibur,  //ファイターエクスカリバー
        FrigateCorsair,   //フリゲート艦コルセア
        DestroyerPhoenix    //駆逐艦フェニックス
    }
    private TypeOfFighter fighterType;

    /// <summary>
    /// 戦闘機の種類の設定関数
    /// </summary>
    /// <param name="i"></param>
    public void SetFighterType(TypeOfFighter t)
    {
        fighterType = t;
    }

    /// <summary>
    /// 戦闘機の種類の設定関数
    /// </summary>
    /// <returns></returns>
    public TypeOfFighter GetFighterType()
    {
        return fighterType;
    }
}
