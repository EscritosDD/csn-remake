// Decompiled with JetBrains decompiler
// Type: GuiHyperlink3D
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("Gui3D/Hyperlink")]
public class GuiHyperlink3D : GuiComponent3D
{
  public string URL;
  public bool Disabled;

  public override void OnDown(Vector3 Position)
  {
  }

  public override void OnUp(Vector3 Position)
  {
  }

  public override void OnHeld(Vector3 Position)
  {
  }

  public override void OnPressed(Vector3 Position)
  {
    if (this.Disabled)
      return;
    GlobalAppData.딶(this.URL);
  }

  private void OnDestroy()
  {
    GlobalAppData.땄(((Component) this).gameObject);
    foreach (Renderer componentsInChild in ((Component) this).GetComponentsInChildren<Renderer>())
    {
      for (int index = 0; index < componentsInChild.materials.Length; ++index)
        GlobalAppData.딟(componentsInChild.materials[index]);
    }
  }
}
