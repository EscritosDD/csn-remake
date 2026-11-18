// Decompiled with JetBrains decompiler
// Type: 딶.땿
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딶
{
  public class 땿
  {
    public 땿([In] string[] obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(new List<딙>());
      // ISSUE: reference to a compiler-generated method
      this.딟(new 딙[2]);
      for (int index = 0; index < obj0.Length && index < 2; ++index)
        this.땄()[index] = new 딙(딟.딥.딧(obj0[index]));
      for (int index = 2; index < obj0.Length; ++index)
        this.딧().Add(new 딙(딟.딥.딧(obj0[index])));
    }

    public 땿()
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(new 딙[2]);
      // ISSUE: reference to a compiler-generated method
      this.딟(new List<딙>());
    }

    public 땿([In] 땄.땞 obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(new 딙[2]);
      // ISSUE: reference to a compiler-generated method
      this.딟(new List<딙>());
      땓.딿 딟 = obj0.딟 as 땓.딿;
      if (GlobalAppData.땼().딟(딟.딟()).GenericData.PlayFirstTurnImmediately)
      {
        for (int index = 0; index < obj0.딟.Length && index < 2; ++index)
          this.딟(obj0, index);
        for (int index = 2; index < obj0.딟.Length; ++index)
          this.딧().Add(new 딙(obj0.딟[index].땃(), obj0.딟[index].땄(), obj0.딟[index].딶(), obj0.딟[index].땓()));
      }
      else
      {
        for (int index = 0; index < obj0.딟.Length; ++index)
        {
          딙 딙 = new 딙(obj0.딟[index].땃(), obj0.딟[index].땄(), obj0.딟[index].딶(), obj0.딟[index].땓());
          if (index < 2)
            this.땄()[index] = 딙;
          else
            this.딧().Add(딙);
        }
      }
    }

    private bool 딟([In] 땄.땞 obj0, [In] int obj1)
    {
      TacticsInitialTurnState initialTurnState = 딧.땾.딟<TacticsInitialTurnState>(obj0.딟[obj1].땃());
      if (initialTurnState == null)
        return false;
      땄.땉 땉 = obj0.딟[obj1];
      DateTime dateTime = 땉.땄();
      this.땄()[obj1] = new 딙(initialTurnState.InitialData, dateTime, 땉.딶(), 땉.땓());
      this.딧().Add(new 딙(initialTurnState.TurnData, dateTime, (Dictionary<string, int>) null, (List<딟.떀>) null));
      return true;
    }

    public string[] 딟()
    {
      List<string> stringList = new List<string>();
      for (int index = 0; index < this.땄().Length; ++index)
      {
        if (this.땄()[index] != null)
          stringList.Add(딟.딥.딟(this.땄()[index].딟()));
      }
      for (int index = 0; index < this.딧().Count; ++index)
        stringList.Add(딟.딥.딟(this.딧()[index].딟()));
      return stringList.ToArray();
    }

    [CompilerGenerated]
    [SpecialName]
    public 딙[] 땄() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public List<딙> 딧() => this.딟;
  }
}
