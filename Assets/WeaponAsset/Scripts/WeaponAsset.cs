﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponAsset
{
    public delegate float DelGetDirDegree();    // 총구 방향 각도
    public delegate Vector3 DelGetPosition();   // owner position이지만 일단 player position 용도로만 사용.

    public enum WeaponState { Idle, Attack, Reload, Charge, Switch, PickAndDrop }
    /// <summary>
    /// 원거리 : 권총, 산탄총, 기관총, 저격소총, 레이저, 활, 지팡이, 원거리 특수
    /// 근거리 기반 : 창, 몽둥이, 스포츠용품, 검, 청소도구, 주먹장착무기, 근거리 특수
    /// 폭발형? : 폭탄, 접근발동무기
    /// 17개
    /// </summary>
    // END 는 WeaponType 총 갯수를 알리기 위해서 enum 맨 끝에 기입 했음.
    public enum WeaponType
    {
        NULL, PISTOL, SHOTGUN, MACHINEGUN, SNIPER_RIFLE, LASER, BOW,
        SPEAR, CLUB, SPORTING_GOODS, SWORD, CLEANING_TOOL, KNUCKLE,
        BOMB, TRAP,
        WAND, MELEE_SPECIAL, RANGED_SPECIAL, END
    }

    // PISTOL, SHOTGUN, MACHINEGUN, SNIPLER_RIFLE, LASER, BOW
    public enum AttackAniType { None, Blow, Strike, Swing, Punch, Shot }
    public enum AttackType { MELEE, RANGED, TRAP }
    public enum TouchMode { Normal, Charge }
    public enum BulletType { PROJECTILE, LASER, MELEE, NULL, MINE, EXPLOSION }
    public enum BulletPresetType
    {
        None, YELLOW_CIRCLE, RED_CIRCLE, SKYBLUE_BASH, BLUE_BASH, RED_BASH, ORANGE_BASH,
        BLUE_CIRCLE, SKYBLUE_CIRCLE, PINK_CIRCLE, VIOLET_CIRCLE, EMPTY,
        YELLOW_BULLET, BLUE_BULLET, PINK_BULLET, VIOLET_BULLET, RED_BULLET, GREEN_BULLET,
        YELLOW_BEAM, BLUE_BEAM, PINK_BEAM, VIOLET_BEAM, RED_BEAM, GREEN_BEAM, GREEN_CIRCLE,
        YELLOW_BULLET2, SKYBLUE_BULLET2, BLUE_BULLET2, PINK_BULLET2, VIOLET_BULLET2, RED_BULLET2, GREEN_BULLET2,
        TEST, TEST2, TEST3, TEST4
    };
    /*---*/
    public enum BulletParticleType { NONE, BASIC }
    public enum ImpactParticleType { NONE, BASIC }
    public enum TrailParticleType { NONE, BASIC }
    public enum MuzzleFlashType
    {
        NONE, BASIC, MUZZLE_FLASH_FROST, MUZZLE_FLASH_FIRE_BALL_BLUE, MUZZLE_FLASH_FIRE_BALL_GREEN, MUZZLE_FLASH_FIRE_BALL_PURPLE, MUZZLE_FLASH_FIRE_BALL_RED, MUZZLE_FLASH_FIRE_BALL_YELLOW,
        MUZZLE_FLASH_SPIKY_YELLOW
    }

    public enum BulletPropertyType { Collision, Update, Delete }
    public enum CollisionPropertyType { BaseNormal, Laser, Undeleted }
    public enum UpdatePropertyType { StraightMove, AccelerationMotion, Laser, Summon, Homing, MineBomb, FixedOwner, Spiral, Rotation, Child, TRIGONOMETRIC }
    public enum DeletePropertyType { BaseDelete, Laser, SummonBullet, SummonPattern }
    public enum BehaviorPropertyType { SpeedControl, Rotate }

    /*---*/

    public enum ColliderType { NONE, Beam, AUTO_SIZE_BOX, AUTO_SIZE_CIRCLE, MANUAL_SIZE_BOX, MANUAL_SIZE_CIRCLE }

    public enum BulletAnimationType
    {
        NotPlaySpriteAnimation,
        BashAfterImage,
        PowerBullet,
        Wind,
        BashAfterImage2,
        Explosion0,
        BashSkyBlue,
        BashBlue,
        BashRed,
        BashOrange,
        PaperShot
    }

    /*---*/


    // 총알 삭제 함수 델리게이트
    public delegate void DelDestroyBullet();
    // 총알 충돌 함수 델리게이트
    public delegate void DelCollisionBullet(Collider2D coll);
}