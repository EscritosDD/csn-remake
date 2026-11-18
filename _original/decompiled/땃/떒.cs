// Decompiled with JetBrains decompiler
// Type: 땃.떒
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  public class 떒 : 땧
  {
    public 떒([In] TacticsActionData obj0)
    {
    }

    public 떒()
    {
    }

    public override TacticsActionData 딟() => new TacticsActionData()
    {
      Action = 딢.땀.땃
    };

    public override 땓.딟 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 땓.떒 obj2)
    {
      obj1.딟(떒.땄(obj0, obj1, obj2));
      return new 땓.딟();
    }

    private static 땓.딟 땄([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 땓.떒 obj2)
    {
      땓.딟 딟 = new 땓.딟();
      딟.딟((딶.땏) new 딶.떑(string.Format("--------- START POST TURN for Team: {0} ActiveTeam: {1} -------------", (object) obj1.땃(), (object) obj0.딝())));
      List<딶.땊> 땊List = new List<딶.땊>();
      for (int index = 0; index < obj1.땺().Count; ++index)
      {
        땓.땊 땊1 = obj1.땺()[index];
        if (땊1.땄 == obj1.땃() && !땊1.땺())
        {
          땮.딟(obj0, obj1, obj2, 딟, index, 땊1, 딢.떍.땢);
          땮.땄(obj0, obj1, obj2, 딟, index, 땊1, 딢.떍.땼);
          if (땊1.딢(딢.떍.딢) > 0)
          {
            if (땊1.땄 == obj0.딝())
              딟.딟((딶.땏) new 딶.딜(new 딶.땩(땊1.땃, 땊1.딶)));
            딟.딟((딶.땏) new 땓.땃(obj0, obj1, obj2, index, 딢.떍.땥, 땓.딢.딟, 땊1.땃));
            딟.딟((딶.땏) new 땓.땃(obj0, obj1, obj2, index, 딢.떍.딝, 땓.딢.딟, 땊1.딶));
            딟.딟((딶.땏) new 땓.딝(obj0, obj1, obj2, index, 딶.땩.딟, 땊1.딟));
            if (땊1.땄 == obj0.딝())
            {
              딶.땊 땊2 = new 딶.땊(new 딶.땩(땊1.땃, 땊1.딶), ((Component) 땓.땧.딟(딢.떍.딢)).gameObject, 3f, -1f);
              딟.딟((딶.땏) 땊2);
              땊List.Add(땊2);
            }
          }
        }
      }
      for (int index1 = 0; index1 < obj1.땺().Count; ++index1)
      {
        땓.땊 땊3 = obj1.땺()[index1];
        if (땊3.땄 == obj1.땃() && !땊3.땺() && obj0.땻()[index1].땄(딢.딴.딶))
        {
          List<int> intList = new List<int>();
          for (int index2 = 0; index2 < obj1.땺().Count; ++index2)
          {
            땓.땊 땊4 = obj1.땺()[index2];
            if (땊3.땄 == 땊4.땄 && !땊4.땺())
            {
              int radius = obj0.땞().땄().Radius;
              if (땊3.땄(obj1.땺()[index2]) <= radius)
              {
                if (obj0.땞().땄().DoWeaponCheck)
                {
                  WeaponGameplayData weaponGameplayData = obj0.땞().딟(obj0.땻()[index2].딧());
                  if (Object.op_Equality((Object) weaponGameplayData, (Object) null) || !weaponGameplayData.AllowsReturnFire)
                    continue;
                }
                if (obj0.딟(obj1, index2, 땊4.땃, 땊4.딶, obj0.딝(), false))
                  intList.Add(index2);
                딟.딟((딶.땏) new 땓.땃(obj0, obj1, obj2, index2, 딢.떍.땢, 땓.딢.딧, -1));
              }
            }
          }
          if (intList.Count > 0)
            딟.딟((딶.땏) new 딶.땾(땊3.땃, 땊3.딶, 딢.딴.딶, intList));
        }
      }
      for (int index = 0; index < 땊List.Count; ++index)
        딟.딟((딶.땏) new 딶.딺(땊List[index]));
      딟.딟((딶.땏) new 딶.떑(string.Format("--------- END POST TURN for Team: {0} ActiveTeam: {1} -------------", (object) obj1.땃(), (object) obj0.딝())));
      return 딟;
    }
  }
}
