using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float speed = 5f;
    private float horizontalInput;
    private float forwardInput;
    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }
    
    private void OnCollisionEnter(Collision hit)
    {
        switch(hit.gameObject.tag)
        {
            case "BallSpeed":
            speed = 20f;
            Destroy(gameObject,10);
            break;

            case "Multiple":
            Destroy(hit.gameObject);
            Instantiate(this.gameObject, transform.position, Quaternion.identity);
            Destroy(gameObject,10);
            break;

            case"TimeSpeed":
            gameObject.GetComponent<TimeControl>().fastForward = true;
            break;
        }
    }
}
