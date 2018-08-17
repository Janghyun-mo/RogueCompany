﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 0806 모장현
// 각종 디버그 및 테스트를 위한 on / off 변수들

/// <summary>
/// 디버그용 셋팅, 변수들
/// </summary>
public class DebugSetting : MonoBehaviourSingleton<DebugSetting>
{
    [Header("Enemy Data로 무기 설정")]
    public bool equipsEnemyDataWeapon = true;
    [Header("몬스터 테스트용으로 장착할 무기 id")]
    public int enemyEquipWeaponId;

}
