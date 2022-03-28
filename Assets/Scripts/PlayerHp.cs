
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHp : MonoBehaviour
{

    // Health bar ref
    public HealthBar hp;

    public GameObject hud;


    public int maxHp = 100;
    public int currentHp;
    // Start is called before the first frame update

    PlayerMovement player;

    void Start()
    {
        currentHp = maxHp;
        hp.setMaxHp(maxHp);
        player = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        takeDamage(20);
    //    }

    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            takeDamage(20);
            player.damage = true;
        }
        
        if (collision.gameObject.tag == "HP")
        {
            if (currentHp < 100)
            {
                currentHp += 10;
                hp.setHealth(currentHp);
            }
            Destroy(collision.gameObject);
        }

        if (currentHp <= 0)
        {
           
            player.isDead = true;
            hud.SetActive(true);
        }

        if(collision.gameObject.tag == "InstantDeath")
        {

            hp.setHealth(0);
            player.isDead = true;
            hud.SetActive(true);
        }

       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            
            player.damage = false;
        }
    }

    // when damage
    void takeDamage(int damage)
    {
        currentHp -= damage;

        hp.setHealth(currentHp);
    }

    // restart
    public void Restart()
    {
        SceneManager.LoadScene("LevelOne");
    }
}
