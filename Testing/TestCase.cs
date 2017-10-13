using System;
using System.Collections.Generic;
//Abstract test case, provied run interface and double equality check.
/*
    Author: Joshua Hanf.
 */
public abstract class TestCase{
    public abstract List<TestResult> run();

    public bool compare(double one, double two){
        return one == two;
    }
}