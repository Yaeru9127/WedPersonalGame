using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager gameManager;
    public static GameManager instance => gameManager;

    private bool isPause;
    private const float backGroundSpeed = 100f; //�w�i�̈ړ����x

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
                NotifyPause?.Invoke(isPause);
            }
        }
    }
    //�|�[�Y��Ԃ�ʒm����C�x���g
    public event System.Action<bool> NotifyPause;

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
