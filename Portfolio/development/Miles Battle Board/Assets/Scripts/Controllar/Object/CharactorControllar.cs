using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorControllar : MonoBehaviour
{
    public MainControllar mainControllar;
    public MasuControllar masuControllar;
    public Grid grid;
    public Flag flag;
    public PrefabsControllar PrefabsControllar;
    public ReturnButton returnButton;
    public DamageControllar damageControllar;
    public UI3Controllar ui3Controllar;
    public Judges judges;
    

    private Vector3 doublepos;      //ワールド座標
    ///帰ってきた値が移動可能な範囲か確認
    private Vector3Int confirmation = new Vector3Int(-1, -1, 0);
    private Vector3Int posset = new Vector3Int(0, 0, 0);
    private Vector3Int charapos;    //キャラクター位置　セル座標
    
    //インスペクターから変更する
    public byte plnum;                   //プレイヤーナンバー
    public byte allnum;                  //キャラクターを全体で見た番号
    public byte resist_turn;             //軽減の残りターン
    public byte jobnum;                  //職業       1:戦士     2:騎士     3:僧侶     4:魔女
    public byte move_power;              //行動力

    public int maxhp;                   //最大体力
    public int maxmp;                   //最大mp
    public int hp;                      //体力　総量
    public int mp;                      //マジックパワー　総量
    public int atk;                     //基礎攻撃力　1:30(戦士) 2:20(騎士) 3:10(僧侶) 4:10(魔女)
    public int skill_power;             //スキルの威力・回復力・持続ターン
    public int skill_cost;              //スキルに必要なコスト
    
    public bool action_flag = false;    //Attackとskill用のフラグ　1:行動可能 0:行動不可能
    public bool move_flag = false;            //move用フラグ false:行動可能　true:行動済み

    
    
    void Start()
    {
        SetMyPosition();   
    }

    public void SetMyPosition(){
        //自身の場所を調べVector3に
        Transform myTransform = this.transform;
        doublepos = myTransform.position;
        //ワールド座標のキャラの位置をセル座標に変換
        charapos = grid.WorldToCell(doublepos);
        //masuControllarにキャラクターの情報を送る
        masuControllar.CharactorPositionSet(charapos.x, charapos.y, allnum);
    }

    //キャラクタークリックしたら起動
    public void onclick()
    {
        
        int nowPlturn = mainControllar.GetPlayerTurn();//現在のターンを取得
        //行動してもよいか
        if (!flag.GetSelectFlag() && nowPlturn == plnum && Input.GetMouseButtonDown(0))
        {
            //それぞれに自身の情報を入力
            mainControllar.SetActionCharactor(this.gameObject);
            damageControllar.SetSkillPower(skill_power);
            damageControllar.AttackInput(atk);
            judges.SetMpJudge(mp, skill_cost);
            flag.SetActionPlNum(plnum);
            flag.SetAllNumber(allnum);
            masuControllar.SetActionJobNum(jobnum);
            //PointClick起動
            mainControllar.PointClick();
            //別のキャラクターをクリックできないように
            flag.SetSelectFlag(true);
            //選択中緑に
            GetComponent<Renderer>().material.color = new Color(0.5f, 0.9f, 0.5f, 1.0f);
        }
        if (!flag.GetSelectFlag() && nowPlturn != plnum && Input.GetMouseButtonDown(0))
            Debug.Log("相手のキャラクターです");

        //右クリックでCharactorsUIの情報開示
        if (Input.GetMouseButton(1))
        {
            mainControllar.CharactorDetails();
        }
    }

    //キャラクターが死亡したた起動
    public void Die()
    {
        Debug.Log("キャラクター" + allnum + "は死亡した。");
        masuControllar.CharaDie(allnum);
        mainControllar.DeadFlag(plnum);
        Destroy(this.gameObject);
        ui3Controllar.UI3BoardData(444);
    }    
}
