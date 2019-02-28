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

    public GameObject soundObject;

    private float velocity;
    private int answerValue;
    private int score;
    private int life;

    // Start is called before the first frame update
    void Start()
    {
        answerValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        life = Int32.Parse(value.text);
        score = gameController.score;
        velocity = ((float)(Mathf.Log(score + 10) * 17.942) + UnityEngine.Random.Range(8, 13)) / 50;
        if (transform.position.y < -7)
        {
            setBalloonColor();
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
            soundObject.GetComponent<AudioSource>().Play(0);
            Handheld.Vibrate();
            gameController.lastAnswerDestroyed = answerValue;
            answerValue = 0;
        }
    }

    private void setBalloonColor()
    {
        int randomSet = UnityEngine.Random.Range(0, 4);
        switch (randomSet)
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = blueColor;
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = redColor;
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = greenColor;
                break;
            case 3:
                GetComponent<SpriteRenderer>().sprite = yellowColor;
                break;
        }
    }
}
