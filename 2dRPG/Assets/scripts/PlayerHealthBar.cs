using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour {
    RectTransform rt;

    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    public void updateHealth(float maxHealth, float currentHealth)
    {
        float healthPrecentage = maxHealth / currentHealth;

//        rt.localScale += new Vector3(healthPrecentage * 0.1f * -1, 0);
        rt.localScale = new Vector3(healthPrecentage, 0.5f);

    }
}
