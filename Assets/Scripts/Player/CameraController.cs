using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player; // gets the object to follow
    public Vector3 Offset; // sets the offset for the camera
    public float TurnSpeed; // sets the pawns turn speed
    private Camera PlayerCamera; // gets the camera

    public void Start()
    {
        PlayerCamera = GetComponent<Camera>(); // Gets the camera
    }

    private void Update()
    {
        RotateToMouse(); // calls the rotate to mouse function
    }

    private void LateUpdate()
    {
        transform.position = Player.position + Offset; // sets the cameras position to the players with an offset
    }

    public void RotateToMouse()
    {
        Plane GroundPlane = new Plane(Vector3.up, Player.position); // sets up a plane for the mouse to click
        Ray TheRay = PlayerCamera.ScreenPointToRay(Input.mousePosition); // makes a ray from the mouse to the world

        float Distance; // holds the distance
        GroundPlane.Raycast(TheRay, out Distance); // sets the distance
        Vector3 TargetPoint = TheRay.GetPoint(Distance); // sets the target

        RotateTowards(TargetPoint); // calls the rotate towards function
    }

    public void RotateTowards(Vector3 LookAtPoint)
    {
        Quaternion GoalRotation = Quaternion.LookRotation(LookAtPoint - Player.position, Vector3.up); // sets up desired rotation

        Player.rotation = Quaternion.RotateTowards(Player.rotation, GoalRotation, TurnSpeed * Time.deltaTime); // rotates the player
    }
}
