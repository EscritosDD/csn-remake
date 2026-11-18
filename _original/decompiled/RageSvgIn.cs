// Decompiled with JetBrains decompiler
// Type: RageSvgIn
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Xml;
using UnityEngine;
using 땺;

[AddComponentMenu("RageTools/Rage SVG In")]
[ExecuteInEditMode]
public class RageSvgIn : MonoBehaviour
{
  public char Separator = '/';
  public string Directory = "RageTools/Demo/SvgFiles";
  public Object SvgFile;
  public int MinVertexDensity = 3;
  public int MaxVertexDensity = 5;
  public float AntialiasWidth = 1f;
  public float ZsortOffset = -0.1f;
  public float MergeRadius = 0.01f;
  public bool ImportOnStart;
  public bool UseUrl;
  public bool DebugMeshCreation;
  public bool DebugStyleCreation;
  public bool MidlineControls = true;
  public bool OutlineBehindFill;
  public bool AutoLayering;
  public bool AutoLayeringGroup;
  public bool AutoLayeringMaterials;
  private Dictionary<string, RageSvgGradient> 딟;
  public bool CreateHoles = true;
  public string UrlPath = string.Empty;
  private string 딟 = string.Empty;
  public bool _showDebugMessage;
  public bool PerspectiveMode;

  [SpecialName]
  private bool get_AdaptiveDensity() => this.MinVertexDensity != this.MaxVertexDensity;

  [DebuggerHidden]
  public IEnumerator Start() => (IEnumerator) new RageSvgIn.\u003CStart\u003Ec__Iterator1A()
  {
    딟 = this
  };

  [SpecialName]
  public string get_AbsoluteSvgFilePath() => Object.op_Equality(this.SvgFile, (Object) null) ? string.Empty : this.get_AbsoluteDirectory() + this.SvgFile.name + ".svg";

  [SpecialName]
  public string get_AbsoluteDirectory()
  {
    if (this.Directory == null)
      return string.Empty;
    return Application.dataPath + (object) this.Separator + this.Directory + (object) this.Separator;
  }

  [SpecialName]
  public string get_SvgFilePath()
  {
    if (Object.op_Equality(this.SvgFile, (Object) null))
      return string.Empty;
    return this.Directory + (object) this.Separator + this.SvgFile.name + ".svg";
  }

  public void FixPath()
  {
    if (Object.op_Equality(this.SvgFile, (Object) null))
      return;
    this.Separator = Path.AltDirectorySeparatorChar;
    string str = (string) null;
    if (string.IsNullOrEmpty(str))
      return;
    char[] separator = new char[1]{ this.Separator };
    string[] strArray = str.Split(separator, 2);
    this.Directory = strArray.Length <= 1 ? string.Empty : strArray[1];
  }

  public void OnGUI()
  {
    if (!this._showDebugMessage)
      return;
    GUI.Label(new Rect(10f, 10f, 450f, 100f), this.딟);
  }

  public void ImportSvg() => this.StartCoroutine(this.ImportSvg(this.GetPathFromEditor()));

  [DebuggerHidden]
  public IEnumerator ImportSvg(string path) => (IEnumerator) new RageSvgIn.\u003CImportSvg\u003Ec__Iterator1B()
  {
    딟 = path,
    땄 = path,
    딟 = this
  };

  [DebuggerHidden]
  public IEnumerator SvgLoad(RageSvgObject svgData, string path) => (IEnumerator) new RageSvgIn.\u003CSvgLoad\u003Ec__Iterator1C()
  {
    딟 = path,
    딟 = svgData,
    땄 = path,
    땄 = svgData,
    딟 = this
  };

  [DebuggerHidden]
  public IEnumerator LoadXml(WWW xml) => (IEnumerator) new RageSvgIn.\u003CLoadXml\u003Ec__Iterator1D()
  {
    딟 = xml,
    땄 = xml
  };

  public string GetPathFromEditor()
  {
    string str = !this.UseUrl ? "file://" + this.get_AbsoluteSvgFilePath() : (this.UrlPath.Contains("/") ? this.UrlPath : (!Application.isEditor ? Application.dataPath + "/" + this.UrlPath : "file://" + Application.dataPath + "/" + this.UrlPath));
    this.딟 = str;
    return str;
  }

  private void FindAndParseSvg(XmlNode node, RageSvgObject svgData) => this.ParseSvg((XmlNode) node["svg"], svgData, false, 0);

  private void ParseSvg(XmlNode svgNode, RageSvgObject svgData, bool subPath, int level)
  {
    if (svgNode == null)
    {
      Debug.Log((object) "Error: SVG Node not found or invalid");
    }
    else
    {
      if (this.DebugMeshCreation)
      {
        Debug.Log((object) (svgNode.Name.Trim() + " parse start: \n================="));
        Debug.Log((object) ("(Parse SVG) Level " + (object) level));
      }
      if (Object.op_Equality((Object) svgData.Style, (Object) null) || level <= 1)
        svgData.Style = RageSvgStyle.딟();
      string key = svgNode.Name.Trim();
      if (key != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (RageSvgIn.딟 == null)
        {
          // ISSUE: reference to a compiler-generated field
          RageSvgIn.딟 = new Dictionary<string, int>(11)
          {
            {
              "g",
              0
            },
            {
              "linearGradient",
              1
            },
            {
              "radialGradient",
              2
            },
            {
              "stop",
              3
            },
            {
              "rect",
              4
            },
            {
              "circle",
              5
            },
            {
              "ellipse",
              6
            },
            {
              "line",
              7
            },
            {
              "polyline",
              8
            },
            {
              "polygon",
              9
            },
            {
              "path",
              10
            }
          };
        }
        int num;
        // ISSUE: reference to a compiler-generated field
        if (RageSvgIn.딟.TryGetValue(key, out num))
        {
          switch (num)
          {
            case 0:
              this.ParseGroup(svgNode, svgData, subPath, ref level);
              break;
            case 1:
              this.ParseGradient(svgNode, svgData, RageSvgGradient.때.딟, subPath, level);
              break;
            case 2:
              this.ParseGradient(svgNode, svgData, RageSvgGradient.때.땄, subPath, level);
              break;
            case 3:
              this.ParseGradientStop(svgNode, svgData);
              break;
            case 4:
              this.ParseRect(svgNode, ref svgData, subPath);
              break;
            case 5:
              this.ParseCircle(svgNode, ref svgData, subPath);
              break;
            case 6:
              this.ParseEllipse(svgNode, ref svgData, subPath);
              break;
            case 7:
              this.ParseLine(svgNode, ref svgData, subPath);
              break;
            case 8:
              this.ParsePolyLine(svgNode, ref svgData, RageSvgIn.딱.딟, subPath);
              break;
            case 9:
              this.ParsePolyLine(svgNode, ref svgData, RageSvgIn.딱.땄, subPath);
              break;
            case 10:
              this.ParsePathPrepare(svgNode, ref svgData, subPath, false);
              break;
          }
        }
      }
      if (!string.IsNullOrEmpty(svgData.StyleString))
        this.ParseStyle(ref svgData);
      if (svgNode.Name.Trim() == "g" || svgNode.Name.Trim() == "linearGradient" || svgNode.Name.Trim() == "radialGradient" || svgNode.Name.Trim() == "pattern" || !svgNode.HasChildNodes)
        return;
      ++level;
      foreach (XmlNode childNode in svgNode.ChildNodes)
        this.ParseSvg(childNode, svgData, subPath, level);
    }
  }

  private void ParsePathPrepare(
    XmlNode svgNode,
    ref RageSvgObject svgData,
    bool subPath,
    bool derivedPath)
  {
    svgData.Paths = new List<RageSvgPathElement>();
    this.ParsePath(svgNode, ref svgData, subPath, derivedPath);
  }

  private void ParsePath(
    XmlNode svgEntry,
    ref RageSvgObject svgData,
    bool subPath,
    bool derivedPath)
  {
    this.CreateGameObject(svgData.Parent, ref svgData, false, subPath, derivedPath);
    if (!derivedPath)
      svgData.TransformString = string.Empty;
    if (svgEntry.Attributes != null)
    {
      foreach (XmlAttribute attribute in (XmlNamedNodeMap) svgEntry.Attributes)
      {
        string name = attribute.Name;
        string svgValue = attribute.Value;
        if (this.ParseSvgStyle(name, svgValue, ref svgData))
        {
          this.ParseRageStyle(ref svgData);
        }
        else
        {
          string key = name;
          if (key != null)
          {
            // ISSUE: reference to a compiler-generated field
            if (RageSvgIn.땄 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RageSvgIn.땄 = new Dictionary<string, int>(3)
              {
                {
                  "id",
                  0
                },
                {
                  "transform",
                  1
                },
                {
                  "d",
                  2
                }
              };
            }
            int num;
            // ISSUE: reference to a compiler-generated field
            if (RageSvgIn.땄.TryGetValue(key, out num))
            {
              switch (num)
              {
                case 0:
                  ((Object) svgData.땄().gO).name = svgValue;
                  continue;
                case 1:
                  svgData.TransformString = svgValue;
                  continue;
                case 2:
                  this.ParseDrawCommand(ref svgData, attribute, false);
                  continue;
                default:
                  continue;
              }
            }
          }
        }
      }
    }
    this.ApplyStyle(svgData);
  }

  private void ParseGroup(XmlNode svgEntry, RageSvgObject svgData, bool subPath, ref int level)
  {
    Transform parent = svgData.Parent;
    bool flag = false;
    string newTransformString = string.Empty;
    svgData.Parent = this.CreateGameObject(svgData.Parent, ref svgData, true, false, false);
    svgData.Id = string.Empty;
    GameObject gameObject = ((Component) svgData.Parent).gameObject;
    RageSvgStyle rageSvgStyle = RageSvgStyle.딟();
    if (level > 1)
      rageSvgStyle.딟(svgData.Style);
    XmlAttributeCollection attributes = svgEntry.Attributes;
    if (attributes != null)
    {
      foreach (XmlAttribute xmlAttribute in (XmlNamedNodeMap) attributes)
      {
        string name = xmlAttribute.Name;
        string svgValue = xmlAttribute.Value;
        if (!this.ParseSvgStyle(name, svgValue, ref svgData))
        {
          string key = name;
          if (key != null)
          {
            // ISSUE: reference to a compiler-generated field
            if (RageSvgIn.딧 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RageSvgIn.딧 = new Dictionary<string, int>(3)
              {
                {
                  "id",
                  0
                },
                {
                  "display",
                  1
                },
                {
                  "transform",
                  2
                }
              };
            }
            int num;
            // ISSUE: reference to a compiler-generated field
            if (RageSvgIn.딧.TryGetValue(key, out num))
            {
              switch (num)
              {
                case 0:
                  svgData.Id = svgValue;
                  continue;
                case 1:
                  flag = svgValue == "none";
                  continue;
                case 2:
                  newTransformString = svgValue;
                  continue;
                default:
                  continue;
              }
            }
          }
        }
      }
    }
    ((Object) gameObject).name = !(svgData.Id == string.Empty) ? svgData.Id : "Group";
    this.ParseRageStyle(ref svgData);
    rageSvgStyle.딟(svgData.Style);
    if (this.DebugMeshCreation)
      Debug.Log((object) ("######### Group children Count: " + (object) svgEntry.ChildNodes.Count + " (level " + (object) level + ")"));
    if (svgEntry.HasChildNodes)
    {
      ++level;
      foreach (XmlNode childNode in svgEntry.ChildNodes)
      {
        svgData.Style.딟(rageSvgStyle);
        this.ParseSvg(childNode, svgData, subPath, level);
      }
    }
    if (this.DebugMeshCreation)
      Debug.Log((object) ("\tGroup transform: " + newTransformString + " :: Group = " + ((Object) gameObject).name));
    this.ApplyTransform(gameObject, newTransformString);
    svgData.TransformString = string.Empty;
    if (flag)
    {
      foreach (Component componentsInChild in gameObject.GetComponentsInChildren<Transform>())
        componentsInChild.gameObject.active = false;
      gameObject.active = false;
    }
    svgData.Parent = parent;
  }

  private void ParseLine(XmlNode svgEntry, ref RageSvgObject svgData, bool subPath)
  {
    svgData.Paths[svgData.딟()].IsLinear = true;
    double num1;
    float num2 = (float) (num1 = 0.0);
    float num3 = (float) num1;
    float num4 = (float) num1;
    float num5 = (float) num1;
    if (svgEntry.Attributes != null)
    {
      foreach (XmlAttribute attribute in (XmlNamedNodeMap) svgEntry.Attributes)
      {
        string name = attribute.Name;
        string svgValue = attribute.Value;
        if (!this.ParseSvgStyle(name, svgValue, ref svgData))
        {
          string key = name;
          if (key != null)
          {
            // ISSUE: reference to a compiler-generated field
            if (RageSvgIn.딢 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RageSvgIn.딢 = new Dictionary<string, int>(6)
              {
                {
                  "x1",
                  0
                },
                {
                  "y1",
                  1
                },
                {
                  "x2",
                  2
                },
                {
                  "y2",
                  3
                },
                {
                  "transform",
                  4
                },
                {
                  "id",
                  5
                }
              };
            }
            int num6;
            // ISSUE: reference to a compiler-generated field
            if (RageSvgIn.딢.TryGetValue(key, out num6))
            {
              switch (num6)
              {
                case 0:
                  num5 = 땳.땄(svgValue);
                  continue;
                case 1:
                  num3 = 땳.땄(svgValue);
                  continue;
                case 2:
                  num4 = 땳.땄(svgValue);
                  continue;
                case 3:
                  num2 = 땳.땄(svgValue);
                  continue;
                case 4:
                  svgData.TransformString = svgValue;
                  continue;
                case 5:
                  svgData.Id = svgValue;
                  continue;
                default:
                  continue;
              }
            }
          }
        }
      }
    }
    string str = (!(svgData.StyleString == string.Empty) ? "<path style=\"" + svgData.StyleString + "\" d=\"" : "<path d=\"") + "M " + num5.ToString() + "," + num3.ToString() + " " + "L " + num4.ToString() + "," + num2.ToString() + "\"/>";
    if (this.DebugMeshCreation)
      Debug.Log((object) ("svgLineToPath: " + str));
    XmlNode xmlNode = 땠.딟(str);
    svgData.Style.CornersType = 땺.땔.땘.땄;
    this.ParsePathPrepare(xmlNode.ChildNodes[0], ref svgData, subPath, true);
  }

  private void ParsePolyLine(
    XmlNode svgEntry,
    ref RageSvgObject svgData,
    RageSvgIn.딱 polyType,
    bool subPath)
  {
    svgData.Style.CornersType = 땺.땔.땘.땄;
    string str1 = string.Empty;
    if (svgEntry.Attributes != null)
    {
      foreach (XmlAttribute attribute in (XmlNamedNodeMap) svgEntry.Attributes)
      {
        string name = attribute.Name;
        string svgValue = attribute.Value;
        if (!this.ParseSvgStyle(name, svgValue, ref svgData))
        {
          string key = name;
          if (key != null)
          {
            // ISSUE: reference to a compiler-generated field
            if (RageSvgIn.땃 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RageSvgIn.땃 = new Dictionary<string, int>(3)
              {
                {
                  "points",
                  0
                },
                {
                  "transform",
                  1
                },
                {
                  "id",
                  2
                }
              };
            }
            int num;
            // ISSUE: reference to a compiler-generated field
            if (RageSvgIn.땃.TryGetValue(key, out num))
            {
              switch (num)
              {
                case 0:
                  str1 = svgValue;
                  continue;
                case 1:
                  svgData.TransformString = svgValue;
                  continue;
                case 2:
                  svgData.Id = svgValue;
                  continue;
                default:
                  continue;
              }
            }
          }
        }
      }
    }
    string str2 = (!(svgData.StyleString == string.Empty) ? "<path style=\"" + svgData.StyleString + "\" d=\"" : "<path d=\"") + "M " + str1;
    string str3 = polyType != RageSvgIn.딱.딟 ? str2 + " z\"/>" : str2 + "\"/>";
    if (this.DebugMeshCreation)
      Debug.Log((object) ("svgPolygon: " + str3));
    XmlNode xmlNode = 땠.딟(str3);
    svgData.Style.CornersType = 땺.땔.땘.땄;
    this.ParsePathPrepare(xmlNode.ChildNodes[0], ref svgData, subPath, true);
    svgData.땄().IsLinear = true;
  }

  private void ParseRect(XmlNode svgEntry, ref RageSvgObject svgData, bool subPath)
  {
    svgData.Style.CornersType = 땺.땔.땘.땄;
    double num1;
    float num2 = (float) (num1 = 0.0);
    float num3 = (float) num1;
    float num4 = (float) num1;
    float num5 = (float) num1;
    if (svgEntry.Attributes != null)
    {
      foreach (XmlAttribute attribute in (XmlNamedNodeMap) svgEntry.Attributes)
      {
        string name = attribute.Name;
        string svgValue = attribute.Value;
        if (!this.ParseSvgStyle(name, svgValue, ref svgData))
        {
          string key = name;
          if (key != null)
          {
            // ISSUE: reference to a compiler-generated field
            if (RageSvgIn.딶 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RageSvgIn.딶 = new Dictionary<string, int>(6)
              {
                {
                  "x",
                  0
                },
                {
                  "y",
                  1
                },
                {
                  "width",
                  2
                },
                {
                  "height",
                  3
                },
                {
                  "transform",
                  4
                },
                {
                  "id",
                  5
                }
              };
            }
            int num6;
            // ISSUE: reference to a compiler-generated field
            if (RageSvgIn.딶.TryGetValue(key, out num6))
            {
              switch (num6)
              {
                case 0:
                  num5 = 땳.땄(svgValue);
                  continue;
                case 1:
                  num4 = 땳.땄(svgValue);
                  continue;
                case 2:
                  num3 = 땳.땄(svgValue);
                  continue;
                case 3:
                  num2 = 땳.땄(svgValue);
                  continue;
                case 4:
                  svgData.TransformString = svgValue;
                  continue;
                case 5:
                  svgData.Id = svgValue;
                  continue;
                default:
                  continue;
              }
            }
          }
        }
      }
    }
    if (Mathf.Approximately(num3, 0.0f) || Mathf.Approximately(num2, 0.0f))
      return;
    string str = (!(svgData.StyleString == string.Empty) ? "<path style=\"" + svgData.StyleString + "\" d=\"" : "<path d=\"") + "M " + num5.ToString() + "," + num4.ToString() + " " + "L " + (num5 + num3).ToString() + "," + num4.ToString() + " " + "L " + (num5 + num3).ToString() + "," + (num4 + num2).ToString() + " " + "L " + num5.ToString() + "," + (num4 + num2).ToString() + " " + "L " + num5.ToString() + "," + num4.ToString() + " " + " z\" />";
    if (this.DebugMeshCreation)
      Debug.Log((object) ("svgRectToPath: " + str));
    XmlNode xmlNode = 땠.딟(str);
    svgData.Style.CornersType = 땺.땔.땘.땄;
    this.ParsePathPrepare(xmlNode.ChildNodes[0], ref svgData, subPath, true);
  }

  private void ParseCircle(XmlNode svgEntry, ref RageSvgObject svgData, bool subPath)
  {
    svgData.Style.CornersType = 땺.땔.땘.딟;
    double num1;
    float num2 = (float) (num1 = 0.0);
    float num3 = (float) num1;
    float num4 = (float) num1;
    if (svgEntry.Attributes != null)
    {
      foreach (XmlAttribute attribute in (XmlNamedNodeMap) svgEntry.Attributes)
      {
        string name = attribute.Name;
        string svgValue = attribute.Value;
        if (!this.ParseSvgStyle(name, svgValue, ref svgData))
        {
          string key = name;
          if (key != null)
          {
            // ISSUE: reference to a compiler-generated field
            if (RageSvgIn.땓 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RageSvgIn.땓 = new Dictionary<string, int>(5)
              {
                {
                  "cx",
                  0
                },
                {
                  "cy",
                  1
                },
                {
                  "r",
                  2
                },
                {
                  "transform",
                  3
                },
                {
                  "id",
                  4
                }
              };
            }
            int num5;
            // ISSUE: reference to a compiler-generated field
            if (RageSvgIn.땓.TryGetValue(key, out num5))
            {
              switch (num5)
              {
                case 0:
                  num4 = 땳.땄(svgValue);
                  continue;
                case 1:
                  num3 = 땳.땄(svgValue);
                  continue;
                case 2:
                  num2 = 땳.땄(svgValue);
                  continue;
                case 3:
                  svgData.TransformString = svgValue;
                  continue;
                case 4:
                  svgData.Id = svgValue;
                  continue;
                default:
                  continue;
              }
            }
          }
        }
      }
    }
    if (Mathf.Approximately(num2, 0.0f))
      return;
    string str1 = !(svgData.StyleString == string.Empty) ? "<path style=\"" + svgData.StyleString + "\" d=\"" : "<path d=\"";
    float num6 = 0.5522848f * num2;
    string str2 = str1 + " S " + (num4 - num6).ToString() + "," + (num3 + num2).ToString() + " " + num4.ToString() + "," + (num3 + num2).ToString() + "S " + (num4 + num2).ToString() + "," + (num3 + num6).ToString() + " " + (num4 + num2).ToString() + "," + num3.ToString() + " S " + (num4 + num6).ToString() + "," + (num3 - num2).ToString() + " " + num4.ToString() + "," + (num3 - num2).ToString() + " S " + (num4 - num2).ToString() + "," + (num3 - num6).ToString() + " " + (num4 - num2).ToString() + "," + num3.ToString() + " S " + (num4 - num6).ToString() + "," + (num3 + num2).ToString() + " " + num4.ToString() + "," + (num3 + num2).ToString() + " z\" />";
    if (this.DebugMeshCreation)
      Debug.Log((object) ("svgCircleToPath: " + str2));
    XmlNode xmlNode = 땠.딟(str2);
    svgData.Style.CornersType = 땺.땔.땘.땄;
    this.ParsePathPrepare(xmlNode.ChildNodes[0], ref svgData, subPath, true);
  }

  private void ParseEllipse(XmlNode svgEntry, ref RageSvgObject svgData, bool subPath)
  {
    svgData.Style.CornersType = 땺.땔.땘.딟;
    double num1;
    float num2 = (float) (num1 = 0.0);
    float num3 = (float) num1;
    float num4 = (float) num1;
    float num5 = (float) num1;
    if (svgEntry.Attributes != null)
    {
      foreach (XmlAttribute attribute in (XmlNamedNodeMap) svgEntry.Attributes)
      {
        string name = attribute.Name;
        string svgValue = attribute.Value;
        if (!this.ParseSvgStyle(name, svgValue, ref svgData))
        {
          string key = name;
          if (key != null)
          {
            // ISSUE: reference to a compiler-generated field
            if (RageSvgIn.땺 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RageSvgIn.땺 = new Dictionary<string, int>(6)
              {
                {
                  "cx",
                  0
                },
                {
                  "cy",
                  1
                },
                {
                  "rx",
                  2
                },
                {
                  "ry",
                  3
                },
                {
                  "transform",
                  4
                },
                {
                  "id",
                  5
                }
              };
            }
            int num6;
            // ISSUE: reference to a compiler-generated field
            if (RageSvgIn.땺.TryGetValue(key, out num6))
            {
              switch (num6)
              {
                case 0:
                  num5 = 땳.땄(svgValue);
                  continue;
                case 1:
                  num4 = 땳.땄(svgValue);
                  continue;
                case 2:
                  num3 = 땳.땄(svgValue);
                  continue;
                case 3:
                  num2 = 땳.땄(svgValue);
                  continue;
                case 4:
                  svgData.TransformString = svgValue;
                  continue;
                case 5:
                  svgData.Id = svgValue;
                  continue;
                default:
                  continue;
              }
            }
          }
        }
      }
    }
    if (Mathf.Approximately(num3, 0.0f) || Mathf.Approximately(num2, 0.0f))
      return;
    string str1 = !(svgData.StyleString == string.Empty) ? "<path style=\"" + svgData.StyleString + "\" d=\"" : "<path d=\"";
    float num7 = 0.5522848f * num3;
    float num8 = 0.5522848f * num2;
    string str2 = str1 + " S " + (num5 - num7).ToString() + "," + (num4 + num2).ToString() + " " + num5.ToString() + "," + (num4 + num2).ToString() + "S " + (num5 + num3).ToString() + "," + (num4 + num8).ToString() + " " + (num5 + num3).ToString() + "," + num4.ToString() + " S " + (num5 + num7).ToString() + "," + (num4 - num2).ToString() + " " + num5.ToString() + "," + (num4 - num2).ToString() + " S " + (num5 - num3).ToString() + "," + (num4 - num8).ToString() + " " + (num5 - num3).ToString() + "," + num4.ToString() + " S " + (num5 - num7).ToString() + "," + (num4 + num2).ToString() + " " + num5.ToString() + "," + (num4 + num2).ToString() + " z\" />";
    if (this.DebugMeshCreation)
      Debug.Log((object) ("svgCircleToPath: " + str2));
    XmlNode xmlNode = 땠.딟(str2);
    svgData.Style.CornersType = 땺.땔.땘.땄;
    this.ParsePathPrepare(xmlNode.ChildNodes[0], ref svgData, subPath, true);
  }

  private void ParseDrawCommand(
    ref RageSvgObject svgData,
    XmlAttribute svgAttribute,
    bool derivedPath)
  {
    bool flag1 = false;
    bool flag2 = true;
    RageSvgPathElement path = svgData.땄();
    foreach (string str in RageSvgIn.딟(svgAttribute.Value.TrimEnd((char[]) null)))
    {
      if (this.DebugMeshCreation)
        Debug.Log((object) ("commandset: " + str));
      List<float> coords = new List<float>(RageSvgIn.땄(str.Trim()));
      char c = str[0];
      bool isRelative = char.IsLower(c);
      char upper = char.ToUpper(c);
      switch (upper)
      {
        case 'H':
          this.MoveTo(coords, ref svgData, isRelative, false, true);
          continue;
        case 'L':
          this.MoveTo(coords, ref svgData, isRelative, false, false);
          continue;
        case 'M':
          if (flag2)
          {
            this.MoveTo(coords, ref svgData, isRelative, false, false);
            flag2 = false;
            continue;
          }
          if (this.DebugMeshCreation)
            Debug.Log((object) "\t ### Starting Sub-Path");
          svgData.PointIdx = 0;
          if (!flag1)
          {
            this.FinalizePath(ref svgData, svgData.땄(), true, true);
            flag1 = true;
          }
          this.CreateGameObject(svgData.Parent, ref svgData, false, true, derivedPath);
          this.MoveTo(coords, ref svgData, isRelative, false, false);
          continue;
        default:
          switch (upper)
          {
            case 'S':
              this.SmoothCurveTo(coords, ref svgData, isRelative);
              continue;
            case 'V':
              this.MoveTo(coords, ref svgData, isRelative, true, false);
              continue;
            default:
              switch (upper)
              {
                case 'C':
                  this.CurveTo(coords, ref svgData, isRelative);
                  continue;
                case 'Z':
                  svgData.땄().IsClosed = true;
                  this.FinalizePath(ref svgData, path, false, !flag2);
                  flag1 = true;
                  continue;
                default:
                  continue;
              }
          }
      }
    }
    if (!flag1)
      this.FinalizePath(ref svgData, svgData.땄(), false, !flag2);
    if (!this.CreateHoles)
      return;
    땺.땩.딟(svgData);
  }

  private void FinalizePath(
    ref RageSvgObject svgData,
    RageSvgPathElement path,
    bool keepTransform,
    bool subPath)
  {
    if (path.Spline.딷() == 0)
    {
      if (!this.DebugMeshCreation)
        return;
      Debug.Log((object) "Parsing Error: Path has no valid points");
    }
    else
    {
      if (subPath)
        svgData.Paths.Add(path);
      path.Spline.딟(this.OutlineBehindFill);
      bool flag = path.Spline.땟().딟(this.DebugMeshCreation);
      if (!path.IsClosed && flag)
        path.IsClosed = true;
      this.MergePointsCheck(ref svgData);
      this.ApplyTransform(path.gO, svgData.TransformString);
      if (keepTransform)
        return;
      svgData.TransformString = string.Empty;
    }
  }

  private void MergePointsCheck(ref RageSvgObject svgData)
  {
    RageSvgPathElement path = svgData.Paths[svgData.딟()];
    if ((double) this.MergeRadius > 0.0 && path.Spline.땟().GetPointCount() <= 3)
      return;
    bool flag = false;
    do
    {
      int pointCount = path.Spline.땟().GetPointCount();
      for (int index = 0; index < pointCount; ++index)
        flag = path.Spline.땟().딟(index - 1, index, this.MergeRadius, this.DebugMeshCreation);
    }
    while (flag && path.Spline.땟().GetPointCount() > 3);
  }

  private Transform CreateGameObject(
    Transform parentTransform,
    ref RageSvgObject svgData,
    bool isGroup,
    bool subPath,
    bool derivedPath)
  {
    RageSvgPathElement newElement = RageSvgPathElement.딟();
    newElement.gO = new GameObject();
    newElement.gO.transform.parent = parentTransform;
    if (isGroup)
    {
      newElement.Spline = (딥) null;
      if (this.AutoLayeringGroup)
        ++svgData.GroupId;
      return newElement.gO.transform;
    }
    this.CreateShape(ref svgData, subPath, derivedPath, newElement);
    return newElement.gO.transform;
  }

  private void CreateShape(
    ref RageSvgObject svgData,
    bool subPath,
    bool derivedPath,
    RageSvgPathElement newElement)
  {
    string str = "<Path" + (object) svgData.PathId + ">";
    if (!derivedPath)
      ((Object) newElement.gO).name = str;
    else if (svgData.Id != string.Empty)
    {
      ((Object) newElement.gO).name = svgData.Id;
      svgData.Id = string.Empty;
    }
    else
      ((Object) newElement.gO).name = str;
    svgData.딟(newElement);
    this.SetZordering(newElement.gO, ref svgData);
    newElement.Spline = 땺.땔.딢(newElement.gO);
    newElement.Spline.떁();
    newElement.Spline.딝().땄(this.AntialiasWidth);
    svgData.PointIdx = 0;
    if (subPath)
      return;
    svgData.CursorPos = new Vector3(0.0f, 0.0f);
  }

  private void SetZordering(GameObject gO, ref RageSvgObject svgData)
  {
    RageSvgPathElement path = svgData.Paths[svgData.딟()];
    if (!this.AutoLayering)
    {
      gO.transform.position = new Vector3((float) path.gO.transform.position.x, (float) path.gO.transform.position.y, this.NewZOffset(ref svgData));
    }
    else
    {
      RageLayer rageLayer = gO.AddComponent<RageLayer>();
      if (Object.op_Equality((Object) rageLayer, (Object) null))
        return;
      rageLayer.Zorder = !this.AutoLayeringGroup ? (int) this.NewZOffset(ref svgData) : svgData.GroupId * Mathf.CeilToInt(this.ZsortOffset * -1f);
      rageLayer.ForceRefresh = this.AutoLayeringMaterials;
    }
  }

  private float NewZOffset(ref RageSvgObject svgData)
  {
    int pathId = svgData.PathId;
    ++svgData.PathId;
    return !this.AutoLayering ? (float) pathId * this.ZsortOffset : (float) (pathId * Mathf.CeilToInt(this.ZsortOffset * -1f));
  }

  private void CreateDotCircle(ref RageSvgPathElement path, RageSvgStyle style)
  {
    string str1 = "<circle ";
    Color outlineColor1 = style.OutlineColor1;
    bool hasOutline = style.HasOutline;
    string name = ((Object) ((Component) path.Spline.땟()).gameObject).name;
    string str2 = str1 + "stroke=\"none\" ";
    Vector3 vector3 = path.Spline.딧(0).땄();
    string str3 = str2 + "cx=\"" + (object) (float) vector3.x + "\" " + "cy=\"" + (object) (float) (-1.0 * vector3.y) + "\" " + "r=\"" + (object) path.Spline.딝().딟(0) + "\"/>";
    if (this.DebugMeshCreation)
      Debug.Log((object) ("svgDotCircle: " + ((Object) ((Component) path.Spline.땟()).gameObject).name + " " + str3));
    Transform parent = ((Component) path.Spline.땟()).transform.parent;
    XmlNode xmlNode = 땠.딟(str3);
    style.CornersType = 땺.땔.땘.땄;
    RageSvgObject svgData = RageSvgObject.딧();
    svgData.Style = style;
    this.ParseCircle(xmlNode.ChildNodes[0], ref svgData, false);
    svgData.땄().gO.transform.parent = parent;
    if (hasOutline)
    {
      path.Spline.딟(땺.땔.땷.땄);
      path.Spline.딟(outlineColor1);
    }
    else
      path.Spline.딟(땺.땔.땷.딟);
    ((Object) ((Component) path.Spline.땟()).gameObject).name = name;
  }

  private void ApplyVertexDensity(ref RageSvgPathElement path)
  {
    if (path.Spline.딷() < 2)
      return;
    if (path.IsLinear)
    {
      this.OptimizeLinearShape(ref path);
    }
    else
    {
      int maxVertexDensity = this.MaxVertexDensity;
      if (this.get_AdaptiveDensity())
      {
        Rect rect1 = path.Spline.딟();
        double width = (double) ((Rect) ref rect1).width;
        Rect rect2 = path.Spline.딟();
        double height = (double) ((Rect) ref rect2).height;
        maxVertexDensity = Mathf.RoundToInt(Mathf.Lerp((float) this.MinVertexDensity, (float) this.MaxVertexDensity, Mathf.Clamp((float) (width * height / (double) Camera.mainCamera.딟() * 10.0), 0.0f, 1f)));
      }
      path.Spline.딟(maxVertexDensity);
    }
  }

  private void ApplyTransform(GameObject targetGO, string newTransformString)
  {
    if (string.IsNullOrEmpty(newTransformString))
      return;
    if (this.DebugMeshCreation)
      Debug.Log((object) ("Transformation String: " + newTransformString));
    newTransformString = new Regex(",\\s*", RegexOptions.IgnoreCase).Replace(newTransformString, " ");
    string[] transformCommand = newTransformString.Split(' ', ',', '(', ')', '\r', '\n');
    transformCommand.딟();
    Vector3 vector3_1 = Vector3.zero;
    Vector3 vector3_2 = Vector3.zero;
    float num = 1f;
    for (int index = 0; index < transformCommand.Length; ++index)
    {
      if (transformCommand[index] == "matrix")
      {
        this.ApplyTransformMatrix(transformCommand, targetGO);
        break;
      }
      if (transformCommand[index] == "translate")
      {
        if (this.DebugMeshCreation)
          Debug.Log((object) ("\tTransform translate: " + (object) 땳.땄(transformCommand[index + 1]) + "," + (object) 땳.땄(transformCommand[index + 2])));
        vector3_1 = Vector3.op_Addition(vector3_1, new Vector3(땳.땄(transformCommand[index + 1]), 땳.땄(transformCommand[index + 2]), 0.0f));
        index += 2;
      }
      if (transformCommand[index] == "rotate")
      {
        if (this.DebugMeshCreation)
          Debug.Log((object) ("\tTransform Rotate: " + (object) 땳.땄(transformCommand[index + 1])));
        vector3_2 = Vector3.op_Addition(vector3_2, new Vector3(0.0f, 0.0f, 땳.땄(transformCommand[index + 1])));
        ++index;
      }
      if (transformCommand[index] == "scale")
      {
        if (this.DebugMeshCreation)
          Debug.Log((object) ("\tTransform scale: " + (object) 땳.땄(transformCommand[index + 1])));
        num *= 땳.땄(transformCommand[index + 1]);
        ++index;
      }
    }
    Transform transform1 = targetGO.transform;
    transform1.eulerAngles = Vector3.op_Subtraction(transform1.eulerAngles, vector3_2);
    Transform transform2 = targetGO.transform;
    transform2.localScale = Vector3.op_Multiply(transform2.localScale, num);
    Vector3 vector3_3 = Vector3.op_Addition(targetGO.transform.position, vector3_1);
    targetGO.transform.position = new Vector3((float) vector3_3.x, (float) (-1.0 * vector3_3.y), (float) vector3_3.z);
  }

  private void ApplyTransformMatrix(string[] transformCommand, GameObject targetGO)
  {
    string str1 = string.Empty;
    if (this.DebugMeshCreation)
    {
      foreach (string str2 in transformCommand)
        str1 = str1 + str2 + "|| ";
      Debug.Log((object) str1);
    }
    float num1 = 땳.땄(transformCommand[1]);
    float num2 = 땳.땄(transformCommand[2]);
    float num3 = 땳.땄(transformCommand[3]);
    float num4 = 땳.땄(transformCommand[4]);
    float num5 = 땳.땄(transformCommand[5]);
    float num6 = 땳.땄(transformCommand[6]);
    Vector3 position = targetGO.transform.position;
    Vector2 vector2;
    // ISSUE: explicit constructor call
    ((Vector2) ref vector2).\u002Ector((float) (position.x * (double) num1 + position.y * (double) num3) + num5, (float) (position.x * (double) num2 + position.y * (double) num4) + num6);
    float num7 = Mathf.Sign(num1);
    float num8 = Mathf.Sign(num4);
    float num9 = Mathf.Atan2(num3, num1) * 57.29578f;
    targetGO.transform.eulerAngles = new Vector3(0.0f, 0.0f, num7 * num8 * num9);
    float num10 = Mathf.Sqrt(Mathf.Pow(num1, 2f) + Mathf.Pow(num3, 2f));
    float num11 = Mathf.Sqrt(Mathf.Pow(num2, 2f) + Mathf.Pow(num4, 2f));
    targetGO.transform.position = new Vector3((float) vector2.x, (float) vector2.y, (float) targetGO.transform.position.z);
    targetGO.transform.localScale = new Vector3(num7 * num10, num8 * num11, 1f);
  }

  private void MoveTo(
    List<float> coords,
    ref RageSvgObject svgData,
    bool isRelative,
    bool keepX,
    bool keepY)
  {
    for (int index = 0; index < coords.Count; index = keepX || keepY ? index + 1 : index + 2)
    {
      Vector3 zero = Vector3.zero;
      if (keepX)
      {
        zero.x = svgData.CursorPos.x;
        zero.y = (__Null) -(double) coords[index];
        if (isRelative)
        {
          ref Vector3 local = ref zero;
          local.y = local.y + svgData.CursorPos.y;
        }
      }
      else if (keepY)
      {
        zero.x = (__Null) (double) coords[index];
        zero.y = svgData.CursorPos.y;
        if (isRelative)
        {
          ref Vector3 local = ref zero;
          local.x = local.x + svgData.CursorPos.x;
        }
      }
      else
      {
        zero.x = (__Null) (double) coords[index];
        zero.y = (__Null) -(double) coords[index + 1];
        if (isRelative)
        {
          ref Vector3 local1 = ref zero;
          local1.x = local1.x + svgData.CursorPos.x;
          ref Vector3 local2 = ref zero;
          local2.y = local2.y + svgData.CursorPos.y;
        }
      }
      if (this.DebugMeshCreation)
        Debug.Log((object) ("\tcurrent x/y: " + (object) (float) svgData.CursorPos.x + " " + (object) (float) svgData.CursorPos.y));
      this.AddSplinePoint(ref svgData, Vector3.zero, zero);
      if (this.DebugMeshCreation)
        Debug.Log((object) ("Move To (" + (object) svgData.PointIdx + ") X/Y: " + (object) (float) zero.x + "," + (object) (float) zero.y + " InCtrl: " + (object) svgData.Paths[svgData.딟()].Spline.땟().GetInControlPositionWorldSpace(svgData.PointIdx)));
      if (this.MidlineControls)
        this.CreateHalfwayTangents(ref svgData);
      svgData.CursorPos = zero;
      ++svgData.PointIdx;
    }
  }

  private void CurveTo(List<float> coords, ref RageSvgObject svgData, bool isRelative)
  {
    for (int index = 0; index < coords.Count; index += 6)
    {
      땺.딛 딛 = svgData.Paths[svgData.딟()].Spline.딧(svgData.PointIdx - 1);
      if (isRelative)
        딛.딶(new Vector3(coords[index], -coords[index + 1]));
      else
        딛.딧(new Vector3(coords[index], -coords[index + 1]));
      Vector3 newPos;
      // ISSUE: explicit constructor call
      ((Vector3) ref newPos).\u002Ector(coords[index + 4], -coords[index + 5]);
      Vector3 inCtrl;
      // ISSUE: explicit constructor call
      ((Vector3) ref inCtrl).\u002Ector(coords[index + 2], -coords[index + 3]);
      inCtrl = Vector3.op_Subtraction(inCtrl, newPos);
      if (isRelative)
        newPos = Vector3.op_Addition(newPos, svgData.CursorPos);
      this.AddSplinePoint(ref svgData, inCtrl, newPos);
      if (this.DebugMeshCreation)
        Debug.Log((object) ("(c)index: " + (object) (svgData.PointIdx - 1) + " Position: " + (object) (float) newPos.x + "," + (object) (float) newPos.y + " Pos: " + (object) (float) newPos.x + "," + (object) (float) newPos.y));
      ++svgData.PointIdx;
      svgData.CursorPos = newPos;
    }
  }

  private 땺.딛 AddSplinePoint(ref RageSvgObject svgData, Vector3 inCtrl, Vector3 newPos) => svgData.Paths[svgData.딟()].Spline.딟(svgData.PointIdx, newPos, inCtrl, Vector3.zero, 1f, false);

  private void SmoothCurveTo(List<float> coords, ref RageSvgObject svgData, bool isRelative)
  {
    int index = 0;
    bool flag = false;
    RageSvgPathElement path = svgData.Paths[svgData.딟()];
    if (svgData.PointIdx > 0)
      path.Spline.딧(svgData.PointIdx - 1).딟(true);
    else
      flag = true;
    for (; index < coords.Count; index += 4)
    {
      Vector3 newPos;
      // ISSUE: explicit constructor call
      ((Vector3) ref newPos).\u002Ector(coords[index + 2], -coords[index + 3]);
      if (isRelative)
        newPos = Vector3.op_Addition(newPos, svgData.CursorPos);
      Vector3 inCtrl;
      // ISSUE: explicit constructor call
      ((Vector3) ref inCtrl).\u002Ector(coords[index], -coords[index + 1]);
      Vector3 vector3;
      // ISSUE: explicit constructor call
      ((Vector3) ref vector3).\u002Ector(coords[index + 2], -coords[index + 3]);
      inCtrl = Vector3.op_Subtraction(inCtrl, vector3);
      this.AddSplinePoint(ref svgData, inCtrl, newPos);
      ++svgData.PointIdx;
      if (this.DebugMeshCreation)
        Debug.Log((object) ("(s)index: " + (object) svgData.PointIdx + " Pos: " + (object) (float) newPos.x + "," + (object) (float) newPos.y + " InCtrl: " + (object) (float) inCtrl.x + "," + (object) (float) inCtrl.y));
      svgData.CursorPos = newPos;
    }
    if (!flag)
      return;
    path.Spline.딧(svgData.PointIdx).딟(true);
  }

  private void OptimizeLinearShape(ref RageSvgPathElement path)
  {
    if (path.Spline.딷() == 2)
    {
      path.Spline.딟(24);
      path.Spline.딝().딟(땺.땔.땘.딟);
    }
    if (path.Spline.딷() != 4 || path.Spline.딝().딟() != 땺.땔.딸.땄)
      return;
    path.Spline.딟(1);
  }

  private void CreateHalfwayTangents(ref RageSvgObject svgData)
  {
    if (svgData.PointIdx <= 0)
      return;
    RageSvgPathElement path = svgData.Paths[svgData.딟()];
    땺.딛 딛1 = path.Spline.딧(svgData.PointIdx - 1);
    땺.딛 딛2 = path.Spline.딧(svgData.PointIdx);
    딛1.딧(new Vector3((float) ((딛2.땄().x + 딛1.땄().x) / 2.0), (float) ((딛2.땄().y + 딛1.땄().y) / 2.0), (float) ((딛2.땄().z + 딛1.땄().z) / 2.0)));
  }

  [DebuggerHidden]
  private static IEnumerable<string> 딟([In] string obj0)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    RageSvgIn.\u003CSplitCommands\u003Ec__Iterator1E commandsCIterator1E = new RageSvgIn.\u003CSplitCommands\u003Ec__Iterator1E()
    {
      딟 = obj0,
      딢 = obj0
    };
    // ISSUE: reference to a compiler-generated field
    commandsCIterator1E.딧 = -2;
    return (IEnumerable<string>) commandsCIterator1E;
  }

  [DebuggerHidden]
  private static IEnumerable<float> 땄([In] string obj0)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    RageSvgIn.\u003CParseCoordinates\u003Ec__Iterator1F coordinatesCIterator1F = new RageSvgIn.\u003CParseCoordinates\u003Ec__Iterator1F()
    {
      딟 = obj0,
      딧 = obj0
    };
    // ISSUE: reference to a compiler-generated field
    coordinatesCIterator1F.땄 = -2;
    return (IEnumerable<float>) coordinatesCIterator1F;
  }

  private void ParseStyle(ref RageSvgObject pathData)
  {
    if (this.DebugStyleCreation)
      Debug.Log((object) ("svgStyle String: " + pathData.StyleString));
    this.ParseRageStyle(ref pathData);
    pathData.StyleString = string.Empty;
  }

  private void ApplyStyle(RageSvgObject pathData)
  {
    foreach (RageSvgPathElement path in pathData.Paths)
      this.ApplyRageStyle(path, pathData.Style);
  }

  private void ParseRageStyle(ref RageSvgObject pathData)
  {
    RageSvgStyle style = pathData.Style;
    string styleString = pathData.StyleString;
    if (string.IsNullOrEmpty(styleString))
      return;
    foreach (RageSvgStyleEntry rageSvgStyleEntry in RageSvgIn.딧(styleString))
    {
      string command = rageSvgStyleEntry.Command;
      if (command != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (RageSvgIn.땥 == null)
        {
          // ISSUE: reference to a compiler-generated field
          RageSvgIn.땥 = new Dictionary<string, int>(9)
          {
            {
              "stroke-miterlimit",
              0
            },
            {
              "stroke-linejoin",
              1
            },
            {
              "stroke-linecap",
              2
            },
            {
              "opacity",
              3
            },
            {
              "fill",
              4
            },
            {
              "stroke",
              5
            },
            {
              "stroke-width",
              6
            },
            {
              "stroke-opacity",
              7
            },
            {
              "fill-opacity",
              8
            }
          };
        }
        int num;
        // ISSUE: reference to a compiler-generated field
        if (RageSvgIn.땥.TryGetValue(command, out num))
        {
          switch (num)
          {
            case 0:
              if (rageSvgStyleEntry.Value != "0")
              {
                style.CornersType = 땺.땔.땘.땄;
                continue;
              }
              continue;
            case 1:
              style.CornersType = !(rageSvgStyleEntry.Value == "miter") ? 땺.땔.땘.딟 : 땺.땔.땘.땄;
              continue;
            case 3:
              style.FillColor1Alpha = 땳.땄(rageSvgStyleEntry.Value);
              style.OutlineAlpha = 땳.땄(rageSvgStyleEntry.Value);
              continue;
            case 4:
              if (rageSvgStyleEntry.Value == "none" || rageSvgStyleEntry.Value == "transparent")
              {
                style.HasFill = false;
                continue;
              }
              style.HasFill = true;
              if (rageSvgStyleEntry.Value[0] == '#')
              {
                style.FillColor1 = 땺.땴.땄(rageSvgStyleEntry.Value.Substring(1));
                continue;
              }
              if (rageSvgStyleEntry.Value.StartsWith("url"))
              {
                int length = rageSvgStyleEntry.Value.Length - 6;
                RageSvgGradient rageSvgGradient;
                if (this.딟.TryGetValue(rageSvgStyleEntry.Value.Substring(5, length), out rageSvgGradient))
                {
                  style.HasGradient = true;
                  style.RageSvgGradient = rageSvgGradient;
                  continue;
                }
                continue;
              }
              style.FillColor1 = 땺.땴.땄(땺.땴.딟(rageSvgStyleEntry.Value));
              continue;
            case 5:
              if (rageSvgStyleEntry.Value == "none" || rageSvgStyleEntry.Value == "transparent")
              {
                style.HasOutline = false;
                continue;
              }
              style.OutlineColor1 = rageSvgStyleEntry.Value[0] != '#' ? 땺.땴.땄(땺.땴.딟(rageSvgStyleEntry.Value)) : 땺.땴.땄(rageSvgStyleEntry.Value.Substring(1));
              style.HasOutline = true;
              continue;
            case 6:
              string str = 땳.딟(rageSvgStyleEntry.Value);
              style.OutlineWidth = 땳.땄(str);
              if (this.DebugMeshCreation)
              {
                Debug.Log((object) ("stroke width ===> " + str));
                continue;
              }
              continue;
            case 7:
              style.OutlineAlpha = 땳.땄(rageSvgStyleEntry.Value);
              continue;
            case 8:
              style.FillColor1Alpha = 땳.땄(rageSvgStyleEntry.Value);
              continue;
            default:
              continue;
          }
        }
      }
    }
    if (!this.DebugStyleCreation)
      return;
    Debug.Log((object) ("### After Parse Style ###\n>>> Current Fill: " + (object) style.FillType + " :: Color: " + (object) style.FillColor1 + " :: Has Fill? " + (object) style.HasFill));
  }

  private void ApplyRageStyle(RageSvgPathElement path, RageSvgStyle style)
  {
    style.OutlineType = !style.HasOutline ? 땺.땔.딸.딟 : (!path.IsClosed ? 땺.땔.딸.딧 : 땺.땔.딸.땄);
    style.FillType = !style.HasFill ? 땺.땔.땷.딟 : (!style.HasGradient ? 땺.땔.땷.땄 : 땺.땔.땷.딧);
    if (this.DebugStyleCreation)
    {
      Debug.Log((object) ("\tOutline: " + (object) style.OutlineType + "; Has Outline: " + (object) style.HasOutline));
      Debug.Log((object) ("\tFill: " + (object) style.FillType + "; Has Fill: " + (object) style.HasFill));
      Debug.Log((object) style.땄());
    }
    if (path.Spline == null)
      return;
    this.ApplyStyleToSpline(path, style);
    if (path.Spline.딷() == 1)
      this.CreateDotCircle(ref path, style);
    this.ApplyVertexDensity(ref path);
    path.Spline.땟().RefreshMeshInEditor(true, true, true);
  }

  private void ApplyStyleToSpline(RageSvgPathElement path, RageSvgStyle style)
  {
    path.Spline.딟(style.FillType);
    path.Spline.딝().딟(style.OutlineType);
    path.Spline.딝().딟(style.OutlineWidth);
    path.Spline.딝().딟(style.CornersType);
    Color fillColor1 = style.FillColor1;
    fillColor1.a = (__Null) (double) style.FillColor1Alpha;
    if (style.FillType == 땺.땔.땷.딧)
      this.ApplyFillGradient(path, style);
    else
      path.Spline.딟(fillColor1);
    Color outlineColor1 = style.OutlineColor1;
    outlineColor1.a = (__Null) (double) style.OutlineAlpha;
    path.Spline.딝().딟(outlineColor1);
  }

  private void ParseGradient(
    XmlNode svgEntry,
    RageSvgObject pathData,
    RageSvgGradient.때 gradientType,
    bool subPath,
    int level)
  {
    pathData.Gradient = RageSvgGradient.딟();
    pathData.Gradient.Type = gradientType;
    float num1 = 0.0f;
    string gradientTransformString = string.Empty;
    XmlAttributeCollection attributes = svgEntry.Attributes;
    if (attributes != null)
    {
      foreach (XmlAttribute xmlAttribute in (XmlNamedNodeMap) attributes)
      {
        string name = xmlAttribute.Name;
        string str = xmlAttribute.Value;
        string key = name;
        if (key != null)
        {
          // ISSUE: reference to a compiler-generated field
          if (RageSvgIn.딝 == null)
          {
            // ISSUE: reference to a compiler-generated field
            RageSvgIn.딝 = new Dictionary<string, int>(12)
            {
              {
                "id",
                0
              },
              {
                "xlink:href",
                1
              },
              {
                "x1",
                2
              },
              {
                "y1",
                3
              },
              {
                "x2",
                4
              },
              {
                "y2",
                5
              },
              {
                "cx",
                6
              },
              {
                "cy",
                7
              },
              {
                "fx",
                8
              },
              {
                "fy",
                9
              },
              {
                "r",
                10
              },
              {
                "gradientTransform",
                11
              }
            };
          }
          int num2;
          // ISSUE: reference to a compiler-generated field
          if (RageSvgIn.딝.TryGetValue(key, out num2))
          {
            switch (num2)
            {
              case 0:
                pathData.Gradient.Id = str;
                continue;
              case 1:
                this.ParseGradientLink(ref pathData.Gradient, str.Substring(1));
                continue;
              case 2:
                pathData.Gradient.X1 = 땳.땄(str);
                continue;
              case 3:
                pathData.Gradient.Y1 = 땳.땄(str);
                continue;
              case 4:
                pathData.Gradient.X2 = 땳.땄(str);
                continue;
              case 5:
                pathData.Gradient.Y2 = 땳.땄(str);
                continue;
              case 6:
                pathData.Gradient.X2 = 땳.땄(str);
                continue;
              case 7:
                pathData.Gradient.Y2 = 땳.땄(str);
                continue;
              case 8:
                pathData.Gradient.X1 = 땳.땄(str);
                continue;
              case 9:
                pathData.Gradient.Y1 = 땳.땄(str);
                continue;
              case 10:
                num1 = 땳.땄(str);
                continue;
              case 11:
                gradientTransformString = str;
                continue;
              default:
                continue;
            }
          }
        }
      }
    }
    if (!땺.땢.딟(num1, 0.0f))
    {
      pathData.Gradient.X2 = pathData.Gradient.X1 + num1;
      pathData.Gradient.Y2 += num1;
    }
    if (this.DebugStyleCreation)
      Debug.Log((object) ("######### Gradient children Count: " + (object) svgEntry.ChildNodes.Count));
    if (svgEntry.ChildNodes.Count != 0)
    {
      ++level;
      foreach (XmlNode childNode in svgEntry.ChildNodes)
        this.ParseSvg(childNode, pathData, subPath, level);
    }
    this.ApplyGradientTransform(gradientTransformString, pathData);
    if (this.딟.ContainsKey(pathData.Gradient.Id))
      return;
    if (this.DebugStyleCreation)
      Debug.Log((object) ("Gradient entry added: " + pathData.Gradient.Id));
    this.딟.Add(pathData.Gradient.Id, pathData.Gradient);
  }

  private void ParseGradientLink(ref RageSvgGradient currentGradient, string gradientKey)
  {
    RageSvgGradient rageSvgGradient;
    if (!this.딟.TryGetValue(gradientKey, out rageSvgGradient))
      return;
    currentGradient.딟(rageSvgGradient);
  }

  private void ParseGradientStop(XmlNode svgEntry, RageSvgObject pathData)
  {
    string s1 = string.Empty;
    string str1 = string.Empty;
    string s2 = string.Empty;
    XmlAttributeCollection attributes = svgEntry.Attributes;
    if (attributes != null)
    {
      foreach (XmlAttribute xmlAttribute in (XmlNamedNodeMap) attributes)
      {
        string name = xmlAttribute.Name;
        string str2 = xmlAttribute.Value;
        if (this.DebugStyleCreation)
          Debug.Log((object) ("Gradient Stop: " + name + " " + str2));
        string key = name;
        if (key != null)
        {
          // ISSUE: reference to a compiler-generated field
          if (RageSvgIn.떂 == null)
          {
            // ISSUE: reference to a compiler-generated field
            RageSvgIn.떂 = new Dictionary<string, int>(4)
            {
              {
                "offset",
                0
              },
              {
                "stop-color",
                1
              },
              {
                "stop-opacity",
                2
              },
              {
                "style",
                3
              }
            };
          }
          int num1;
          // ISSUE: reference to a compiler-generated field
          if (RageSvgIn.떂.TryGetValue(key, out num1))
          {
            switch (num1)
            {
              case 0:
                s1 = str2;
                continue;
              case 1:
                str1 = str2.Substring(1);
                continue;
              case 2:
                s2 = str2;
                continue;
              case 3:
                using (IEnumerator<RageSvgStyleEntry> enumerator = RageSvgIn.딧(str2).GetEnumerator())
                {
                  while (enumerator.MoveNext())
                  {
                    RageSvgStyleEntry current = enumerator.Current;
                    string command = current.Command;
                    if (command != null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      if (RageSvgIn.떎 == null)
                      {
                        // ISSUE: reference to a compiler-generated field
                        RageSvgIn.떎 = new Dictionary<string, int>(2)
                        {
                          {
                            "stop-color",
                            0
                          },
                          {
                            "stop-opacity",
                            1
                          }
                        };
                      }
                      int num2;
                      // ISSUE: reference to a compiler-generated field
                      if (RageSvgIn.떎.TryGetValue(command, out num2))
                      {
                        switch (num2)
                        {
                          case 0:
                            str1 = current.Value.Substring(1);
                            continue;
                          case 1:
                            s2 = current.Value;
                            continue;
                          default:
                            continue;
                        }
                      }
                    }
                  }
                  continue;
                }
              default:
                continue;
            }
          }
        }
      }
    }
    Color color = 땺.땴.땄(str1);
    if (s2 != string.Empty)
      color.a = (__Null) (double) float.Parse(s2);
    if ((double) float.Parse(s1) < 0.5)
      pathData.Gradient.EndColor = color;
    else
      pathData.Gradient.StartColor = color;
  }

  private bool ParseSvgStyle(string svgCommand, string svgValue, ref RageSvgObject pathData)
  {
    string key = svgCommand;
    if (key != null)
    {
      // ISSUE: reference to a compiler-generated field
      if (RageSvgIn.땭 == null)
      {
        // ISSUE: reference to a compiler-generated field
        RageSvgIn.땭 = new Dictionary<string, int>(10)
        {
          {
            "opacity",
            0
          },
          {
            "stroke-miterlimit",
            0
          },
          {
            "stroke-linejoin",
            0
          },
          {
            "stroke",
            0
          },
          {
            "stroke-opacity",
            0
          },
          {
            "stroke-width",
            0
          },
          {
            "stroke-linecap",
            0
          },
          {
            "fill",
            0
          },
          {
            "fill-opacity",
            0
          },
          {
            "style",
            1
          }
        };
      }
      int num;
      // ISSUE: reference to a compiler-generated field
      if (RageSvgIn.땭.TryGetValue(key, out num))
      {
        switch (num)
        {
          case 0:
            RageSvgObject rageSvgObject = pathData;
            rageSvgObject.StyleString = rageSvgObject.StyleString + svgCommand + ":" + svgValue + ";";
            return true;
          case 1:
            if (pathData.StyleString != string.Empty && pathData.StyleString[pathData.StyleString.Length - 1] != ';')
              pathData.StyleString += ";";
            pathData.StyleString += svgValue;
            return true;
        }
      }
    }
    return false;
  }

  private void ApplyGradientTransform(string gradientTransformString, RageSvgObject pathData)
  {
    if (gradientTransformString == string.Empty)
    {
      pathData.Gradient.Y1 *= -1f;
      pathData.Gradient.Y2 *= -1f;
    }
    else
    {
      Vector2 target1;
      // ISSUE: explicit constructor call
      ((Vector2) ref target1).\u002Ector(pathData.Gradient.X1, pathData.Gradient.Y1);
      Vector2 target2 = this.ApplyTransform(target1, gradientTransformString);
      pathData.Gradient.딟(target2);
      // ISSUE: explicit constructor call
      ((Vector2) ref target2).\u002Ector(pathData.Gradient.X2, pathData.Gradient.Y2);
      target2 = this.ApplyTransform(target2, gradientTransformString);
      pathData.Gradient.땄(target2);
    }
  }

  private void ApplyFillGradient(RageSvgPathElement path, RageSvgStyle style)
  {
    RageSvgGradient rageSvgGradient = style.RageSvgGradient;
    Vector2 vector2_1;
    // ISSUE: explicit constructor call
    ((Vector2) ref vector2_1).\u002Ector(rageSvgGradient.X1, rageSvgGradient.Y1);
    Vector2 vector2_2;
    // ISSUE: explicit constructor call
    ((Vector2) ref vector2_2).\u002Ector(rageSvgGradient.X2, rageSvgGradient.Y2);
    if (this.DebugStyleCreation)
      Debug.Log((object) ("\tGradient Start Color:" + (object) rageSvgGradient.StartColor));
    path.Spline.땥().딟(rageSvgGradient.StartColor);
    path.Spline.땥().땄(rageSvgGradient.EndColor);
    path.Spline.땥().딟(true);
    path.Spline.땥().딟(Vector2.op_Division(Vector2.op_Addition(vector2_1, vector2_2), 2f));
    땺.떓 떓 = path.Spline.땥();
    Vector2 vector2_3 = Vector2.op_Division(Vector2.op_Subtraction(vector2_2, vector2_1), 2f);
    double num1 = 1.0 / (double) ((Vector2) ref vector2_3).magnitude;
    떓.딟((float) num1);
    float num2 = 땺.땴.딟(new Vector2(rageSvgGradient.X1, rageSvgGradient.Y1), new Vector2(rageSvgGradient.X2, rageSvgGradient.Y2));
    if (this.DebugStyleCreation)
      Debug.Log((object) ("\tGradient Angle: " + (object) num2));
    path.Spline.땥().땄(num2);
  }

  [DebuggerHidden]
  private static IEnumerable<RageSvgStyleEntry> 딧([In] string obj0)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    RageSvgIn.\u003CGetSvgStyleCommands\u003Ec__Iterator20 commandsCIterator20 = new RageSvgIn.\u003CGetSvgStyleCommands\u003Ec__Iterator20()
    {
      딟 = obj0,
      땄 = obj0
    };
    // ISSUE: reference to a compiler-generated field
    commandsCIterator20.딧 = -2;
    return (IEnumerable<RageSvgStyleEntry>) commandsCIterator20;
  }

  private Vector2 ApplyTransform(Vector2 target, string newTransformString)
  {
    if (string.IsNullOrEmpty(newTransformString))
      return target;
    if (this.DebugMeshCreation)
      Debug.Log((object) ("Transformation String: " + newTransformString));
    string[] strArray = newTransformString.Split(' ', ',', '(', ')', '\r', '\n');
    strArray.딟();
    for (int index = 0; index < strArray.Length; ++index)
    {
      if (strArray[index] == "matrix")
      {
        float num1 = 땳.땄(strArray[1]);
        float num2 = 땳.땄(strArray[2]);
        float num3 = 땳.땄(strArray[3]);
        float num4 = 땳.땄(strArray[4]);
        float num5 = 땳.땄(strArray[5]);
        float num6 = 땳.땄(strArray[6]);
        // ISSUE: explicit constructor call
        ((Vector2) ref target).\u002Ector((float) (target.x * (double) num1 + target.y * (double) num3) + num5, (float) (target.x * (double) num2 + target.y * (double) num4) + num6);
      }
      if (strArray[index] == "translate")
      {
        if (this.DebugMeshCreation)
          Debug.Log((object) ("\tTransform translate: " + (object) 땳.땄(strArray[index + 1]) + "," + (object) 땳.땄(strArray[index + 2])));
        Vector2 vector2;
        // ISSUE: explicit constructor call
        ((Vector2) ref vector2).\u002Ector(땳.땄(strArray[index + 1]), 땳.땄(strArray[index + 2]));
        // ISSUE: explicit constructor call
        ((Vector2) ref target).\u002Ector((float) (target.x + vector2.x), (float) (target.y + vector2.y));
        index += 2;
      }
    }
    return target;
  }

  private enum 딱
  {
    딟,
    땄,
  }
}
