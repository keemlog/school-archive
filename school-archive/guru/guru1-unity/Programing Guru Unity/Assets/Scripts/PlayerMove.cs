using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 5f;

    public int walkCount;
    protected int currentWalkCount;

    protected Vector3 dirVec;

    //public CapsuleCollider2D collider;
    public Animator anim;

    protected void Move(string _dir)
    {
        StartCoroutine(MoveCoroutine(_dir));
    }

    IEnumerator MoveCoroutine(string _dir)
    {

        dirVec.Set(0, 0, dirVec.z);

        switch (_dir)
        {
            case "UP":
                dirVec.y = 1f;
                break;

            case "DOWN":
                dirVec.y = -1f;
                break;

            case "RIGHT":
                dirVec.x = 1f;
                break;

            case "LEFT":
                dirVec.x = -1f;
                break;
        }

        while (currentWalkCount < walkCount)
        {
            transform.Translate(dirVec.x * speed, dirVec.y * speed, 0);

            currentWalkCount++;
            yield return new WaitForSeconds(0.01f);
        }
    }



}
