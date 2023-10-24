/*
 * 
 * using UnityEngine;
using System;

public class saveTodayData : MonoBehaviour
{
    public EntriesList dataToManipulate;
    public EntriesList dataHasRead;

    void Start()
    {
        //dataToManipulate.AllData = new countData[10];

        //Debug.Log(dataToManipulate.AllData[0].malaCountToday);
        //dataToManipulate.AllData[0].malaCountToday = 500;
        //dataToManipulate.AllData[0].dateAndTime = JsonUtility.ToJson((JsonDateTime) DateTime.Now );
        

        //dataToManipulate.AllData[0].malaCountToday = 400;

        //dataToManipulate.AllData[0].malaCountToday = 300;
    }




    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            saveToJSON();
        }
    }




    public void saveToJSON()
    {
        String dataToSaveString = JsonUtility.ToJson(dataToManipulate);
        String filePath = Application.persistentDataPath + "/malaAppCountData";

        System.IO.File.WriteAllText(filePath, dataToSaveString);

        // deletable
        Debug.Log(filePath);
    }




    public void loadFromJSON()
    {
        //dataHasRead = JsonUtility
    }

}



[System.Serializable]
public class countData
{
    public String dateAndTime = "";

    public int malaCountToday = 0;
    public int maniCountToday = 0;
    public String timeCounterMeasured = "";
}



[System.Serializable]
public class EntriesList
{
    //int size;
    public countData[] AllData = new countData[10];
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

*/