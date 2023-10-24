using UnityEngine;
using System;
using TMPro;

public class saveData : MonoBehaviour
{
    string filePath;
    string dataToSaveString; // (str)dayDate (int)malaCount (int)maniCount (str)duration



    // to get data
    public TextMeshProUGUI malaCountRead, maniCountRead, durationRead;
    DateTime currentTimeRead;
    string DateTimeConvert;


    // data
    string duringSaveDateTime, MalaC, ManiC, durationC;

    string oldFileEntry = "";

    void Start()
    {
        filePath = Application.persistentDataPath + "/malaAppCountData.txt";
        //saveTodaysData();
    }

    public void saveTodaysData()
    {
        currentTimeRead = DateTime.Now;
        duringSaveDateTime = JsonUtility.ToJson((JsonDateTime)currentTimeRead);
        // string to save

        MalaC = malaCountRead.text;
        ManiC = maniCountRead.text;
        durationC = durationRead.text;

        //dataToSaveString
        dataToSaveString = duringSaveDateTime + "," + MalaC + "," + ManiC + "," + durationC + ";\n";

        if (cropComparer(dataToSaveString) != cropComparer(oldFileEntry))
        {
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.AppendAllText(filePath, dataToSaveString);
                
            } else
            {
                System.IO.File.WriteAllText(filePath, dataToSaveString);
            }
        }



        oldFileEntry = dataToSaveString;
        Debug.Log(filePath);
    }

    string cropComparer( string toCrop)
    {
        bool tmp = false;

        for (int ij = 0; ij < toCrop.Length - 1; ij++)
        {
            if (toCrop[ij] == '}')
            {
                tmp = true;
            }
            if (tmp)
            {
                toCrop = toCrop.Remove(0, ij);
                tmp = false;
            }
        }

        return toCrop;
    }
}



[Serializable]
struct JsonDateTime
{
    public long value;
    public static implicit operator DateTime(JsonDateTime jdt)
    {
        return DateTime.FromFileTimeUtc(jdt.value);
    }
    public static implicit operator JsonDateTime(DateTime dt)
    {
        JsonDateTime jdt = new JsonDateTime();
        jdt.value = dt.ToFileTimeUtc();
        return jdt;
    }
}