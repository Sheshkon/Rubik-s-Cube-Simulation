using System;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;


public class TImer : MonoBehaviour
{
    public Text timerText;
    public static Stopwatch stopWatch;
    public static TimeSpan ts;
    public static bool start;
    public static bool is_started;
    public static bool end;
    public static bool is_stopped;



    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            stopWatch.Stop();
            return;
        }
        if (!is_started && CubeManager.isShuffled && (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.F) ||
           Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.E) ||
           Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.O) ||
           Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.L) ||
           Input.GetKeyDown(KeyCode.Period) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.U) ||
           Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.V) || Input.GetKeyDown(KeyCode.C) ||
           Input.GetKeyDown(KeyCode.Comma) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.B) ||
           Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Slash))) 
        {
            start = true;
            is_started = true;
        }
        
        if (start && is_started && CubeManager.moves.Count == 0)
            stopWatch.Start();

        if (!end)
            ts = stopWatch.Elapsed;

        if ((end && !is_stopped) || Input.GetKeyDown(KeyCode.Escape))
        {
            stopWatch.Stop();
            is_stopped = true;
        }

        timerText.text = TimeToString();

    }

    public static void ResetTimer()
    {
        stopWatch = new Stopwatch();
        start = false;
        is_started = false;
        end = false;
        is_stopped = false;
        
    }
    public static string TimeToString()
    {
        return string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
           ts.Hours, ts.Minutes,ts.Seconds,
           ts.Milliseconds / 10);
    }

    public static string TimeToString(string time)
    {
        TimeSpan tmp = new TimeSpan(long.Parse(time));

        return string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
           tmp.Hours, tmp.Minutes, tmp.Seconds,
           tmp.Milliseconds / 10);
    }

    public static int CompareStringTime(string time1, string time2)
    {
        if (time2.Length < 5)
            return -1;

        string[] first = time1.Split(':', '.');
        string[] second = time2.Split(':', '.');

        for(int i = 0; i < first.Length; i++)
        {
            if (int.Parse(first[i]) < int.Parse(second[i]))
                return -1;
            if (int.Parse(first[i]) > int.Parse(second[i]))
                return 1;
        }
        return 0;
    }

}
