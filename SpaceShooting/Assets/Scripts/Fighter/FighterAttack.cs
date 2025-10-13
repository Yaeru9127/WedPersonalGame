using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

/*戦闘機の攻撃ロジック*/
public class FighterAttack : MonoBehaviour
{
    /// <summary>
    /// Other Scripts
    /// </summary>
    private InputSystem_Actions actions;

    //戦闘機の複数の攻撃パターンのList
    private List<I_FighterAttack> attackPatterns = new List<I_FighterAttack>();

    //攻撃処理の非同期タスクをキャンセルするためのトークン管理オブジェクト
    //=> 攻撃を止めたい時にキャンセル処理を実行するために使う
    private CancellationTokenSource attackCTS;


    private void OnEnable()
    {
        //新たなCancellationTokenSourceを生成
        attackCTS = new CancellationTokenSource();

        //attackPatternsに登録された全ての攻撃パターンに対して非同期で攻撃処理を開始する
        foreach (var attack in attackPatterns)
        {
            attack.AttackAsync(attackCTS.Token).Forget();
        }
    }

    private void Start()
    {
        actions = InputSystemManager.instance.GetActions();
    }


    /// <summary>
    /// 攻撃ボタンの押してる判定を返す関数
    /// </summary>
    /// <returns></returns>
    public bool GetActionKeyPressed()
    {
        return actions.Player.Attack.WasPressedThisFrame();
    }

    private void OnDisable()
    {
        //実行中のタスクにキャンセル要求
        attackCTS?.Cancel();
    }

    /// <summary>
    /// 戦闘機の攻撃パターンを外部からセットする関数
    /// </summary>
    /// <param name="attackPattern"></param>
    public void Initialize(List<I_FighterAttack> attackPattern)
    {
        //攻撃パターンのリストを"attackPatterns"に保存する
        this.attackPatterns = attackPattern;
    }
}
