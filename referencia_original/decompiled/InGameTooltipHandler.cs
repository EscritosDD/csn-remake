// Decompiled with JetBrains decompiler
// Type: InGameTooltipHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

public class InGameTooltipHandler : MonoBehaviour
{
  private DateTime 딟;
  private bool 딟;
  private float 딟;
  public float CharacterPortraitStartX = 1.03f;
  public float CharacterPortraitEndX = 0.54f;
  public float DelayTime = 1f;
  public float AnimLength;
  public GameObject CharacterPortraint;
  public GuiMultiLineText3D TooltipText;
  public bool AnimateCharacter = true;

  private void Awake()
  {
    this.딟 = DateTime.Now;
    if (this.AnimateCharacter)
      return;
    this.PositionElement(this.CharacterPortraint, this.CharacterPortraitEndX);
  }

  public void Update()
  {
    if (this.딟)
      return;
    this.딟 += Time.deltaTime / this.AnimLength;
    this.딟 = Mathf.Clamp01(this.딟);
    this.AnimateElement(this.CharacterPortraint, this.CharacterPortraitStartX, this.CharacterPortraitEndX);
    if ((double) this.딟 != 1.0)
      return;
    this.딟 = true;
    this.딟 = 0.0f;
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (InGameTooltipHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      InGameTooltipHandler.딟 = new Dictionary<string, int>(1)
      {
        {
          "Close",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!InGameTooltipHandler.딟.TryGetValue(key, out num) || num != 0 || (DateTime.Now - this.딟).TotalSeconds < (double) this.DelayTime)
      return;
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  private void AnimateElement(GameObject TargetObject, float StartPos, float EndPos)
  {
    float NewX = Mathf.Lerp(StartPos, EndPos, this.딟);
    this.PositionElement(TargetObject, NewX);
  }

  private void PositionElement(GameObject TargetObject, float NewX)
  {
    Vector3 localPosition = TargetObject.transform.localPosition;
    TargetObject.transform.localPosition = new Vector3(NewX, (float) localPosition.y, (float) localPosition.z);
  }
}
