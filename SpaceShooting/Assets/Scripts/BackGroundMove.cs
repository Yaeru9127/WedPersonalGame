using UnityEditor;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    private GameManager manager;
    private RectTransform rect;

    private RectTransform pairBackPanel;    //�����ꖇ�̔w�i
    private float speed; //�w�i�̈ړ����x

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //������
        manager = GameManager.instance;
        rect = this.gameObject.GetComponent<RectTransform>();
        speed = manager.publicBackGroundSpeed;

        //�f�o�b�O
        //if (rect == null) Debug.LogError("error");
        //else if (rect != null) Debug.Log("not null");
    }

    /// <summary>
    /// �����ꖇ�̔w�i��ݒ肷��֐�
    /// </summary>
    /// <param name="pair"></param>
    public void SetPairBackGroundPanel(RectTransform pair)
    {
        pairBackPanel = pair;
    }

    /// <summary>
    /// �w�i�ړ��֐�
    /// </summary>
    private void MoveBackGround()
    {
        if (manager == null || manager.SetPause) return;

        //�w�i�̈ړ�
        rect.anchoredPosition += Vector2.down.normalized * speed * Time.deltaTime;

        //��ʊO�ɂȂ����烊�Z�b�g�|�W�V�����Ɉړ�
        if (rect.anchoredPosition.y <= -rect.rect.height)
        {
            //X���W�͕ς����AY���W��(���݂̍��� + �w�i�̍��� -1)�Ō��Ԃ�h��
            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, 
                pairBackPanel.anchoredPosition.y + rect.rect.height - 1);
        }
    }

    private void Update()
    {
        MoveBackGround();
    }
}
