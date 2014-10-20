﻿using Ivony.TableGame.BasicCardGames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ivony.TableGame.SimpleGames.Rules
{
  public class AttackEvent : GameEventBase, IGameBehaviorEvent
  {
    public AttackEvent( SimpleGamePlayer user, SimpleGamePlayer target, int point )
    {
      InitiatePlayer = user;
      RecipientPlayer = target;
      AttackPoint = point;


      Game = user.Game;
    }


    protected SimpleGame Game { get; private set; }

    GamePlayerBase IGameBehaviorEvent.InitiatePlayer { get { return InitiatePlayer; } }


    GamePlayerBase IGameBehaviorEvent.RecipientPlayer { get { return RecipientPlayer; } }



    public SimpleGamePlayer InitiatePlayer { get; private set; }


    public SimpleGamePlayer RecipientPlayer { get; private set; }



    public int AttackPoint { get; private set; }



    public void AnnounceAttackEffective()
    {
      Game.AnnounceMessage( "{0} 对 {1} 发起攻击。", InitiatePlayer.PlayerName, RecipientPlayer.PlayerName );
    }


    public void AnnounceAttackIneffective()
    {
      Game.AnnounceMessage( "{0} 对 {1} 发起攻击，但是 {1} 看起来毫发无损。", InitiatePlayer.PlayerName, RecipientPlayer.PlayerName );
    }


    public bool Handled
    {
      get;
      internal set;
    }

  }
}
