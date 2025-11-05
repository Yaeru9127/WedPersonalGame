/*戦闘機（プレイヤー）のステータス*/
public class FighterStatus
{
    public FighterType.TypeOfFighter type { get; private set; }

    public FighterLevel Level { get; private set; }

    public FighterStatus(FighterType.TypeOfFighter type)
    {
        this.type = type;
    }
}
