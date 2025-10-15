using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

/*弾の生成*/
public class CreateAttackObject
{
    public async Task<GameObject> LoadAndInstantiate(string address)
    {
        //アドレスから取得
        AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(address);

        try
        {
            GameObject prefab = await handle.Task;

            if (prefab != null)
            {
                GameObject instance = GameObject.Instantiate(prefab);
                return instance;
            }
            else
            {
                Debug.LogError("Asset loading failed");
                return null;
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("An exception occurred while loading the asset: " + ex);
            return null;
        }
        finally
        {
            // アセットの参照を解放
            Addressables.Release(handle);
        }
    }

    //呼び出しのテストコード
    //private async void Test()
    //{
    //    CreateAttackObject helper = new CreateAttackObject();
    //    GameObject obj = await helper.LoadAndInstantiate("MyPrefab");

    //    if (obj != null)
    //    {
    //        obj.transform.position = Vector3.zero;
    //    }
    //}

    public void CreateAttack(FighterType.TypeOfFighter type, int l)
    {
        switch (type)
        {
            case FighterType.TypeOfFighter.FighterExcalibur:
                FighterExcaliburBullet(l);
                break;
            case FighterType.TypeOfFighter.FrigateCorsair:
                FrigateCorsairBullet(l);
                break;
            case FighterType.TypeOfFighter.DestroyerPhoenix:
                DestroyerPhoenix(l);
                break;
            default:
                Debug.LogError("this type is none");
                break;
        }
    }

    public void FighterExcaliburBullet(int l)
    {
        switch (l)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                Debug.LogError("this level is out of fighter's level");
                break;
        }
    }

    public void FrigateCorsairBullet(int l)
    {
        switch (l)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                Debug.LogError("level is out of fighter's level");
                break;
        }
    }

    public void DestroyerPhoenix(int l)
    {
        switch (l)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                Debug.LogError("level is out of fighter's level");
                break;
        }
    }
}
