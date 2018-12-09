using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gasball : MonoBehaviour, Spell
{
    public void execute(Dictionary<string, object> context)
    {
        Rigidbody2D playerBody = (Rigidbody2D)context["casterRbody"];

        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        var projectile = Instantiate(gameObject, target, Quaternion.identity); 
    }

    // Use this for initialization
    void Start()
    {
        //TODO need to implement a better way of destroying object after animation
        Destroy(gameObject, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.tag.Equals("Player") && !col.gameObject.tag.Equals("Event"))
        {
            if (col.gameObject.tag.Equals("Monster"))
            {
                Monster mon = col.GetComponent<Monster>();

                if (mon != null)
                {
                    mon.takeDamage(50);
                }
            }

        }
    }
}
