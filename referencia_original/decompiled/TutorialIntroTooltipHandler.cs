// Decompiled with JetBrains decompiler
// Type: TutorialIntroTooltipHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

public class TutorialIntroTooltipHandler : MonoBehaviour
{
  private TutorialIntroTooltipHandler.때 딟;
  private DateTime 딟;
  private float 딟;
  public float DelayTime = 1f;
  public float AnimLength;
  public PortraitInfo[] CharacterPortraits;
  public GuiMultiLineText3D TooltipText;

  private void Awake()
  {
    this.딟 = DateTime.Now;
    this.딟 = TutorialIntroTooltipHandler.때.딟;
  }

  public void Update()
  {
    if (this.딟 == TutorialIntroTooltipHandler.때.땄)
      return;
    this.딟 += Time.deltaTime / this.AnimLength;
    this.딟 = Mathf.Clamp01(this.딟);
    if (this.딟 == TutorialIntroTooltipHandler.때.딟)
    {
      foreach (PortraitInfo characterPortrait in this.CharacterPortraits)
        this.AnimateElement(characterPortrait.Portrait, characterPortrait.StartX, characterPortrait.EndX);
    }
    if ((double) this.딟 != 1.0)
      return;
    ++this.딟;
    this.딟 = 0.0f;
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (TutorialIntroTooltipHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      TutorialIntroTooltipHandler.딟 = new Dictionary<string, int>(1)
      {
        {
          "Close",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!TutorialIntroTooltipHandler.딟.TryGetValue(key, out num) || num != 0 || (DateTime.Now - this.딟).TotalSeconds < (double) this.DelayTime)
      return;
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  private void AnimateElement(GameObject TargetObject, float StartPos, float EndPos)
  {
    float num = Mathf.Lerp(StartPos, EndPos, this.딟);
    Vector3 localPosition = TargetObject.transform.localPosition;
    TargetObject.transform.localPosition = new Vector3(num, (float) localPosition.y, (float) localPosition.z);
  }

  private enum 때
  {
    딟,
    땄,
  }
}
