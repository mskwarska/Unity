using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Transform Player;
    public float speed = 0.4f;
    private Vector3 currentPosition;
    private Vector3 velocity = Vector3.zero;


    private void Update()
    {
        currentPosition = new Vector3(Player.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(gameObject.transform.position, currentPosition, ref velocity, speed);
    }

}
