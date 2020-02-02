using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int health = 1;
    private bool gotCoffee = false;
    private bool gotWheat = false;
    private GameObject.GetComponent<moveMe>.runSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Text");
            health -= 1;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (other.gameObject.CompareTag("Grass"))
        {

            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Coffee"))
        {
            Destroy(other.gameObject);

        }
    }
}
