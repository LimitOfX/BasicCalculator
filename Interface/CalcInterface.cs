using System;
/*
    Author: Joshua Hanf.
 */
 //Creates interface for a GUI or CLI to send in expressions and get results.
class CalcInterface {
    Parser parser = new Parser();

    double lastVal = 0;
    string replace = "ANS";

    public string evaluate(string str){
        str = str.Replace(replace,lastVal.ToString());
        if(parser.sanityCheck(str)){
            
            lastVal = parser.parse(str).evaluate();
            return lastVal.ToString();
        } else {
            return "Error, expression not valid.";
        }
    }
}