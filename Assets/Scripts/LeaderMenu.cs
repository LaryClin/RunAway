using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

public class LeaderMenu : MonoBehaviour
{
    public List<TextMeshProUGUI> level1GUI;
    public List<TextMeshProUGUI> level2GUI;
    void Start()
    {
        List<Leaderboard> leaderboard = Leaderboard.Load();
        List<Leaderboard> firstLevel  = leaderboard.FindAll(el => el.level == 1); // récupère le classement du premier niveau
        List<Leaderboard> secondLevel = leaderboard.FindAll(el => el.level == 2); // récupère le classement du second niveau

        // changer les textes liés au classement du premier niveau
        if (firstLevel != null)
        {
            level1GUI[0].GetComponent<TextMeshProUGUI>().text = firstLevel[0].time.ToString();
            level1GUI[1].GetComponent<TextMeshProUGUI>().text = firstLevel[1].time.ToString();
            level1GUI[2].GetComponent<TextMeshProUGUI>().text = firstLevel[2].time.ToString();
        }

        // changer les textes liés au classement du second niveau
        if (secondLevel != null)
        {
            level2GUI[0].GetComponent<TextMeshProUGUI>().text = secondLevel[0].time.ToString();
            level2GUI[1].GetComponent<TextMeshProUGUI>().text = secondLevel[1].time.ToString();
            level2GUI[2].GetComponent<TextMeshProUGUI>().text = secondLevel[2].time.ToString();
        }
    }
}

[System.Serializable]
public class Leaderboard
{
    public int level;
    public int time;

    // constructeur
    public Leaderboard(int level, int time)
    {
        this.level = level;
        this.time = time;
    }

    // chargement du classement
    // @signature: Leaderboard.Load();
    public static List<Leaderboard> Load()
    {
        if (File.Exists(Application.persistentDataPath + "/leaderboard.dat"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/leaderboard.dat", FileMode.Open);

            List<Leaderboard> content = formatter.Deserialize(file) as List<Leaderboard>;
            file.Close();

            return content;
        }

        return null;
    }

    // sauvegarde du classement (fonction uniquement utile afin de tester la persistance)
    // @signature: Leaderboard.Save();
    public static void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/leaderboard.dat", FileMode.OpenOrCreate);

        List<Leaderboard> l = new List<Leaderboard>();
        l.Add(new Leaderboard(1, 15));
        l.Add(new Leaderboard(1, 25));
        l.Add(new Leaderboard(1, 31));

        l.Add(new Leaderboard(2, 14));
        l.Add(new Leaderboard(2, 28));
        l.Add(new Leaderboard(2, 87));

        formatter.Serialize(file, l);
        file.Close();
    }
}