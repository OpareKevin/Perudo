using System;
using NUnit.Framework;
using Perudo;
using Perudo.Properties;

namespace PerudoTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void IsDieFacebetweenRange()
        {
            Die die = new Die();
            Assert.IsTrue((int)die.Face>=1 || (int)die.Face<=6);
        }

        [Test]
        public void PlayerHasSixDice()
        {
            Player human = new Human(1);
            Assert.AreEqual(human.Peek().Count,5);
        }

        [Test]
        public void RollDiceAfterLost()
        {
            Player human = new Human(1);
            human.RemoveDice();
            Assert.AreEqual(human.Peek().Count,4);
        }
        
        [Test]
        public void CallDudo()
        {
            Player human = new Human(1);
            human.Dudo();
            Assert.AreEqual(human.Call,Call.CallDudo);
        }
        
        [Test]
        public void IncreaseBid()
        {
            Player human = new Human(1);
            human.RaiseBid();
            Assert.AreEqual(human.Call,Call.IncreaseBid);
        }
        
        [Test]
        public void CreatePlayers()
        {
            // CreatePlayers createPlayers = new CreatePlayers();
            //
            // while (!createPlayers.CreatedPlayers)
            // {
            //    // createPlayers.Execute();
            // }
        }
    }
}