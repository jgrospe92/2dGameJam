using UnityEngine;
using System.Collections;

public class AIPatrol : MonoBehaviour
{


    public bool mustPatrol;
   
    // Control enemy movement
    public float walkSpeed;

    public Rigidbody2D rigidBody;

    [SerializeField] private GameObject groundObject;
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask layers;

    [SerializeField] GameObject otherEnemy;

    [Header("RayCast parameter")]
    [SerializeField] private float maxRayDistance;

    // ref to the bullet
    public Bullet bulletPrefab;

    private SpriteRenderer sp;



    [SerializeField] private HealthBar hp;

    public float maxHp;
    private float currentHp;


    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
        isGrounded = true;

        // set inital HP
        currentHp = maxHp;
        hp.setMaxHp(currentHp);

        sp = GetComponent<SpriteRenderer>();


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            StartCoroutine(FlashRed());
            TakeDamage(bulletPrefab.bulletDamage);


        }

        if (currentHp < 0.01f)
        {
            Destroy(gameObject);
        }
    }

    // when damage
    void TakeDamage(float damage)
    {
        currentHp -= damage;

        hp.setHealth(currentHp);
    }


    private void GroundCheck()
    {
        isGrounded = Physics2D.Raycast(groundObject.transform.position, Vector2.down, maxRayDistance, layers);
        
    }
    // Update is called once per frame
    void Update()
    {
        hp.fill.color = Color.red;

        GroundCheck();
        if (!isGrounded)
        {
            flip();
        }


    }

    private void FixedUpdate()
    {

        if (mustPatrol && isGrounded)
        {
            Patrol();
        }

    }

    void Patrol()
    {
        if(transform.rotation.y == -1)
        {
            rigidBody.velocity = new Vector2(-walkSpeed * Time.fixedDeltaTime, 0);
        }
        else
        {
            rigidBody.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, 0);
        }

    }

    void flip()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0) * transform.rotation;
    }

    public IEnumerator FlashRed()
    {
        sp.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sp.color = Color.white;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(groundObject.transform.position, Vector2.down * maxRayDistance);
    }
}
