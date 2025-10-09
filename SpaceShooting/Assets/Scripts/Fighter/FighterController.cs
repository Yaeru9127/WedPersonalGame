using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

/*�퓬�@�̋��ʐ��䃍�W�b�N*/
public class FighterController : MonoBehaviour
{
    //�퓬�@�̕����̍U���p�^�[����List
    private List<I_FighterAttack> attackPatterns = new List<I_FighterAttack>();

    //�U�������̔񓯊��^�X�N���L�����Z�����邽�߂̃g�[�N���Ǘ��I�u�W�F�N�g
    //=> �U�����~�߂������ɃL�����Z�����������s���邽�߂Ɏg��
    private CancellationTokenSource attackCTS;

    private void OnEnable()
    {
        //�V����CancellationTokenSource�𐶐�
        attackCTS = new CancellationTokenSource();

        //attackPatterns�ɓo�^���ꂽ�S�Ă̍U���p�^�[���ɑ΂��Ĕ񓯊��ōU���������J�n����
        foreach (var attack in attackPatterns)
        {
            attack.AttackAsync(attackCTS.Token).Forget();
        }
    }

    private void OnDisable()
    {
        //���s���̃^�X�N�ɃL�����Z���v��
        attackCTS?.Cancel();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    /// <summary>
    /// �퓬�@�̍U���p�^�[�����O������Z�b�g����֐�
    /// </summary>
    /// <param name="attackPattern"></param>
    public void Initialize(List<I_FighterAttack> attackPattern)
    {
        //�U���p�^�[���̃��X�g��"attackPatterns"�ɕۑ�����
        this.attackPatterns = attackPattern;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
