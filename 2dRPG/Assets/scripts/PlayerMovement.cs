using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    Animator anim;
    public float speed;

    public bool canTakeAction; 

    [SerializeField]
    float bulletSpeed;

    [SerializeField]
    Rigidbody2D rbody;

    [SerializeField]
    Rigidbody2D fireball;

    [SerializeField]
    Transform gun;

    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canTakeAction = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (canTakeAction)
        {
            move();
            castSpell();
        }
    }

    public void castingEnded()
    {
      //  Debug.Log("Entering casting ended");
        anim.SetBool("iscasting", false);
        anim.SetBool("iswalking", true);
        canTakeAction = true;
        fire();
    }

    void castSpell()
    {
        if (Input.GetMouseButtonDown(0))
        {
            canTakeAction = false;
            anim.SetBool("iscasting", true);
            anim.SetBool("iswalking", false);
        }
    }

    void fire()
    {
        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Vector2 myPos = new Vector2(rbody.position.x, rbody.position.y);
        Vector2 direction = target - myPos;

        direction.Normalize();
        var projectile = Instantiate(fireball, myPos, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        //projectile.position = Vector2.MoveTowards(myPos, target, bulletSpeed * Time.deltaTime);
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

}
