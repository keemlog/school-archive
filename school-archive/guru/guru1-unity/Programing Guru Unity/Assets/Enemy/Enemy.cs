using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public DialogueManager dM;

    public float speed;
    public float detectionRadius; // ������� ���� �ݰ�
    public Rigidbody2D target;

    public Animator anim;
    float h;
    float v;

    bool isLive;

    Rigidbody2D rigid;
    SpriteRenderer spriter;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (dM.isAction)
        {
            speed = 0;
            anim.SetBool("isChange", false);
        }
        else
        {
            speed = 3;
        }

        // �÷��̾���� �Ÿ� ���
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);

        // �÷��̾ ������� �ݰ� ���� ���� ���� ���������
        if (distanceToPlayer <= detectionRadius)
        {
            Vector2 dirVec = target.position - rigid.position;
            Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
            rigid.MovePosition(rigid.position + nextVec);
            rigid.velocity = Vector2.zero;

            // �÷��̾ �����ʿ� ������ �������� ����
            // �÷��̾ ���ʿ� ������ ������ ����
            spriter.flipX = target.position.x > transform.position.x;


            //�ִϸ��̼�
            anim.SetBool("isChange", true);
        }
        else
            anim.SetBool("isChange", false);
    }

    // �浹 ����
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // �÷��̾�� �ε����� �� ���� ������ �̵�
            SceneManager.LoadScene("Over Scene");
        }
    }
}
