using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class answerMovimentController : MonoBehaviour
{
    public TextMeshPro value;

    public Sprite blueColor;
    public Sprite redColor;
    public Sprite greenColor;
    public Sprite yellowColor;

    float velocity;
    int answerValue;
    int score;
    int life;

    // Start is called before the first frame update
    void Start()
    {
        answerValue = 0;
        velocity = ((float)(Mathf.Log(10) * 17.942) + UnityEngine.Random.Range(8, 13)) / 50;
    }

    // Update is called once per frame
    void Update()
    {
        life = Int32.Parse(value.text);
        score = gameController.score;
        if (score > 0)
        {
            velocity = ((float)(Mathf.Log(score + 10) * 17.942) + UnityEngine.Random.Range(8, 13)) / 50;
        }
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, Screen.height), velocity * Time.deltaTime);
    }

    public void OnMouseDown()
    {
        if (answerValue == 0)
        {
            answerValue = life;
        }
        life--;
        value.text = life.ToString();
        if (life <= 0)
        {
            gameObject.SetActive(false);
            Handheld.Vibrate();
            gameController.lastAnswerDestroyed = answerValue;
            answerValue = 0;
        }
    }
}
