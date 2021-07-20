using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    public class Robot
    {
        const string LOST = "LOST";
        public int X { get; set; }
        public int Y { get; set; }
        
        public string Message { get; set; }
        public bool IsLost { get; set; }
        public Direction O { get; set; }
        public enum Direction { N = 0, E = 1, S = 2, W = 3 };


        //method that adds lost message.
        public Robot  OnIsLost(Robot rob) 
        {
            if (rob.IsLost)
            {
                rob.Message = LOST;
            }
            else
            {
                rob.Message = "";
            }
            return rob;
        }
        //constructor
        public Robot() 
        { 
        }
        //method that sets the robot start position
        public Robot setRobotOrigin(String str, Robot rob)
        {
            int x = 0, y = 0;
            string o  = "";
            var arr = str.Trim().Split();
            if (arr.Length > 1)
            {
                x = Int32.Parse(arr[0]);
                y = Int32.Parse(arr[1]);
                o = arr[2];
            }
            else {

                var arrChar = str.ToCharArray();

                x = Int32.Parse(arrChar[0].ToString());
                y = Int32.Parse(arrChar[1].ToString());
                o = arrChar[2].ToString();
            }
            
            rob.X = x;
            rob.Y = y;
            IsLost = false;
            if ((o == "N") || (o == "n"))
            {
                rob.O = Direction.N;
            }
            if ((o == "E") || (o == "e"))
            {
                rob.O = Direction.E;
            }
            if ((o == "S") || (o == "s"))
            {
                rob.O = Direction.S;
            }
            if ((o == "W") || (o == "w"))
            {
                rob.O = Direction.W;
            }
            return rob;
        }
        //method for the advance of the robot position
        public Robot RobotMovePosition(char pos, Robot rob, Mars mars)
        {
            if (pos.Equals('F'))
            {

                if ((int)rob.O == 0 )
                {
                    rob.Y = rob.Y + 1;
                }
                else if ((int)rob.O == 1)
                {
                    rob.X = rob.X + 1;
                }
                else if ((int)rob.O == 2)
                {
                    rob.Y = rob.Y - 1;
                }
                else if ((int)rob.O == 3)
                {
                    rob.X = rob.X - 1;
                }
            }
            if (rob.Y > mars.MaxY)
            {
                 rob.CheckDimY(mars, rob, mars.MaxY);
            }
            if (rob.X > mars.MaxX)
            {
                rob.CheckDimX(mars, rob, mars.MaxX);
            }
            if (rob.Y < mars.MinY)
            {
                rob.CheckDimY(mars, rob, mars.MinY);
            }
            if (rob.X < mars.MinX)
            {
                rob.CheckDimX(mars, rob, mars.MinX);
            }
            return rob;
        }
        //method for the turn of the robot position
        public Robot RobotTurnPosition(char pos, Robot rob)
        {

            if (pos.Equals('R'))
            {
                int value = (int)rob.O;
                if (value == 3)
                {
                    value = 0;
                    rob.O = Direction.N;
                }
                else
                {
                    value++;
                    if (value == 1) {
                        rob.O = Direction.E;
                    }

                    if (value == 2)
                    {
                        rob.O = Direction.S;
                    }
                    if (value == 3)
                    {
                        rob.O = Direction.W;
                    }
                }
               
            }
            
            if (pos.Equals('L'))
            {
                int value = (int)rob.O;
                if (value == 0)
                {
                    value = 3;
                    rob.O = Direction.W;
                }
                else
                {
                    value--;
                    if (value == 1)
                    {
                        rob.O = Direction.E;
                    }

                    if (value == 2)
                    {
                        rob.O = Direction.S;
                    }
                    if (value == 0)
                    {
                        rob.O = Direction.N;
                    }
                }

            }
            return rob;
        }

        //method for the movement of the robot
        public Robot RobotMovement(string movement, Robot rob, Mars mars) 
        {
            char[] mov =  movement.ToCharArray();

            foreach (char m in mov)
            {

                if (m.Equals('F'))
                {
                    rob.RobotMovePosition(m, rob, mars);
                }
                else
                {
                    rob.RobotTurnPosition(m, rob);
                }
                
            }
            return rob;
        }
            //method for cheking that the robot doesnt get lost in vertical
        public Robot CheckDimY(Mars mars, Robot rob, int MarsCoord)
        {
            rob.IsLost = true;
            if (!(mars.Smelly.Contains(MarsCoord)))
            {
                mars.Smelly.Add(MarsCoord);
                OnIsLost(rob);
            }
            else
            {
                if (mars.Smelly.Count > 0)
                {
                    if (mars.Smelly.Any(p => p == MarsCoord))
                    {
                        rob.Y = MarsCoord;
                    }
                }
            }

            return rob;
            
        }
        //method for cheking that the robot doesnt get lost in horizontal
        public Robot CheckDimX(Mars mars, Robot rob, int MarsCoord)
        {
            rob.IsLost = true;
            if (!(mars.Smelly.Contains(MarsCoord)))
            {
                mars.Smelly.Add(MarsCoord);
                OnIsLost(rob);
            }
            else
            {
                if (mars.Smelly.Count > 0)
                {
                    if (mars.Smelly.Any(p => p == MarsCoord))
                    {
                        rob.X = MarsCoord;
                    }
                }
            }

            return rob;
        }

        public string getRobotInstructions(String str)
        {
            if(str.Length<101)
            {
                return str.ToUpper();
            }
                Console.WriteLine("ERROR: The instuctions must  100 characters long or less.");
            return "";
        }
       
    }
}
