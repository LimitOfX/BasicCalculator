using System;
using System.Globalization;
/*
    Author: Joshua Hanf.
 */

//Parses strings into expression trees, and can check if strings are valid expressions.
public class Parser{

    //Sanity check and parsing are separate. More cpu intensive since it reads the expression twice, but simpler to implement. This isn't meant for big use.

    //States for sanity check.
    enum states{Paren, Value, Operator, End, Fail};

    //Parses string into a tree of Expression objects.
    //Don't use without using sanityCheck first.
    public Expression parse(string str){

        string operators = "-+/*^";
        bool inParen = false;
        bool parenFound = false;

        //Okay, recursive expression. It finds the top level operator, then recursively parses the other two operators

        //So, search for highest priority, non enclosed, operator. Priority is reverse PEMDAS. Then create the expression, using the text to the left and right as the child nodes.
        //Skip stuff in parens, if you can't find non enclosed operators, then make a paren expression.
        //Can't find operators or parens, make an atomic expression.

        foreach(char c in operators){
            for(int i = 0; i < str.Length; i++){
                if(str[i] == c && !inParen){
                    // Console.WriteLine(str.Substring(0,i));
                    Expression leftExpr = parse(str.Substring(0,i));
                    // Console.WriteLine("Error in right");
                    Expression rightExpr = parse(str.Substring(i+1, str.Length-i-1));
                    switch (c){
                    case '-':
                        return new SubtractExpression(leftExpr, rightExpr);

                    case '+':
                        return new AddExpression(leftExpr, rightExpr);

                    case '*':
                        return new MultiplyExpression(leftExpr, rightExpr);

                    case '/':
                        return new DivideExpression(leftExpr, rightExpr);

                    case '^':
                        return new ExponentExpression(leftExpr, rightExpr);

                    }
                }
                if(str[i] == '('){ inParen = true; parenFound = true;}
                if(str[i] == ')'){ inParen = false;}
            }
        }

        //Must be enclosed, take off parens and parse.
        if(parenFound){
            str = str.Trim();
            return new ParenExpression(parse(str.Substring(1,str.Length - 2)));
        }

        //Has to be atomic
        var fmt = new NumberFormatInfo();
        fmt.NegativeSign = "−";
        return new AtomicExpression(Convert.ToDouble(str,fmt));

        
    }

    //Checks if string is a valid expression.
    public bool sanityCheck(string str){
       
        string operators = "+ - * / ^";
        states state = states.Operator; //Had a beginning state, but the first elements of an expression are the
                                        //same as what comes after an operator so I dropped it.
        double garbage = 0;
        str = str.Trim();

        //Loop until we reach end.

        //State changes as we parse, determining what we're looking for next.
        while (true){
            switch (state)
            {
                //Some error in parsing, invalid
                case states.Fail:
                    return false;
                //Reached end and valid
                case states.End:
                    return true;
                //Operator, looking for paren or value.
                case states.Operator:
                    if (String.IsNullOrEmpty(str)){
                        state = states.Fail;
                        break;
                    }
                    if(str[0] == ' '){str = str.Trim();}
                    
                    if (Double.TryParse(Char.ToString(str[0]), out garbage)) {
                        state = states.Value;
                        str = advance(str);
                    } else {
                        if (str[0] != '('){
                            state = states.Fail;
                        } else {
                            state = states.Paren;
                            str = advance(str);
                        }
                    }
                    break;
                //Value, looking for an operator or the end.
                case states.Value:
                    if (String.IsNullOrEmpty(str)){
                        //Reached the end.
                        state = states.End;
                        break;
                    }
                    if (Double.TryParse(Char.ToString(str[0]), out garbage)) {
                        str = advance(str);
                    } else {
                        if(str[0] == ' '){str = str.Trim();}
                        if(operators.Contains(Char.ToString(str[0]))){
                            //Found an operator.
                            str = advance(str);
                            state = states.Operator;
                        } else {
                            //Invalid character.
                            state = states.Fail;
                        }
                    }
                    break;
                //Found a paren, find the end paren, then evaluate what's between them. Then look for an operator or end.
                case states.Paren:
                    if(str.Contains(")")){ //If other paren exists, evaluate what's between.
                        string next = str.Substring(0,str.IndexOf(")"));
                        if (sanityCheck(next)){
                            str = str.Substring(str.IndexOf(")") + 1); //Now look for either an operator or the end.
                            if (String.IsNullOrEmpty(str)){
                                state = states.End;
                                break;
                            } else {
                                if(str[0] == ' '){str = str.Trim();}
                                if(operators.Contains(Char.ToString(str[0]))){
                                    str = advance(str);
                                    state = states.Operator;
                                } else {
                                    state = states.Fail;
                                }
                            }
                        } else {
                            state = states.Fail;
                        }
                    } else {
                        state = states.Fail;
                        break;
                    }
                    break;
                default:
                    state = states.Fail; //This shouldn't happen so let's just break out.
                    break;
            }
        }
        
    }

    //Takes a string, returns that string minus the first character. Advances in parsing the string.
    public string advance(string str){
        return str.Substring(1);
    }
}