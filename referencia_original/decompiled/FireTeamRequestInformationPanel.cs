// Decompiled with JetBrains decompiler
// Type: FireTeamRequestInformationPanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using 땄;

public class FireTeamRequestInformationPanel : MonoBehaviour
{
  private 땘 딟;
  private float 딟;
  public GuiText3D StartTimeText;
  public GuiText3D DoneValue;
  public GuiText3D SuccessValue;
  public GuiText3D DoneTimeTakenText;
  public GuiText3D SuccessTimeTakenText;

  public static void 딟([In] 땘 obj0, [In] string obj1) => (Object.Instantiate((Object) GlobalAppData.딟.FireTeamRequestInformationPanelPrefab) as FireTeamRequestInformationPanel).Init(obj0, obj1);

  private void Init(땘 SingleResponse, string Text)
  {
    this.딟 = SingleResponse;
    this.딟 = Time.time;
    this.DoneValue.Text = Text;
    this.DoneValue.UpdateMesh();
  }

  private void Update()
  {
    if (this.딟 != null && this.딟.땄())
    {
      Object.Destroy((Object) ((Component) this).gameObject);
      this.딟 = (땘) null;
    }
    this.StartTimeText.Text = (Time.time - this.딟).ToString();
    this.StartTimeText.UpdateMesh();
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (FireTeamRequestInformationPanel.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      FireTeamRequestInformationPanel.딟 = new Dictionary<string, int>(1)
      {
        {
          "Close",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!FireTeamRequestInformationPanel.딟.TryGetValue(key, out num) || num != 0)
      return;
    Object.Destroy((Object) ((Component) this).gameObject);
  }
}
