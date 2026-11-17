// Decompiled with JetBrains decompiler
// Type: ScenarioComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class ScenarioComponent : MonoBehaviour
{
  public 딶.땨 Rules;
  public GameRulesComponent[] GameComponents;

  public T GetGameComponent<T>() where T : GameRulesComponent
  {
    foreach (GameRulesComponent gameComponent in this.GameComponents)
    {
      T obj = gameComponent as T;
      if (Object.op_Inequality((Object) (object) obj, (Object) null))
        return obj;
    }
    return (T) null;
  }

  public List<T> GetGameComponents<T>() where T : GameRulesComponent
  {
    List<T> objList = new List<T>();
    foreach (GameRulesComponent gameComponent in this.GameComponents)
    {
      T obj = gameComponent as T;
      if (Object.op_Inequality((Object) (object) obj, (Object) null))
        objList.Add(obj);
    }
    return objList;
  }
}
