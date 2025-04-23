using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public DialogueManager dM;

    public float speed;
    public float detectionRadius; // 따라오기 감지 반경
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

        // 플레이어와의 거리 계산
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);

        // 플레이어가 따라오는 반경 내에 있을 때만 따라오도록
        if (distanceToPlayer <= detectionRadius)
        {
            Vector2 dirVec = target.position - rigid.position;
            Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
            rigid.MovePosition(rigid.position + nextVec);
            rigid.velocity = Vector2.zero;

            // 플레이어가 오른쪽에 있으면 오른쪽을 보게
            // 플레이어가 왼쪽에 있으면 왼쪽을 보게
            spriter.flipX = target.position.x > transform.position.x;


            //애니메이션
            anim.SetBool("isChange", true);
        }
        else
            anim.SetBool("isChange", false);
    }

    // 충돌 감지
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // 플레이어와 부딪혔을 때 다음 씬으로 이동
            SceneManager.LoadScene("Over Scene");
        }
    }
}
