// Decompiled with JetBrains decompiler
// Type: FSWorldComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using UnityEngine;

[AddComponentMenu("FarseerUnity/Physics World Component")]
public class FSWorldComponent : MonoBehaviour
{
  protected static FSWorldComponent 딟;
  private 땥.땱 딟;
  public Vector2 Gravity = new Vector2(0.0f, -9.8f);
  protected int 딟 = 2;

  private void Awake()
  {
    FSWorldComponent.딟 = this;
    this.딟 = new 땥.땱(new 땥.떁((float) this.Gravity.x, (float) this.Gravity.y));
  }

  private void FixedUpdate()
  {
    if (this.딟 > 0)
      --this.딟;
    else
      this.딟.땓(Time.fixedDeltaTime);
  }

  [SpecialName]
  public static 땥.땱 딟() => FSWorldComponent.딟.딟;
}
