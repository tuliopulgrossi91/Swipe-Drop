using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    #region Default
    public GameObject [] Elements;
    public GameObject Player, Flag, PanelGame, PanelManager, Options, Credits, Back, ButtonsManager;
    public GameObject [] Arrows;
    public GameObject [] TextManager;
    private readonly Font[] fonts = new Font[12]; // array fonts
    public static int t;
    public static int c;
    public static int a;
    public static int s;
    public static int j;

    void Start()
    {
        LevelManager();
    }

    void Update()
    {
        if (PlayerManager.r == true)
        {
            PanelManager.SetActive(true);
        }
        else
        {
            PanelManager.SetActive(false);
        }
        if (ElementManager.d == true)
        {
            // create new object
            GameObject prefab_Clone = Instantiate(Resources.Load<GameObject>("Prefabs/Element4"), new Vector3(0.0f, -2.0f, 1.0f), Quaternion.identity) as GameObject;
            prefab_Clone.GetComponent<SpriteRenderer>().sprite = ElementManager.spritesElements[s];
        }
    }

    #region ButtonsManager
    public void SelectManager(int s)
    {
        if (s == 0)
        {
            PanelGame.SetActive(false);
        }
        if (s == 1) // options
        {
            ButtonsManager.SetActive(false);
            Options.SetActive(true);
            Back.SetActive(true);
        }
        if (s == 2) // credits
        {
            ButtonsManager.SetActive(false);
            Credits.SetActive(true);
            Back.SetActive(true);
        }
        if (s == 3)
        {
            Options.SetActive(false);
            Credits.SetActive(false);
            ButtonsManager.SetActive(true);
            Back.SetActive(false);
        }
    }

    public void Reset()
    {
        // reset
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion

    void LevelManager()
    {
        #region LevelManager

        // create new object
        GameObject prefab_Clone = Instantiate(Resources.Load<GameObject>("Prefabs/Element4"), new Vector3(0.0f, -2.0f, 1.0f), Quaternion.identity) as GameObject;
        prefab_Clone.GetComponent<SpriteRenderer>().sprite = ElementManager.spritesElements[s];

        t = Random.Range(0, 4); // transparence element 
        c = Random.Range(0, 4); // car position
        s = Random.Range(0, 3); // sprite element
        a = Random.Range(0, 8); // arrow position

        #region SET RANDOM FONT
        for (int i = 0; i < fonts.Length; i++)
        {
            fonts[i] = Resources.Load("Fonts/" + i + "") as Font;
        }

        Font n = fonts[Random.Range(0, fonts.Length)];

        for (int j = 0; j < TextManager.Length; j++)
        {
            TextManager[j].GetComponent<Text>().font = n;
        }
        #endregion

        while (t == c)
        {
            c = Random.Range(0, 4);
        }

        #region Elements
        Elements[t].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        Elements[t].tag = "Element";
        GameObject.FindGameObjectWithTag("Element").AddComponent<Element>();

        if (s == 0)
        {
            Elements[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Elements0/0");
            Elements[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Elements0/1");
            Elements[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Elements0/2");
            Elements[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Elements0/3");
            Player.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Elements0/car0");
            ElementManager.spritesElements[0] = Resources.Load<Sprite>("Sprites/Elements/Elements0/0");
            ElementManager.spritesElements[1] = Resources.Load<Sprite>("Sprites/Elements/Elements0/1");
            ElementManager.spritesElements[2] = Resources.Load<Sprite>("Sprites/Elements/Elements0/2");
            ElementManager.spritesElements[3] = Resources.Load<Sprite>("Sprites/Elements/Elements0/3");
        }
        if (s == 1)
        {
            Elements[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Elements1/0");
            Elements[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Elements1/1");
            Elements[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Elements1/2");
            Elements[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Elements1/3");
            Player.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Elements1/car1");
            ElementManager.spritesElements[0] = Resources.Load<Sprite>("Sprites/Elements/Elements1/0");
            ElementManager.spritesElements[1] = Resources.Load<Sprite>("Sprites/Elements/Elements1/1");
            ElementManager.spritesElements[2] = Resources.Load<Sprite>("Sprites/Elements/Elements1/2");
            ElementManager.spritesElements[3] = Resources.Load<Sprite>("Sprites/Elements/Elements1/3");
        }
        if (s == 2)
        {
            Elements[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Elements2/0");
            Elements[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Elements2/1");
            Elements[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Elements2/2");
            Elements[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Elements2/3");
            Player.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Elements2/car2");
            ElementManager.spritesElements[0] = Resources.Load<Sprite>("Sprites/Elements/Elements2/0");
            ElementManager.spritesElements[1] = Resources.Load<Sprite>("Sprites/Elements/Elements2/1");
            ElementManager.spritesElements[2] = Resources.Load<Sprite>("Sprites/Elements/Elements2/2");
            ElementManager.spritesElements[3] = Resources.Load<Sprite>("Sprites/Elements/Elements2/3");
        }
        #endregion

        #region Flag
        int f = Random.Range(0, 2);

        if (f == 0)
        {
            Flag.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Flags/0");
        }
        else
        {
            Flag.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Flags/1");
        }

        Flag.transform.position = GameObject.FindGameObjectWithTag("Element").transform.position;
        #endregion

        #region Car
        GameObject.FindGameObjectWithTag("Player").AddComponent<PlayerManager>();
        Elements[c].tag = "Start";
        Player.transform.position = GameObject.FindGameObjectWithTag("Start").transform.position;
        #endregion

        #region Arrows
        if (a == 0)
        {
            Arrows[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow1");
            Arrows[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow2");
            Arrows[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow3");
            Arrows[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow0");
        }
        if (a == 1)
        {
            Arrows[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow2");
            Arrows[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow1");
            Arrows[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow0");
            Arrows[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow3");
        }
        if (a == 2)
        {
            Arrows[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow2");
            Arrows[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow3");
            Arrows[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow0");
            Arrows[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow1");
        }
        if (a == 3)
        {
            Arrows[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow3");
            Arrows[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow2");
            Arrows[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow1");
            Arrows[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow0");
        }
        if (a == 4)
        {
            Arrows[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow3");
            Arrows[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow0");
            Arrows[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow1");
            Arrows[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow2");
        }
        if (a == 5)
        {
            Arrows[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow0");
            Arrows[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow3");
            Arrows[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow2");
            Arrows[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow1");
        }
        if (a == 6)
        {
            Arrows[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow0");
            Arrows[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow1");
            Arrows[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow2");
            Arrows[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow3");
        }
        if (a == 7)
        {
            Arrows[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow1");
            Arrows[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow0");
            Arrows[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow3");
            Arrows[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Elements/Arrows/Arrow2");
        }
        #endregion
        #endregion
    }
    #endregion
}