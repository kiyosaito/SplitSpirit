// =========================================================
// Title: PlayerManager
// Author(s): Martin Nguyen,
// Date: 05/06/2019
// Details: handles player movement,animation according interaction, 
// Reference: Jack Adam-De-Villiers
// =========================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Variables
    public float speed;
    public Vector2 motion;
    private Animator anim;
    private SpriteRenderer rend;
    private Rigidbody2D rigid;
    #endregion
    void Start()
    {
        //when game is started components are automatically added
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    void Move() //Function for movement going horizontal and vertical on x and y axis
    {
        float inputH = Input.GetAxisRaw("Horizontal");
        float inputV = Input.GetAxisRaw("Vertical");
        Vector2 moveInput = new Vector2(inputH, inputV);
        motion = moveInput.normalized * speed;

        anim.SetBool("IsRunningH", inputH !=0);
        anim.SetBool("IsRunningV", inputV !=0);
        rend.flipX = inputH < 0;
        rigid.MovePosition(rigid.position + motion * Time.deltaTime);

    }
}
