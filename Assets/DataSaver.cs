using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataSaver : MonoBehaviour
{
    [SerializeField] private GameObject objectToSave;

    private string filePath = Application.dataPath + "/objectData.json";
    Data objectData = new Data();

    void SaveObjectPosition()
    {
        Data objectData = new Data();
        objectData.position = objectToSave.transform.position;

        string json = JsonUtility.ToJson(objectData);
        File.WriteAllText(filePath, json);
    }

    void LoadObjectPosition()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            Data objectData = JsonUtility.FromJson<Data>(json);

            objectToSave.transform.position = objectData.position;
        }
    }
}

