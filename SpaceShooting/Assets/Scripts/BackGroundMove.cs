using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    Vector2 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = GetStartPosition();
    }

    /// <summary>
    /// �w�i�摜�̃��Z�b�g�|�W�V�����ݒ�֐�
    /// </summary>
    /// <returns></returns>
    private Vector2 GetStartPosition()
    {
        //null�`�F�b�N
        if (this.gameObject.transform.parent == null) Debug.LogError("this object's parent is null");

        //Panel�Ȃ̂ŁA�e�ł���Canvas�̒��S���W���擾
        GameObject parent = this.gameObject.transform.parent.gameObject;
        RectTransform canvasRect = parent.GetComponent<RectTransform>();

        return canvasRect.rect.center;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
