using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour, Spell
{
    Rigidbody2D spellRbody;

    public string targetTag;
    public string casterTag;
    public int damage = 30;

    public void execute(Dictionary<string, object> context)
    {
        Rigidbody2D casterRbody = (Rigidbody2D) context["casterRbody"];
        this.targetTag = (string) context["targetTag"];
        this.casterTag = (string)context["casterTag"]; 

        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        if (context.ContainsKey("targetRbody"))
        {
            Rigidbody2D targetRbody = (Rigidbody2D) context["targetRbody"];

            target = new Vector2(targetRbody.position.x, targetRbody.position.y);
        }

        Vector2 myPos = new Vector2(casterRbody.position.x, casterRbody.position.y);
        Vector2 direction = target - myPos;

        spellRbody = gameObject.GetComponent<Rigidbody2D>();
        
        direction.Normalize();
        var projectile = Instantiate(spellRbody, myPos, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * 5;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.tag.Equals(this.casterTag) && !col.gameObject.tag.Equals("Event"))

        {
            Destroy(gameObject);

            if (col.gameObject.tag.Equals(this.targetTag))
            {
                if ("Monster".Equals(this.targetTag))
                {
                    Monster mon = col.GetComponent<Monster>();
                    mon.takeDamage(this.damage);
                }

                if ("Player".Equals(this.targetTag))
                {
                    Player player = col.GetComponent<Player>();                  
                    player.takeDamage(this.damage);
                }

            }

        }
        
    }
}