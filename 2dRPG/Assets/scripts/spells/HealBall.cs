using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBall : MonoBehaviour, Spell
{
    public void execute(Dictionary<string, object> context)
    {
        Player player = (Player) context["player"];

        player.health += 50;
        if (player.health > 500) player.health = 500;
        player.healthbar.updateHealth(player.health, player.maxHealth);

        Rigidbody2D casterRbody = (Rigidbody2D)context["casterRbody"];
        Vector2 myPos = new Vector2(casterRbody.position.x, casterRbody.position.y);

        Instantiate(gameObject, myPos, Quaternion.identity);
    }

    // Use this for initialization
    void Start () {
        //TODO need to implement a better way of destroying object after animation
        Destroy(gameObject, 0.7f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
