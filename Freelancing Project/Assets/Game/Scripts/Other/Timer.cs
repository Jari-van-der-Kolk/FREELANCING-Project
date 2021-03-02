using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    public float Multiplecation = 0;
    public float time = 0;

    public void GetDeltaTime(float deltatime) => time += deltatime * Multiplecation;

    public void ResetTime(float resetValue) => time = resetValue;

    public void TimeMultiplication(float multiplier) => Multiplecation = multiplier;


}
