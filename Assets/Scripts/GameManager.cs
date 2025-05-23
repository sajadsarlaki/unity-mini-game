using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static GameManager Instance;
    [SerializeField] TMP_Text _score_text;



    public int score = 0;
    public int shooted_bullets = 0;
    public int spawned_enenmies = 0;


    private void Awake()
    {
        MakeSingletone();
    }
    void Start()
    {

    }


    public void MakeSingletone()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void AddToScore(int amount)
    {
        score += amount;
        UpdateScoreUI(score);
    }

  

    public void AddToshootedBullets()
    {
        shooted_bullets += 1;
        UpdateShootedBulletUI(shooted_bullets);
    }

    public void AddToSpawnedEnemies()
    {
        spawned_enenmies += 1;
    }

    private void UpdateScoreUI(int score)
    {

        string[] splitted_text = _score_text.text.Split("\n");

        splitted_text[0]= "Score: " + score;

        _score_text.text = string.Join("\n",splitted_text);
    }

    private void UpdateShootedBulletUI(int shooted_bullets)
    {

        string[] splitted_text = _score_text.text.Split("\n");

        splitted_text[1] = "Used Bullets: " + shooted_bullets;

        _score_text.text = string.Join("\n", splitted_text);
    }
}
