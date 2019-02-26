using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public static int lastAnswerDestroyed = 0;
    public static int score = 0;

    public GameObject firstAnswer;
    public GameObject secondAnswer;
    public GameObject thirdAnswer;
    public TextMeshPro firstAnswerText;
    public TextMeshPro secondAnswerText;
    public TextMeshPro thirdAnswerText;

    public Text firstNumberText;
    public Text resultText;
    public Text scoreText;

    private int firstNumber;
    private int secondNumber = 0;
    private int result;

    private int rightAnswer;

    // Start is called before the first frame update
    void Start()
    {
        setAnswers();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        if (lastAnswerDestroyed != 0 && lastAnswerDestroyed == secondNumber)
        {
            lastAnswerDestroyed = 0;
            score += 1;
            checkIfIsHighscore(score);
            setAnswers();
        }
    }

    public void setAnswers()
    {
        firstAnswer.transform.position = new Vector2(-2, Random.Range(-10.0F, -7.0F));
        secondAnswer.transform.position = new Vector2(0, Random.Range(-10.0F, -7.0F));
        thirdAnswer.transform.position = new Vector2(2, Random.Range(-10.0F, -7.0F));

        firstAnswer.SetActive(true);
        secondAnswer.SetActive(true);
        thirdAnswer.SetActive(true);

        firstNumber = Random.Range(1, 10);
        secondNumber = Random.Range(1, 10);

        result = firstNumber * secondNumber;

        firstNumberText.text = firstNumber.ToString();
        resultText.text = result.ToString();

        rightAnswer = Random.Range(1, 4);
        switch (rightAnswer)
        {
            case 1:
                firstAnswerText.text = secondNumber.ToString();
                secondAnswerText.text = Random.Range(1,10).ToString();
                thirdAnswerText.text = Random.Range(1, 10).ToString();
                break;
            case 2:
                firstAnswerText.text = Random.Range(1, 10).ToString();
                secondAnswerText.text = secondNumber.ToString();
                thirdAnswerText.text = Random.Range(1, 10).ToString();
                break;
            case 3:
                firstAnswerText.text = Random.Range(1, 10).ToString();
                secondAnswerText.text = Random.Range(1, 10).ToString();
                thirdAnswerText.text = secondNumber.ToString();
                break;
        }
    }

    private void checkIfIsHighscore(int score)
    {
        if(score > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
