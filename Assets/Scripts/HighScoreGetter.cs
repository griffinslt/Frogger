using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class HighScoreGetter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI  l1HighscoreText;
    [SerializeField] private TextMeshProUGUI  l2HighscoreText;
    [SerializeField] private TextMeshProUGUI  l3HighscoreText;
    private string _workingDirectory;
    void Awake()
    {
        _workingDirectory = RootPathStorer.RootPath + Path.DirectorySeparatorChar;
        l1HighscoreText.text = ChangeScreenText(_workingDirectory + "Level1HIGHSCORE.txt");
        l2HighscoreText.text = ChangeScreenText(_workingDirectory + "Level2HIGHSCORE.txt");
        l3HighscoreText.text = ChangeScreenText(_workingDirectory + "Level3HIGHSCORE.txt");
    }

    public string ChangeScreenText(string fileName)
    {
        if (File.Exists(fileName))
        {
            string score = File.ReadLines(fileName).First();
            string player = "Player " + File.ReadLines(fileName).Skip(1).First() + ": ";
            return player + score;
        }

        return "0";
    }

}
