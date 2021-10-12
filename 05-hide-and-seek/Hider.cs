using System;
using System.Collections.Generic;

namespace _05_hide_and_seek
{
    /// <summary>
    /// The Hider is responsible to watch the seeker and give hints.
    /// 
    /// Stereotype:
    ///     Information Holder
    /// </summary>
    public class Hider
    {
        // TODO: Add any member variables here
        public int _hidingSpot;
        public List<int> _distance;

        public int seekerLocation;
        /// <summary>
        /// Initializes the location of the hider to a random location 1-1000.
        /// Also initializes the list of distances to be a new, empty list.
        /// </summary>
        public Hider()
        {
            Random randomGenerator = new Random();
            _hidingSpot = randomGenerator.Next(1,1001);

            _distance= new List<int>();
        }

        /// <summary>
        /// Computes the distance from the hider's location to the provided location of the seeker
        /// and stores it in a list of distances to use later.
        /// </summary>
        /// <param name="seekerLocation">The current location of the seeker.</param>
        public void Watch(int seekerLocation)
        {
            // Find the distance from the Hiding Spot and the seekers guess
            int seekerDistance = (_hidingSpot - seekerLocation);

            _distance.Add(seekerDistance);
        }

        /// <summary>
        /// Get's a hint.
        /// 
        /// If there is not enough information yet (fewer than 2 distances), a generic hint is given.
        /// If the seeker has found the hider, the hint notes they have been found.
        /// If the seeker is moving closer, the hint notes they are getting warmer.
        /// If the seeker is moving futher away, the hing notes they are getting colder.
        /// </summary>
        /// <returns>The hint message</returns>
        public string GetHint()
        {
            string hint = "";

            //Not able to tell if warmer or colder
            if (_distance.Count <2)
            {
                hint = "I think I'll Just take a nap -.-";
            }
            else 
            {
                //found
                if (IsFound())
                {
                    hint = "Oh darn! You found me!";
                }
                //closer
                else if (_distance[_distance.Count - 1] > _distance[_distance.Count - 2])
                {
                    hint = "Getting colder ^.^";
                }
                else
                {
                    hint = "Getting Warmer! >.<";
                }
            }
            return hint;
        }

        /// <summary>
        /// Returns whether the hider has been found. (Hint: the last distance is 0 in that case.)
        /// </summary>
        /// <returns>True if the hider has been found.</returns>
        public bool IsFound()
        {
            return _distance[_distance.Count - 1] == 0;
        }
    }
}
