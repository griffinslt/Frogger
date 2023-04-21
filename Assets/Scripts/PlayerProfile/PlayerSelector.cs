using System;
using System.IO;
using UnityEngine;

namespace PlayerProfile
{
  public class PlayerSelector : MonoBehaviour
  {
    public static int SelectedPlayer;

    private void Start()
    {
      CheckDefault();
    }

    public static void CheckDefault()
    {
      string file = Application.dataPath + "/SaveFiles/defaultPlayer.txt";
      var num = int.Parse(File.ReadAllText(file));
      SelectedPlayer = num;
    }

    public void SelectPlayer1()
    {
      SelectedPlayer = 1;
    }

    public void SelectPlayer2()
    {
      SelectedPlayer = 2;
    }

    public void SetAsDefault(int p)
    {
      string file = Application.dataPath + "/SaveFiles/defaultPlayer.txt";
      File.WriteAllText(file, p.ToString());
      CheckDefault();
    }
  }
}
