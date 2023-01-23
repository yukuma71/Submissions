using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillDetailsUI : MonoBehaviour
{
	public SkillDetailsNameUI skilldetailsnameui;
    public SkillDetailsTextUI skilldetailstextui;

	public void ChangeSkillDetails(int jobnum){
		skilldetailsnameui.ChangeSkillName(jobnum);//UIのスキル名を職業に合わせて変更
        skilldetailstextui.ChangeSkillText(jobnum);
}
}
