using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static void SavePlayerData(string playerName, int playerScore)
    {
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.SetInt("PlayerScore", playerScore);
        PlayerPrefs.Save();
    }

    public static string LoadPlayerName()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            return PlayerPrefs.GetString("PlayerName");
        }
        else
        {
            return "";
        }
    }

    public static int LoadPlayerScore()
    {
        if (PlayerPrefs.HasKey("PlayerScore"))
        {
            return PlayerPrefs.GetInt("PlayerScore");
        }
        else
        {
            return 0;
        }
    }
}

