using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class FighterFactory : MonoBehaviour
{
    private GameObject player;

    private async void Start()
    {
        //プレイヤーオブジェクトの生成
        await LoadFighter("FighterExcalibur");

        //FighterAttackの取得
        FighterAttack fighterAttack;
        fighterAttack = player.GetComponent<FighterAttack>();
        if (fighterAttack == null) fighterAttack = player.AddComponent<FighterAttack>();

        //レベルの設定
        FighterLevel level = new FighterLevel();
        level.SetLevel(1);

        //攻撃パターンの生成と設定
        AttackSpawnPoints spawnPoints = new AttackSpawnPoints(fighterAttack);
        spawnPoints.GetAttackSpawnPoints(player);
        List<I_FighterAttack> pattern = spawnPoints.GetLevelAttacks(1);
        fighterAttack.SetAttackPattern(pattern);
    }

    /// <summary>
    /// 戦闘機を読み込む関数
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private async UniTask LoadFighter(string name)
    {
        var handle = Addressables.LoadAssetAsync<GameObject>(name);
        try
        {
            player = await handle.ToUniTask();
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed {ex}");
        }
        finally
        {
            //生成(値は仮)
            Instantiate(player, Vector3.zero, Quaternion.identity);

            //リリース
            Addressables.Release(handle);
        }
    }


}