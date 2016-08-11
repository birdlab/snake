using UnityEngine;
using System.Collections;

public class CollisionControl : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        Snake snake = gameObject.transform.parent.gameObject.GetComponent<Snake>();

        print("Object in contact with " + col.name);
        if (col.name == "speedup")
        {
            snake.targetlenght += 1;
            snake.speed += 10;
            col.GetComponent<PointControler>().setRandomState();
        }
        if (col.name == "longer")
        {
            snake.targetlenght += 3;
            col.GetComponent<PointControler>().setRandomState();
        }
        if (col.name == "brake")
        {
            snake.targetlenght += 1;
            snake.speed -= 5;
            col.GetComponent<PointControler>().setRandomState();
        }
        if (col.name == "inside")
        {
            snake.dead();
        }
    }
}
