using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadCSVMap
{
    private string pass = "map";
    private List<string[]> dates = new List<string[]>();

    public LoadCSVMap()
    {

    }

    public List<string[]> LoadCsv(int _number)
    {
        TextAsset file_name = Resources.Load("Data/CsvData/" + pass + _number.ToString()) as TextAsset;
        StringReader render = new StringReader(file_name.text);

        while (render.Peek() != -1) {
            string line = render.ReadLine();
            dates.Add(line.Split(','));
        }

        return dates;
    }
}
