using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        if (rb == null) Debug.LogError("Rigidbody2D is none!!");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�G�ɓ��������甚���G�t�F�N�g�ƃI�u�W�F�N�g�̔j��
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = Vector2.up.normalized * 5;
    }
}
