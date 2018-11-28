using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbar : MonoBehaviour {
    RectTransform rt;
    
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    public void updateHealth(float maxHealth, float currentHealth)
    {
        float healthPrecentage = maxHealth/ currentHealth;

       rt.localScale = new Vector2(healthPrecentage * 0.1f, 0.1f);
    }

}
