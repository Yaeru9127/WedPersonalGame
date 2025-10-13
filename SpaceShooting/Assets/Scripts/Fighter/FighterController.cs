using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

/*戦闘機の共通制御ロジック*/
public class FighterController : MonoBehaviour
{
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

    private void OnDisable()
    {
        //実行中のタスクにキャンセル要求
        attackCTS?.Cancel();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
