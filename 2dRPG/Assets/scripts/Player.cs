using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{
    public Animator anim;
    public float speed;
    public bool canTakeAction;

    public int maxHealth;
    public PlayerHealthBar healthbar;

    public Spellbook spellBook;
    public Spell currentSpell;

    [SerializeField]
    Rigidbody2D rbody;

    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canTakeAction = true;
        maxHealth = 500;
        health = maxHealth;

        spellBook = new Spellbook(new List<string>(new string[] { "fireball", "gasball", "healball" }));
        currentSpell = spellBook.spells[0];      
    }

    // Update is called once per frame
    void Update()
    {
        if (canTakeAction && Time.timeScale == 1f)
        {
            move();
           // getPlayerInput();
        }
    }

    public void castingEnded()
    {
        anim.SetBool("iscasting", false);
        anim.SetBool("iswalking", true);
        canTakeAction = true;
        castSpell(currentSpell);
    }

   

    void castSpell(Spell spell)
    {
        Dictionary<string, object> context = new Dictionary<string, object>();
        context.Add("targetTag", "Monster");
        context.Add("casterTag", "Player");
        context.Add("casterRbody", this.rbody);
        context.Add("player", this);
    
        spell.execute(context);
    }

    void move()
    {
        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (movement_vector != Vector2.zero)
        {
            anim.SetBool("iswalking", true);
            anim.SetFloat("input_x", movement_vector.x);
            anim.SetFloat("input_y", movement_vector.y);
        }
        else
        {
            anim.SetBool("iswalking", false);
        }

        rbody.MovePosition(rbody.position + movement_vector * speed * Time.deltaTime);
    }

    public void takeDamage(int amount)
    {
        health -= amount;
       
        healthbar.updateHealth(health, maxHealth);
        Debug.Log("Player Health: " + health);
    }

}
