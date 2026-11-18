// Decompiled with JetBrains decompiler
// Type: 딢.땫
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딢
{
  public class 땫
  {
    private List<땆> 딟;
    private bool 딟;
    private bool 땄;

    public 땫() => this.딟 = new List<땆>();

    public void 딟([In] ScoreTableData obj0, [In] string obj1)
    {
      for (int index1 = 0; index1 < obj0.Users.Count; ++index1)
      {
        KeyValuePair<string, Dictionary<string, ScoreTableEntryData>> keyValuePair1 = obj0.Users.ElementAt<KeyValuePair<string, Dictionary<string, ScoreTableEntryData>>>(index1);
        for (int index2 = 0; index2 < keyValuePair1.Value.Count; ++index2)
        {
          KeyValuePair<string, ScoreTableEntryData> keyValuePair2 = keyValuePair1.Value.ElementAt<KeyValuePair<string, ScoreTableEntryData>>(index2);
          if (keyValuePair2.Key == obj1 && keyValuePair2.Value.Score > 0)
            this.딟.Add(new 땆(keyValuePair1.Key, keyValuePair2.Value.Score));
        }
      }
      this.딟 = true;
      if (!this.땄)
        return;
      this.딧();
    }

    public void 딟([In] string obj0, [In] string obj1, [In] int obj2)
    {
      if (obj2 > 0)
        this.딟.Add(new 땆(obj0, obj1, obj2));
      this.땄 = true;
      if (!this.딟)
        return;
      this.딧();
    }

    public void 딟()
    {
      for (int index = 0; index < this.땃(); ++index)
        this.딟[index].땄();
    }

    public List<땆> 땄() => this.딟;

    private int 딟([In] 땆 obj0, [In] 땆 obj1) => obj1.딟 - obj0.딟;

    private void 딧()
    {
      this.딟.Sort(new Comparison<땆>(this.딟));
      for (int index = 0; index < this.땃(); ++index)
        this.딟[index].딟();
    }

    [SpecialName]
    public bool 딢()
    {
      for (int index = 0; index < this.땃(); ++index)
      {
        if (!this.딟[index].딧())
          return false;
      }
      return true;
    }

    [SpecialName]
    public void 딟([In] bool obj0)
    {
    }

    [SpecialName]
    private int 땃() => Mathf.Min(this.딟.Count, 3);

    [SpecialName]
    private void 딟([In] int obj0)
    {
    }
  }
}
