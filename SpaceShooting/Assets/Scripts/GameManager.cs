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
    /// �w�i�̈ړ����x
    /// </summary>
    private const float backGroundSpeed = 100f;
    public float publicBackGroundSpeed => backGroundSpeed;

    /// <summary>
    /// �e���˂̃C���^�[�o��
    /// </summary>
    private float interval;
    public float publicInterval => interval;

    /// <summary>
    /// �|�[�Y
    /// </summary>
    private ReactiveProperty<bool> isPause = new ReactiveProperty<bool>(false);
    public IReadOnlyReactiveProperty<bool> IsPause => isPause;
    public bool SetPause
    {
        get => isPause.Value;     //�O�����猻�݂̒l��ǂݎ��
        set
        {
            //�l���ς�����Ƃ������ʒm����
            if (isPause.Value != value)
            {
                isPause.Value = value;                        //�|�[�Y�̃I���I�t
                Time.timeScale = isPause.Value ? 0f : 1f;     //�^�C���X�P�[���̃I���I�t
            }
        }
    }

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
    }
}
