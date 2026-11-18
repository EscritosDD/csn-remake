// Decompiled with JetBrains decompiler
// Type: GuiButton3D
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using UnityEngine;

[AddComponentMenu("Gui3D/Button")]
public class GuiButton3D : GuiComponent3D
{
  private GameObjectPulse 딟;
  public string Command;
  public bool Disabled;
  public bool SuspendPressedAudio;
  public AudioShader2 PlayAudio;
  public AudioShader2 SwishAudio;
  public AudioShader2 DisabledAudio;
  public bool AnimateButton = true;
  public bool checkFocusOnCarriageReturn;

  private void Start()
  {
  }

  private void Update()
  {
    if (!this.checkFocusOnCarriageReturn || !Object.op_Equality((Object) GuiComponent3D.땃(), (Object) this) || !Input.GetKeyDown((KeyCode) 13))
      return;
    this.OnPressed(((Component) this).transform.position);
  }

  public override void OnDown(Vector3 Position)
  {
    if (this.Disabled || !this.AnimateButton || !Object.op_Equality((Object) this.딟, (Object) null))
      return;
    this.딟 = ((Component) this).gameObject.AddComponent<GameObjectPulse>();
  }

  public override void OnUp(Vector3 Position)
  {
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.딟.OnButtonReleased();
  }

  public override void OnHeld(Vector3 Position)
  {
  }

  public override void OnPressed(Vector3 Position)
  {
    if (this.Disabled)
    {
      if (!Object.op_Inequality((Object) this.DisabledAudio, (Object) null))
        return;
      double num = (double) this.DisabledAudio.PlayOneShot(((Component) this).gameObject, 0.0f);
    }
    else
    {
      if (Object.op_Inequality((Object) this.PlayAudio, (Object) null) && !this.SuspendPressedAudio)
      {
        double num1 = (double) this.PlayAudio.PlayOneShot(((Component) this).gameObject, 0.0f);
      }
      if (Object.op_Inequality((Object) this.SwishAudio, (Object) null))
      {
        double num2 = (double) this.SwishAudio.PlayOneShot(((Component) this).gameObject, 0.0f);
      }
      if (!string.IsNullOrEmpty(this.get_CustomPressFunc()))
        ((Component) this).SendMessageUpwards(this.get_CustomPressFunc(), this.get_CustomPressValue());
      else
        ((Component) this).SendMessageUpwards("OnButtonPressed", (object) this.Command);
    }
  }

  public void ResetButtonPulseToDefault()
  {
    if (!this.AnimateButton || !Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.딟.ResetPulseBackToDefault();
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

  private void DrawCollider()
  {
    BoxCollider component = ((Component) this).gameObject.GetComponent<BoxCollider>();
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    DebugRenderer.딟(new Vector3[5]
    {
      Vector3.op_Addition(((Component) this).transform.localPosition, new Vector3((float) (-((Component) this).transform.localScale.x * component.size.x * 0.5), 0.0f, (float) (-((Component) this).transform.localScale.z * component.size.z * 0.5))),
      Vector3.op_Addition(((Component) this).transform.localPosition, new Vector3((float) (((Component) this).transform.localScale.x * component.size.x * 0.5), 0.0f, (float) (-((Component) this).transform.localScale.z * component.size.z * 0.5))),
      Vector3.op_Addition(((Component) this).transform.localPosition, new Vector3((float) (((Component) this).transform.localScale.x * component.size.x * 0.5), 0.0f, (float) (((Component) this).transform.localScale.z * component.size.z * 0.5))),
      Vector3.op_Addition(((Component) this).transform.localPosition, new Vector3((float) (-((Component) this).transform.localScale.x * component.size.x * 0.5), 0.0f, (float) (((Component) this).transform.localScale.z * component.size.z * 0.5))),
      Vector3.op_Addition(((Component) this).transform.localPosition, new Vector3((float) (-((Component) this).transform.localScale.x * component.size.x * 0.5), 0.0f, (float) (-((Component) this).transform.localScale.z * component.size.z * 0.5)))
    }, ((Object) this).name + "collider");
  }

  [CompilerGenerated]
  [SpecialName]
  public string get_CustomPressFunc() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public void set_CustomPressFunc(string value) => this.딟 = value;

  [CompilerGenerated]
  [SpecialName]
  public object get_CustomPressValue() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public void set_CustomPressValue(object value) => this.딟 = value;
}
