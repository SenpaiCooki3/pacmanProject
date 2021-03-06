﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManLibrary;
using Microsoft.Xna.Framework;

namespace PacManTest
{
    /// <summary>
    /// In this test class the Tile abstract class will be tested as wall
    /// as the Colide method that is overriden by Path and its children 
    /// Pellet and Energizer. Moreover, these tests for Collide will test the
    /// event handlers in the ScoreLives class as well due to them being 
    /// depandent on one another.
    /// </summary>
    [TestClass]
    public class TileTest
    {
        /// <summary>
        /// This test case will try to create a path and will compare
        /// the type to the expected result.
        /// </summary>
        [TestMethod]
        public void TilePathTest()
        {
            Tile tile = new Path(1,1, new Pellet());
          
            Assert.AreEqual(tile.Member().GetType(), new Pellet().GetType());
        }
        /// <summary>
        /// This test case will test if the CanEnter method works by calling
        /// the method via a GameState object calling the tile indexer in the 
        /// maze class which then will call the CanEnter method of a particular
        /// index. The test data is index [5,6] which is a wall so the CanEnter
        /// method will return False.
        /// </summary>
        [TestMethod]
        public void TileCanEnterTest()
        {
            Tile tile = new Path(1, 1, new Pellet());
            GameState game = GetGameState();

            Assert.AreEqual(game.Maze[6,5].CanEnter(), false);
        }
        /// <summary>
        /// This test case will test if the CanEnter method when
        /// called by an index that is ment to be a path will return
        /// true as expected result.
        /// </summary>
        [TestMethod]
        public void TileCanEnter2Test()
        {
            Tile tile = new Path(1, 1, new Pellet());
            GameState game = GetGameState();

            Assert.AreEqual(game.Maze[1, 1].CanEnter(), true);
        }
        /// <summary>
        /// This method will test the is empty method in The tile abstract
        /// class. When there is a pellet or energizer object at that index
        /// the isempty will return false because yes there is something there.
        /// </summary>
        [TestMethod]
        public void TileIsEMptyTest()
        {
            GameState game = GetGameState();

            Assert.AreEqual(game.Maze[1, 1].IsEmpty(), false);
        }
        /// <summary>
        /// This method will test the is empty method in The tile abstract
        /// class. This test case will test a wall tile which the expected 
        /// result will be true.
        /// </summary>
        [TestMethod]
        public void TileIsEMpty2Test()
        {
            GameState game = GetGameState();
            Console.WriteLine(game.Maze[0, 0].IsEmpty());

            Assert.AreEqual(game.Maze[0, 0].IsEmpty(), true);
        }
        /// <summary>
        /// This test case will test the collide event, in this test I will 
        /// demonstrate it works by first printing the score which it will be
        /// zero and then comparing in the Asert to the amount of points
        /// expected to have once collided on.
        /// </summary>
        [TestMethod]
        public void ColideTest()
        {
            GameState game = GetGameState();
            Console.WriteLine(game.Score.Score + "\t" + game.Maze[1, 1].IsEmpty());
            game.Maze[1, 1].Collide();

            Assert.AreEqual(game.Score.Score, 100);
        }
        /// <summary>
        /// This test case will further show how the collide works, since the
        /// tile's collide method was invoked the tile now is empty so when
        /// calling the 
        /// </summary>
        [TestMethod]
        public void Colide2Test()
        {
            GameState game = GetGameState();
            game.Maze[1, 1].Collide();

            Assert.AreEqual(game.Maze[1, 1].IsEmpty(), true);
        }
        /// <summary>
        /// This test case is tasked to test the collision of the energizer
        /// when called it will increase the score in the ScoreLives
        /// class by 500.
        /// </summary>
        [TestMethod]
        public void Colide3Test()
        {
            GameState game = GetGameState();
            game.Maze[1, 3].Collide();

            Assert.AreEqual(game.Score.Score, 500);
        }
        /// <summary>
        /// This test case will show how the event to change the state of the ghost
        /// when an energizer is collided on will change the state of the ghost to
        /// scare mode.
        /// </summary>
        [TestMethod]
        public void Colide4Test()
        {
            GameState game = GetGameState();
            Ghost ghost = new Ghost(game, new Vector2(10, 10), new Vector2(15, 15),
            GhostState.Chase, new Color(255, 0, 0));

            game.GhostPack.Add(ghost);
            game.Maze[1, 3].Collide();

            Assert.AreEqual(ghost.CurrenState,GhostState.Scared);
        }
        /// <summary>
        /// This test case will test if when pacman has the sam point as
        /// a ghost if the event is triggered that pacman must lose a life
        /// in ScoreLives class, the expected result will be 2, being the amount
        /// of lives he has left.
        /// </summary>
        [TestMethod]
        public void Colide5Test()
        {
            GameState game = GetGameState();
            Ghost ghost = new Ghost(game, new Vector2(10, 10), new Vector2(15, 15),
            GhostState.Chase, new Color(255, 0, 0));

            game.GhostPack.Add(ghost);
            //move pacman to place a ghost is sure tobe.
            game.Pacman.Position = new Vector2(10, 10); 
              
            game.GhostPack.CheckCollideGhosts(game.Pacman.Position);

            Assert.AreEqual(game.Score.Lives, 2);
        }
        /// <summary>
        /// This test case will show that the GetDistance method in the
        /// tile class works by creating two vectors comparing the distance
        /// and then comparing that distance to tiles within the maze (which are
        /// vector2 themselves) and using the same points.
        /// </summary>
        [TestMethod]
        public void GetDistanceTest()
        {
            GameState game = GetGameState();
            Vector2 p1 = new Vector2(0, 0);
            Vector2 p2 = new Vector2(10, 10);

            float f1 = Vector2.Distance(p1, p2);
            float f2 = game.Maze[0, 0].GetDistance(game.Maze[10,10].Position);

            Assert.AreEqual(f1, f2);

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
w p w w w p w m w x 2 3 4 x w m w p w w w p w
w p w w w p m m w x x x x x w m m p w w w p w
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
