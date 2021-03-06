﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour {
    protected new string name;
    protected int value;
    protected Sprite sprite;
    protected Rating rating;
    public System.Action action;

    public Rating GetRating() { return rating; }
    public int GetValue() { return value; }
    public virtual void Active() { }
    public virtual void SubActive() { }
    public virtual string GetName() { return name; }
    public Sprite GetSprite() { return sprite; }

}

public class Coin : Item
{
    bool isActive = false;

    public override void Active()
    {
        if (!isActive)
        {
            GameDataManager.Instance.SetCoin();
            isActive = !isActive;
            MoveToTarget();
        }
    }

    public override void SubActive()
    {
        GameDataManager.Instance.SetCoin();
        isActive = !isActive;
        MoveToTarget();
    }

    void MoveToTarget()
    {
        float distance = Vector2.Distance(transform.position, PlayerManager.Instance.GetPlayerPosition());

        StartCoroutine(CoroutineMoveToTarget(transform, distance / 2));
    }
   
    IEnumerator CoroutineMoveToTarget(Transform _transform, float _duration)
    {
        float elapsed = 0.0f;
        Vector2 start = _transform.position;
        Vector2 target;
        while (elapsed < _duration)
        {
            target = PlayerManager.Instance.GetPlayerPosition();
            elapsed += Time.deltaTime + elapsed * elapsed / 50;
            _transform.position = Vector2.Lerp(start, target, elapsed / _duration);
            yield return YieldInstructionCache.WaitForEndOfFrame;
        }

        gameObject.SetActive(false);
        gameObject.transform.parent = null;
        Destroy(this);
    }
}

public class Key : Item
{
    bool isActive = false;

    public override void Active()
    {
        if (!isActive)
        {
            GameDataManager.Instance.SetKey();
            isActive = !isActive;
            MoveToTarget();
        }
    }

    public override void SubActive()
    {
        GameDataManager.Instance.SetKey();
        isActive = !isActive;
        MoveToTarget();
    }

    void MoveToTarget()
    {
        float distance = Vector2.Distance(transform.position, PlayerManager.Instance.GetPlayerPosition());

        StartCoroutine(CoroutineMoveToTarget(transform, distance / 2));
    }

    IEnumerator CoroutineMoveToTarget(Transform _transform, float _duration)
    {
        float elapsed = 0.0f;
        Vector2 start = _transform.position;
        Vector2 target;
        while (elapsed < _duration)
        {
            target = PlayerManager.Instance.GetPlayerPosition();
            elapsed += Time.deltaTime + elapsed * elapsed / 50;
            _transform.position = Vector2.Lerp(start, target, elapsed / _duration);
            yield return YieldInstructionCache.WaitForEndOfFrame;
        }

        gameObject.SetActive(false);
        gameObject.transform.parent = null;
        Destroy(this);
    }
}

public class Ammo : Item
{
    bool isActive = false;

    private void Start()
    {
        name = "탄약";
    }

    public bool isCanFill()
    {
        return PlayerManager.Instance.GetPlayer().GetWeaponManager().FillUpAmmo();
    }

    public override void Active()
    {
        if (!isActive)
        {
            isActive = !isActive;
            gameObject.SetActive(false);
            gameObject.transform.parent = null;
            Destroy(this);
        }
    }
}
