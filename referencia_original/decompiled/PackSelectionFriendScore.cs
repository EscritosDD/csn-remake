// Decompiled with JetBrains decompiler
// Type: PackSelectionFriendScore
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PackSelectionFriendScore : MonoBehaviour
{
  public GameObject AvatarImage;
  public GuiText3D ScoreText;
  public GuiText3D NameText;
  public GameObject Display;
  public float MaxUserNameLength;
  private 딢.떌 딟;
  private 딢.땃 딟;
  private bool 딟;

  private void Awake() => this.Display.SetActive(false);

  private void Update()
  {
    if (this.딟 && !GlobalAppData.땢().떂())
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      // ISSUE: variable of a compiler-generated type
      딝.딳<땄.딽, FireTeamUserProfileChallengeJsonData> 딳 = ((IEnumerable<딝.딳<땄.딽, FireTeamUserProfileChallengeJsonData>>) ((IEnumerable<땄.딽>) GlobalAppData.땢().떎()).Select<땄.딽, 딝.딳<땄.딽, FireTeamUserProfileChallengeJsonData>>((Func<땄.딽, 딝.딳<땄.딽, FireTeamUserProfileChallengeJsonData>>) (f => new 딝.딳<땄.딽, FireTeamUserProfileChallengeJsonData>(f, (f.땃() as 땓.땇).땄(this.딟.딧())))).Where<딝.딳<땄.딽, FireTeamUserProfileChallengeJsonData>>((Func<딝.딳<땄.딽, FireTeamUserProfileChallengeJsonData>, bool>) (obj0 => obj0.땄() != null && obj0.땄().Score > 0)).ToArray<딝.딳<땄.딽, FireTeamUserProfileChallengeJsonData>>()).OrderByDescending<딝.딳<땄.딽, FireTeamUserProfileChallengeJsonData>, int>((Func<딝.딳<땄.딽, FireTeamUserProfileChallengeJsonData>, int>) (obj0 => obj0.땄().Score)).FirstOrDefault<딝.딳<땄.딽, FireTeamUserProfileChallengeJsonData>>();
      if (딳 != null)
      {
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        this.딟 = new 딢.떌(딳.딟(), 딳.땄());
        // ISSUE: reference to a compiler-generated method
        this.ScoreText.Text = 딳.땄().Score.ToString();
        this.ScoreText.UpdateMesh();
        if (Object.op_Inequality((Object) this.NameText, (Object) null))
        {
          // ISSUE: reference to a compiler-generated method
          this.NameText.Text = this.NameText.ShortenText(딳.딟().땄(), this.MaxUserNameLength);
          this.NameText.UpdateMesh();
        }
        this.Display.SetActive(true);
      }
      this.딟 = false;
    }
    if (this.딟 == null || !this.딟.딟())
      return;
    this.AvatarImage.renderer.sharedMaterial = this.딟.땄();
  }

  public void Init(딢.땃 Pack)
  {
    this.딟 = Pack;
    this.딟 = true;
  }

  public void OnDestroy()
  {
    if (this.딟 == null)
      return;
    this.딟.Dispose();
    this.딟 = (딢.떌) null;
  }
}
