// Decompiled with JetBrains decompiler
// Type: 땃.땗
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 땃
{
  public class 땗 : 땖
  {
    public override 딡 딟([In] 딵 obj0)
    {
      딡 딡1 = (딡) null;
      땞 땞 = obj0.땷();
      int num1 = -1;
      for (int index = 0; index < obj0.땔().Count; ++index)
      {
        딡 딡2 = obj0.땔()[index];
        if (this.딟(obj0, 딡2) && obj0.딣().땼().떂().땺()[딡2.딟.땔()].딢 >= 딡2.땄)
        {
          딡 딡3 = this.딟(딡1, 딡2, obj0.딣().땼().떂());
          if (딡3 == 딡2)
          {
            int num2 = this.딟(딡3, obj0, 땞);
            if (num2 != -1)
            {
              num1 = num2;
              딡1 = 딡3;
            }
          }
        }
      }
      if (딡1 != null)
        딡1.딟(땜.딶, new 땯() { 딟 = num1, 딟 = 딢.딴.딟 });
      return 딡1;
    }

    private 딡 딟([In] 딡 obj0, [In] 딡 obj1, [In] 딶.땙 obj2) => !obj1.땃 || obj0 != null && obj2.땺()[obj1.딟.땔()].딧 >= obj2.땺()[obj0.딟.땔()].딧 ? obj0 : obj1;

    private int 딟([In] 딡 obj0, [In] 딵 obj1, [In] 땞 obj2)
    {
      땓.땊 땊 = obj1.딣().땼().떂().땺()[obj0.딟.땔()];
      short maxValue = short.MaxValue;
      int index1 = -1;
      int num = int.MaxValue;
      for (int index2 = 0; index2 < obj0.딟.Length; ++index2)
      {
        GameTileComponent gameTileComponent = obj0.딟[index2];
        if (!obj1.딟(obj1.딣().땼().떂(), gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, 땊, true) && this.딟(obj1, gameTileComponent, obj0.딟[index2].땄, (int) maxValue, num, obj2))
        {
          maxValue = obj1.땘()[gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, 딮.딟];
          index1 = index2;
          num = obj0.딟[index2].땄;
        }
      }
      if (index1 != -1 && 땊.땃 == obj0.딟[index1].TileIndexX && 땊.딶 == obj0.딟[index1].TileIndexY)
        index1 = -1;
      return index1;
    }

    private bool 딟([In] 딵 obj0, [In] GameTileComponent obj1, [In] int obj2, [In] int obj3, [In] int obj4, [In] 땞 obj5)
    {
      int num = (int) obj0.땘()[obj1.TileIndexX, obj1.TileIndexY, 딮.딟];
      return obj5 == 땞.땄 ? obj2 < obj4 || obj2 == obj4 && num < obj3 : num < obj3 || num == obj3 && obj2 < obj4;
    }
  }
}
