using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class GameClearUI : MonoBehaviour
{
    private PlayerInputSet _playerInputSet;

    void OnEnable(){
        _playerInputSet = PlayerInputSet.instance;
        _playerInputSet.Tab.Where(x => x == true).Subscribe(x => { ReStartGame();  }).AddTo(this);
    }

    void ReStartGame(){
        #if UNITY_STANDALONE_WIN
        //再起動
                System.Diagnostics.Process.Start(Application.dataPath.Replace("_Data", ".exe"));
                Application.Quit();
        #endif
    }
}
