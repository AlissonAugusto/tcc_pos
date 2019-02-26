using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setLastCalculation : MonoBehaviour
{
    private int firstNumber;
    private int secondNumber;
    private int result;
    // Start is called before the first frame update
    void Start()
    {
        firstNumber = PlayerPrefs.GetInt("firstNumber", 0);
        result = PlayerPrefs.GetInt("result", 0);
        secondNumber = result / firstNumber;
        GetComponent<Text>().text = firstNumber + " x " + secondNumber + " = " + result;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
