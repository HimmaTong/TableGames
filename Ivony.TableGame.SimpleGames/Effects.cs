﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivony.TableGame.SimpleGames
{
  public static class Effects
  {

    public static ShieldEffect ShieldEffect()
    {
      return new ShieldEffect();
    }


    public static AngelEffect AngelEffect()
    {
      return new AngelEffect();
    }

    internal static DevilEffect DevilEffect()
    {
      return new DevilEffect();
    }
  }
}