using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Restore : MonoBehaviour
{
    // Start is called before the first frame update
    // Health bar ref
    public HealthBar hp;

    public int maxHp = 100;
    public int currentHp;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        hp.setMaxHp(maxHp);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            takeDamage(20);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            takeDamage(20);
        }

        if (currentHp == 0)
        {
            Debug.Log("game over");
        }
    }

    // when damage
    void takeDamage(int damage)
    {
        currentHp -= damage;

        hp.setHealth(currentHp);
    }
}
