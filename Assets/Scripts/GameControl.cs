using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl control;

    public List<Level> achievedLevels; // liste des niveaux accomplis (persistance)
	void Awake () {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
	}

    // sauvegarder les niveaux réussis
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/levels.dat");
        
        bf.Serialize(file, achievedLevels);
        file.Close();
    }

    // charger les niveaux réussis
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/levels.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/levels.dat", FileMode.Open);

            achievedLevels = (List<Level>)bf.Deserialize(file);
            file.Close();
        }
    }
}

[System.Serializable]
public class Level
{
    public int number;
    public string name;
}