// Decompiled with JetBrains decompiler
// Type: AbilityUnlockPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class AbilityUnlockPanelHandler : MonoBehaviour
{
  public GuiText3D AbilityUnlockHeader;
  public GuiMultiLineText3D AbilityUnlockText;
  public GameObject AbilityUnlockIcon;
  public GameObject AbilityUnlockIconBackground;
  public Material LockedAbilityBackground;
  public Material UnlockedAbilityBackground;

  public void Init(PlayerAbilityEntry Entry)
  {
    this.AbilityUnlockText.LocText = Entry.AbilityInfo.Description;
    this.AbilityUnlockHeader.LocText = Entry.AbilityInfo.Title;
    this.AbilityUnlockIcon.renderer.material = Entry.AbilityInfo.Icon;
    this.AbilityUnlockIconBackground.renderer.sharedMaterial = this.LockedAbilityBackground;
    this.AbilityUnlockText.UpdateMesh();
    this.AbilityUnlockHeader.UpdateMesh();
  }

  public void Close() => Object.Destroy((Object) ((Component) this).gameObject);

  private void OnDestroy() => GlobalAppData.땄(this.AbilityUnlockIcon);
}
