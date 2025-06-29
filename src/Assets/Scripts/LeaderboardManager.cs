using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class LeaderboardManager
{
    [Serializable]
    public class Entry
    {
        public int score;
        public string timestamp;
    }

    public static string FilePath => Path.Combine(Application.persistentDataPath, "leaderboard.json");
    public static int MaxEntries = 5;

    [Serializable]
    public class LeaderboardData
    {
        public List<Entry> entries = new List<Entry>();
    }

    public static void AddEntry(int score)
    {
        var data = Load();
        data.entries.Add(new Entry
        {
            score = score,
            timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        });
        data.entries.Sort((a, b) => b.score.CompareTo(a.score));
        if (data.entries.Count > MaxEntries)
            data.entries.RemoveRange(MaxEntries, data.entries.Count - MaxEntries);
        Save(data);
    }

    public static LeaderboardData Load()
    {
        if (!File.Exists(FilePath))
            return new LeaderboardData();
        var json = File.ReadAllText(FilePath);
        return JsonUtility.FromJson<LeaderboardData>(json);
    }

    public static void Save(LeaderboardData data)
    {
        var json = JsonUtility.ToJson(data, true);
        File.WriteAllText(FilePath, json);
    }
}