using System;
using System.IO;
using UnityEngine;

namespace PlayerProfile
{
  public class PlayerSelector : MonoBehaviour
  {
    public static int SelectedPlayer = 1;

    private void Start()
    {
      CheckDefault();
      if (!Directory.Exists( RootPathStorer.RootPath + "Start Of Level"))
      {
        Directory.CreateDirectory(RootPathStorer.RootPath + "Start Of Level");
      }
    }

    public static void CheckDefault()
    {
      string file = RootPathStorer.RootPath + "defaultPlayer.txt";
      int num;
      if (!File.Exists(file))
      {
        num = 1;
      }
      else
      {
        num = int.Parse(File.ReadAllText(file));
      }
      
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
      string file =  RootPathStorer.RootPath + "defaultPlayer.txt";
      File.WriteAllText(file, p.ToString());
      CheckDefault();
    }
  }
}
