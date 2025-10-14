using Cysharp.Threading.Tasks;
using System;
using System.Threading;

/*インターフェース*/
public interface I_FighterAttack : IDisposable
{
    UniTask AttackAsync(CancellationToken token);
}
