using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager gameManager;
    public static GameManager instance => gameManager;

    protected bool isPause;

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
                PauseChange?.Invoke(isPause);
            }
        }
    }
    public event System.Action<bool> PauseChange;

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
