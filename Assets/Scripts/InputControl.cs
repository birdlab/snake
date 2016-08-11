using UnityEngine;
using System.Collections;

public class InputControl : MonoBehaviour
{

    public Snake snake;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                snake.turnLeft();
            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                snake.turnRigth();
            }
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                snake.rotateLeft();
            }
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                snake.rotateRigth();
            }
        }
    }
}
