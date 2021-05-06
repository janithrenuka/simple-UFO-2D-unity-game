using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;
    private int count;

    public Text countText;
    public Text winText;

    private Rigidbody2D rBody;

    void Start()
    {
        count = 0;
        countText.text = "";
        winText.text = "";
        //handle to the rigidbody
        rBody = GetComponent<Rigidbody2D>();   
    }

    void FixedUpdate()
    {
        //A, D, rigth arrow, left arrow
        float horizontalInput = Input.GetAxis("Horizontal");
        //W, S, up arrow, down arrow
        float verticalInput = Input.GetAxis("Vertical");
        
        rBody.AddForce(new Vector2(horizontalInput, verticalInput) * speed);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("PickUp"))
        {
            Destroy(target.gameObject);
            Count();
        }
    }//on trigger method

    void Count()
    {        
        count = count + 1;
        countText.text = "Count: " + count.ToString();

        if(count >=8 )
        {
           winText.text = "You Win !"; 
        }
    }//Count method
}
