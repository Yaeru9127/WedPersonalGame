using UnityEditor;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    private RectTransform rect;

    private Vector3 startPos;                   //�w�i�̃��Z�b�g�|�W�V����
    private Vector2 moveDirection = new Vector2(0, -1);
    private float speed; //�w�i�̈ړ����x

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //������
        rect = this.gameObject.GetComponent<RectTransform>();
        speed = GameManager.instance.publicBackGroundSpeed;

        //�f�o�b�O
        //if (rect == null) Debug.LogError("error");
        //else if (rect != null) Debug.Log("not null");
    }

    public void GetStartPos(Vector3 pos)
    {
        startPos = pos;
    }

    /// <summary>
    /// �w�i�ړ��֐�
    /// </summary>
    private void MoveBackGround()
    {
        if (GameManager.instance != null && GameManager.instance.SetPause) return;

        //�w�i�̈ړ�
        Vector2 move = moveDirection.normalized * speed * Time.deltaTime;
        rect.anchoredPosition += move;

        //��ʊO�ɂȂ����烊�Z�b�g�|�W�V�����Ɉړ�
        if (rect.anchoredPosition.y <= -450)
        {
            rect.anchoredPosition = startPos;
        }
    }

    private void Update()
    {
        MoveBackGround();
    }
}
