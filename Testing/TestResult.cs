using System;
/*
    Author: Joshua Hanf.
 */
//For passing results of the tests back to the driver.
public class TestResult {
    private string name; //Test name
    private object expected; //Expected result
    private object actual; //Actual result
    private bool pass; //Pass or fail

    public TestResult(string name, object expected, object actual, bool pass){
        this.name = name;
        this.expected = expected;
        this.actual = actual;
        this.pass = pass;
    }

    public string getName(){return name;}

    public object getExpected(){return expected;}

    public object getActual(){return actual;}

    public bool getPass(){return pass;}

    public string printResult(){
        return "Name:" + name + " Pass: " + pass + "; Expected result:" + expected + "; Actual:" + actual;
    }
}