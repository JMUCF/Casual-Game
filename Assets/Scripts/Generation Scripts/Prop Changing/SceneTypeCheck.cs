using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class SceneTypeCheck : MonoBehaviour
{
    public void Check()
    {
        Debug.Log(SceneChange.propType.ToString());
        switch (SceneChange.propType.ToString())
        {
            case "Suburbs":
                CreateSuburbs();
                break;
            case "City":
                CreateCity();
                break ;
            case "Army":
                CreateArmy();
                break;
            default:
                CreateSuburbs();
                break;
        }
    }

    protected virtual void CreateSuburbs()
    {
        Debug.LogWarning("Creating " + SceneChange.propType);
    }
    protected virtual void CreateCity()
    {
        Debug.LogWarning("Creating " + SceneChange.propType);
    }
    protected virtual void CreateArmy()
    {
        Debug.LogWarning("Creating " + SceneChange.propType);
    }
}
