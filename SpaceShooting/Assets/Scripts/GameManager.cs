using UnityEngine;
using UniRx;
using System;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// instance
    /// </summary>
    private static GameManager gameManager;
    public static GameManager instance => gameManager;

    /// <summary>
    /// 背景の移動速度
    /// </summary>
    private const float backGroundSpeed = 100f;
    public float publicBackGroundSpeed => backGroundSpeed;

    /// <summary>
    /// 弾発射のインターバル
    /// </summary>
    private float interval;
    public float publicInterval => interval;

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
