using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ViewSesion : MonoBehaviour
{
    public Text Sesion;
  
    void Start()
    {
        UpdateSesion();
    }



    public void UpdateSesion()
    {
        Sesion.text = "";
        string Path =
       Application.persistentDataPath + "/sesion.txt";
        if (File.Exists(Path) == false)
            return;

       string[] sesionText =  MySesion.Load();

        for (int i = sesionText.Length - 1; i >= 0; i--)
        {
            Sesion.text += i + 1 + ")\t\t\t" + sesionText[i] + '\n';
        }
    }

}
