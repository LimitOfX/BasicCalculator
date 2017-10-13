using System;
using System.Collections.Generic;
/*
    Author: Joshua Hanf.
 */
 
//Tests the Expression classes. Non-exhaustive.

public class ExpressionTest : TestCase{

    public override List<TestResult> run(){
        //Do some tests, make results, pass back a list

        List<TestResult> results = new List<TestResult>();

        double expected = 5.0;
        Expression expr = new AtomicExpression(expected);
        double actual = expr.evaluate();
        TestResult res = new TestResult("Atomic Positive Int", expected, actual, compare(expected, actual));
        results.Add(res);

        expected = -5.0;
        expr = new AtomicExpression(expected);
        actual = expr.evaluate();
        res = new TestResult("Atomic Negative Int", expected, actual, compare(expected, actual));
        results.Add(res);

        expected = 0;
        expr = new AtomicExpression(expected);
        actual = expr.evaluate();
        res = new TestResult("Atomic 0 Int", expected, actual, compare(expected, actual));
        results.Add(res);

        expected = 5.0;
        expr = new ParenExpression(new AtomicExpression(expected));
        actual = expr.evaluate();
        res = new TestResult("Paren Positive Int", expected, actual, compare(expected, actual));
        results.Add(res);

        expected = -5.0;
        expr = new ParenExpression(new AtomicExpression(expected));
        actual = expr.evaluate();
        res = new TestResult("Paren Positive Int", expected, actual, compare(expected, actual));
        results.Add(res);

        expected = 0;
        expr = new ParenExpression(new AtomicExpression(expected));
        actual = expr.evaluate();
        res = new TestResult("Paren 0 Int", expected, actual, compare(expected, actual));
        results.Add(res);

        expected = 7;
        expr = new AddExpression(new AtomicExpression(5), new AtomicExpression(2));
        actual = expr.evaluate();
        res = new TestResult("Add Positive Int", expected, actual, compare(expected, actual));
        results.Add(res);

        expected = 3;
        expr = new SubtractExpression(new AtomicExpression(5), new AtomicExpression(2));
        actual = expr.evaluate();
        res = new TestResult("Subtract Postive Int", expected, actual, compare(expected, actual));
        results.Add(res);

        expected = 10;
        expr = new MultiplyExpression(new AtomicExpression(5), new AtomicExpression(2));
        actual = expr.evaluate();
        res = new TestResult("Multiply Positive Int", expected, actual, compare(expected, actual));
        results.Add(res);

        expected = 2.5;
        expr = new DivideExpression(new AtomicExpression(5), new AtomicExpression(2));
        actual = expr.evaluate();
        res = new TestResult("Divide Positive Float", expected, actual, compare(expected, actual));
        results.Add(res);

        expected = 25;
        expr = new ExponentExpression(new AtomicExpression(5), new AtomicExpression(2));
        actual = expr.evaluate();
        res = new TestResult("Exponent Positive Float", expected, actual, compare(expected, actual));
        results.Add(res);

        return results; //I can be reasonably certain they won't mess up in different circumstances. It's just wrappers for primitive expressions.
    }
}