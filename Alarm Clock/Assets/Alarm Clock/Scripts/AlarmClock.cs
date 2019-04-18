///<summary>
///Atchyutha Choday, April 18th, 2019
/// </summary>
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmClock : MonoBehaviour {

    //To display the text on the clock
    public Text DisplayText; 
    //To input the current time
    public string CurrentTime;
    //To input when the alarm should ring
    public string AlarmTime;
    //Giving the format of hour and minutes
    public string Format = "HH :mm";
    //Boolean value to check the alarm state
    public bool StopAlarm = false;

    /// <summary>
    /// Adding the audio source to alarm sound in the alarm clock code
    /// </summary>
    private AudioSource alarmSound;
    /// <summary>
    /// Adding the time variable in the alarmclock code
    /// </summary>
    private DateTime _time = DateTime.Now;
    /// <summary>
    /// Adding the alarm variable in the alarmclock code
    /// </summary>
    private DateTime _alarm = DateTime.MinValue;

    // Use this for initialization
    void Start () {
        //Alarm sound initialization
        alarmSound = GetComponent<AudioSource>();

        //The time gets updated 
        InvokeRepeating("UpdateTime", 0.0f, 1.0f);

        //Try to parse time, if not a valid time use current time.
        if (!String.IsNullOrEmpty(CurrentTime)){
            DateTime.TryParse(CurrentTime, out _time);
        }

        //Try to parse alarm time, if not a valid time use MinValue (alarm wont activate)
        if (!String.IsNullOrEmpty(AlarmTime))
        {
            DateTime.TryParse(AlarmTime, out _alarm);
        }
    }

    //Check to see if the stop alarm is not active
    //only then activate it
    public void ActivateAlarm() {
        if (!StopAlarm)
        {
            StopAlarm = true;
            if (alarmSound != null)
            {
                alarmSound.Play();
            }
        }
    }

    //silence the alarm by using the stop alarm
    //when stopalarm is activated, it doesn't ring
    public void SilenceAlarm()
    {
        if (StopAlarm)
        {
            StopAlarm = false;
            if (alarmSound != null)
            {
                alarmSound.Stop();
            }
        }
    }

    //Method to update time
    void UpdateTime()
    {

        _time = _time.AddSeconds(1);
        if (DisplayText)
        {
            DisplayText.text = _time.ToString(Format);
        }

        //if an alarm has been set
        if (_alarm > DateTime.MinValue)
        {
            if (_time.Hour == _alarm.Hour 
                && _time.Minute == _alarm.Minute
                && _time.Second == _alarm.Second)
            {
                ActivateAlarm();
            } 
        }

    }

}
