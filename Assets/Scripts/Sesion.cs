using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Threading.Tasks;

public class TimeSesion
{
    public string time;
    public string scramble;

    public TimeSesion(string time, string scramble)
    {
        this.time = time;
        this.scramble = scramble;
    }
}


public static class MySesion
{
    private readonly static string Path = 
         Application.persistentDataPath + "/sesion.txt";

    public  static void Save(TimeSesion data)
    {
        string text ="";
       
            text += data.time + "\t\t\t" + data.scramble + '\n';

        using(FileStream fStream = new FileStream(Path, FileMode.Append))
        {
            byte[] array = System.Text.Encoding.Default.GetBytes(text);
             fStream.Write(array, 0, array.Length);
        }    
    }

    public static string[] Load()
    {
        return File.ReadAllLines(Path);
        
    }

        public static void ResetSesion()
    {
        if (File.Exists(Path))
         File.Delete(Path);
    }
}

