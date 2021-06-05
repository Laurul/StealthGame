using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(PlayerContoller playerReference, PlayerStats stats,ActiveAbilitySwapper playerAttacks,PlayerHudSwap hudSwap)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.savedata";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(playerReference, stats,playerAttacks,hudSwap);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.savedata";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data=formatter.Deserialize(stream) as PlayerData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("SAVE FILE COULD NOT BE FOUND IN" + path);
            return null;
        }
    }
}
