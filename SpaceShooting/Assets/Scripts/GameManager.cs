using UnityEngine;
using UniRx;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// instance
    /// </summary>
    private static GameManager gameManager;
    public static GameManager instance => gameManager;

    /// <summary>
    /// ポーズ
    /// </summary>
    private ReactiveProperty<bool> isPause = new ReactiveProperty<bool>(false);
    public IReadOnlyReactiveProperty<bool> IsPause => isPause;
    public bool SetPause
    {
        get => isPause.Value;     //外部から現在の値を読み取る
        set
        {
            //値が変わったときだけ通知する
            if (isPause.Value != value)
            {
                isPause.Value = value;                        //ポーズのオンオフ
                Time.timeScale = isPause.Value ? 0f : 1f;     //タイムスケールのオンオフ
            }
        }
    }

    private void Awake()
    {
        //シングルトン
        if (gameManager != null && gameManager != this)
        {
            Destroy(this.gameObject);
            return;
        }
        gameManager = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
