using System;
using System.Collections.Generic;

/*
    Author: Joshua Hanf.
 */

//Tests various parser and sanity checker scenarios. Non-exhaustive. Should split this up.
public class ParserTest : TestCase{
    public override List<TestResult> run(){

        List<TestResult> results = new List<TestResult>();
        Parser parser = new Parser();

        string str = "bob";
        string actualstr = "ob"; 
        string resultstr = parser.advance(str);
        TestResult res = new TestResult("Parse Advance", actualstr, resultstr, String.Equals(actualstr, resultstr));
        results.Add(res);

        bool expectedBool = true;
        bool actualBool = parser.sanityCheck("5");
        res = new TestResult("Parse Atomic", expectedBool, actualBool, actualBool==expectedBool);
        results.Add(res);

        expectedBool = false;
        actualBool = parser.sanityCheck("q");
        res = new TestResult("Parse Atomic Bad", expectedBool, actualBool, actualBool==expectedBool);
        results.Add(res);

        expectedBool = true;
        actualBool = parser.sanityCheck("5+2");
        res = new TestResult("Parse Add", expectedBool, actualBool, actualBool==expectedBool);
        results.Add(res);

        expectedBool = false;
        actualBool = parser.sanityCheck("5+");
        res = new TestResult("Parse Add Bad", expectedBool, actualBool, actualBool==expectedBool);
        results.Add(res);

        expectedBool = true;
        actualBool = parser.sanityCheck("5-2");
        res = new TestResult("Parse Sub", expectedBool, actualBool, actualBool==expectedBool);
        results.Add(res);

        expectedBool = false;
        actualBool = parser.sanityCheck("5-");
        res = new TestResult("Parse Sub Bad", expectedBool, actualBool, actualBool==expectedBool);
        results.Add(res);

        expectedBool = true;
        actualBool = parser.sanityCheck("5*2");
        res = new TestResult("Parse Mult", expectedBool, actualBool, actualBool==expectedBool);
        results.Add(res);

        expectedBool = false;
        actualBool = parser.sanityCheck("5*");
        res = new TestResult("Parse Mult Bad", expectedBool, actualBool, actualBool==expectedBool);
        results.Add(res);

        expectedBool = true;
        actualBool = parser.sanityCheck("5/2");
        res = new TestResult("Parse Div", expectedBool, actualBool, actualBool==expectedBool);
        results.Add(res);

        expectedBool = false;
        actualBool = parser.sanityCheck("5/");
        res = new TestResult("Parse Div Bad", expectedBool, actualBool, actualBool==expectedBool);
        results.Add(res);

        expectedBool = true;
        actualBool = parser.sanityCheck("5^2");
        res = new TestResult("Parse Exp", expectedBool, actualBool, actualBool==expectedBool);
        results.Add(res);

        expectedBool = false;
        actualBool = parser.sanityCheck("5^");
        res = new TestResult("Parse Exp Bad", expectedBool, actualBool, actualBool==expectedBool);
        results.Add(res);

        expectedBool = true;
        actualBool = parser.sanityCheck("5+2+1");
        res = new TestResult("Parse Add Complex", expectedBool, actualBool, actualBool==expectedBool);
        results.Add(res);

        expectedBool = false;
        actualBool = parser.sanityCheck("5+2+");
        res = new TestResult("Parse Add Complex Bad", expectedBool, actualBool, actualBool==expectedBool);
        results.Add(res);

        expectedBool = false;
        actualBool = parser.sanityCheck("()");
        res = new TestResult("Parse Empty Parens", expectedBool, actualBool, actualBool==expectedBool);
        results.Add(res);

        expectedBool = false;
        actualBool = parser.sanityCheck("(");
        res = new TestResult("Parse Incomplete Paren", expectedBool, actualBool, actualBool==expectedBool);
        results.Add(res);

        expectedBool = true;
        actualBool = parser.sanityCheck("(5+5+5)");
        res = new TestResult("Parse Complex In Paren", expectedBool, actualBool, actualBool==expectedBool);
        results.Add(res);

        expectedBool = true;
        actualBool = parser.sanityCheck("(5+5+5) + 5");
        res = new TestResult("Parse Complex Paren and Atomic", expectedBool, actualBool, actualBool==expectedBool);
        results.Add(res);

        expectedBool = true;
        actualBool = parser.sanityCheck("(5+5+5) + (5 + 5)");
        res = new TestResult("Parse Complex Paren and Paren", expectedBool, actualBool, actualBool==expectedBool);
        results.Add(res);

        expectedBool = false;
        actualBool = parser.sanityCheck("5 ++ 5");
        res = new TestResult("Double Op", expectedBool, actualBool, actualBool==expectedBool);
        results.Add(res);

        expectedBool = false;
        actualBool = parser.sanityCheck("+");
        res = new TestResult("No Value Just Op", expectedBool, actualBool, actualBool==expectedBool);
        results.Add(res);

        expectedBool = false;
        actualBool = parser.sanityCheck("5 6");
        res = new TestResult("Two Values Spaced", expectedBool, actualBool, actualBool==expectedBool);
        results.Add(res);
        
        double expected = 5;
        Expression expr = parser.parse("5");
        double actual = expr.evaluate();
        res = new TestResult("Parse Pos Atomic", expected, actual, compare(expected, actual));
        results.Add(res);
//Issue, it can't tell the diff between neg numbers and a - without a minus without a left arg. solution, use longer dashes for neg.
        expected = -5;
        expr = parser.parse("−5");
        actual = expr.evaluate();
        res = new TestResult("Parse Neg Atomic", expected, actual, compare(expected, actual));
        results.Add(res);

        expected = 7;
        expr = parser.parse("5 + 2");
        actual = expr.evaluate();
        res = new TestResult("Parse add", expected, actual, compare(expected, actual));
        results.Add(res);

        expected = 7;
        expr = parser.parse("5+2");
        actual = expr.evaluate();
        res = new TestResult("Parse add no space", expected, actual, compare(expected, actual));
        results.Add(res);

        expected = 3;
        expr = parser.parse("5 - 2");
        actual = expr.evaluate();
        res = new TestResult("Parse sub", expected, actual, compare(expected, actual));
        results.Add(res);

        expected = 3;
        expr = parser.parse("5-2");
        actual = expr.evaluate();
        res = new TestResult("Parse sub", expected, actual, compare(expected, actual));
        results.Add(res);

        expected = 10;
        expr = parser.parse("5 * 2");
        actual = expr.evaluate();
        res = new TestResult("Parse mult", expected, actual, compare(expected, actual));
        results.Add(res);

        expected = 2.5;
        expr = parser.parse("5 / 2");
        actual = expr.evaluate();
        res = new TestResult("Parse div", expected, actual, compare(expected, actual));
        results.Add(res);

        expected = 25;
        expr = parser.parse("5 ^ 2");
        actual = expr.evaluate();
        res = new TestResult("Parse Exponent", expected, actual, compare(expected, actual));
        results.Add(res);

        expected = 13;
        expr = parser.parse("5 * 2 + 3");
        actual = expr.evaluate();
        res = new TestResult("Parse Complex", expected, actual, compare(expected, actual));
        results.Add(res);

        expected = 0;
        expr = parser.parse("5 - 2 + 3");
        actual = expr.evaluate();
        res = new TestResult("Parse Complex 2", expected, actual, compare(expected, actual));
        results.Add(res);

        expected = 25;
        expr = parser.parse("5 * (2 + 3)");
        actual = expr.evaluate();
        res = new TestResult("Parse Paren Plus Value", expected, actual, compare(expected, actual));
        results.Add(res);

        expected = 930.5;
        expr = parser.parse("5 ^ 4 * 3 / 2 + 1 - 8");
        actual = expr.evaluate();
        res = new TestResult("All Operators", expected, actual, compare(expected, actual));
        results.Add(res);

        expected = 122070305.5;
        expr = parser.parse("5 ^ (4 * 3) / 2 + 1 - 8");
        actual = expr.evaluate();
        res = new TestResult("All Operators and Paren", expected, actual, compare(expected, actual));
        results.Add(res);

        return results;
    }
}