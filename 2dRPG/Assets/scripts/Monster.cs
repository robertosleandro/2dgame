using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int health;
    public string state;
    public int maxHealth;
    public healthbar healthbar;
    public float speed;

    public float actionTime; 

    Spellbook spellBook;
    Spell currentSpell;

    [SerializeField]
    Rigidbody2D rbody;
    [SerializeField]
    Rigidbody2D player;

    Vector2 direction;

    private IEnumerator directionTimer;
    private IEnumerator actionTimer;

    // Use this for initialization
    void Start () {

        maxHealth = 200;

        actionTime = 0.0f;
        health = maxHealth;
        // healthbar = GetComponent<healthbar>();
        rbody = GetComponent<Rigidbody2D>();
        state = "passive";
        directionTimer = WaitForDirection(1.0f);
        

        StartCoroutine(directionTimer);
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        spellBook = new Spellbook(new List<string>(new string[] { "fireball" }));
        currentSpell = spellBook.spells[0];
    }
	
	// Update is called once per frame
	void Update () {
        if (health > 0)
        {
            move();
        }else
        {
            Destroy(gameObject);
        }
	}

    private IEnumerator WaitForDirection(float waitTime)
    {
        while (true)
        {

            yield return new WaitForSeconds(waitTime);

            if ("passive".Equals(state))
            {
                direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            }else if ("aggro".Equals(state))
            {
                castSpell(currentSpell);

                waitTime = 2.0f;
            }
           
        }
    }

    private IEnumerator WaitForAction(float actionTime)
    {
        while (true)
        {

            yield return new WaitForSeconds(actionTime);

        }
    }

    public void takeDamage(int amount)
    {
        health -= amount;
        // Debug.Log("Player health: " + this.health);
        state = "aggro";
        healthbar.updateHealth(health, maxHealth);
    }

    void castSpell(Spell spell)
    {
        Dictionary<string, object> context = new Dictionary<string, object>();
        context.Add("targetTag", "Player");
        context.Add("casterTag", "Monster");
        context.Add("casterRbody", this.rbody);
        context.Add("targetRbody", this.player); 

        spell.execute(context);
    }

    public void move()
    {

        if ("aggro".Equals(state))
        {
            Vector2 closness = rbody.position - player.position;

            bool isTooClose = closness.x < 1 && closness.y < 1;

            if (!isTooClose)
            {
                rbody.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            
        }else
        {
            rbody.MovePosition(rbody.position + direction * speed * Time.deltaTime);
        }
    }
}
