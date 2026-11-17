// Decompiled with JetBrains decompiler
// Type: 딶.딢
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 딢 : 땃.땧
  {
    private int 딟;
    private int 땄;
    private 딢.딴 딟;

    public 딢([In] 떏 obj0)
    {
      this.딟 = obj0.딟;
      this.딟 = obj0.딟;
      this.땄 = obj0.땄;
    }

    public 딢([In] TacticsActionData obj0)
    {
      this.딟 = obj0.Index;
      this.딟 = obj0.Ability;
      this.땄 = obj0.TargetIndex;
    }

    public static int 딟([In] 땖 obj0, [In] 땙 obj1, [In] int obj2, [In] 딢.딴 obj3, [In] bool obj4)
    {
      for (int index = 0; index < obj0.땻().Count; ++index)
      {
        if (obj0.땻()[index] is 땚 땚1 && 땚1.딢() == obj3 && 땚1.딧() == obj2)
        {
          if (obj4)
          {
            int num1 = 땚1.땄();
            int num2 = obj1.땺()[index].딢(딢.떍.땄);
            if (num1 > 0 && num2 >= num1)
              continue;
          }
          return index;
        }
      }
      return -1;
    }

    public static int 딟([In] 땖 obj0, [In] 땙 obj1, [In] int obj2, [In] 딢.딴 obj3) => 딶.딢.딟(obj0, obj1, obj2, obj3, true);

    public override 땓.딟 딟([In] 땖 obj0, [In] 땙 obj1, [In] 땓.떒 obj2)
    {
      땓.딟 딟 = new 땓.딟();
      딟.딟(딶.딢.딟(obj0, obj1, obj2, this.딟, this.땄, this.딟));
      return 딟;
    }

    public static 땓.딟 딟([In] 땖 obj0, [In] 땙 obj1, [In] 땓.떒 obj2, [In] int obj3, [In] int obj4, [In] 딢.딴 obj5)
    {
      int index = 딶.딢.딟(obj0, obj1, obj3, obj5);
      if (index == -1)
        return (땓.딟) null;
      땓.땊 땊1 = obj1.땺()[obj3];
      땚 땚1 = obj0.땻()[index] as 땚;
      if (땊1.딢 < 땚1.땃())
        return (땓.딟) null;
      if (!땚1.딟(obj1, obj4))
        return (땓.딟) null;
      땓.딟 딟1 = new 땓.딟();
      땓.땊 땊2 = obj1.땺()[obj4];
      if (obj0.땉() != null)
      {
        bool canFitWithoutMoving;
        Vector3 focusOnTargets = obj0.땉().딟.CalculateFocusOnTargets(new List<int>((IEnumerable<int>) new int[2]
        {
          obj3,
          obj4
        }), true, out int _, out 딢.땘 _, out canFitWithoutMoving);
        if (!canFitWithoutMoving)
          딟1.딟((땏) new 딜(focusOnTargets, 0.5f));
      }
      딢.딯 딟2 = 땊1.딟;
      딢.딯 딯 = 땃.땸.딟(obj0.땹().get_Tiles()[땊1.땃, 땊1.딶], obj0.땹().get_Tiles()[땊2.땃, 땊2.딶], 땊1.딟);
      if (딟2 != 딯)
      {
        딟1.딟((땏) new 땓.딝(obj0, obj1, obj2, obj3, new 땩(땊1.땃, 땊1.딶), 딯));
        딟1.딟((땏) new 딬(obj3, 딟2, 딯));
      }
      AudioShader2 audioShader2 = 땓.땎.땥(obj5);
      if (Object.op_Inequality((Object) audioShader2, (Object) null))
        딟1.딟((땏) new 땫(obj3, audioShader2));
      if (obj0.땻()[obj3] is 땓.떀 && obj3 != obj4 && 땊1.땄 == 땊2.땄)
        딟1.딟((땏) new 땫(obj4, 땓.딘.땴));
      딟1.딟((땏) new 땣(obj3, "Interact", (WrapMode) 1, 땮.떎));
      땚1.딟(obj1, obj4, 딟1, obj2);
      딟1.딟((땏) new 땓.땃(obj0, obj1, obj2, index, 딢.떍.땄, 땓.딢.딧, -1));
      딟1.딟((땏) new 땓.땭(obj0, obj1, obj2, obj3, index));
      땚 땚2 = obj0.땻()[index] as 땚;
      obj2.땄(obj1, obj3, index, 땊1.땃, 땊1.딶);
      obj2.딟(obj1, 땚2.딧(), 땚2.땓());
      땙 땙 = obj1;
      땙.땄(땙.딢() + obj0.땞().RatingModifiersData.PerAbilityUse);
      return 딟1;
    }

    public override TacticsActionData 딟() => new TacticsActionData()
    {
      Action = 딢.땀.땓,
      Index = this.딟,
      Ability = this.딟,
      TargetIndex = this.땄
    };

    public override int 땄() => this.딟;
  }
}
