using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using static System.Collections.Specialized.BitVector32;

public class AttackTriggerStream : IDisposable
{
    private IDisposable stream;

    /// <summary>
    /// �U���X�g���[���̊J�n
    /// </summary>
    /// <param name="interval">�U���Ԋu�i�b�j</param>
    /// <param name="isAttackPresed">�U���{�^���̓��͊Ď�</param>
    /// <param name="onAttack">���ۂ̍U������</param>
    /// <param name="cancellation">�L�����Z���p�g�[�N��</param>
    public void StartAttackStream(float interval, Func<bool> isAttackPresed, Action onAttack, CancellationToken cancellation)
    {
        /*�U�����̃|�[�Y�̃`�F�b�N*/
        GameManager.instance.IsPause    //�|�[�Y��Ԃ̊Ď�
            .Subscribe(pause =>
            {
                //�|�[�Y���͏������~�߂�
                //��|�[�Y���͏������ēx�J�n
                stream?.Dispose();

                //�|�[�Y���łȂ��ꍇ
                if (!pause)
                {
                    stream = Observable.EveryUpdate()                       //�C�x���g�X�g���[���̍쐬
                    .Where(_ => isAttackPresed())                           //�U���{�^����������Ă���Ԃ̂݃C�x���g��ʂ�
                        .ThrottleFirst(TimeSpan.FromSeconds(interval))      //�A�ˑ��x����
                        .TakeUntilDestroy(GameManager.instance)             //GameManager.instance���j��
                        .TakeUntilDisable(GameManager.instance)             //GameManager.instance�������������܂ōw�ǂ��p��
                        .Subscribe(_ =>
                        {
                            if (!cancellation.IsCancellationRequested) onAttack?.Invoke();  //�L�����Z���g�[�N�����`�F�b�N���U������(�e�̐����Ȃ�)���Ă�
                        });
                }
            })
            .AddTo(GameManager.instance);                                   //�w�ǂ���������
    }

    public void Dispose()
    {
        stream?.Dispose();
    }
}
