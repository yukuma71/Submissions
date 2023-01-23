using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Constants;
using System;

public class MasuControllar : MonoBehaviour
{

    private byte jobnum;                 //行動中のキャラのジョブ番号
    private Vector3Int save_postion;    //クリックした座標をセーブ
    private Vector3Int clickpos;        //クリックした座標を格納

    public PrefabsControllar prefabsControllar;
    public Flag flag;
    public Judges judges;



    //マス情報 土地:0 キャラクター:全体番号(1 ～ 8)
    public int[,] masu_data = new int[13, 13]{{0,0,0,0,0,0,0,0,0,0,0,0,0},
                                            {0,0,0,0,0,0,0,0,0,0,0,0,0},
                                            {0,0,0,0,0,0,0,0,0,0,0,0,0},
                                            {0,0,0,0,0,0,0,0,0,0,0,0,0},
                                            {0,0,0,0,0,0,0,0,0,0,0,0,0},
                                            {0,0,0,0,0,0,0,0,0,0,0,0,0},
                                            {0,0,0,0,0,0,0,0,0,0,0,0,0},
                                            {0,0,0,0,0,0,0,0,0,0,0,0,0},
                                            {0,0,0,0,0,0,0,0,0,0,0,0,0},
                                            {0,0,0,0,0,0,0,0,0,0,0,0,0},
                                            {0,0,0,0,0,0,0,0,0,0,0,0,0},
                                            {0,0,0,0,0,0,0,0,0,0,0,0,0},
                                            {0,0,0,0,0,0,0,0,0,0,0,0,0}};

    //マス情報 射程内の場合 0  移動にり自軍陣地は10
    public int[,] range_data = new int[13, 13]{{9,9,9,9,9,9,9,9,9,9,9,9,9},
                                               {9,9,9,9,9,9,9,9,9,9,9,9,9},
                                               {9,9,9,9,9,9,9,9,9,9,9,9,9},
                                               {9,9,9,9,9,9,9,9,9,9,9,9,9},
                                               {9,9,9,9,9,9,9,9,9,9,9,9,9},
                                               {9,9,9,9,9,9,9,9,9,9,9,9,9},
                                               {9,9,9,9,9,9,9,9,9,9,9,9,9},
                                               {9,9,9,9,9,9,9,9,9,9,9,9,9},
                                               {9,9,9,9,9,9,9,9,9,9,9,9,9},
                                               {9,9,9,9,9,9,9,9,9,9,9,9,9},
                                               {9,9,9,9,9,9,9,9,9,9,9,9,9},
                                               {9,9,9,9,9,9,9,9,9,9,9,9,9},
                                               {9,9,9,9,9,9,9,9,9,9,9,9,9}};

    
    //マス情報 0範囲内
    public int[,] area_data = new int[13, 13]{{9,9,9,9,9,9,9,9,9,9,9,9,9},
                                              {9,9,9,9,9,9,9,9,9,9,9,9,9},
                                              {9,9,9,9,9,9,9,9,9,9,9,9,9},
                                              {9,9,9,9,9,9,9,9,9,9,9,9,9},
                                              {9,9,9,9,9,9,9,9,9,9,9,9,9},
                                              {9,9,9,9,9,9,9,9,9,9,9,9,9},
                                              {9,9,9,9,9,9,9,9,9,9,9,9,9},
                                              {9,9,9,9,9,9,9,9,9,9,9,9,9},
                                              {9,9,9,9,9,9,9,9,9,9,9,9,9},
                                              {9,9,9,9,9,9,9,9,9,9,9,9,9},
                                              {9,9,9,9,9,9,9,9,9,9,9,9,9},
                                              {9,9,9,9,9,9,9,9,9,9,9,9,9},
                                              {9,9,9,9,9,9,9,9,9,9,9,9,9}};
    public DamageControllar demegeControllar;
    public MainControllar mainControllar;
    public Grid grid;


//行動範囲の配列リセット
    public void MoveDataReset()
    {
        for (byte i = 0; i < 13; i++)
        {
            for (byte f = 0; f < 13; f++)
            {
                range_data[f, i] = 9;
            }
        }
    }

    //キャラ死亡時マスデータ書き換え
    public void CharaDie(int number)
    {
        for (byte i = 0; i < 13; i++)
        {
            for (byte f = 0; f < 13; f++)
            {
                if (masu_data[f, i] == number)
                    masu_data[f, i] = 0;
            }
        }
    }

    //キャラの初期位置をMasuDataに入力
    public void CharactorPositionSet(int x, int y, int all_number)
    {
        masu_data[MAP_SIZE_MAX - y, x] = all_number;
    }

    //RangeDataの初期化
    public void RangeDataReset()
    {
        for (byte i = 0; i < 13; i++)
        {
            for (byte f = 0; f < 13; f++)
            {
                range_data[f, i] = 9;
            }
        }
    }

    //AreaDataの初期化
    public void AreaDataReset()
    {
        for (byte i = 0; i < 13; i++)
        {
            for (byte f = 0; f < 13; f++)
            {
                area_data[f, i] = 9;
            }
        }
    }
    

    void Update()
    {
        // Vector3でマウス位置座標を取得する
        Vector3 pos = Input.mousePosition;
        // Z軸修正
        pos.z = 10f;
        // マウス位置座標をスクリーン座標からワールド座標に変換する
        Vector3 pos2 = Camera.main.ScreenToWorldPoint(pos);
        //ワールド座標をクリックしたセル座標に変換
        clickpos = grid.WorldToCell(pos2);
        if (!(save_postion == null || save_postion != clickpos)) return;
        AreaDataReset();
        save_postion = clickpos;
        prefabsControllar.DeleteAreaClone();
        //Mapの範囲外　スキルの射程外だった場合スキップ
        if (!( judges.withinRangeJudge(clickpos.x) && judges.withinRangeJudge(clickpos.y))) return;
        if (!(range_data[MAP_SIZE_MAX - clickpos.y, clickpos.x] == 0)) return;
        //対応した効果範囲を表示
        if(flag.GetSkillFlag()) SetSkillArea();
        if(flag.GetAttackFlag()) SetAttackArea();
        if(flag.GetMoveFlag()) SetMoveArea();
        
    }



    //攻撃可能範囲を入力・表示
    public void CharaAttack(int charactorpos_x, int charactorpos_y)
    {
        //自キャラの座標に全体番号入力
        range_data[MAP_SIZE_MAX - charactorpos_y, charactorpos_x] = masu_data[MAP_SIZE_MAX - charactorpos_y, charactorpos_x];

        //x軸
        for(int x = charactorpos_x - 1; x <= charactorpos_x + 1; x++)
        {
            //x軸がMAPの範囲外だったらSKIP
            if(!judges.withinRangeJudge(x)) continue;
            //y軸
            for(int y = charactorpos_y - 1; y <= charactorpos_y + 1; y++)
            {
                //自身が対象だったらSKIP
                if(y == charactorpos_y && x == charactorpos_x) continue;
                //y軸がMAPの範囲外だったらSKIP
                if(!judges.withinRangeJudge(y)) continue;

                range_data[MAP_SIZE_MAX - y, x] = 0;
            }
        }

        //行動範囲に丸設置
        for (byte i = 0; i < 13; i++)
        {
            for (byte f = 0; f < 13; f++)
            {
                if (range_data[i, f] == 0)
                    prefabsControllar.SetAttackRange(f, MAP_SIZE_MAX - i);
            }
        }
    }

    //スキルの発動可能範囲を乳・表示
    public void CharaSkill(int charactorpos_x, int charactorpos_y, int jobnumber)
    {
        //自キャラの座標に全体番号入力
        range_data[MAP_SIZE_MAX - charactorpos_y, charactorpos_x] = masu_data[MAP_SIZE_MAX - charactorpos_y, charactorpos_x];
        switch (jobnumber)
        {
            case SENSHI://キャラクター（全体番号)
                for (int i = -KISHI_SKILL_RANGE; i <= KISHI_SKILL_RANGE; i++)
                {
                    //上下
                    if (judges.withinRangeJudge(MAP_SIZE_MAX - charactorpos_y + i))
                    {
                        if (range_data[MAP_SIZE_MAX - charactorpos_y + i, charactorpos_x] != 9) continue;
                        range_data[MAP_SIZE_MAX - charactorpos_y + i, charactorpos_x] = 0;
                    }
                    //左右
                    if (judges.withinRangeJudge(charactorpos_x + i))
                    {
                        if (range_data[MAP_SIZE_MAX - charactorpos_y, charactorpos_x + i] != 9) continue;
                        range_data[MAP_SIZE_MAX - charactorpos_y, charactorpos_x + i] = 0;
                    }
                }
                break;
            case KISHI:
            	range_data[MAP_SIZE_MAX - charactorpos_y, charactorpos_x] =　0;
                break;

            case SOURYO:
                for(int x = charactorpos_x - SOURYO_SKILL_RANGE; x <= charactorpos_x + SOURYO_SKILL_RANGE; x++)
                {
                    //MAPの範囲外だったらSKIP
                    if(!judges.withinRangeJudge(x)) continue;
                    for(int y = charactorpos_y - SOURYO_SKILL_RANGE; y <= charactorpos_y + SOURYO_SKILL_RANGE; y++)
                    {
                        //自身が対象だったらSKIP
                        if(y == charactorpos_y && x == charactorpos_x) continue;
                        //MAPの範囲外だったらSKIP
                        if(!judges.withinRangeJudge(y)) continue;
                        range_data[MAP_SIZE_MAX - y, x] = 0;
                    }
                }
                
                break;
            case MAJO:
                //x軸
                for(int x = MAJO_SKILL_RANGE; x >= -MAJO_SKILL_RANGE; x--)
                {   
                    //x軸がMAPの範囲外だったらSKIP
                    if(!judges.withinRangeJudge(charactorpos_x + x)) continue;
                    for (int y = MAJO_SKILL_RANGE - Math.Abs(x); y >= 0; y--)
                    {
                        //自身が対象だったらSKIP
                        if(y == 0 && x == 0) continue;
                        //上下
                        if(judges.withinRangeJudge(MAP_SIZE_MAX - charactorpos_y + y))
                        {
                            range_data[MAP_SIZE_MAX - charactorpos_y + y, charactorpos_x + x] = 0;
                        }
                        if(judges.withinRangeJudge(MAP_SIZE_MAX - charactorpos_y - y))
                        {
                            range_data[MAP_SIZE_MAX - charactorpos_y - y, charactorpos_x + x] = 0;
                        }
                    }
                }
                break;
            default:
                break;
        }
        //発動可能範囲にプレハブ設置
        for (byte i = 0; i < 13; i++)
        {
            for (byte f = 0; f < 13; f++)
            {
                if (range_data[i, f] == 0)
                    prefabsControllar.SetSkillRange(f, MAP_SIZE_MAX - i);
            }
        }
    }

    //キャラクターをクリックして動く（ReturnClick内）行動範囲の計算
    public void CharaMove(int charactorpos_x, int charactorpos_y, int move_power, int number)
    {
        //以下4つのフラグはキャラの飛び越しをしないように道中にいたら true
        bool up_flag = false;
        bool down_flag = false;
        bool right_flag = false;
        bool left_flag = false;
        //masu_dataのキャラクターの位置を読み込み、１を代入
        for (byte i = 0; i < 13; i++)
        {
            for (byte f = 0; f < 13; f++)
            {
                if (masu_data[f, i] != 0 && masu_data[f, i] != 9) //土地、自陣地以外のキャラクターの全体番号を入力
                    range_data[f, i] = masu_data[f, i];
            }
        }
        //自分の陣地に入れなくする
        if (number == 1)
        {
            range_data[MAP_SIZE_MAX, 5] = 10;
            range_data[MAP_SIZE_MAX, 6] = 10;
            range_data[MAP_SIZE_MAX, 7] = 10;
        }
        if (number == 2)
        {
            range_data[MAP_SIZE_MIN, 5] = 10;
            range_data[MAP_SIZE_MIN, 6] = 10;
            range_data[MAP_SIZE_MIN, 7] = 10;
        }
        //行動可能範囲を計算し０を代入
        for (byte i = 1; i <= move_power; i++)
        {
            //上方向
            if (MAP_SIZE_MAX - charactorpos_y - i >= 0)
            {
                if (range_data[MAP_SIZE_MAX - charactorpos_y - i, charactorpos_x] != 9)
                    up_flag = true;
                if (!up_flag)
                    range_data[MAP_SIZE_MAX - charactorpos_y - i, charactorpos_x] = 0;
            }
            //右方向
            if (charactorpos_x + i <= MAP_SIZE_MAX)
            {
                if (range_data[MAP_SIZE_MAX - charactorpos_y, charactorpos_x + i] != 9)
                    right_flag = true;
                if (!right_flag)
                    range_data[MAP_SIZE_MAX - charactorpos_y, charactorpos_x + i] = 0;
            }
            //左方向
            if (charactorpos_x - i >= 0)
            {
                if (range_data[MAP_SIZE_MAX - charactorpos_y, charactorpos_x - i] != 9)
                    left_flag = true;
                if (!left_flag)
                    range_data[MAP_SIZE_MAX - charactorpos_y, charactorpos_x - i] = 0;
            }
            //下方向
            if (MAP_SIZE_MAX - charactorpos_y + i <= MAP_SIZE_MAX)
            {
                if (range_data[MAP_SIZE_MAX - charactorpos_y + i, charactorpos_x] != 9)
                    down_flag = true;
                if (!down_flag)//フラグ１のとき飛び越し禁止
                    range_data[MAP_SIZE_MAX - charactorpos_y + i, charactorpos_x] = 0;
            }
        }
        //行動範囲にプレハブ設置
        for (byte i = 0; i < 13; i++)
        {
            for (byte f = 0; f < 13; f++)
            {
                if (range_data[i, f] == 0)
                   prefabsControllar.SetMoveRange(f, MAP_SIZE_MAX - i);
            }
        }
    }

    //勝利判定・MasuDataの書き換え
    public void Movedate(GameObject move_charactor, Vector3 reset_postion)
    {
        //勝利判定のために必要な変数
        int movepos_x = (int) move_charactor.GetComponent<Transform>().position.x;
        int movepos_y = (int) move_charactor.GetComponent<Transform>().position.y;
        int player_number = mainControllar.GetPlayerTurn();

        //現在地をMasuDataに書き込み
        move_charactor.GetComponent<CharactorControllar>().SetMyPosition();

        //元いた位置地点を空白に
        Vector3Int reset_cell_postion = grid.WorldToCell(reset_postion);
        masu_data[MAP_SIZE_MAX - reset_cell_postion.y, reset_cell_postion.x] = 0;

        //勝利判定
        if (player_number == 1 )
        {
            if (movepos_y == 6 && (movepos_x == -1 ||movepos_x == 0 || movepos_x == 1))
            {
                SceneManager.LoadScene("1PWIN");
            }
        }
        else
        {
            if (movepos_y == -6 && (movepos_x == -1 || movepos_x == 0 || movepos_x == 1))
            {
                SceneManager.LoadScene("2PWIN");
            }
        }
    }

    //行動中のキャラのjobnumを入力
    public void SetActionJobNum(byte number){
        jobnum = number;

    }

    

    //PointClick用の返し
    public int GetMasu(int x, int y)
    {
        return masu_data[MAP_SIZE_MAX - y, x];
    }


    //攻撃地点の表示
    public void SetAttackArea(){
        area_data[MAP_SIZE_MAX - clickpos.y, clickpos.x] = 0;
        for (byte i = 0; i < 13; i++)
        {
            for (byte f = 0; f < 13; f++)
            {
                if (area_data[i, f] == 0) prefabsControllar.SetAttackArea(f, MAP_SIZE_MAX - i);
            }
        }
    }

    //スキル効果範囲の表示
    public void SetSkillArea(){
        //ジョブごとにSkillの効果範囲配列へ
        switch (jobnum)
        {
            case SENSHI:
                area_data[MAP_SIZE_MAX - clickpos.y, clickpos.x] = 0;
                int this_playr_unit_allid  = (mainControllar.player_turn == 1) ? 1 : 5;
                    for(int i = -1; i <= 1; i++)
                    {
                        if( judges.withinRangeJudge(MAP_SIZE_MAX - clickpos.y + i) && judges.withinRangeJudge(MAP_SIZE_MAX - clickpos.y - i)){
                            if(masu_data[MAP_SIZE_MAX - clickpos.y - i, clickpos.x] == this_playr_unit_allid){
                                area_data[MAP_SIZE_MAX - clickpos.y + i, clickpos.x] = 0;
                            }
                        }
                        if(judges.withinRangeJudge(clickpos.x + i) && judges.withinRangeJudge(clickpos.x - i)){
                            if(masu_data[MAP_SIZE_MAX - clickpos.y, clickpos.x - i] == this_playr_unit_allid){
                                area_data[MAP_SIZE_MAX - clickpos.y, clickpos.x + i] = 0;
                            }
                        }
                    }
                break;
            case KISHI:
                area_data[MAP_SIZE_MAX - clickpos.y, clickpos.x] = 0;
                break;
            case SOURYO:
                area_data[MAP_SIZE_MAX - clickpos.y, clickpos.x] = 0;
                break;
            case MAJO:
                //x軸
                for(int x = clickpos.x - 1; x <= clickpos.x + 1; x++)
                {
                    //x軸がMAPの範囲外だったらSKIP
                    if(!judges.withinRangeJudge(x)) continue;
                    //y軸
                    for(int y = clickpos.y - 1; y <= clickpos.y + 1; y++)
                    {
                        //y軸がMAPの範囲外だったらSKIP
                        if(!judges.withinRangeJudge(y)) continue;
                        area_data[MAP_SIZE_MAX - y, x] = 0;
                    }
                }
                break;
            default:
                break;
        }
        //効果範囲にAreaプレハブ設置
        for (byte i = 0; i < 13; i++)
        {
            for (byte f = 0; f < 13; f++)
            {
                if (area_data[i, f] == 0) prefabsControllar.SetSkillArea(f, MAP_SIZE_MAX - i);
            }
        }
    }

    public void SetMoveArea(){
        area_data[MAP_SIZE_MAX - clickpos.y, clickpos.x] = 0;
        for (byte i = 0; i < 13; i++)
        {
            for (byte f = 0; f < 13; f++)
            {
                if (area_data[i, f] == 0) prefabsControllar.SetMoveArea(f, MAP_SIZE_MAX - i);
            }
        }
    }

    

    //センターポジションを出力
    public Vector3Int GetClickPosition()
    {
        return save_postion;
    }
}