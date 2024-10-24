using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            Init();
            DontDestroyOnLoad(gameObject);
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private string highScoreKey = "HighScore";

    public int HighScore
    {
        get
        {
            return PlayerPrefs.GetInt(highScoreKey, 0);
        }
        set
        {
            PlayerPrefs.SetInt(highScoreKey, value);
        }
    }

    public int CurrentScore { get; set;}

    public bool Initialized { get; set;}

    private void Init()
    {
        CurrentScore = 0;
        Initialized = false;
    }

    public const string MainMenu = "MainMenu";
    private const string GamePlay = "GamePlay";

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(MainMenu);
    }

    public void GoToGamePlay()
    {
        SceneManager.LoadScene(GamePlay);
    }
}
