using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class Motion : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField] private float speed;
    [SerializeField] private GameObject sword;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.L))
        {
            GameObject createdSword = Instantiate(sword, new Vector3(transform.position.x + 5, transform.position.y, 0), transform.rotation);
            Destroy(createdSword, 1f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Hi");
            StartCoroutine(Jump());
        }
    }

    private void FixedUpdate()
    {
        
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(1f);
        rb.AddForce(new Vector2(0, speed), ForceMode2D.Impulse);
    }
}
