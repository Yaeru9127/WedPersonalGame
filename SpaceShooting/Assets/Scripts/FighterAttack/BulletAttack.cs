using Cysharp.Threading.Tasks;
using System.Threading;
using System;
using UnityEngine;

public class BulletAttack : I_FighterAttack
{
    private Transform firePoint;    //�e�����ꏊ
    private GameObject bullet;      //�e�̃I�u�W�F�N�g
    private const float interval = 0.2f;         //�U���̃C���^�[�o��

    public BulletAttack(Transform firePoint, GameObject bulletPrefab)
    {
        this.firePoint = firePoint;
        this.bullet = bulletPrefab;
    }

    public async UniTask AttackAsync(CancellationToken token)
    {
        try
        {
            //�L�����Z���v��������܂Ń��[�v���p��
            while (!token.IsCancellationRequested)
            {
                /*�U������*/
                //���ˊԊu�̃C���^�[�o��
                await UniTask.Delay((int)(interval * 1000f), cancellationToken: token);

                /*�����Ɏ��ۂ̍U�������i�e�̐����A���˂Ȃǁj*/
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"AttackAsync error: {ex}");
        }
    }
}
