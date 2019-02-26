using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class limitColliderController : MonoBehaviour
{
    public Text firstNumber;
    public Text result;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerPrefs.SetInt("firstNumber", Int32.Parse(firstNumber.text));
        PlayerPrefs.SetInt("result", Int32.Parse(result.text));
        SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
    }
}
