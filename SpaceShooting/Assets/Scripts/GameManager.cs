using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager gameManager;
    public static GameManager instance => gameManager;

    private bool isPause;
    private const float backGroundSpeed = 100f; //背景の移動速度

    public bool SetPause
    {
        get => isPause;     //外部から現在の値を読み取る
        set
        {
            //値が変わったときだけ通知する
            if (isPause != value)
            {
                isPause = value;    //ポーズのオンオフ
                Time.timeScale = isPause ? 0f : 1f;     //タイムスケールのオンオフ
                NotifyPause?.Invoke(isPause);
            }
        }
    }
    //ポーズ状態を通知するイベント
    public event System.Action<bool> NotifyPause;

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
        isPause = false;
    }
}
