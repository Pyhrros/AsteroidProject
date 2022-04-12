using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier;

    private bool counting = true;
    public float score;
    // Update is called once per frame
    void Update()
    {
        if(!counting){
            return;
        }
        score += Time.deltaTime * scoreMultiplier;

        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    public int endScore(){
        counting = false;
        scoreText.text = string.Empty;
        return Mathf.FloorToInt(score);
    }
}
