///<summary>
///Atchyutha Choday, April 18th, 2019
///</summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class to manage the increment and decrement buttons
public class ButtonManager : MonoBehaviour
{
    //initialize a variable for hour 
    private int _hour;
    //initialize a variable for minutes
    private int _minute;

    //Method to increment the hour when button is clicked 
    public void HourIncrement()
    {
        _hour += 1;
        if(_hour>=24)
        {
            _hour = 0;
        }
    }

    //Method to decrement the hour when button is clicked 
    public void HourDecrement()
    {
        _hour -= 1;
        if (_hour >= 24)
        {
            _hour = 0;
        }
    }

    //Method to increment the minute when button is clicked 
    public void MinuteIncrement()
    {
        _minute -= 1;
        if (_minute >= 60)
        {
            _minute = 0;
        }
    }

    //Method to decrement the minute when button is clicked 
    public void MinuteDecrement()
    {
        _minute -= 1;
        if (_minute >= 60)
        {
            _minute = 0;
        }
    }
}
