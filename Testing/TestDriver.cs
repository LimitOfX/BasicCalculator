using System;
using System.Collections.Generic;
/*
    Author: Joshua Hanf.
 */
public class TestDriver{

    //Let's not get too fancy and over engineer this. Just run through some prebaked test cases and compare them to expected results
    //Rolling my own unit testing framework will just distract me.

    //Basic test driver is a good exercise. Not full fledged by any measure.

    //Alright, we'll make test objects that run themselves and passback result objs.
    public static void Main(string[] args){
        Console.WriteLine("Expression Test");
        TestCase test = new ExpressionTest();
        List<TestResult> res = test.run();
        bool testResult = true;
        foreach (TestResult result in res){
            Console.WriteLine(result.printResult());
            if (!result.getPass()){
                testResult = false;
            }
        }
        Console.WriteLine(testResult);
        Console.WriteLine();

        Console.WriteLine("Parser Test");
        test = new ParserTest();
        res = test.run();
        foreach (TestResult result in res){
            Console.WriteLine(result.printResult());
            if (!result.getPass()){
                testResult = false;
            }
        }
        Console.WriteLine(testResult);
        Console.WriteLine();

        Console.WriteLine("Interface Test");
        test = new InterfaceTest();
        res = test.run();
        foreach (TestResult result in res){
            Console.WriteLine(result.printResult());
            if (!result.getPass()){
                testResult = false;
            }
        }
        Console.WriteLine(testResult);
        Console.WriteLine();
    }
}