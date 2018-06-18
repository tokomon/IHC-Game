using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    static private string SCORE_FILE = @"\scores.sqlite";
    static public List<string> scoreList = new List<string>();
    public Text scoreText;
 
    class ScoreWrapper : System.IComparable<ScoreWrapper>
    {
        public string name;
        public int score;

        public ScoreWrapper(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        public int CompareTo(ScoreWrapper other)
        {
            if (score < other.score)
                return 1;
            else if (score == other.score)
                return 0;
            else
                return -1;

        }

        public static bool operator <(ScoreWrapper lhs, ScoreWrapper rhs)
        {
            return lhs.score < rhs.score;
        }
        public static bool operator >(ScoreWrapper lhs, ScoreWrapper rhs)
        {
            return lhs.score > rhs.score;
        }
    }

    // Use this for initialization
    void Start () {
        scoreText = GameObject.Find("textDinamic").GetComponent<Text>();


        for (int i = 0; i < scoreList.Count; i++)
        {
            scoreText.GetComponent<Text>().text = scoreList[i] + '\n';
        }

        ReadScoresFile();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReadScoresFile() {
        string path = Application.dataPath + SCORE_FILE;
        string[] lines = System.IO.File.ReadAllLines(path);
        List<ScoreWrapper> dataList = new List<ScoreWrapper>();

        // Display the file contents by using a foreach loop.
        foreach (string line in lines)
        {
            string[] data = line.Split(' ');
            dataList.Add(new ScoreWrapper(data[0], int.Parse(data[1])));
        }
        dataList.Sort();
        foreach (ScoreWrapper score in dataList)
        {
            string scoreFormat = string.Format("{0,-16}{1}", score.name, score.score.ToString("0000000000"));
            //scoreList.Add(scoreFormat);
            scoreText.text += scoreFormat + '\n';
        }

        // Cuando hay un nuevo score ponerlo en la lista y luego pasarlo al archivo.
    }

    static public void WriteScoreFile(string playerName, int score)
    {
        string path = Application.dataPath + SCORE_FILE;
        using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(path, true))
        {
            file.WriteLine('\n' + playerName + ' ' + score.ToString());
        }
    }

}
