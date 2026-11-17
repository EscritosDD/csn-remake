// Decompiled with JetBrains decompiler
// Type: 땺.딤
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땺
{
  public static class 딤
  {
    private const double 딟 = 1.5707963267949;
    private const double 땄 = 2.35619449019234;

    public static void 딟([In] 땣 obj0)
    {
      obj0.딢();
      딤.땄(obj0);
      if (((떊) obj0).땄() == 떒.딧)
        딤.딢(obj0);
      else
        딤.딧(obj0);
      obj0.땺();
    }

    private static void 땄([In] 땣 obj0)
    {
      List<땮> 딟 = ((떊) obj0).딟;
      for (int index = 1; index < 딟.Count; ++index)
      {
        땮 땮 = 딟[index];
        땰 땰 = 딤.딟(obj0, 땮);
        if (땮.딢())
        {
          foreach (딭 딭 in 땮.딟())
            딤.딟(obj0, 딭, 땰);
        }
        obj0.딟((string) null);
      }
    }

    private static void 딧([In] 땣 obj0)
    {
      땰 딟1 = obj0.딟.딟.딟;
      땰 딟2 = 딟1.딟;
      땮 딟3 = 딟1.딟;
      딤.딟(obj0, 딟1, 딟2);
      땰 땄1 = obj0.딟.딧.땄;
      if (땄1.딟.딢(땄1.딟.딟) && 땄1.딟.딢(땄1.땄.딟))
      {
        딽 딽 = 땄1.딟.땓(땄1.딟);
        딤.딟(땄1.딟, 땄1.딟, 딽, 딽.딟(땄1.딟, 땄1.딟));
        obj0.딢(땄1.딟);
        obj0.딢(딽);
      }
      땰 딟4 = obj0.딟.딟.딟;
      if (딟4.딟.딢(딟4.땄.딟) && 딟4.딟.딢(딟4.딟.딟))
      {
        딽 딽 = 딟4.딟.땓(딟4.딟);
        딤.딟(딟4.딟, 딟4.딟, 딽, 딽.딟(딟4.딟, 딟4.딟));
        obj0.딢(딟4.딟);
        obj0.딢(딽);
      }
      땮 딟5 = obj0.딟.딟.딟;
      땰 땄2 = obj0.딟.딧.땄;
      딽 딽1 = 땄2.딟;
      땮 땮1 = 땄2.딟;
      땄2.딟 = (딽) null;
      while (true)
      {
        obj0.딟(딽1);
        땮1 = 딽1.땺(땮1);
        if (땮1 != 딟5)
        {
          딽 딽2 = 딽1.딶(땮1);
          딽1.딧();
          딽1 = 딽2;
        }
        else
          break;
      }
      땮 딟6 = obj0.딟.딟.딟.딟;
      땮 땮2 = 딽1.땥(obj0.딟.딟.딟);
      딽 딽3 = 딽1.땃(obj0.딟.딟.딟);
      딽1.딧();
      딽 딽4 = 딽3;
      while (땮2 != 딟6)
      {
        obj0.딟(딽4);
        땮2 = 딽4.땺(땮2);
        딽 딽5 = 딽4.딶(땮2);
        딽4.딧();
        딽4 = 딽5;
      }
      obj0.딟.딟 = obj0.딟.딟.딟;
      obj0.딟.딟.땄 = (땰) null;
      obj0.딟.딧 = obj0.딟.딧.땄;
      obj0.딟.딧.딟 = (땰) null;
      obj0.땃();
    }

    private static void 딟([In] 땣 obj0, [In] 땰 obj1, [In] 땰 obj2)
    {
      땰 땰 = obj1;
      while (obj2 != obj0.딟.딧)
      {
        if (땥.딟.딟(obj1.딟, obj2.딟, obj2.딟.딟) == 딼.땄)
        {
          딤.땃(obj0, obj2);
          obj2 = obj2.딟;
        }
        else if (obj1 != 땰 && 땥.딟.딟(obj1.땄.딟, obj1.딟, obj2.딟) == 딼.땄)
        {
          딤.땃(obj0, obj1);
          obj1 = obj1.땄;
        }
        else
        {
          obj1 = obj2;
          obj2 = obj2.딟;
        }
      }
    }

    private static void 딢([In] 땣 obj0)
    {
      딽 딽 = obj0.딟.딟.딟.딟;
      땮 딟 = obj0.딟.딟.딟.딟;
      while (!딽.떎(딟))
        딽 = 딽.딶(딟);
      obj0.땄(딽);
    }

    private static 땰 딟([In] 땣 obj0, [In] 땮 obj1)
    {
      땰 땰1 = obj0.딧(obj1);
      땰 땰2 = 딤.딟(obj0, obj1, 땰1);
      if (obj1.딟 <= 땰1.딟.딟 + 땥.딟.딟)
        딤.땃(obj0, 땰1);
      obj0.딟(땰2);
      딤.딟(obj0, 땰2);
      return 땰2;
    }

    private static 땰 딟([In] 땣 obj0, [In] 땮 obj1, [In] 땰 obj2)
    {
      딽 딽 = new 딽(obj1, obj2.딟, obj2.딟.딟);
      딽.딟(obj2.딟);
      ((떊) obj0).딟.Add(딽);
      땰 땰 = new 땰(obj1);
      땰.딟 = obj2.딟;
      땰.땄 = obj2;
      obj2.딟.땄 = 땰;
      obj2.딟 = 땰;
      obj0.딟(땰);
      if (!딤.딟(obj0, 딽))
        obj0.딢(딽);
      return 땰;
    }

    private static void 딟([In] 땣 obj0, [In] 딭 obj1, [In] 땰 obj2)
    {
      try
      {
        obj0.딟.딟 = obj1;
        obj0.딟.딟 = obj1.딟.딟 > obj1.땄.딟;
        if (딤.딟(obj2.딟, obj1.딟, obj1.땄))
          return;
        딤.땄(obj0, obj1, obj2);
        딤.딟(obj0, obj1.딟, obj1.땄, obj2.딟, obj1.땄);
      }
      catch (땆 ex)
      {
      }
    }

    private static void 땄([In] 땣 obj0, [In] 딭 obj1, [In] 땰 obj2)
    {
      if (obj0.딟.딟)
        딤.딶(obj0, obj1, obj2);
      else
        딤.딝(obj0, obj1, obj2);
    }

    private static void 딧([In] 땣 obj0, [In] 딭 obj1, [In] 땰 obj2)
    {
      딤.땃(obj0, obj2.딟);
      if (obj2.딟.딟 == obj1.딟 || 땥.딟.딟(obj1.땄, obj2.딟.딟, obj1.딟) != 딼.땄 || 땥.딟.딟(obj2.딟, obj2.딟.딟, obj2.딟.딟.딟) != 딼.땄)
        return;
      딤.딧(obj0, obj1, obj2);
    }

    private static void 딢([In] 땣 obj0, [In] 딭 obj1, [In] 땰 obj2)
    {
      if (땥.딟.딟(obj2.딟.딟, obj2.딟.딟.딟, obj2.딟.딟.딟.딟) == 딼.땄)
      {
        딤.딧(obj0, obj1, obj2.딟);
      }
      else
      {
        if (땥.딟.딟(obj1.땄, obj2.딟.딟.딟, obj1.딟) != 딼.땄)
          return;
        딤.딢(obj0, obj1, obj2.딟);
      }
    }

    private static void 땃([In] 땣 obj0, [In] 딭 obj1, [In] 땰 obj2)
    {
      if (obj2.딟.딟 >= obj1.딟.딟)
        return;
      if (땥.딟.딟(obj2.딟, obj2.딟.딟, obj2.딟.딟.딟) == 딼.땄)
      {
        딤.딧(obj0, obj1, obj2);
      }
      else
      {
        딤.딢(obj0, obj1, obj2);
        딤.땃(obj0, obj1, obj2);
      }
    }

    private static void 딶([In] 땣 obj0, [In] 딭 obj1, [In] 땰 obj2)
    {
      while (obj2.딟.딟.딟 < obj1.딟.딟)
      {
        if (땥.딟.딟(obj1.땄, obj2.딟.딟, obj1.딟) == 딼.땄)
          딤.땃(obj0, obj1, obj2);
        else
          obj2 = obj2.딟;
      }
    }

    private static void 땓([In] 땣 obj0, [In] 딭 obj1, [In] 땰 obj2)
    {
      if (땥.딟.딟(obj2.땄.딟, obj2.땄.땄.딟, obj2.땄.땄.땄.딟) == 딼.딟)
      {
        딤.땺(obj0, obj1, obj2.땄);
      }
      else
      {
        if (땥.딟.딟(obj1.땄, obj2.땄.땄.딟, obj1.딟) != 딼.딟)
          return;
        딤.땓(obj0, obj1, obj2.땄);
      }
    }

    private static void 땺([In] 땣 obj0, [In] 딭 obj1, [In] 땰 obj2)
    {
      딤.땃(obj0, obj2.땄);
      if (obj2.땄.딟 == obj1.딟 || 땥.딟.딟(obj1.땄, obj2.땄.딟, obj1.딟) != 딼.딟 || 땥.딟.딟(obj2.딟, obj2.땄.딟, obj2.땄.땄.딟) != 딼.딟)
        return;
      딤.땺(obj0, obj1, obj2);
    }

    private static void 땥([In] 땣 obj0, [In] 딭 obj1, [In] 땰 obj2)
    {
      if (obj2.딟.딟 <= obj1.딟.딟)
        return;
      if (땥.딟.딟(obj2.딟, obj2.땄.딟, obj2.땄.땄.딟) == 딼.딟)
      {
        딤.땺(obj0, obj1, obj2);
      }
      else
      {
        딤.땓(obj0, obj1, obj2);
        딤.땥(obj0, obj1, obj2);
      }
    }

    private static void 딝([In] 땣 obj0, [In] 딭 obj1, [In] 땰 obj2)
    {
      while (obj2.땄.딟.딟 > obj1.딟.딟)
      {
        if (땥.딟.딟(obj1.땄, obj2.땄.딟, obj1.딟) == 딼.딟)
          딤.땥(obj0, obj1, obj2);
        else
          obj2 = obj2.땄;
      }
    }

    private static bool 딟([In] 딽 obj0, [In] 땮 obj1, [In] 땮 obj2)
    {
      int num = obj0.딢(obj1, obj2);
      if (num == -1)
        return false;
      obj0.딟(num);
      obj0 = obj0.딟.딟(num);
      obj0?.딧(obj1, obj2);
      return true;
    }

    private static void 딟([In] 땣 obj0, [In] 땮 obj1, [In] 땮 obj2, [In] 딽 obj3, [In] 땮 obj4)
    {
      if (딤.딟(obj3, obj1, obj2))
        return;
      땮 땮1 = obj3.땺(obj4);
      딼 딼1 = 땥.딟.딟(obj2, 땮1, obj1);
      if (딼1 == 딼.딧)
      {
        if (!obj3.딟(obj2, 땮1))
          throw new 땆("EdgeEvent - Point on constrained edge not supported yet");
        obj3.딧(obj2, 땮1);
        obj0.딟.딟.땄 = 땮1;
        obj3 = obj3.땓(obj4);
        딤.딟(obj0, obj1, 땮1, obj3, 땮1);
        if (!obj0.땓())
          ;
      }
      else
      {
        땮 땮2 = obj3.땥(obj4);
        딼 딼2 = 땥.딟.딟(obj2, 땮2, obj1);
        if (딼2 == 딼.딧)
        {
          if (!obj3.딟(obj2, 땮2))
            throw new 땆("EdgeEvent - Point on constrained edge not supported yet");
          obj3.딧(obj2, 땮2);
          obj0.딟.딟.땄 = 땮2;
          obj3 = obj3.땓(obj4);
          딤.딟(obj0, obj1, 땮2, obj3, 땮2);
          if (!obj0.땓())
            ;
        }
        else if (딼1 == 딼2)
        {
          obj3 = 딼1 != 딼.딟 ? obj3.땃(obj4) : obj3.딶(obj4);
          딤.딟(obj0, obj1, obj2, obj3, obj4);
        }
        else
          딤.땄(obj0, obj1, obj2, obj3, obj4);
      }
    }

    private static void 땄([In] 땣 obj0, [In] 땮 obj1, [In] 땮 obj2, [In] 딽 obj3, [In] 땮 obj4)
    {
      딽 딽 = obj3.땓(obj4);
      땮 땮1 = 딽.딟(obj3, obj4);
      if (딽 == null)
        throw new InvalidOperationException("[BUG:FIXME] FLIP failed due to missing triangle");
      if (땥.딟.땄(obj4, obj3.땺(obj4), obj3.땥(obj4), 땮1))
      {
        딤.딟(obj3, obj4, 딽, 땮1);
        obj0.딢(obj3);
        obj0.딢(딽);
        if (obj4 == obj2 && 땮1 == obj1)
        {
          if (obj2 == obj0.딟.딟.땄 && obj1 == obj0.딟.딟.딟)
          {
            if (obj0.땓())
              Console.WriteLine("[FLIP] - constrained edge done");
            obj3.딧(obj1, obj2);
            딽.딧(obj1, obj2);
            딤.딟(obj0, obj3);
            딤.딟(obj0, 딽);
          }
          else
          {
            if (!obj0.땓())
              return;
            Console.WriteLine("[FLIP] - subedge done");
          }
        }
        else
        {
          if (obj0.땓())
            Console.WriteLine("[FLIP] - flipping and continuing with triangle still crossing edge");
          딼 딼 = 땥.딟.딟(obj2, 땮1, obj1);
          obj3 = 딤.딟(obj0, 딼, obj3, 딽, obj4, 땮1);
          딤.땄(obj0, obj1, obj2, obj3, obj4);
        }
      }
      else
      {
        땮 땮2 = 딤.딟(obj1, obj2, 딽, 땮1);
        딤.딟(obj0, obj1, obj2, obj3, 딽, 땮2);
        딤.딟(obj0, obj1, obj2, obj3, obj4);
      }
    }

    private static 땮 딟([In] 땮 obj0, [In] 땮 obj1, [In] 딽 obj2, [In] 땮 obj3)
    {
      switch (땥.딟.딟(obj1, obj3, obj0))
      {
        case 딼.딟:
          return obj2.땺(obj3);
        case 딼.땄:
          return obj2.땥(obj3);
        default:
          throw new 땆("Point on constrained edge not supported yet");
      }
    }

    private static 딽 딟([In] 땣 obj0, [In] 딼 obj1, [In] 딽 obj2, [In] 딽 obj3, [In] 땮 obj4, [In] 땮 obj5)
    {
      if (obj1 == 딼.땄)
      {
        int num = obj3.딢(obj4, obj5);
        obj3.땄.딟(num, true);
        딤.딟(obj0, obj3);
        obj3.땄.땄();
        return obj2;
      }
      int num1 = obj2.딢(obj4, obj5);
      obj2.땄.딟(num1, true);
      딤.딟(obj0, obj2);
      obj2.땄.땄();
      return obj3;
    }

    private static void 딟([In] 땣 obj0, [In] 땮 obj1, [In] 땮 obj2, [In] 딽 obj3, [In] 딽 obj4, [In] 땮 obj5)
    {
      딽 딽 = obj4.땓(obj5);
      땮 땮1 = 딽.딟(obj4, obj5);
      if (딽 == null)
        throw new Exception("[BUG:FIXME] FLIP failed due to missing triangle");
      if (땥.딟.땄(obj2, obj3.땺(obj2), obj3.땥(obj2), 땮1))
      {
        딤.땄(obj0, obj2, 땮1, 딽, 땮1);
      }
      else
      {
        땮 땮2 = 딤.딟(obj1, obj2, 딽, 땮1);
        딤.딟(obj0, obj1, obj2, obj3, 딽, 땮2);
      }
    }

    private static void 딟([In] 땣 obj0, [In] 땰 obj1)
    {
      for (땰 딟 = obj1.딟; 딟.딟(); 딟 = 딟.딟)
      {
        double num = 딤.딟(딟);
        if (num <= Math.PI / 2.0 && num >= -1.0 * Math.PI / 2.0)
          딤.땃(obj0, 딟);
        else
          break;
      }
      for (땰 땄 = obj1.땄; 땄.땄(); 땄 = 땄.땄)
      {
        double num = 딤.딟(땄);
        if (num <= Math.PI / 2.0 && num >= -1.0 * Math.PI / 2.0)
          딤.땃(obj0, 땄);
        else
          break;
      }
      if (!obj1.딟() || !obj1.딟.딟() || 딤.땄(obj1) >= 3.0 * Math.PI / 4.0)
        return;
      딤.땄(obj0, obj1);
    }

    private static void 땄([In] 땣 obj0, [In] 땰 obj1)
    {
      obj0.딟.땄 = 땥.딟.딟(obj1.딟, obj1.딟.딟, obj1.딟.딟.딟) != 딼.땄 ? obj1.딟 : obj1;
      obj0.딟.딟 = obj0.딟.땄;
      while (obj0.딟.딟.딟() && obj0.딟.딟.딟.땄 >= obj0.딟.딟.딟.딟.땄)
        obj0.딟.딟 = obj0.딟.딟.딟;
      if (obj0.딟.딟 == obj0.딟.땄)
        return;
      obj0.딟.딧 = obj0.딟.딟;
      while (obj0.딟.딧.딟() && obj0.딟.딧.딟.땄 < obj0.딟.딧.딟.딟.땄)
        obj0.딟.딧 = obj0.딟.딧.딟;
      if (obj0.딟.딧 == obj0.딟.딟)
        return;
      obj0.딟.딟 = obj0.딟.딧.딟.딟 - obj0.딟.땄.딟.딟;
      obj0.딟.딟 = obj0.딟.땄.딟.땄 > obj0.딟.딧.딟.땄;
      딤.딧(obj0, obj0.딟.딟);
    }

    private static void 딧([In] 땣 obj0, [In] 땰 obj1)
    {
      if (딤.딢(obj0, obj1))
        return;
      딤.땃(obj0, obj1);
      if (obj1.땄 == obj0.딟.땄 && obj1.딟 == obj0.딟.딧)
        return;
      if (obj1.땄 == obj0.딟.땄)
      {
        if (땥.딟.딟(obj1.딟, obj1.딟.딟, obj1.딟.딟.딟) == 딼.딟)
          return;
        obj1 = obj1.딟;
      }
      else if (obj1.딟 == obj0.딟.딧)
      {
        if (땥.딟.딟(obj1.딟, obj1.땄.딟, obj1.땄.땄.딟) == 딼.땄)
          return;
        obj1 = obj1.땄;
      }
      else
        obj1 = obj1.땄.딟.땄 >= obj1.딟.딟.땄 ? obj1.딟 : obj1.땄;
      딤.딧(obj0, obj1);
    }

    private static bool 딢([In] 땣 obj0, [In] 땰 obj1)
    {
      double num = !obj0.딟.딟 ? obj0.딟.딧.딟.땄 - obj1.딟.땄 : obj0.딟.땄.딟.땄 - obj1.딟.땄;
      return obj0.딟.딟 > num;
    }

    private static double 딟([In] 땰 obj0)
    {
      double 딟 = obj0.딟.딟;
      double 땄 = obj0.딟.땄;
      double num1 = obj0.딟.딟.딟 - 딟;
      double num2 = obj0.딟.딟.땄 - 땄;
      double num3 = obj0.땄.딟.딟 - 딟;
      double num4 = obj0.땄.딟.땄 - 땄;
      return Math.Atan2(num1 * num4 - num2 * num3, num1 * num3 + num2 * num4);
    }

    private static double 땄([In] 땰 obj0)
    {
      double x = obj0.딟.딟 - obj0.딟.딟.딟.딟;
      return Math.Atan2(obj0.딟.땄 - obj0.딟.딟.딟.땄, x);
    }

    private static void 땃([In] 땣 obj0, [In] 땰 obj1)
    {
      딽 딽 = new 딽(obj1.땄.딟, obj1.딟, obj1.딟.딟);
      딽.딟(obj1.땄.딟);
      딽.딟(obj1.딟);
      ((떊) obj0).딟.Add(딽);
      obj1.땄.딟 = obj1.딟;
      obj1.딟.땄 = obj1.땄;
      obj0.땄(obj1);
      if (딤.딟(obj0, 딽))
        return;
      obj0.딢(딽);
    }

    private static bool 딟([In] 땣 obj0, [In] 딽 obj1)
    {
      for (int index = 0; index < 3; ++index)
      {
        if (!obj1.땄.딟(index))
        {
          딽 딽 = obj1.딟.딟(index);
          if (딽 != null)
          {
            땮 땮1 = obj1.딟.딟(index);
            땮 땮2 = 딽.딟(obj1, 땮1);
            int num = 딽.딟(땮2);
            if (딽.딟.딟(num) || 딽.땄.딟(num))
              obj1.딟.딟(index, 딽.딟.딟(num));
            else if (땥.딟.딟(땮1, obj1.땺(땮1), obj1.땥(땮1), 땮2))
            {
              obj1.땄.딟(index, true);
              딽.땄.딟(num, true);
              딤.딟(obj1, 땮1, 딽, 땮2);
              if (!딤.딟(obj0, obj1))
                obj0.딢(obj1);
              if (!딤.딟(obj0, 딽))
                obj0.딢(딽);
              obj1.땄.딟(index, false);
              딽.땄.딟(num, false);
              return true;
            }
          }
        }
      }
      return false;
    }

    private static void 딟([In] 딽 obj0, [In] 땮 obj1, [In] 딽 obj2, [In] 땮 obj3)
    {
      딽 딽1 = obj0.딶(obj1);
      딽 딽2 = obj0.땃(obj1);
      딽 딽3 = obj2.딶(obj3);
      딽 딽4 = obj2.땃(obj3);
      bool flag1 = obj0.딝(obj1);
      bool flag2 = obj0.떎(obj1);
      bool flag3 = obj2.딝(obj3);
      bool flag4 = obj2.떎(obj3);
      bool flag5 = obj0.땭(obj1);
      bool flag6 = obj0.딦(obj1);
      bool flag7 = obj2.땭(obj3);
      bool flag8 = obj2.딦(obj3);
      obj0.땄(obj1, obj3);
      obj2.땄(obj3, obj1);
      obj2.딢(obj1, flag5);
      obj0.땃(obj1, flag6);
      obj0.딢(obj3, flag7);
      obj2.땃(obj3, flag8);
      obj2.딟(obj1, flag1);
      obj0.땄(obj1, flag2);
      obj0.딟(obj3, flag3);
      obj2.땄(obj3, flag4);
      obj0.딟.땄();
      obj2.딟.땄();
      if (딽1 != null)
        obj2.딟(딽1);
      if (딽2 != null)
        obj0.딟(딽2);
      if (딽3 != null)
        obj0.딟(딽3);
      if (딽4 != null)
        obj2.딟(딽4);
      obj0.딟(obj2);
    }
  }
}
