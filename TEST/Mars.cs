using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    public class Mars
    {
        //constructor
        public Mars() {
            Smelly = new List<int>();
        }
        
        public int MaxX { get; set; }

        public int MaxY { get; set; }

        public int MinX { get; set; }

        public int MinY { get; set; }
        public List <int> Smelly { get; set; }

        //method for setting mars dimensions
        public void setMarsDimensions(int x, int y) {

            MinX = 0;
            MinY = 0;
            if (x < 51) 
            {
                MaxX = x;
            }
            if (y < 51) 
            {
                MaxY = y;
            }
        }

        //method that gets the upper right coordinate given by user.
        public List<int> getUpperRightCoord(string str)
        {
            List<int> coords = new List<int>();
            var strCoord = str.Trim().Split();
            if (strCoord.Length > 1)
            {
                coords.Add(Int32.Parse(strCoord[0].ToString()));
                coords.Add(Int32.Parse(strCoord[strCoord.Length - 1].ToString()));
            }
            else 
            {
                var coor = str.ToCharArray();
                coords.Add(Int32.Parse(coor[0].ToString()));
                coords.Add(Int32.Parse(coor[1].ToString()));
            }
            return coords;
        }

    }
}
