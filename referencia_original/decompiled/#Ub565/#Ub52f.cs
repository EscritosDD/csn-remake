// Decompiled with JetBrains decompiler
// Type: 땥.딯
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;

namespace 땥
{
  public class 딯
  {
    private List<딺> 딟 = new List<딺>();
    private List<떀> 딟 = new List<떀>();
    private List<딝.땺> 딟 = new List<딝.땺>();
    private List<땺.땏> 딟 = new List<땺.땏>();

    public 땱 딟([In] Stream obj0)
    {
      땱 땱 = new 땱(떁.딟());
      this.딟(땱, obj0);
      return 땱;
    }

    public void 딟([In] 땱 obj0, [In] Stream obj1)
    {
      obj0.딷();
      딴 딴1 = 딩.땄(obj1);
      if (딴1.딧().ToLower() != "world")
        throw new Exception();
      foreach (딴 딴2 in (IEnumerable<딴>) 딴1.딟())
      {
        if (딴2.딧().ToLower() == "gravity")
          obj0.딟 = this.딟(딴2);
      }
      int num1;
      foreach (딴 딴3 in (IEnumerable<딴>) 딴1.딟())
      {
        if (딴3.딧().ToLower() == "shapes")
        {
          foreach (딴 딴4 in (IEnumerable<딴>) 딴3.딟())
          {
            if (딴4.딧().ToLower() != "shape")
              throw new Exception();
            switch ((int) Enum.Parse(typeof (땺.땙), 딴4.땄()[0].땄(), true))
            {
              case 0:
                땺.땶 땶 = new 땺.땶();
                foreach (딴 딴5 in (IEnumerable<딴>) 딴4.딟())
                {
                  string lower = 딴5.딧().ToLower();
                  if (lower != null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    if (딯.딟 == null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      딯.딟 = new Dictionary<string, int>(2)
                      {
                        {
                          "radius",
                          0
                        },
                        {
                          "position",
                          1
                        }
                      };
                    }
                    // ISSUE: reference to a compiler-generated field
                    if (딯.딟.TryGetValue(lower, out num1))
                    {
                      if (num1 != 0)
                      {
                        if (num1 == 1)
                        {
                          땶.딟(this.딟(딴5));
                          continue;
                        }
                      }
                      else
                      {
                        땶.땄(float.Parse(딴5.딢()));
                        continue;
                      }
                    }
                  }
                  throw new Exception();
                }
                this.딟.Add((땺.땏) 땶);
                continue;
              case 1:
                땺.땖 땖 = new 땺.땖();
                foreach (딴 딴6 in (IEnumerable<딴>) 딴4.딟())
                {
                  string lower = 딴6.딧().ToLower();
                  if (lower != null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    if (딯.딧 == null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      딯.딧 = new Dictionary<string, int>(6)
                      {
                        {
                          "hasvertex0",
                          0
                        },
                        {
                          "hasvertex3",
                          1
                        },
                        {
                          "vertex0",
                          2
                        },
                        {
                          "vertex1",
                          3
                        },
                        {
                          "vertex2",
                          4
                        },
                        {
                          "vertex3",
                          5
                        }
                      };
                    }
                    // ISSUE: reference to a compiler-generated field
                    if (딯.딧.TryGetValue(lower, out num1))
                    {
                      switch (num1)
                      {
                        case 0:
                          땖.딟 = bool.Parse(딴6.딢());
                          continue;
                        case 1:
                          땖.딟 = bool.Parse(딴6.딢());
                          continue;
                        case 2:
                          땖.딟 = this.딟(딴6);
                          continue;
                        case 3:
                          땖.딟(this.딟(딴6));
                          continue;
                        case 4:
                          땖.땄(this.딟(딴6));
                          continue;
                        case 5:
                          땖.땄 = this.딟(딴6);
                          continue;
                      }
                    }
                  }
                  throw new Exception();
                }
                this.딟.Add((땺.땏) 땖);
                continue;
              case 2:
                땺.떅 떅 = new 땺.떅();
                foreach (딴 딴7 in (IEnumerable<딴>) 딴4.딟())
                {
                  string lower = 딴7.딧().ToLower();
                  if (lower != null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    if (딯.땄 == null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      딯.땄 = new Dictionary<string, int>(2)
                      {
                        {
                          "vertices",
                          0
                        },
                        {
                          "centroid",
                          1
                        }
                      };
                    }
                    // ISSUE: reference to a compiler-generated field
                    if (딯.땄.TryGetValue(lower, out num1))
                    {
                      switch (num1)
                      {
                        case 0:
                          List<떁> 떁List = new List<떁>();
                          foreach (딴 딴8 in (IEnumerable<딴>) 딴7.딟())
                            떁List.Add(this.딟(딴8));
                          떅.딟(new 땨(떁List.ToArray()));
                          continue;
                        case 1:
                          ((땺.땏) 떅).딟.딟 = this.딟(딴7);
                          continue;
                        default:
                          continue;
                      }
                    }
                  }
                }
                this.딟.Add((땺.땏) 떅);
                continue;
              default:
                continue;
            }
          }
        }
      }
      foreach (딴 딴9 in (IEnumerable<딴>) 딴1.딟())
      {
        if (딴9.딧().ToLower() == "fixtures")
        {
          foreach (딴 딴10 in (IEnumerable<딴>) 딴9.딟())
          {
            떀 떀 = new 떀();
            if (딴10.딧().ToLower() != "fixture")
              throw new Exception();
            foreach (딴 딴11 in (IEnumerable<딴>) 딴10.딟())
            {
              string lower1 = 딴11.딧().ToLower();
              if (lower1 != null)
              {
                // ISSUE: reference to a compiler-generated field
                if (딯.땃 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  딯.땃 = new Dictionary<string, int>(7)
                  {
                    {
                      "shape",
                      0
                    },
                    {
                      "density",
                      1
                    },
                    {
                      "filterdata",
                      2
                    },
                    {
                      "friction",
                      3
                    },
                    {
                      "issensor",
                      4
                    },
                    {
                      "restitution",
                      5
                    },
                    {
                      "userdata",
                      6
                    }
                  };
                }
                // ISSUE: reference to a compiler-generated field
                if (딯.땃.TryGetValue(lower1, out num1))
                {
                  switch (num1)
                  {
                    case 0:
                      떀.딟(this.딟[int.Parse(딴11.딢())]);
                      continue;
                    case 1:
                      떀.땃().딟(float.Parse(딴11.딢()));
                      continue;
                    case 2:
                      using (IEnumerator<딴> enumerator = 딴11.딟().GetEnumerator())
                      {
                        while (enumerator.MoveNext())
                        {
                          딴 current = enumerator.Current;
                          string lower2 = current.딧().ToLower();
                          if (lower2 != null)
                          {
                            // ISSUE: reference to a compiler-generated field
                            if (딯.딢 == null)
                            {
                              // ISSUE: reference to a compiler-generated field
                              딯.딢 = new Dictionary<string, int>(3)
                              {
                                {
                                  "categorybits",
                                  0
                                },
                                {
                                  "maskbits",
                                  1
                                },
                                {
                                  "groupindex",
                                  2
                                }
                              };
                            }
                            int num2;
                            // ISSUE: reference to a compiler-generated field
                            if (딯.딢.TryGetValue(lower2, out num2))
                            {
                              switch (num2)
                              {
                                case 0:
                                  떀.땄 = (땑) int.Parse(current.딢());
                                  continue;
                                case 1:
                                  떀.딟 = (땑) int.Parse(current.딢());
                                  continue;
                                case 2:
                                  떀.딟 = short.Parse(current.딢());
                                  continue;
                                default:
                                  continue;
                              }
                            }
                          }
                        }
                        continue;
                      }
                    case 3:
                      떀.딟(float.Parse(딴11.딢()));
                      continue;
                    case 4:
                      떀.딟(bool.Parse(딴11.딢()));
                      continue;
                    case 5:
                      떀.땄(float.Parse(딴11.딢()));
                      continue;
                    case 6:
                      떀.딟(this.딟(딴11, (Type) null, false));
                      continue;
                    default:
                      continue;
                  }
                }
              }
            }
            this.딟.Add(떀);
          }
        }
      }
      foreach (딴 딴12 in (IEnumerable<딴>) 딴1.딟())
      {
        if (딴12.딧().ToLower() == "bodies")
        {
          foreach (딴 딴13 in (IEnumerable<딴>) 딴12.딟())
          {
            딺 딺 = new 딺(obj0);
            if (딴13.딧().ToLower() != "body")
              throw new Exception();
            딺.딟((땎) Enum.Parse(typeof (땎), 딴13.땄()[0].땄(), true));
            foreach (딴 딴14 in (IEnumerable<딴>) 딴13.딟())
            {
              string lower = 딴14.딧().ToLower();
              if (lower != null)
              {
                // ISSUE: reference to a compiler-generated field
                if (딯.딶 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  딯.딶 = new Dictionary<string, int>(13)
                  {
                    {
                      "active",
                      0
                    },
                    {
                      "allowsleep",
                      1
                    },
                    {
                      "angle",
                      2
                    },
                    {
                      "angulardamping",
                      3
                    },
                    {
                      "angularvelocity",
                      4
                    },
                    {
                      "awake",
                      5
                    },
                    {
                      "bullet",
                      6
                    },
                    {
                      "fixedrotation",
                      7
                    },
                    {
                      "lineardamping",
                      8
                    },
                    {
                      "linearvelocity",
                      9
                    },
                    {
                      "position",
                      10
                    },
                    {
                      "userdata",
                      11
                    },
                    {
                      "fixtures",
                      12
                    }
                  };
                }
                // ISSUE: reference to a compiler-generated field
                if (딯.딶.TryGetValue(lower, out num1))
                {
                  switch (num1)
                  {
                    case 0:
                      if (bool.Parse(딴14.딢()))
                      {
                        딺.딟 |= 떑.땓;
                        continue;
                      }
                      딺.딟 &= ~떑.땓;
                      continue;
                    case 1:
                      딺.땄(bool.Parse(딴14.딢()));
                      continue;
                    case 2:
                      떁 떁1 = 딺.땼();
                      딺.땄(ref 떁1, float.Parse(딴14.딢()));
                      continue;
                    case 3:
                      딺.딢(float.Parse(딴14.딢()));
                      continue;
                    case 4:
                      딺.땄(float.Parse(딴14.딢()));
                      continue;
                    case 5:
                      딺.딧(bool.Parse(딴14.딢()));
                      continue;
                    case 6:
                      딺.딟(bool.Parse(딴14.딢()));
                      continue;
                    case 7:
                      딺.땃(bool.Parse(딴14.딢()));
                      continue;
                    case 8:
                      딺.딧(float.Parse(딴14.딢()));
                      continue;
                    case 9:
                      딺.딟(this.딟(딴14));
                      continue;
                    case 10:
                      float num3 = 딺.땢();
                      떁 떁2 = this.딟(딴14);
                      딺.땄(ref 떁2, num3);
                      continue;
                    case 11:
                      딺.딟(this.딟(딴14, (Type) null, false));
                      continue;
                    case 12:
                      using (IEnumerator<딴> enumerator = 딴14.딟().GetEnumerator())
                      {
                        while (enumerator.MoveNext())
                        {
                          떀 떀1 = this.딟[int.Parse(enumerator.Current.딢())];
                          떀 떀2 = new 떀(딺, 떀1.땃());
                          떀2.땄(떀1.떂());
                          떀2.딟(떀1.땺());
                          떀2.딟(떀1.떎());
                          떀2.딟(떀1.땄());
                          떀2.땄(떀1.딧());
                          떀2.딟(떀1.딟());
                        }
                        continue;
                      }
                    default:
                      continue;
                  }
                }
              }
            }
            this.딟.Add(딺);
          }
        }
      }
      foreach (딴 딴15 in (IEnumerable<딴>) 딴1.딟())
      {
        if (딴15.딧().ToLower() == "joints")
        {
          foreach (딴 딴16 in (IEnumerable<딴>) 딴15.딟())
          {
            딝.딢 딢 = !(딴16.딧().ToLower() != "joint") ? (딝.딢) Enum.Parse(typeof (딝.딢), 딴16.땄()[0].땄(), true) : throw new Exception();
            int index1 = -1;
            int index2 = -1;
            bool flag = false;
            object obj = (object) null;
            foreach (딴 딴17 in (IEnumerable<딴>) 딴16.딟())
            {
              string lower = 딴17.딧().ToLower();
              if (lower != null)
              {
                // ISSUE: reference to a compiler-generated field
                if (딯.땓 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  딯.땓 = new Dictionary<string, int>(4)
                  {
                    {
                      "bodya",
                      0
                    },
                    {
                      "bodyb",
                      1
                    },
                    {
                      "collideconnected",
                      2
                    },
                    {
                      "userdata",
                      3
                    }
                  };
                }
                // ISSUE: reference to a compiler-generated field
                if (딯.땓.TryGetValue(lower, out num1))
                {
                  switch (num1)
                  {
                    case 0:
                      index1 = int.Parse(딴17.딢());
                      continue;
                    case 1:
                      index2 = int.Parse(딴17.딢());
                      continue;
                    case 2:
                      flag = bool.Parse(딴17.딢());
                      continue;
                    case 3:
                      obj = this.딟(딴17, (Type) null, false);
                      continue;
                    default:
                      continue;
                  }
                }
              }
            }
            딺 딺1 = this.딟[index1];
            딺 딺2 = this.딟[index2];
            딝.땺 땺;
            switch (딢)
            {
              case 딝.딢.딟:
                땺 = (딝.땺) new 떒();
                break;
              case 딝.딢.땄:
                땺 = (딝.땺) new 땬();
                break;
              case 딝.딢.딧:
                땺 = (딝.땺) new 땧();
                break;
              case 딝.딢.딢:
                땺 = (딝.땺) new 떊();
                break;
              case 딝.딢.땃:
                throw new Exception("GearJoint is not supported.");
              case 딝.딢.딶:
                땺 = (딝.땺) new 딝.딧();
                break;
              case 딝.딢.땓:
                땺 = (딝.땺) new 딝.땄();
                break;
              case 딝.딢.땺:
                땺 = (딝.땺) new 딬();
                break;
              case 딝.딢.땥:
                땺 = (딝.땺) new 딝.딟();
                break;
              case 딝.딢.딝:
                땺 = (딝.땺) new 딼();
                break;
              case 딝.딢.떎:
                땺 = (딝.땺) new 땮();
                break;
              default:
                throw new Exception("Invalid or unsupported joint.");
            }
            땺.딟(flag);
            땺.딟(obj);
            땺.딟(딺1);
            땺.땄(딺2);
            this.딟.Add(땺);
            obj0.딟(땺);
            foreach (딴 딴18 in (IEnumerable<딴>) 딴16.딟())
            {
              switch (딢)
              {
                case 딝.딢.딟:
                  string lower3 = 딴18.딧().ToLower();
                  if (lower3 != null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    if (딯.떎 == null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      딯.떎 = new Dictionary<string, int>(9)
                      {
                        {
                          "enablelimit",
                          0
                        },
                        {
                          "enablemotor",
                          1
                        },
                        {
                          "localanchora",
                          2
                        },
                        {
                          "localanchorb",
                          3
                        },
                        {
                          "maxmotortorque",
                          4
                        },
                        {
                          "motorspeed",
                          5
                        },
                        {
                          "lowerangle",
                          6
                        },
                        {
                          "upperangle",
                          7
                        },
                        {
                          "referenceangle",
                          8
                        }
                      };
                    }
                    // ISSUE: reference to a compiler-generated field
                    if (딯.떎.TryGetValue(lower3, out num1))
                    {
                      switch (num1)
                      {
                        case 0:
                          ((떒) 땺).딟(bool.Parse(딴18.딢()));
                          continue;
                        case 1:
                          ((떒) 땺).땄(bool.Parse(딴18.딢()));
                          continue;
                        case 2:
                          ((떒) 땺).딟 = this.딟(딴18);
                          continue;
                        case 3:
                          ((떒) 땺).땄 = this.딟(딴18);
                          continue;
                        case 4:
                          ((떒) 땺).땓(float.Parse(딴18.딢()));
                          continue;
                        case 5:
                          ((떒) 땺).딶(float.Parse(딴18.딢()));
                          continue;
                        case 6:
                          ((떒) 땺).딢(float.Parse(딴18.딢()));
                          continue;
                        case 7:
                          ((떒) 땺).땃(float.Parse(딴18.딢()));
                          continue;
                        case 8:
                          ((떒) 땺).딧(float.Parse(딴18.딢()));
                          continue;
                        default:
                          continue;
                      }
                    }
                    else
                      continue;
                  }
                  else
                    continue;
                case 딝.딢.땄:
                  string lower4 = 딴18.딧().ToLower();
                  if (lower4 != null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    if (딯.딝 == null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      딯.딝 = new Dictionary<string, int>(10)
                      {
                        {
                          "enablelimit",
                          0
                        },
                        {
                          "enablemotor",
                          1
                        },
                        {
                          "localanchora",
                          2
                        },
                        {
                          "localanchorb",
                          3
                        },
                        {
                          "local1axis1",
                          4
                        },
                        {
                          "maxmotorforce",
                          5
                        },
                        {
                          "motorspeed",
                          6
                        },
                        {
                          "lowertranslation",
                          7
                        },
                        {
                          "uppertranslation",
                          8
                        },
                        {
                          "referenceangle",
                          9
                        }
                      };
                    }
                    // ISSUE: reference to a compiler-generated field
                    if (딯.딝.TryGetValue(lower4, out num1))
                    {
                      switch (num1)
                      {
                        case 0:
                          ((땬) 땺).딟(bool.Parse(딴18.딢()));
                          continue;
                        case 1:
                          ((땬) 땺).땄(bool.Parse(딴18.딢()));
                          continue;
                        case 2:
                          ((땬) 땺).딟 = this.딟(딴18);
                          continue;
                        case 3:
                          ((땬) 땺).땄 = this.딟(딴18);
                          continue;
                        case 4:
                          ((땬) 땺).땄(this.딟(딴18));
                          continue;
                        case 5:
                          ((땬) 땺).딶(float.Parse(딴18.딢()));
                          continue;
                        case 6:
                          ((땬) 땺).땃(float.Parse(딴18.딢()));
                          continue;
                        case 7:
                          ((땬) 땺).딧(float.Parse(딴18.딢()));
                          continue;
                        case 8:
                          ((땬) 땺).딢(float.Parse(딴18.딢()));
                          continue;
                        case 9:
                          ((땬) 땺).땥(float.Parse(딴18.딢()));
                          continue;
                        default:
                          continue;
                      }
                    }
                    else
                      continue;
                  }
                  else
                    continue;
                case 딝.딢.딧:
                  string lower5 = 딴18.딧().ToLower();
                  if (lower5 != null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    if (딯.땺 == null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      딯.땺 = new Dictionary<string, int>(5)
                      {
                        {
                          "dampingratio",
                          0
                        },
                        {
                          "frequencyhz",
                          1
                        },
                        {
                          "length",
                          2
                        },
                        {
                          "localanchora",
                          3
                        },
                        {
                          "localanchorb",
                          4
                        }
                      };
                    }
                    // ISSUE: reference to a compiler-generated field
                    if (딯.땺.TryGetValue(lower5, out num1))
                    {
                      switch (num1)
                      {
                        case 0:
                          ((땧) 땺).땃(float.Parse(딴18.딢()));
                          continue;
                        case 1:
                          ((땧) 땺).딢(float.Parse(딴18.딢()));
                          continue;
                        case 2:
                          ((땧) 땺).딧(float.Parse(딴18.딢()));
                          continue;
                        case 3:
                          ((땧) 땺).딟 = this.딟(딴18);
                          continue;
                        case 4:
                          ((땧) 땺).땄 = this.딟(딴18);
                          continue;
                        default:
                          continue;
                      }
                    }
                    else
                      continue;
                  }
                  else
                    continue;
                case 딝.딢.땃:
                  throw new Exception("Gear joint is unsupported");
                case 딝.딢.땓:
                  string lower6 = 딴18.딧().ToLower();
                  if (lower6 != null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    if (딯.떂 == null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      딯.떂 = new Dictionary<string, int>(2)
                      {
                        {
                          "localanchora",
                          0
                        },
                        {
                          "localanchorb",
                          1
                        }
                      };
                    }
                    // ISSUE: reference to a compiler-generated field
                    if (딯.떂.TryGetValue(lower6, out num1))
                    {
                      switch (num1)
                      {
                        case 0:
                          ((딝.땄) 땺).딟 = this.딟(딴18);
                          continue;
                        case 1:
                          ((딝.땄) 땺).땄 = this.딟(딴18);
                          continue;
                        default:
                          continue;
                      }
                    }
                    else
                      continue;
                  }
                  else
                    continue;
                case 딝.딢.땺:
                  string lower7 = 딴18.딧().ToLower();
                  if (lower7 != null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    if (딯.땥 == null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      딯.땥 = new Dictionary<string, int>(4)
                      {
                        {
                          "localanchora",
                          0
                        },
                        {
                          "localanchorb",
                          1
                        },
                        {
                          "maxforce",
                          2
                        },
                        {
                          "maxtorque",
                          3
                        }
                      };
                    }
                    // ISSUE: reference to a compiler-generated field
                    if (딯.땥.TryGetValue(lower7, out num1))
                    {
                      switch (num1)
                      {
                        case 0:
                          ((딬) 땺).딟 = this.딟(딴18);
                          continue;
                        case 1:
                          ((딬) 땺).땄 = this.딟(딴18);
                          continue;
                        case 2:
                          ((딬) 땺).딧(float.Parse(딴18.딢()));
                          continue;
                        case 3:
                          ((딬) 땺).딢(float.Parse(딴18.딢()));
                          continue;
                        default:
                          continue;
                      }
                    }
                    else
                      continue;
                  }
                  else
                    continue;
                case 딝.딢.땥:
                  string lower8 = 딴18.딧().ToLower();
                  if (lower8 != null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    if (딯.땤 == null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      딯.땤 = new Dictionary<string, int>(6)
                      {
                        {
                          "dampingratio",
                          0
                        },
                        {
                          "frequencyhz",
                          1
                        },
                        {
                          "maxlength",
                          2
                        },
                        {
                          "minlength",
                          3
                        },
                        {
                          "localanchora",
                          4
                        },
                        {
                          "localanchorb",
                          5
                        }
                      };
                    }
                    // ISSUE: reference to a compiler-generated field
                    if (딯.땤.TryGetValue(lower8, out num1))
                    {
                      switch (num1)
                      {
                        case 0:
                          ((딝.딟) 땺).딶(float.Parse(딴18.딢()));
                          continue;
                        case 1:
                          ((딝.딟) 땺).땃(float.Parse(딴18.딢()));
                          continue;
                        case 2:
                          ((딝.딟) 땺).딧(float.Parse(딴18.딢()));
                          continue;
                        case 3:
                          ((딝.딟) 땺).딢(float.Parse(딴18.딢()));
                          continue;
                        case 4:
                          ((딝.딟) 땺).딟 = this.딟(딴18);
                          continue;
                        case 5:
                          ((딝.딟) 땺).땄 = this.딟(딴18);
                          continue;
                        default:
                          continue;
                      }
                    }
                    else
                      continue;
                  }
                  else
                    continue;
                case 딝.딢.딝:
                  string lower9 = 딴18.딧().ToLower();
                  if (lower9 != null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    if (딯.딦 == null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      딯.딦 = new Dictionary<string, int>(4)
                      {
                        {
                          "biasfactor",
                          0
                        },
                        {
                          "maximpulse",
                          1
                        },
                        {
                          "softness",
                          2
                        },
                        {
                          "targetangle",
                          3
                        }
                      };
                    }
                    // ISSUE: reference to a compiler-generated field
                    if (딯.딦.TryGetValue(lower9, out num1))
                    {
                      switch (num1)
                      {
                        case 0:
                          ((딼) 땺).딟 = float.Parse(딴18.딢());
                          continue;
                        case 1:
                          ((딼) 땺).땄 = float.Parse(딴18.딢());
                          continue;
                        case 2:
                          ((딼) 땺).딧 = float.Parse(딴18.딢());
                          continue;
                        case 3:
                          ((딼) 땺).딧(float.Parse(딴18.딢()));
                          continue;
                        default:
                          continue;
                      }
                    }
                    else
                      continue;
                  }
                  else
                    continue;
                case 딝.딢.떎:
                  string lower10 = 딴18.딧().ToLower();
                  if (lower10 != null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    if (딯.땭 == null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      딯.땭 = new Dictionary<string, int>(3)
                      {
                        {
                          "localanchora",
                          0
                        },
                        {
                          "localanchorb",
                          1
                        },
                        {
                          "maxlength",
                          2
                        }
                      };
                    }
                    // ISSUE: reference to a compiler-generated field
                    if (딯.땭.TryGetValue(lower10, out num1))
                    {
                      switch (num1)
                      {
                        case 0:
                          ((땮) 땺).땄(this.딟(딴18));
                          continue;
                        case 1:
                          ((땮) 땺).딧(this.딟(딴18));
                          continue;
                        case 2:
                          ((땮) 땺).딧(float.Parse(딴18.딢()));
                          continue;
                        default:
                          continue;
                      }
                    }
                    else
                      continue;
                  }
                  else
                    continue;
                default:
                  continue;
              }
            }
          }
        }
      }
    }

    private 떁 딟([In] 딴 obj0)
    {
      string[] strArray = obj0.딢().Split(' ');
      return new 떁(float.Parse(strArray[0]), float.Parse(strArray[1]));
    }

    private object 딟([In] 딴 obj0, [In] Type obj1, [In] bool obj2)
    {
      if ((object) obj1 == null)
        return this.딟(obj0.딟()[1], Type.GetType(obj0.딟()[0].딢()), obj2);
      XmlSerializer xmlSerializer = new XmlSerializer(obj1);
      new XmlSerializerNamespaces().Add(string.Empty, string.Empty);
      using (MemoryStream memoryStream = new MemoryStream())
      {
        StreamWriter streamWriter = new StreamWriter((Stream) memoryStream);
        streamWriter.Write(!obj2 ? obj0.딶() : obj0.땃());
        streamWriter.Flush();
        memoryStream.Position = 0L;
        return xmlSerializer.Deserialize(XmlReader.Create((Stream) memoryStream, new XmlReaderSettings()
        {
          ConformanceLevel = ConformanceLevel.Fragment
        }));
      }
    }
  }
}
