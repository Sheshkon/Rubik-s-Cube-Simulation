using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem
{

    private readonly static string FilePathForCubeManager = Application.persistentDataPath + "/cubeManager.data";
    private readonly static string FilePathForMoveCamera = Application.persistentDataPath + "/moveCamera.data";

    public static void SavePlayer(CubeManager cubeManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = FilePathForCubeManager;
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(cubeManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }


    public static void SavePlayer(MoveCamera moveCamera)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = FilePathForMoveCamera;
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(moveCamera);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer(string className)
    {
        string path = null;
        if (className == "CubeManager")
            path = FilePathForCubeManager;
        else if (className == "MoveCamera")
            path = FilePathForMoveCamera;

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("same file not found in " + path);
            return null;
        }

    }

    }
