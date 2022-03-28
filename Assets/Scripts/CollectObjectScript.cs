using UnityEngine;

public class CollectObjectScript : MonoBehaviour
{
    private CollectiblesCounter thisObject;

    private void Awake()
    {
        thisObject = GetComponent<CollectiblesCounter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetInt(thisObject.ID, PlayerPrefs.GetInt(thisObject.ID) + 1);
            Destroy(gameObject);
        }
    }
}
