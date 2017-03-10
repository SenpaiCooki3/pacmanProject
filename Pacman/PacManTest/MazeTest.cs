﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManLibrary;
using Microsoft.Xna.Framework;

namespace PacManTest
{
    [TestClass]
    public class MazeTest
    {
        [TestMethod]
        public void TestGameStateParsePacmanPosition()
        {
            GameState game1 = GetGameState();
            Pacman pacman = new Pacman(game1); //17, 11
            pacman.Position = new Vector2(17, 11);

            Assert.AreEqual(game1.Pacman.Position, pacman.Position);
        }
        [TestMethod]
        public void TestGameStateParsePelletPosition()
        {
            GameState game1 = GetGameState();
            Pellet pellet = new Pellet();
            Tile path = new Path(1, 1, pellet);


            Assert.AreEqual(game1.Maze[1,1].Member().ToString(), path.Member().ToString());
        }
        [TestMethod]
        //[ExpectedException(typeof(NotImplementedException))]
        public void TestGameStateParseWallPosition()
        {
            GameState game1 = GetGameState();
            Tile path = new Wall(0, 0);

            Console.WriteLine(" ======>  " + game1.Maze[0, 0].Member().ToString() + "    ||   "+ path.ToString());

            Assert.AreEqual(game1.Maze[1,1].ToString(), path.ToString());
        }
        private GameState GetGameState()
        {
            return GameState.Parse
(@"w w w w w w w w w w w w w w w w w w w w w w w
w p p p p p p p p p p w p p p p p p p p p p w
w p w w w p w w w w p w p w w w w p w w w p w
w e w w w p w w w w p w p w w w w p w w w e w
w p p p p p p p p p p p p p p p p p p p p p w
w p w w w p w p w w w w w w w p w p w w w p w
w p p p p p w p p p p w p p p p w p p p p p w
w w w w w p w w w w m w m w w w w p w w w w w
w p p p p p w m m m m 1 m m m m w p p p p p w
w p w w w p w m w w w w w w w m w p w w w p w
w p w w w p w m w m 2 3 4 m w m w p w w w p w
w p w w w p m m w m m m m m w m m p w w w p w
w p w w w p w m w w w w w w w m w p w w w p w
w p p p p p w m m m m m m m m m w p p p p p w
w w w w w p w m w w w w w w w m w p w w w w w
w p p p p p p p p p p w p p p p p p p p p p w
w p w w w p w w w w p w p w w w w p w w w p w
w e p p w p p p p p p P p p p p p p w p p e w
w w w p w p w p w w w w w w w p w p w p w w w
w p p p p p w p p p p w p p p p w p p p p p w
w p w w w w w w w w p w p w w w w w w w w p w
w p p p p p p p p p p p p p p p p p p p p p w
w w w w w w w w w w w w w w w w w w w w w w w");
        }
    }
}
