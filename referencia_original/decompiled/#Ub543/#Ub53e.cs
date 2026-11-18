// Decompiled with JetBrains decompiler
// Type: 땃.딾
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

namespace 땃
{
  public class 딾
  {
    public static int 딟 = 10;
    public 땚[] 딟 = new 땚[딾.딟];
    public int 땄;

    public 딾()
    {
      for (int index = 0; index < 딾.딟; ++index)
        this.딟[index] = new 땚();
    }

    public void 딟()
    {
      for (int index = 0; index < 딾.딟; ++index)
        this.딟[index].딟();
      this.땄 = 0;
    }
  }
}
