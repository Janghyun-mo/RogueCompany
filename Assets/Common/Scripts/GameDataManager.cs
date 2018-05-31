﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameDataManager : MonoBehaviourSingleton<GameDataManager> {

    int m_floor;
    Player.PlayerType m_playerType;
    int m_coin;
    GameData gameData;
    string dataPath;

    // 0531 모장현

    private int[] m_weaponIds;
    private int[] m_weaponAmmos;

    #region setter
    public void SetCoin() { m_coin++; ShowUI(); }
    public void SetFloor() { m_floor++; }
    public void SetPlayerType(Player.PlayerType _playerType) { m_playerType = _playerType; }
    #endregion
    #region getter
    public int GetCoin() { return m_coin; }
    public int GetFloor() { return m_floor; }
    public Player.PlayerType GetPlayerType() { return m_playerType; }
    // 0531 모장현
    public int[] GetWeaponIds() { return m_weaponIds; }
    public int[] GetWeaponAmmos() { return m_weaponAmmos; }
    #endregion
    #region Func
    void ShowUI()
    {
        UIManager.Instance.SetCoinText(m_coin);
    }
  
    public void Savedata()
    {
        if (gameData == null)
            gameData = new GameData();
        gameData.SetFloor();
        gameData.SetCoin(m_coin);

        // 0531 모장현
        gameData.SetWeaponIds(PlayerManager.Instance.GetPlayer().GetWeaponManager().GetWeaponIds());
        gameData.SetWeaponAmmos(PlayerManager.Instance.GetPlayer().GetWeaponManager().GetWeaponAmmos());
        BinarySerialize(gameData);
    }
    public bool LoadData()
    {
        if (File.Exists(dataPath))
        {
            gameData = BinaryDeserialize();
            m_floor = gameData.GetFloor();
            m_coin = gameData.GetCoin();
            m_playerType = gameData.GetPlayerType();
            // 0531 모장현
            m_weaponIds = gameData.GetWeaponIds();
            m_weaponAmmos = gameData.GetWeaponAmmos();
            //Debug.Log(gameData.GetWeaponIds()[0]);

            return true;
        }
        return false;
    }
    public void ResetData()
    {
        if (File.Exists(dataPath))
        {
            File.Delete(dataPath);
        }
        if (gameData != null)
        {
            gameData = null;
            m_floor = 1;
            m_coin = 0;
            m_playerType = Player.PlayerType.SOCCER;
        }
    }
    void BinarySerialize(GameData _gameData)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(dataPath, FileMode.Create);
        binaryFormatter.Serialize(fileStream, gameData);
        fileStream.Close();
    }
    GameData BinaryDeserialize()
    {
        if (File.Exists(dataPath))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(dataPath, FileMode.Open);
            GameData gamedata = (GameData)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            return gamedata;
        }
        else
            return null;
    }
    #endregion

    private void Start()
    {
        dataPath = Application.dataPath + "/Data/save.bin";
        DontDestroyOnLoad(this);
    }


}
