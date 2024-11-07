using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 10f;
    [SerializeField] private float laneDistance = 1f; // There is 3 lanes and the ground is 5f long so the distance between lanes is 1f
    [SerializeField] private int currentLane = 0;   //Center lane by default, -1 and +1 are the other two
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update(){
        //constant forward movement - pay attention here we are not adding any foce or sth like that, just using same vector to move on constant speed
        _rigidbody.velocity = -Vector3.right * forwardSpeed;     //Vector3.right is shorthand for the vector (1, 0, 0)

        //the method for right and left movements
        RightLeftInput();
    }

    private void RightLeftInput(){
        if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 1)
        {
            currentLane++;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > -1)
        {
            currentLane--;
        }

        // Calculate the target position based on lane - the current lane is on the Z axis pay attention there in Unity
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y,currentLane * laneDistance);
        // Smootly move to target lane position
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10);
    }
}
