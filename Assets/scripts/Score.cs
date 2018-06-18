using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    static public List<string> scoreList = new List<string>();
    public Text scoreText;
 
    class ScoreWrapper
    {
        public string name;
        public int score;

        public ScoreWrapper(string name, int score)
        {
            this.name = name;
            this.score = score;
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
            scoreText.text = scoreList[i] + '\n';
        }

        readScoresFile();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void readScoresFile() {
        string path = Application.dataPath + @"\scores.sqlite";
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
            Debug.Log(scoreFormat);
        }

        // Cuando hay un nuevo score ponerlo en la lista y luego pasarlo al archivo.
    }

}
