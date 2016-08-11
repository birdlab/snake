using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public Snake player;
    private GameObject playerNull;
    private smoothMove cameraRig;
    public GameObject freeRotation;
    public GameObject pixels;

    private GameObject introScreen;
    private GameObject gameOverScreen;

    public boxScaler box;

    public string state;

    public static GameManager instance = null;

    private GameObject[] points = new GameObject[1000];
    public GameObject point;

    // Use this for initialization

    //Awake is always called before any Start functions
    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        introScreen = GameObject.Find("/Canvas/IntroScreen");
        gameOverScreen = GameObject.Find("/Canvas/GameOverScreen");
        playerNull = GameObject.FindGameObjectWithTag("player_null");
        box = GameObject.FindGameObjectWithTag("cell").GetComponent<boxScaler>();
        cameraRig = GameObject.FindGameObjectWithTag("camera_rig").GetComponent<smoothMove>();
        cameraRig.target = freeRotation.transform;
        box.cubescale = 6;
        setState("intro");
    }
    private void hideAll()
    {
        gameOverScreen.SetActive(false);
        introScreen.SetActive(false);
    }
    public void setState(string st)
    {
        if (st != state)
        {
            hideAll();
            state = st;
            if (state == "intro")
            {
                introScreen.SetActive(true);
            }
            /*           if (state == "ingame")
                       {
                           introScreen.SetActive(true);
                       }
                       if (state == "pause")
                       {
                           introScreen.SetActive(true);
                       }
                 */
            if (state == "gameover")
            {
                gameOverScreen.SetActive(true);

            }
        }
    }
    public void StartGame()
    {
        setState("game");
        box.cubescale = 25;
        player.setTo(new Vector3(5f, 3f, 5f));
        cameraRig.target = playerNull.transform;
        InputControl inputControl = gameObject.GetComponent<InputControl>();
        inputControl.snake = player;
        SetRandomPoints(30);

    }
    public void SetRandomPoints(int density)
    {
        for (var a = 0; a < density; a++)
        {
            points[a] = Instantiate(point);
            points[a].GetComponent<PointControler>().setRandomState();

        }

    }
    public void destroyPoints(int density)
    {
        for (var a = 0; a < density; a++)
        {
            Destroy(points[a]);
        }

    }
    public void GameOver()
    {

    }

}
