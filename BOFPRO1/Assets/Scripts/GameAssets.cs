using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i {
        get {
            if (_i == null) _i = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();

            return _i; 
        
        }
    }

    public Sprite Bait_1;
    public Sprite Bait_2;
    public Sprite Bait_3;

    public Sprite Fishingrod_1;
    public Sprite Fishingrod_2;
    public Sprite Fishingrod_3;
}
