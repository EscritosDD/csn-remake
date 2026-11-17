// Decompiled with JetBrains decompiler
// Type: 땃.땃
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  public class 땃
  {
    public GuiButton3D 딟;
    private Material 딟;
    private Material 땄;

    public 땃([In] GuiButton3D obj0, [In] Shader obj1)
    {
      this.딟 = obj0;
      this.딟 = ((Component) this.딟).renderer.material;
      this.땄 = GlobalAppData.땲().딟(((Component) this.딟).renderer.material, obj1);
    }

    public void 딟()
    {
      this.딟.Disabled = false;
      this.딟.AnimateButton = true;
      ((Component) this.딟).renderer.sharedMaterial = this.딟;
    }

    public void 땄()
    {
      this.딟.Disabled = true;
      this.딟.AnimateButton = false;
      ((Component) this.딟).renderer.sharedMaterial = this.땄;
    }
  }
}
