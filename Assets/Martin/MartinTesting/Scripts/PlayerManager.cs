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
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    #region Variables
    public float speed;
    public Vector2 motion;
    private Animator anim;
    private SpriteRenderer rend;
    private Rigidbody2D rigid;

    [Header("Player Stats")]
    public float curHealth;
    public float maxHealth;

    public Image[] heartSlots;
    public Sprite[] hearts;
    public float healthPerSection;
    public bool alive = true;
    #endregion
    void Start()
    {
        //when game is started components are automatically added
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        //UpdateHearts();
        alive = true;
    }

    void Update()
    {
        Move();
        //Heart();
        
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

    public void TakeDamage(float amount)
    {
        if (!alive)
        {
            return;
        }
        if (curHealth<=0)
        {
            curHealth = 0;
            alive = false;
            gameObject.SetActive(false);
        }
        curHealth -= amount;
    }
    void Heart()
    {
        int i = 0;
        foreach (Image slot in heartSlots)
        {
            if (curHealth >= ((healthPerSection * 1)) + healthPerSection * 2 * i)
            {
                heartSlots[i].sprite = hearts[0];
            }
            else if (curHealth >= ((healthPerSection * 1)) + healthPerSection * 2 * i)
            {
                heartSlots[i].sprite = hearts[1];
            }
            
            else
            {
                heartSlots[i].sprite = hearts[2];
            }

            i++;
        }
    }
    void UpdateHearts()
    {
        //calculate the health points per heart section
        healthPerSection = maxHealth / (heartSlots.Length * 2);
    }
}
