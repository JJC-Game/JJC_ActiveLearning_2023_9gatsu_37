using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

//クリック時にP2_GachaManagerを実行
public class P2_GachaManager : MonoBehaviour
{
    [SerializeField]
    int gachaPickCharacterId;

    Perform_Gacha1 performGacha1;

    void Awake()
    {
        gachaPickCharacterId = 0;
        performGacha1 = new Perform_Gacha1();　//引いたキャラを表示するためのクラスをインスタンス。
    }
    void Start()
    {
        performGacha1.Init(); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickGachaButton()
    {
        gachaPickCharacterId = Random.Range(0, 32); //0~31までのIDのキャラクターが出る。

        Debug.Log(gachaPickCharacterId.ToString()); //コンソールにログ

        DrawPerform(); //DrawPerformを実行する。

        UserApplication.userDataManager.SetCharaHave(gachaPickCharacterId);
        UserApplication.charaGridRenderer.RefreshGrid(); //入手したガチャキャラ状況に応じて、更新を行う。
    }

    public void DrawPerform() //引いたキャラを表示する。
    {
        performGacha1.Activate();
        FixCharaManager.FixCharaData fixCharaData = UserApplication.fixCharaManager.GetFixCharaData(gachaPickCharacterId);
        performGacha1.SetSprite(Resources.Load<Sprite>(fixCharaData.imagePath));
        performGacha1.SetName(fixCharaData.name);
    }

    public void OnClickGachaPerformBack() //キャラの表示をやめる。
    {
        performGacha1.Deactivate();
    }
}
