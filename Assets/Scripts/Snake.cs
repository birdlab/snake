using UnityEngine;
using System.Collections;

public class Snake : MonoBehaviour
{
    public GameObject cube;
    public int targetlenght;
    public int snakelength;
    private GameObject[] body = new GameObject[5000];
    private GameObject head;
    private Vector3 direction = Vector3.forward;
    private Vector3 orientation = Vector3.up;
    public Quaternion rotation = new Quaternion();
    public int speed = 160;
    public int speedMultipler = 4;
    public Transform target;
    public float cameraAngle;

    private bool TL = false;
    private bool TR = false;

    public ParticleSystem explosion;

    private GameManager gameManager;

    public Material debugMaterial;


    void Start()
    {
        gameManager = GameManager.instance;
        gameObject.name = "Player1_";
    }
    public void setTo(Vector3 pos)
    {
        snakelength = 1;
        targetlenght = 4;

        for (int a = 0; a < snakelength; a++)
        {
            GameObject part = Instantiate(cube);
            part.transform.parent = transform;
            part.transform.position = pos + (direction * a);
            body[a] = part;
            CollisionControl bcc = body[a].GetComponent<CollisionControl>();
            bcc.enabled = false;
        }
        head = body[snakelength - 1];
        StartCoroutine("Move");
    }
    public void dead()
    {
        targetlenght += 1;
        //StopCoroutine("Move");
    }
    public void rotateLeft()
    {

        orientation = Quaternion.AngleAxis(-90, direction) * orientation;
        rotation = rotation * Quaternion.AngleAxis(-90, Vector3.forward);
        target.rotation = rotation * Quaternion.AngleAxis(cameraAngle, Vector3.right);

    }
    public void rotateRigth()
    {

        orientation = Quaternion.AngleAxis(90, direction) * orientation;
        rotation = rotation * Quaternion.AngleAxis(90, Vector3.forward);
        target.rotation = rotation * Quaternion.AngleAxis(cameraAngle, Vector3.right);

    }

    public void turnLeft()
    {
        if (!TL)
        {
            TL = true;
            TR = false;
            direction = Quaternion.AngleAxis(90, orientation) * direction;
            rotation = rotation * Quaternion.AngleAxis(90, Vector3.up);
            target.rotation = rotation * Quaternion.AngleAxis(cameraAngle, Vector3.right);
        }
    }

    public void turnRigth()
    {
        if (!TR)
        {
            TR = true;
            TL = false;
            direction = Quaternion.AngleAxis(-90, orientation) * direction;
            rotation = rotation * Quaternion.AngleAxis(-90, Vector3.up);
            target.rotation = rotation * Quaternion.AngleAxis(cameraAngle, Vector3.right);
        }
    }
    private void addBody()
    {
        snakelength += 1;
        GameObject part = Instantiate(cube);
        part.transform.parent = transform;
        body[snakelength - 1] = part;
        part.transform.position = body[snakelength - 2].transform.position;
        CollisionControl bcc = part.GetComponent<CollisionControl>();
        bcc.enabled = false;
    }

    private void moveBody()
    {
        TL = TR = false;


        if (snakelength < targetlenght)
        {
            addBody();
        }
        if (snakelength > 1)
        {
            head = body[snakelength - 1];
            for (int a = snakelength - 1; a > 0; a--)
            {
                body[a] = body[a - 1];
                body[a].name = gameObject.name + "Body";
            }
            body[0] = head;
            head.transform.position = body[1].transform.position;
            head.name = gameObject.name + "Head";

        }
        head.transform.position += direction;
        target.position = head.transform.position;
        target.rotation = rotation * Quaternion.AngleAxis(cameraAngle, Vector3.right);

    }
    public void makeExplosion() {
        explosion.transform.position=head.transform.position;
        explosion.transform.rotation=Quaternion.LookRotation(direction, orientation);
        explosion.Emit(30);
     }
    IEnumerator Move()
    {
        while (true)
        {
            moveBody();
            float t = speed / 60f * speedMultipler;
            yield return new WaitForSeconds(1 / t);
        }
    }
}

