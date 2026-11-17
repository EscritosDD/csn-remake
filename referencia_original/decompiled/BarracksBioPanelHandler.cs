// Decompiled with JetBrains decompiler
// Type: BarracksBioPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 땓;

public class BarracksBioPanelHandler : MonoBehaviour
{
  private MenuAnimatorHandler 딟;
  private float 딟 = 0.48f;
  public float Buffer;
  public XPProgressBar ProgressBar;
  public GuiText3D CharacterNameText;
  public GuiText3D RankNameText;
  public GuiText3D XPText;
  public GameObject CurrentRankIcon;
  public GameObject NextRankIcon;
  public UnitIconBank UnitIcon;
  public bool IsClosing;
  public GuiScrollList3D BioTextScroller;
  public NewsEntryHandler NewsEntryPrefab;
  public Transform TextDivider;
  public Transform ScrollerPadding;

  private void Awake()
  {
  }

  public void Init(떀 Char, Transform StartPoint, Transform EndPoint)
  {
    this.딟 = ((Component) this).GetComponent<MenuAnimatorHandler>();
    this.딟.StartPoint = StartPoint;
    this.딟.EndPoint = EndPoint;
    this.UnitIcon.Init(Char, 0);
    this.BioTextScroller.AddItem(Object.Instantiate((Object) this.ScrollerPadding) as Transform, 0.0125f);
    NewsEntryHandler newsEntryHandler1 = Object.Instantiate((Object) this.NewsEntryPrefab) as NewsEntryHandler;
    newsEntryHandler1.NewsItemText.LocText = Char.땁().Bio;
    newsEntryHandler1.NewsItemText.UpdateMesh();
    float num1 = newsEntryHandler1.NewsItemText.MeasureHeight();
    newsEntryHandler1.Init(num1 / 2f);
    this.BioTextScroller.AddItem(((Component) newsEntryHandler1).gameObject.transform, (float) (((double) num1 + (double) this.Buffer / 320.0) * 0.5));
    this.BioTextScroller.AddItem(Object.Instantiate((Object) this.TextDivider) as Transform, 0.021875f);
    NewsEntryHandler newsEntryHandler2 = Object.Instantiate((Object) this.NewsEntryPrefab) as NewsEntryHandler;
    newsEntryHandler2.NewsItemText.LocText = Char.땁().FlavourText;
    newsEntryHandler2.NewsItemText.TextColor = Color.white;
    newsEntryHandler2.NewsItemText.UpdateMesh();
    float num2 = newsEntryHandler2.NewsItemText.MeasureHeight();
    newsEntryHandler2.Init(num2 / 2f);
    this.BioTextScroller.AddItem(((Component) newsEntryHandler2).gameObject.transform, (float) (((double) num2 + (double) this.Buffer / 320.0) * 0.5));
    this.BioTextScroller.AddItem(Object.Instantiate((Object) this.ScrollerPadding) as Transform, 0.0375f);
    ((Component) this.BioTextScroller).gameObject.SetActive(false);
    this.CharacterNameText.Text = this.ShortenName(Char.땹());
    this.CharacterNameText.UpdateMesh();
    int num3;
    UnitLevel unitLevel1;
    UnitLevel unitLevel2 = GlobalAppData.딢().딟(Char.땝(), out num3, out unitLevel1);
    if (unitLevel2 == null)
    {
      this.CurrentRankIcon.SetActive(false);
    }
    else
    {
      this.CurrentRankIcon.SetActive(true);
      this.CurrentRankIcon.renderer.material = unitLevel2.RankIcon;
    }
    if (unitLevel1 == null)
    {
      this.NextRankIcon.SetActive(false);
    }
    else
    {
      this.NextRankIcon.SetActive(true);
      this.NextRankIcon.renderer.material = unitLevel1.RankIcon;
    }
    this.RankNameText.LocText = unitLevel2.Title;
    this.RankNameText.UpdateMesh();
    if (unitLevel1 != null)
    {
      this.XPText.set_LocTextParms(new object[2]
      {
        (object) num3,
        (object) unitLevel1.RequiredXP
      });
      this.XPText.UpdateMesh();
    }
    else
      ((Component) this.XPText).gameObject.SetActive(false);
    this.ProgressBar.InitForUnit(Char);
    this.딟.SetOnOpenFinishedCallback(new MenuAnimatorHandler.땔(this.UpdateScrollerClipping));
  }

  private void UpdateScrollerClipping()
  {
    ((Component) this.BioTextScroller).gameObject.SetActive(true);
    this.BioTextScroller.UpdateItemClipping();
  }

  private string ShortenName(string Name)
  {
    string str = Name;
    if (this.CharacterNameText.Font.딟(str, true, this.CharacterNameText.Size).x <= (double) this.딟)
      return Name;
    for (Vector2 vector2 = this.CharacterNameText.Font.딟(str + "...", true, this.CharacterNameText.Size); vector2.x > (double) this.딟; vector2 = this.CharacterNameText.Font.딟(str + "...", true, this.CharacterNameText.Size))
      str = str.Substring(0, str.Length - 1);
    return str + "...";
  }

  public void Update()
  {
    if (!Object.op_Inequality((Object) this.UnitIcon, (Object) null))
      return;
    this.UnitIcon.Update();
  }

  public void Close()
  {
    this.IsClosing = true;
    this.딟.Close();
  }

  public void OnDestroy()
  {
    GlobalAppData.땄(this.CurrentRankIcon);
    GlobalAppData.땄(this.NextRankIcon);
  }
}
