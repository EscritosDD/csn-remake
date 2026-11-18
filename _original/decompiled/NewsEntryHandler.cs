// Decompiled with JetBrains decompiler
// Type: NewsEntryHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class NewsEntryHandler : MonoBehaviour
{
  public GuiMultiLineText3D NewsItemText;

  public void Init(float ZOffset)
  {
    Vector3 vector3;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3).\u002Ector(0.0f, 0.0f, ZOffset);
    Transform transform = ((Component) this.NewsItemText).gameObject.transform;
    transform.localPosition = Vector3.op_Addition(transform.localPosition, vector3);
  }
}
