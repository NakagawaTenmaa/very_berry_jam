using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadCSVMap
{
    private string pass = "Map";
    private List<string[]> dates = new List<string[]>();

    public LoadCSVMap()
    {

    }

    public void LoadCsv(int _number)
    {
        TextAsset file_name = Resources.Load(pass + _number.ToString()) as TextAsset;
        StringReader render = new StringReader(file_name.text);

        while (render.Peek() != -1) {
            string line = render.ReadLine();
            dates.Add(line.Split(','));
        }

        foreach(var data in dates) { 
            foreach(var s in data) {
                Debug.Log(s);
            }
        }
    }
}
