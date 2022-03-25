using UnityEngine;

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



    [SerializeField] private HealthBar hp;

    public int maxHp = 20;
    private int currentHp;


    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
        isGrounded = true;

        // set inital HP
        currentHp = maxHp;
        hp.setMaxHp(currentHp);
        hp.fill.color = Color.red;

        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TakeDamage(20);
            
            Debug.Log("I hit an enemy");
            Debug.Log("current hp" + this.currentHp);
            Debug.Log("max hp" + this.maxHp);

        }
    }

    // when damage
    void TakeDamage(int damage)
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(groundObject.transform.position, Vector2.down * maxRayDistance);
    }
}
