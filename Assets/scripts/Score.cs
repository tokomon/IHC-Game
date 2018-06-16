using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public TextMesh score = null;
    static public List<string> scoreList = new List<string>();
    public Text scoreText;
 

    // Use this for initialization
    void Start () {
        scoreText = GameObject.Find("textDinamic").GetComponent<Text>();


        for (int i = 0; i < scoreList.Count; i++)
        {
            scoreText.text = scoreList[i] + '\n';
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
