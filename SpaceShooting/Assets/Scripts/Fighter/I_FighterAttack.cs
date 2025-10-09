using Cysharp.Threading.Tasks;
using System.Threading;

/*インターフェース*/
public interface I_FighterAttack
{
    UniTask AttackAsync(CancellationToken token);
}
