using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Reflection;
using System;
public class DataManager : MonoBehaviour, ISaveProgress<IProgressInfo>
{
    private static string Path
    {
        get{return Application.persistentDataPath + "/saveFileProgress.json";}
    }
    private IProgressInfo progressInfoPlayer;
    public IProgressInfo ProgressInfoPlayer
    {
        get{return progressInfoPlayer;}
        private set{progressInfoPlayer = value;}
    }
    private void Awake()
    {
        LoadProgress();
    }
    public void SaveProgress(IProgressInfo progressInfo)
    {
        ProgressInfoPlayer = progressInfo;
        string data = JsonUtility.ToJson(progressInfo);
        Debug.Log(data);
        using(StreamWriter writer = new(Path,false))
        {
            writer.Write(data);
        }
    }
    public void LoadProgress()
    {
        string data;
        if(File.Exists(Path))
        {
            using(StreamReader reader = new(Path))
            {
                data = reader.ReadLine();
                Debug.Log(data);
                progressInfoPlayer = JsonUtility.FromJson<PlayerProgressInfo>(data);
            }
        }
        else
        {
            progressInfoPlayer = new PlayerProgressInfo();
            SaveProgress(progressInfoPlayer);
        }
    }
}
