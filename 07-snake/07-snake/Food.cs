using System;

namespace _07_snake
{
    class Food : Actor {
        //Declare public variables here
        private int _points;
        //Declare member variables here

        //Declare methods
        public Food()
        {
            Reset();
        }
        public int GetPoints()
        {
            return _points;
        }
        //Give each piece of food a random value
        //Place food at random location
        public void Reset()
        {
            Random rnd = new Random();
            _points = rnd.Next(1,10);
            _text = _points.ToString();

            int x = rnd.Next(0,Constants.MAX_X);
            int y = rnd.Next(0,Constants.MAX_Y);

            _position = new Point(x,y);
        }
    }
 
}