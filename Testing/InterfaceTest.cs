using System;
using System.Collections.Generic;
/*
    Author: Joshua Hanf.
 */
//Quick and dirty test of my the Calculater's Interface.
public class InterfaceTest : TestCase{
    public override List<TestResult> run(){

        List<TestResult> results = new List<TestResult>();

        CalcInterface face = new CalcInterface();

        string fail = "Error, expression not valid.";
        string success = "5";

        TestResult res;
        string actual = face.evaluate("(");
        res = new TestResult("Interface Fail", actual, fail, actual == fail);
        results.Add(res);

        actual = face.evaluate("5");
        res = new TestResult("Interface Fail", actual, success, actual == success);
        results.Add(res);

        return results;
    }
}