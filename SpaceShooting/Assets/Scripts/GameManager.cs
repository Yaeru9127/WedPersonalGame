using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager gameManager;
    public static GameManager instance => gameManager;

    protected bool isPause;

    public bool SetPause
    {
        get => isPause;     //�O�����猻�݂̒l��ǂݎ��
        set
        {
            //�l���ς�����Ƃ������ʒm����
            if (isPause != value)
            {
                isPause = value;    //�|�[�Y�̃I���I�t
                Time.timeScale = isPause ? 0f : 1f;     //�^�C���X�P�[���̃I���I�t
                PauseChange?.Invoke(isPause);
            }
        }
    }
    public event System.Action<bool> PauseChange;

    private void Awake()
    {
        //�V���O���g��
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
