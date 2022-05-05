using System;
using System.Collections;
using Classes;
using DefaultNamespace;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour
{
    public static int BasicDamage = 20;
    public static Transform Transform;
    private bool _coroutineStarted;
    public static Monster Monster;
    public SpriteRenderer SpriteRenderer;
    [SerializeField]
    public Canvas HPCanvas;
    [SerializeField]
    public double Hp;
    [SerializeField]
    public MonsterHpRenderer HpRenderer;

    public double attackReadyness;

    public void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Transform = GetComponent<Transform>();
        Monster = new Monster(this);
        BigData.MonstersMap[this] = Monster;
    }

    public void OnDestroy()
    {
        BigData.MonstersMap.Remove(this);
        Destroy(SpriteRenderer); //Todo fix death
        Destroy(HPCanvas);
        Destroy(HpRenderer);
    }

    public void Update()
    {
        if (!(BigData.Player == null || _coroutineStarted))
            StartCoroutine(AttackCoroutine());
        if (Monster.IsAlive == false)
        {
            Destroy(this);
        }

        _coroutineStarted = true;
        Hp = Monster.HealtPoints;
    }

    public void HandleDamage()
    {
        var position = Transform.position;
        var vector = position - BigData.Player.PlayerBehaviour.transform.position;
        position += vector.normalized * 0.3f;
        Transform.position = position;
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            if (Math.Abs(attackReadyness - 5) < 1e-9)
            {
                if ((BigData.Player.PlayerBehaviour.transform.position - Transform.position).Length() <= 0.6)
                {
                    BigData.Player.GetDamage(BasicDamage);
                }
                attackReadyness = 0;

            }

            attackReadyness += 0.1;
            yield return new WaitForSeconds(0.1f);
        }
    }
}