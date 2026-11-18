// Decompiled with JetBrains decompiler
// Type: 땓.땊
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  public class 땊
  {
    private const int 딟 = 81;
    public int 땄;
    public int 딧;
    public int 딢;
    public int 땃;
    public int 딶;
    public 딢.딯 딟;
    private sbyte[] 딟;

    private 땊([In] 땊 obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0.땥());
      this.딧 = obj0.딧;
      this.땃 = obj0.땃;
      this.딶 = obj0.딶;
      this.땄 = obj0.땄;
      this.딢 = obj0.딢;
      this.딟 = obj0.딟;
      this.딟 = (sbyte[]) obj0.딟.Clone();
    }

    public 땊([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4, [In] int obj5, [In] 딢.딯 obj6)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0);
      this.딧 = obj1;
      this.땃 = obj2;
      this.딶 = obj3;
      this.땄 = obj4;
      this.딢 = obj5;
      this.딟 = obj6;
      this.딟();
    }

    public 땊([In] int obj0, [In] UnitTurnDataJson obj1)
    {
      this.딟();
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0);
      this.땃 = obj1.TileX;
      this.딶 = obj1.TileY;
      this.딢 = obj1.ActionPoints;
      this.딧 = obj1.Health;
      this.땄 = obj1.TeamIndex;
      this.딟 = obj1.Direction;
      foreach (UnitBuff buff in obj1.Buffs)
        this.딟[(int) buff.Type] = (sbyte) buff.Turns;
    }

    private void 딟()
    {
      this.딟 = new sbyte[81];
      for (int index = 0; index < 81; ++index)
        this.딟[index] = (sbyte) -1;
      this.딟[16] = (sbyte) 1;
      this.딟[13] = (sbyte) 1;
    }

    public bool 딟([In] 땊 obj0)
    {
      if (this.땥() != obj0.땥())
      {
        Debug.LogError((object) "Index != Other.Index");
        return false;
      }
      if (this.딧 != obj0.딧)
      {
        Debug.LogError((object) string.Format("Health:{0} != Other.Health:{1}", (object) this.딧, (object) obj0.딧));
        return false;
      }
      if (this.땃 != obj0.땃)
      {
        Debug.LogError((object) "TileX != Other.TileX");
        return false;
      }
      if (this.딶 != obj0.딶)
      {
        Debug.LogError((object) "TileY != Other.TileY");
        return false;
      }
      if (this.땄 != obj0.땄)
      {
        Debug.LogError((object) "TeamIndex != Other.TeamIndex");
        return false;
      }
      if (this.딢 != obj0.딢)
      {
        Debug.LogError((object) "ActionPoints != Other.ActionPoints");
        return false;
      }
      for (int index = 0; index < this.딟.Length; ++index)
      {
        if ((int) this.딟[index] != (int) obj0.딟[index])
        {
          Debug.LogError((object) ("Buff " + (object) (딢.떍) index + " doesn't match"));
          return false;
        }
      }
      return true;
    }

    public UnitTurnDataJson 땄() => new UnitTurnDataJson()
    {
      Health = this.딧,
      ActionPoints = this.딢,
      TileX = this.땃,
      TileY = this.딶,
      TeamIndex = this.땄,
      Direction = this.딟,
      Buffs = ((IEnumerable<sbyte>) this.딟).Select<sbyte, UnitBuff>((Func<sbyte, int, UnitBuff>) ((obj0, obj1) => new UnitBuff((딢.떍) obj1, (int) obj0))).Where<UnitBuff>((Func<UnitBuff, bool>) (obj0 => obj0.Turns >= 0)).ToArray<UnitBuff>()
    };

    public int 땄([In] 땊 obj0) => Math.Abs(this.땃 - obj0.땃) + Math.Abs(this.딶 - obj0.딶);

    public static int 딟([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3) => Math.Abs(obj2 - obj0) + Math.Abs(obj3 - obj1);

    public int 딟([In] int obj0, [In] int obj1) => 땊.딟(this.땃, this.딶, obj0, obj1);

    public 땊 딧() => new 땊(this);

    public void 딟([In] 딢.떍 obj0, [In] int obj1)
    {
      if (obj1 >= 0 && obj1 <= (int) this.딟[(int) obj0])
        return;
      this.딟[(int) obj0] = (sbyte) obj1;
    }

    public void 딟([In] 딢.떍 obj0)
    {
      if (this.딟[(int) obj0] <= (sbyte) 1)
        this.딟[(int) obj0] = (sbyte) -1;
      else
        --this.딟[(int) obj0];
    }

    public void 땄([In] 딢.떍 obj0)
    {
      if (this.딟[(int) obj0] <= (sbyte) 0)
        this.딟[(int) obj0] = (sbyte) 1;
      else
        ++this.딟[(int) obj0];
    }

    public void 딧([In] 딢.떍 obj0) => this.딟[(int) obj0] = (sbyte) -1;

    public int 딢([In] 딢.떍 obj0) => (int) this.딟[(int) obj0];

    public bool 딢() => this.딢(딢.떍.땓) > 0;

    [SpecialName]
    public Quaternion 땃() => 땊.딟(this.딟);

    public static float 딟([In] float obj0)
    {
      if ((double) obj0 > 180.0)
        return obj0 - 360f;
      return (double) obj0 < -180.0 ? obj0 + 360f : obj0;
    }

    public static float 딟([In] 딢.딯 obj0, [In] 딢.딯 obj1)
    {
      float num = 땊.땄(obj0);
      return 땊.딟(땊.땄(obj1) - num);
    }

    public static Quaternion 딟([In] 딢.딯 obj0) => Quaternion.Euler(0.0f, 땊.땄(obj0), 0.0f);

    public static 딢.딯 땄([In] float obj0)
    {
      obj0 = 땊.딟(obj0);
      float num = Mathf.Abs(obj0);
      if ((double) num < 45.0)
        return 딢.딯.딟;
      if ((double) num > 135.0)
        return 딢.딯.땄;
      return (double) obj0 > 45.0 ? 딢.딯.딧 : 딢.딯.딢;
    }

    public static float 땄([In] 딢.딯 obj0)
    {
      switch (obj0)
      {
        case 딢.딯.땄:
          return 180f;
        case 딢.딯.딧:
          return 90f;
        case 딢.딯.딢:
          return 270f;
        default:
          return 0.0f;
      }
    }

    public static Vector2 딧([In] 딢.딯 obj0)
    {
      switch (obj0)
      {
        case 딢.딯.땄:
          return new Vector2(0.0f, -1f);
        case 딢.딯.딧:
          return new Vector2(1f, 0.0f);
        case 딢.딯.딢:
          return new Vector2(-1f, 0.0f);
        default:
          return new Vector2(0.0f, 1f);
      }
    }

    public static 딢.딯 땄([In] 딢.딯 obj0, [In] 딢.딯 obj1)
    {
      switch (obj1)
      {
        case 딢.딯.땄:
          if (obj0 != 딢.딯.딟)
            return 딢.딯.땄;
          return (double) Random.value > 0.5 ? 딢.딯.딢 : 딢.딯.딧;
        case 딢.딯.딧:
          if (obj0 != 딢.딯.딢)
            return 딢.딯.딧;
          return (double) Random.value > 0.5 ? 딢.딯.땄 : 딢.딯.딟;
        case 딢.딯.딢:
          if (obj0 != 딢.딯.딧)
            return 딢.딯.딢;
          return (double) Random.value > 0.5 ? 딢.딯.땄 : 딢.딯.딟;
        default:
          if (obj0 != 딢.딯.땄)
            return 딢.딯.딟;
          return (double) Random.value > 0.5 ? 딢.딯.딧 : 딢.딯.딢;
      }
    }

    public static 딢.딯 딟([In] 딶.땩 obj0, [In] 딶.땩 obj1) => 땊.땄(obj0.딟, obj0.땄, obj1.딟, obj1.땄);

    public static 딢.딯 땄([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3) => Mathf.Abs(obj0 - obj2) >= Mathf.Abs(obj1 - obj3) ? (obj0 > obj2 ? 딢.딯.딢 : 딢.딯.딧) : (obj1 > obj3 ? 딢.딯.땄 : 딢.딯.딟);

    public bool 딧([In] 땊 obj0)
    {
      switch (obj0.딟)
      {
        case 딢.딯.땄:
          return this.딶 <= obj0.딶;
        case 딢.딯.딧:
          return this.땃 >= obj0.땃;
        case 딢.딯.딢:
          return this.땃 <= obj0.땃;
        default:
          return this.딶 >= obj0.딶;
      }
    }

    public static bool 딟([In] 땊 obj0, [In] int obj1, [In] int obj2) => 땊.딟(obj0.딟, obj0.땃, obj0.딶, obj1, obj2);

    public static bool 딟([In] 딢.딯 obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4)
    {
      switch (obj0)
      {
        case 딢.딯.땄:
          return obj4 <= obj2;
        case 딢.딯.딧:
          return obj3 >= obj1;
        case 딢.딯.딢:
          return obj3 <= obj1;
        default:
          return obj4 >= obj2;
      }
    }

    public bool 딶()
    {
      if (this.땓())
        return true;
      return this.딢(딢.떍.땥) != -1 && this.딢(딢.떍.딝) != -1;
    }

    public 딶.땩 딟([In] bool obj0)
    {
      if (obj0 && this.딢(딢.떍.딢) > 0)
      {
        int num1 = this.딢(딢.떍.땥);
        int num2 = this.딢(딢.떍.딝);
        if (num1 != -1 && num2 != -1)
          return new 딶.땩(num1, num2);
      }
      return new 딶.땩(this.땃, this.딶);
    }

    [SpecialName]
    public bool 땓() => this.땃 != -1 && this.딶 != -1;

    [SpecialName]
    public bool 땺() => this.딧 <= 0;

    [CompilerGenerated]
    [SpecialName]
    public int 땥() => this.땓;
  }
}
