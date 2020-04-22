using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static int Money;
    public int startMoney;

    public static int Lives;
    public int startLives;

    public static int Enemy;
    public static int killEnemy;
    public static int destroyEnemy;

    public static float sliderValue;
    public static float starValue;

    public static int Rounds;
    public static int totalRounds;

    // Start is called before the first frame update
    void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }

    // Update is called once per frame
    void Update()
    {
        sliderValue = killEnemy * 100 / Enemy;
        starValue = Lives * 100 / startLives;
    }
}
