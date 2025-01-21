using UnityEngine;

public class RoomController : MonoBehaviour
{
    public Transform initPos;
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject topWall;
    public GameObject bottomWall;
    public GameObject leftDoor;
    public GameObject rightDoor;
    public GameObject topDoor;
    public GameObject bottomDoor;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        initPos = GameObject.Find("InitPos").transform;
        leftWall = GameObject.Find("LeftWall");
        rightWall = GameObject.Find("RightWall");
        topWall = GameObject.Find("TopWall");
        bottomWall = GameObject.Find("BottomWall");
        leftDoor = GameObject.Find("LeftDoor");
        rightDoor = GameObject.Find("RighttDoor");
        topDoor = GameObject.Find("TopDoor");
        bottomDoor = GameObject.Find("BottomDoor");
    }

}
