using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : PlayerMove
{
    private static PlayerManager instance;
    public GameManager manager;
    public DialogueManager dManager;
    Inventory inventory;

    public string currentMapName;

    float h;
    float v;
    float a = 1;
    bool isHorizonMove;
    bool isVerticalMove;

    public bool canMove = true;

    Rigidbody2D rigid;

    SpriteRenderer spriteRenderer;

    public GameObject scanObject;


    // Start is called before the first frame update
    void Awake()
    {
        //if (instance != null)
        //{
        //    Destroy(gameObject);
        //    return;
        //}
        //else
        //{
        //    instance = this;
        //    DontDestroyOnLoad(this.gameObject);
        //}

        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //이동
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        //버튼 이동 방향 체크
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        //수평 이동 체크
        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = h != 0;


        if (canMove)
        {
            //방향
            if (vDown && v == 1)
                dirVec = Vector3.up;
            else if (vDown && v == -1)
                dirVec = Vector3.down;
            else if (hDown && h == -1)
                dirVec = Vector3.left;
            else if (hDown && h == 1)
                dirVec = Vector3.right;


            //애니메이션
            if (anim.GetInteger("hAxisRaw") != h)
            {
                anim.SetBool("isChange", true);
                anim.SetInteger("hAxisRaw", (int)h);
            }
            else if (anim.GetInteger("vAxisRaw") != v)
            {
                anim.SetBool("isChange", true);
                anim.SetInteger("vAxisRaw", (int)v);
            }
            else
                anim.SetBool("isChange", false);

            if (Input.GetKey(KeyCode.LeftShift))
                speed = 7;
            else
                speed = 5;

            Vector2 dir = new Vector2(h, v) * speed;
            rigid.velocity = dir;


            //Scan Object
            if (Input.GetButtonDown("Jump") && scanObject != null)
            {
                if (scanObject.name == "Empty")
                    Debug.Log("해당 오브젝트에 스크립트가 존재하지 않습니다.");
                else
                    dManager.Action(scanObject);
            }
            else if (Input.GetButtonDown("Jump") && scanObject == null)
            {
                dManager.EndAction();
            }
        }
        else
        {
            Vector2 dir = new Vector2(h, v) * 0;
            rigid.velocity = dir;

            anim.SetInteger("hAxisRaw", 0);
            anim.SetInteger("vAxisRaw", 0);
        }

        
    }

    private void FixedUpdate()
    {

        //Ray
        Debug.DrawRay(rigid.position, dirVec * 0.8f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.8f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("FieldItem"))
    //    {
    //        FieldItems fieldItems = collision.GetComponent<FieldItems>();
    //        if (inventory.AddItem(fieldItems.GetItem()))
    //            fieldItems.DestroyItem();
    //    }
    //}
}
