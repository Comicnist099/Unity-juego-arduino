using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void DuckDel();
    public static DuckDel OnSpawnGhosts;
    public static DuckDel OnGhostShoot;
    public static DuckDel OnGhostDeath;
    public static DuckDel OnGhostFlyAway;
    public static DuckDel OnGhostMiss;

    public static DuckDel OnSpawnSkulls;
    public static DuckDel OnSkullShoot;
    public static DuckDel OnSkullDeath;
    public static DuckDel OnSkullFlyAway;
    public static DuckDel OnSkullMiss;

    public static DuckDel OnSpawnFlames;
    public static DuckDel OnFlameShoot;
    public static DuckDel OnFlameDeath;
    public static DuckDel OnFlameFlyAway;
    public static DuckDel OnFlameMiss;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
