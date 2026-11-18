// Decompiled with JetBrains decompiler
// Type: 땃.땏
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 땃
{
  public class 땏 : 땶
  {
    public override bool 딟([In] 딵 obj0, [In] 딡 obj1) => !obj1.땄 && !obj1.딧 && (!obj1.땓 || obj1.딟()) && obj1.딟(obj0.딣(), false) > 0;

    public override 딡 딟([In] 딵 obj0)
    {
      딡 딡1 = (딡) null;
      int num1 = -1;
      int num2 = -1;
      int num3 = -1;
      int num4 = -1;
      for (int index = 0; index < obj0.땔().Count; ++index)
      {
        딡 딡2 = obj0.땔()[index];
        if (this.딟(obj0, 딡2))
        {
          딡 딡3 = this.딟(딡1, 딡2, obj0.딣().땼().떂());
          if (딡3 == 딡2)
          {
            if (딡3.땓)
            {
              int num5 = this.땄(obj0, 딡3);
              if (num5 != -1)
              {
                num4 = num5;
                딡1 = 딡3;
              }
            }
            else
            {
              따 따 = obj0.딟(딡3.딟.땔(), 딡3.딟[0]);
              if (따 != null && 따.딟 != -1)
              {
                num1 = 따.딟;
                num2 = 따.땄;
                num3 = 따.딝;
                딡1 = 딡3;
              }
            }
            딡3.딟[0] = false;
          }
        }
      }
      if (딡1 != null)
      {
        if (딡1.땓)
          딡1.딟(땜.땺, new 땯() { 딟 = num4, 딟 = 딢.딴.딟 });
        else
          딡1.딟(땜.딟, new 땯()
          {
            딟 = num1,
            땄 = num2,
            딟 = 딢.딴.땄,
            딟 = 땝.딟
          });
      }
      return 딡1;
    }

    private 딡 딟([In] 딡 obj0, [In] 딡 obj1, [In] 딶.땙 obj2)
    {
      if (obj0 == null)
        return obj1;
      if (obj0.딟 == 땪.땃)
        return obj0;
      땓.땊 땊1 = obj2.땺()[obj1.딟.땔()];
      땓.땊 땊2 = obj2.땺()[obj0.딟.땔()];
      if (obj1.딟 == 땪.땃)
        return obj1;
      if (obj1.딟 == 땪.딢)
      {
        if (obj0.딟 != 땪.딢 || 땊1.딧 > 땊2.딧)
          return obj1;
      }
      else if (obj0.딟 == 땪.딟 && obj1.딟 != 땪.땄 || obj0.딟 == 땪.땄 && obj1.딟 != 땪.땄 || 땊1.딧 > 땊2.딧)
        return obj1;
      return obj0;
    }

    private int 땄([In] 딵 obj0, [In] 딡 obj1)
    {
      int num1 = -1;
      딶.땙 땙 = obj0.딣().땼().떂();
      땓.땊 땊1 = 땙.땺()[obj1.딟.땔()];
      땓.딲 딲 = obj0.딣().땼().땻()[obj1.딟.땔()];
      int num2 = 땊1.딢 / obj1.땄 + 1;
      for (int index1 = 0; index1 < obj0.땻(); ++index1)
      {
        딡 딡 = obj0.땁()[index1];
        땓.땊 땊2 = 땙.땺()[딡.딟.땔()];
        GameTileComponent[] gameTileComponentArray = obj0.딣().땓().get_TileNetwork().딟(obj0.딣().땼(), 땙, 땊2.땃, 땊2.딶, 1, 딲, 땊1.땄, -1);
        for (int index2 = 0; index2 < gameTileComponentArray.Length; ++index2)
        {
          if (gameTileComponentArray[index2].TileIndexX != 땊1.땃 || gameTileComponentArray[index2].TileIndexY != 땊1.딶)
          {
            int num3 = -1;
            if (obj1.딟(gameTileComponentArray[index2], ref num3) < num2)
              num1 = num3;
          }
        }
      }
      return num1;
    }
  }
}
