using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class InfoScript : MonoBehaviour
{
    public static InfoScript info;

    public int highscore;


    void Awake()
    {
        if (info == null)
        {
            DontDestroyOnLoad(gameObject);
            info = this;
        }

        else if (info != this)
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/info.dat");

        GameData data = new GameData();
        data.highscore = highscore;


        bf.Serialize(file, data);
        file.Close();
    }


    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/info.dat")) ;
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/info.dat", FileMode.Open);
            GameData data = (GameData)bf.Deserialize(file);
            file.Close();

            highscore = data.highscore;

        }
    }


    void OnApplicationQuit()
    {
        InfoScript.info.Save();
    }
}

[Serializable]
class GameData
{
    public int highscore;
}