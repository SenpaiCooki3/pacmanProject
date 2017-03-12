﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace PacManLibrary
{
   public class Wall : Tile
    {

        public Wall(int x, int y) : base(x, y)
        {
        }
        /// <summary>
        /// Since this class is a wall that means no matter what 
        /// nothing can or must go through it so it must return
        /// false at all times.
        /// </summary>
        public override bool CanEnter()
        {
            return false;
        }
        /// <summary>
        /// Since this class is a wall that means you 
        /// cannot collide into it you should not event be
        /// able to get over it to call a collide method
        /// like we do in the path class where there it is 
        /// possible to hit or collide with an ICollidable object.
        /// </summary>
        public override void Collide()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Since this class is a wall so a wall never contains
        /// something therefor makes it empty all the time        <========== check logic!
        /// </summary>
        public override bool IsEmpty()
        {
            return false;
        }
        /// <summary>
        /// A wall cannot have an ICollidable object so
        /// it cannot implement one in the first place
        /// throwing an exception is apropriate
        /// </summary>
        public override ICollidable Member()
        {
            throw new NotImplementedException();
        }
    }
}