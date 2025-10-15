using UnityEngine;

/*戦闘機（プレイヤー）のステータス*/
public class FighterStatus
{
    private GameObject player;
    private FighterType.TypeOfFighter type;

    public FighterStatus(GameObject player, FighterType.TypeOfFighter type)
    {
        this.player = player;
        this.type = type;
    }
}
