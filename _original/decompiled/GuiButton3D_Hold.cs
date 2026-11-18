// Decompiled with JetBrains decompiler
// Type: GuiButton3D_Hold
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("Gui3D/Button")]
public class GuiButton3D_Hold : GuiComponent3D
{
  private GameObjectPulse 딟;
  public bool Disabled;
  public bool SuspendPressedAudio;
  public AudioShader2 PlayAudio;
  public AudioShader2 DisabledAudio;
  public bool AnimateButton = true;
  public GuiScrollList3D ScrollList;
  public float ScrollSpeed;
  public bool IsLeft;
  public GameObject Button;
  public float Buffer;
  private float 딟;
  public AnimationCurve SpeedRamp;
  public float TimeToMaxSpeed = 0.5f;

  private void Start()
  {
  }

  public override void OnDown(Vector3 Position)
  {
    if (this.AnimateButton && Object.op_Equality((Object) this.딟, (Object) null))
      this.딟 = ((Component) this).gameObject.AddComponent<GameObjectPulse>();
    this.딟 = 0.0f;
  }

  public override void OnUp(Vector3 Position)
  {
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.딟.OnButtonReleased();
  }

  public override void OnHeld(Vector3 Position)
  {
    this.딟 += Time.deltaTime;
    float Amount = this.SpeedRamp.Evaluate(Mathf.Clamp01(this.딟 / this.TimeToMaxSpeed));
    if (this.IsLeft)
      this.ScrollList.SetScrollVel(Amount);
    else
      this.ScrollList.SetScrollVel(-Amount);
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
      if (!Object.op_Inequality((Object) this.PlayAudio, (Object) null) || this.SuspendPressedAudio)
        return;
      double num = (double) this.PlayAudio.PlayOneShot(((Component) this).gameObject, 0.0f);
    }
  }

  private void Update() => this.SetButtonStates();

  private void SetButtonStates()
  {
    BoxCollider component = ((Component) this).GetComponent<BoxCollider>();
    if (this.IsLeft)
    {
      this.Button.SetActive((double) this.ScrollList.get_Offset() > (double) this.ScrollList.get_MinOffset() + (double) this.Buffer);
      ((Collider) component).enabled = (double) this.ScrollList.get_Offset() > (double) this.ScrollList.get_MinOffset() + (double) this.Buffer;
    }
    else
    {
      this.Button.SetActive((double) this.ScrollList.get_Offset() < (double) this.ScrollList.get_MaxOffset() - (double) this.Buffer);
      ((Collider) component).enabled = (double) this.ScrollList.get_Offset() < (double) this.ScrollList.get_MaxOffset() - (double) this.Buffer;
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
}
