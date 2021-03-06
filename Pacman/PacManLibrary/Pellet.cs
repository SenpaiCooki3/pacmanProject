﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    /// <summary>
    /// The Pellet class represents a single pellet object
    /// that contains its worth (points) and is an ICollidable object which
    /// means it must implemant the Collide event and when the Collide method is 
    /// invoked the event is fired.
    /// </summary>
    public class Pellet : ICollidable
    {
        private int points;
        public event CollisionEvent Collision;
        public Pellet()
        {
            this.points = 100;
        }
        /// <summary>
        /// The Points proprety will return the amount of points a
        /// single pellet is worth and it will not provide a setter
        /// so no one can set the value of a pellet to 1Billion.
        /// </summary>
        public int Points
        {
            get
            {
                return this.points;
            }
            
        }
        /// <summary>
        /// When a pelletes collide method is invoked it must
        /// raise the event that it was hit
        /// </summary>
        public void Collide()
        {
            Collision?.Invoke(this);
        }
    }
}
