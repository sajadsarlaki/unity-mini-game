using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static GameManager Instance;
    [SerializeField] TMP_Text _score_text;



    
    public int score = 0;
    public int fired_bullets = 0;
    public int spawned_enenmies = 0;
    public double accuracy = 0;


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

        int destoryed_enemies = score;
        UpdateAccuracy(fired_bullets, destoryed_enemies);
    }

  

    public void AddTofiredBullets()
    {
        fired_bullets += 1;
        UpdateFiredBulletUI(fired_bullets);

        int destoryed_enemies = score;
        UpdateAccuracy(fired_bullets, destoryed_enemies);
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

    private void UpdateFiredBulletUI(int fired_bullets)
    {

        string[] splitted_text = _score_text.text.Split("\n");

        splitted_text[1] = "Fired Bullets: " + fired_bullets;

        _score_text.text = string.Join("\n", splitted_text);
    }

    private void UpdateAccuracy(int fired_bullets, int destroyed_enemies)
    {
    
        if (fired_bullets != 0)
        {
            // casting to float to keep the franctional part
            accuracy = (float)destroyed_enemies / fired_bullets;
            accuracy = Math.Round(accuracy, 2) * 100;
        }
        else
        {
            accuracy = 0;
        }

        string[] splitted_text = _score_text.text.Split("\n");
        splitted_text[2] = "Accuracy: " + accuracy + "%";
        _score_text.text = string.Join("\n", splitted_text);




    }



    public void Gameover()
    {
        GameOverManager gm = FindObjectOfType<GameOverManager>();
        gm.TriggerGameOver();
    }
}
