﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
   public class Pacman
    {
        private GameState controller;
        private Maze maze;
        private Vector2 position;

        public Pacman (GameState gameState)
        {
            this.controller = gameState;
            this.maze = gameState.Maze;
 
        }
        public Vector2 Position
        {
            set { position = new Vector2(value.X, value.Y); }
            get { return new Vector2(position.X, position.Y); }
        }
        public void Move (Direction dir)
        {
            switch (dir)
            {
                case Direction.Down:
                    Position = new Vector2(Position.X, Position.Y + 1);
                    CheckCollisions();
                    break;
                case Direction.Left:
                    Position = new Vector2(Position.X -1, Position.Y);
                    CheckCollisions();
                    break;
                case Direction.Up:
                    Position = new Vector2(Position.X, Position.Y - 1);
                    CheckCollisions();
                    break;
                case Direction.Right:
                    Position = new Vector2(Position.X + 1, Position.Y);
                    CheckCollisions();
                    break;
            }     
        } 
        public void CheckCollisions()
        {
          if (!(maze[(int)Position.Y, (int)Position.X].IsEmpty())){
                //there is something here
                maze[(int)Position.Y, (int)Position.X].Collide();
            }
            //thre is nothing here

        } 
        
    }
}
