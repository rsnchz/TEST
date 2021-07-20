using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    class Program
    {
        //method for reading imput( a string ) from console
        public static string ReadConsole(string str)
        {
            string coord;
            Console.Write(str);
            coord = Console.ReadLine();
            return coord;
        }
        //method for outputing the results in the console.
        public static void RobotOutput(Robot rob)
        {
            Console.WriteLine("");
            Console.WriteLine("OUTPUT Robot position => " + rob.X + " " + rob.Y + " " + rob.O + " " + rob.Message);
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            //variables for Input redLine
            string coord = ReadConsole("INPUT upper-right coordinates of Mars =>");
            string position = ReadConsole("INPUT robot position => ");
            string instructions = ReadConsole("INPUT robot movement instructions => ");

        
            Mars mars = new Mars();

            
            var upperRight = mars.getUpperRightCoord(coord);

        
            mars.setMarsDimensions(upperRight[0], upperRight[1] );

       
            Robot rob = new Robot();

            
            rob.setRobotOrigin(position, rob);

            
            rob.RobotMovement(rob.getRobotInstructions(instructions), rob, mars);

            
            RobotOutput(rob);

            
            position = ReadConsole("INPUT robot position => ");
            instructions = ReadConsole("INPUT robot movement instructions => ");

            
            Robot rob2 = new Robot();

            rob2.setRobotOrigin(position, rob2);

      
            rob2.RobotMovement(rob2.getRobotInstructions(instructions), rob2, mars);

         
            RobotOutput(rob2);

            //variables for Input redLine
            position = ReadConsole("INPUT robot position => ");
            instructions = ReadConsole("INPUT robot movement instructions => ");

         
            Robot rob3 = new Robot();

          
            rob3.setRobotOrigin(position, rob3);

          
            rob3.RobotMovement(rob3.getRobotInstructions(instructions), rob3, mars);

           
            RobotOutput(rob3);


            Console.ReadLine();

        }
    }
}
