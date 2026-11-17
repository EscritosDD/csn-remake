// Decompiled with JetBrains decompiler
// Type: 딶.땡
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

namespace 딶
{
  public class 땡 : 떒
  {
    protected override void 딟()
    {
      CameraController 딟 = 딡.땴().딟;
      base.딟();
      딟.ClearCinematics();
    }

    public override string ToString() => "[CameraClearCinematicEvent]";
  }
}
