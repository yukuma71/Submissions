using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class MainControllar : MonoBehaviour
{
    public Flag flag;
    public Grid grid;
    public MasuControllar MasuControllar;
    public PrefabsControllar prefabsControllar;
    public AttackControllar attackControllar;
    public SkillControllar skillControllar;
    public PlayerTurnText playerTurnText;
    public UI3Controllar ui3Controllar;

    private Vector3Int click_start;
    private Vector3Int click_attack;
    private Vector3Int click_move;
    private Vector3Int skillcenter;
    private int getmasu;
    private byte dead_flag1 = 4;
    private byte dead_flag2 = 4;
    public byte player_turn = 1;// Player1 or Player2　のターンがどちらか

    
    public GameObject action_charactor;
    public GameObject Attackpoint;
    public GameObject AttackArea;
    public GameObject Skillpoint;
    public GameObject SkillArea;
    public GameObject Pointcircle;
    public GameObject MoveArea;
    

    void Start(){
        playerTurnText.TextPlayer(player_turn);
    }

    //キャラクターかタイルマップクリックで起動する関数
    public void PointClick(){
        //キャラクター非選択時のみ動く
        if(!flag.GetSelectFlag()){
            if (Input.GetMouseButtonDown(0))
            {
                click_start = Position();
                //HasTile タイルが存在する場合true
                var tilemap = GetComponent<Tilemap>();
                //クリックした場所マスある？　Y/N
                if(tilemap.HasTile(click_start) == true){
                    getmasu = MasuControllar.GetMasu(click_start.x,click_start.y);//マスの情報取得  
                }
            }
        }
    }

    //右クリックでCharactorUIの情報開示
    public void CharactorDetails()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3Int click_details = Position();
            //HasTile タイルが存在する場合true
            var tilemap = GetComponent<Tilemap>();
            //クリックした場所マスある？　Y/N
            if (tilemap.HasTile(click_details) == true)
            {
                getmasu = MasuControllar.GetMasu(click_details.x, click_details.y);//マスの情報取得
                ui3Controllar.UI3BoardData(getmasu);
            }
            else
                ui3Controllar.UI3BoardData(444);
        }
    }


    public void SetActionCharactor(GameObject set_charactor){
        action_charactor = set_charactor;
    }

    public GameObject GetActionCharactor(){
        return action_charactor;
    }

    public void ResetCommonAction(){
        //クローン削除
        prefabsControllar.DeleteRangeClone();
        prefabsControllar.DeleteAreaClone();
        // //攻撃用配列の初期化
        MasuControllar.RangeDataReset();
        MasuControllar.AreaDataReset();
        //キャラ選択用フラグを0に
        flag.SetSelectFlag(false);
        //全体番号用変数を初期化
        flag.SetAllNumber(0);
        //ボタン処理終了のためフラグを０に
        flag.SetButtonFlag(false);
        //色をもとに戻す
        action_charactor.GetComponent<Renderer>().material.color = Color.white;
        action_charactor = null;
    }


    //キャラクタークリック後AttackButtonで起動関数
    public void AttackRange()
    {
        MasuControllar.CharaAttack(click_start.x, click_start.y);
    }
    //キャラクタークリック後SkillButtonで起動関数
    public void SkillRange(int jobnum){
        MasuControllar.CharaSkill(click_start.x, click_start.y,jobnum);
    }
    //キャラクタークリック後MoveButtonで起動関数
    public void MoveRange(int movepower){ 
        MasuControllar.CharaMove(click_start.x,click_start.y,movepower,player_turn);
    }

    //マップをクリックしたか
    public bool JudgeMapClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            click_attack = Position();
            //HasTile タイルが存在する場合true
            var tilemap = GetComponent<Tilemap>();
            //クリックした場所マスある？　Y/N
            return tilemap.HasTile(click_attack);
        }
        return false;
    }


    public Vector3Int ReturnStartPosition()
    {
        return click_start;
    }


    //クリックした座標を変換関数
    Vector3Int Position(){
            // Vector3でマウス位置座標を取得する
            Vector3 pos = Input.mousePosition;
            // Z軸修正
            pos.z = 10f;
            // マウス位置座標をスクリーン座標からワールド座標に変換する
            Vector3 pos2 = Camera.main.ScreenToWorldPoint(pos);
            //ワールド座標をクリックしたセル座標に変換
            Vector3Int clickpos = grid.WorldToCell(pos2);
            return clickpos;
    }

    //ターンの切り替え
    public void ChangeTurn(){
        //キャラクター選択中か　Y/S
        if(!flag.GetSelectFlag()){
            //プレイヤーターン変更
            player_turn = (player_turn == 1)? (byte)2: (byte)1;
            playerTurnText.TextPlayer(player_turn);//テキストの書き換え
            var charactortags = GameObject.FindGameObjectsWithTag ("charactor");

            //charactorタグを持ったオブジェクトを検索　キャラのflagをfalseに軽減中だった場合ターン-1
            foreach(var charaobj in charactortags){
                charaobj.GetComponent<CharactorControllar>().move_flag = false;
                charaobj.GetComponent<CharactorControllar>().action_flag = false;
                if(charaobj.GetComponent<CharactorControllar>().resist_turn > 0)
                    charaobj.GetComponent<CharactorControllar>().resist_turn -= 1;
            }
            Debug.Log("ターンを切り替えます。\n\n");
        }
        else
            Debug.Log("キャラクター選択中です。");
    }

    //現在のターンを返し
    public int GetPlayerTurn(){
        return player_turn;
    }

    //キャラクターが死んだ場合
    public void DeadFlag(int player)
    {
        if (player == 1)
        {
            dead_flag1 -= 1;
            if (dead_flag1 == 0)
                SceneManager.LoadScene("2PWIN");
        }
        if (player == 2)
        {
            dead_flag2 -= 1;
            if (dead_flag2 == 0)
                SceneManager.LoadScene("1PWIN");
        }
    }
}
