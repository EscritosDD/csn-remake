// Decompiled with JetBrains decompiler
// Type: 땃.딜
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땃
{
  public class 딜 : 땖
  {
    public override 딡 딟([In] 딵 obj0)
    {
      딡 딡1 = (딡) null;
      땞 땞 = obj0.땷();
      int num1 = -1;
      int num2 = -1;
      for (int index = 0; index < obj0.땔().Count; ++index)
      {
        딡 딡2 = obj0.땔()[index];
        if (this.딟(obj0, 딡2) && obj0.딣().땼().떂().땺()[딡2.딟.땔()].딢 >= 딡2.땄)
        {
          딻 딻 = this.딟(obj0, 딡1, 딡2, obj0.딣().땼().떂(), 땞, num2, num1);
          if (딻.땄 != -1 && 딻.딟 == 딡2)
          {
            num1 = 딻.땄;
            딡1 = 딻.딟;
            num2 = 딻.딟;
            딻.딟.딟[4] = false;
          }
        }
      }
      if (딡1 != null)
        딡1.딟(땜.땃, new 땯() { 딟 = num1, 딟 = 딢.딴.딟 });
      return 딡1;
    }

    public override bool 딟([In] 딵 obj0, [In] 딡 obj1) => base.딟(obj0, obj1) && obj0.딣().땼().떔() is 딶.딮;

    private 딻 딟([In] 딵 obj0, [In] 딡 obj1, [In] 딡 obj2, [In] 딶.땙 obj3, [In] 땞 obj4, [In] int obj5, [In] int obj6)
    {
      if (obj0.땓(obj2))
        return new 딻(obj5, obj6, obj1);
      땓.땊 땊1 = obj3.땺()[obj2.딟.땔()];
      bool flag = false;
      if (obj2.딟 != null)
      {
        if (obj2.딟.딟(obj0, obj3, 땊1))
          flag = true;
        else
          obj2.딟 = (딽) null;
      }
      int num1 = -1;
      int maxValue = int.MaxValue;
      if (!flag)
        num1 = obj0.딟(obj2.딟.땔(), out maxValue);
      if (maxValue > 0)
      {
        int num2 = this.딟(obj0, obj2, 땊1, num1, ref maxValue);
        if (num2 != -1)
          num1 = num2;
      }
      else
      {
        obj2.땄 = (딖) null;
        obj2.딟 = (딖) null;
      }
      딻 딻 = new 딻(maxValue, num1, obj2);
      if (obj1 == null || obj4 == 땞.땄 && obj5 > 0 && 딻.딟 == 0)
        return 딻;
      땓.땊 땊2 = obj3.땺()[obj1.딟.땔()];
      if (obj2.딟 == 땪.딧)
      {
        if (obj1.딟 != 땪.딧 || 땊1.딧 > 땊2.딧)
          return 딻;
      }
      else if (obj1.딟 == 땪.딟 && obj2.딟 != 땪.땄 || obj1.딟 == 땪.땄 && obj2.딟 != 땪.땄 || 땊1.딧 > 땊2.딧)
        return 딻;
      딻.딟 = obj1;
      딻.딟 = obj5;
      딻.땄 = obj6;
      return 딻;
    }

    private int 딟([In] 딵 obj0, [In] 딡 obj1, [In] 땓.땊 obj2, [In] int obj3, [In] ref int obj4)
    {
      int num1 = -1;
      obj0.딢(obj1);
      if (obj1.땄 != null && obj1.땄.딟 != null)
      {
        List<GameTileComponent> 딟 = obj1.땄.딟;
        int num2 = obj2.딢 / obj1.땄;
        int num3 = num2 >= 딟.Count ? 딟.Count - 1 : num2;
        int index1 = -1;
        for (int index2 = num3; index2 >= 0; --index2)
        {
          bool flag = false;
          GameTileComponent gameTileComponent = 딟[index2];
          if (!obj0.딟(obj0.딣().땼().떂(), gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, obj2, true))
          {
            short num4 = obj0.땘()[gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, 딮.딟];
            if (obj0.땷() == 땞.딟)
              flag = obj0.딸() || (obj1.딟 != 땪.딧 ? (double) num4 < (double) obj2.딧 * 0.5 : (double) num4 < (double) obj2.딧);
            else if (obj0.땷() == 땞.땄)
              flag = true;
            if (flag)
            {
              index1 = index2;
              break;
            }
          }
        }
        if (index1 != -1)
        {
          GameTileComponent gameTileComponent = 딟[index1];
          if (gameTileComponent.TileIndexX != obj2.땃 || gameTileComponent.TileIndexY != obj2.딶)
          {
            obj1.딟(gameTileComponent, ref num1);
            obj4 = obj0.떔()[gameTileComponent.TileIndexX, gameTileComponent.TileIndexY];
          }
        }
      }
      return num1;
    }
  }
}
