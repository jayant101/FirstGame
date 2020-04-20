
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    

    // Update is called once per frame
    void FixedUpdate()
    {
      rb.AddForce(0,0,forwardForce * Time.deltaTime);

       if (Input.touchCount > 0) {
             // The screen has been touched so store the touch
             Touch touch = Input.GetTouch(0);
             
             if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
                 // If the finger is on the screen, move the object smoothly to the touch position
                 Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10)); 
                 touchPosition.y = transform.position.y;
                 transform.position = Vector3.Lerp(transform.position, touchPosition, 20 * Time.deltaTime);
             }
         }
    }
}
