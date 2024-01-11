using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings
{
    // Player
    public static int PlayerLife = 3;
    public static int Score = 0;

    // Target
    public static float TargetSpeed = 0.5f;
    public static float SpawnFreqMax = 6f;
    public static int TargetLifeSpan = 10;

    // Event
    public static bool isEvent = false;
    public static int ScoreMultiplier = 1;


    // NewGame
    public static bool newGame = true;

}

public enum TargetType
{
    loseLife,
    gainLife,
    multiplier,
    speedPlus,
    speedMinus,
    slowmotion,
    tomato,
    twohit,
    normal
}
