using Cysharp.Threading.Tasks;
using System.Threading;

/*�C���^�[�t�F�[�X*/
public interface I_FighterAttack
{
    UniTask AttackAsync(CancellationToken token);
}
