using System;
 /*
    Author: Joshua Hanf.
 */
//Basic command line interface. Type in expression, press enter to enter, quits on pressing "q".
public class CLInterface
{
    static public void Main ()
    {
        CalcInterface calc = new CalcInterface();
        string str = "";
        while (true){
            Console.WriteLine("Enter expression. Enter q to quit. ");
            str = Console.ReadLine();
            str = str.Trim();
            if (str == "q") {
                break;
            }
            Console.WriteLine(calc.evaluate(str));
        }
    }
}