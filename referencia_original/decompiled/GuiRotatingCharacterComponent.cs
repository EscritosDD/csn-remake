// Decompiled with JetBrains decompiler
// Type: GuiRotatingCharacterComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 땓;

[AddComponentMenu("Gui3D/Rotating Character")]
public class GuiRotatingCharacterComponent : GuiComponent3D
{
  private bool 딟;
  private Vector3 딟;
  private float 딟;
  private float 땄;
  private 땠 딟;
  public Transform CharcterTransform;
  public bool HandleClickThrough;

  public override void OnDown(Vector3 Position)
  {
    this.딟 = true;
    this.딟 = Position;
    if (!this.HandleClickThrough)
      return;
    this.딟.딟(Position);
  }

  public override void OnUp(Vector3 Position)
  {
    this.딟 = false;
    if (!this.HandleClickThrough)
      return;
    this.딟.딟(Position, ((Component) this).collider);
  }

  public override void OnHeld(Vector3 Position)
  {
    if (this.HandleClickThrough)
      this.딟.딟(Position, true);
    if (!this.딟.딟())
    {
      Vector3 vector3 = Vector3.op_Subtraction(Position, this.딟);
      if (this.딟)
        this.UpdateDeltaRotation((float) (100.0 * vector3.x) / (float) Screen.width, true);
    }
    this.딟 = Position;
  }

  private void UpdateDeltaRotation(float Delta, bool SetVel)
  {
    if (Object.op_Equality((Object) this.CharcterTransform, (Object) null))
      return;
    foreach (Transform transform in this.CharcterTransform)
      transform.Rotate(new Vector3(0.0f, -Delta, 0.0f));
    if (!SetVel)
      return;
    float num = Delta / Time.deltaTime;
    if ((double) Mathf.Abs(num) < (double) Mathf.Abs(this.딟 / 2f))
      this.딟 /= 2f;
    else
      this.딟 = num;
  }

  private void Update()
  {
    if (!Object.op_Inequality((Object) this.CharcterTransform, (Object) null) || (double) Mathf.Abs(this.딟) <= 9.99999974737875E-05)
      return;
    this.UpdateDeltaRotation(this.딟 * Time.deltaTime, false);
    this.딟 = Mathf.SmoothDamp(this.딟, 0.0f, ref this.땄, 0.25f);
  }
}
