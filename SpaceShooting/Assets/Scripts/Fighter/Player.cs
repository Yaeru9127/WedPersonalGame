using UnityEngine;
using UniRx;
using System;

public class Player : MonoBehaviour
{
    private InputSystem_Actions action;

    private float bulletInterval;
    private IDisposable shootStream;

    private void OnDestroy()
    {
        shootStream?.Dispose();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*������*/
        //InputSystem
        action = InputSystemManager.instance.GetActions();
        InputSystemManager.instance.PlayerOn();

        bulletInterval = GameManager.instance.publicBulletInterval;

        /*�U�����̃|�[�Y�̃`�F�b�N*/
        GameManager.instance.IsPause
            .Subscribe(pause =>
            {
                //�|�[�YOn
                if (pause)
                {
                    shootStream?.Dispose(); //�A�ˏ����̍w�ǉ���
                    shootStream = null;     //��Ԃ̃N���A
                }
                //�|�[�YOff
                else if (!pause)
                {
                    shootStream = Observable.EveryUpdate()                      //�C�x���g�X�g���[���̍쐬
                        .Where(_ => action.Player.Attack.IsPressed())           //�U���{�^����������Ă���Ԃ̂݃C�x���g��ʂ�
                        .ThrottleFirst(TimeSpan.FromSeconds(bulletInterval))    //�A�ˑ��x����
                        .Subscribe(_ => Fire())                                 //�e�̔��ˊ֐����Ăяo��
                        .AddTo(this);                                           //�����I�ɍw�ǉ���
                }
            })
            .AddTo(this);
    }

    /// <summary>
    /// �v���C���[�̍U���֐�
    /// </summary>
    private void Fire()
    {
        Debug.Log("fire");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
