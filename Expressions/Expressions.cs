using System;

/*
    Author: Joshua Hanf.
 */
//Collection of classes representing types of expressions. As they have two children that are also expressions, end result is a binary tree.
public abstract class Expression{

    // The two sides of the expression, paren type expressions will have right be null.
    protected Expression leftSide;
    //Atomic has both null.
    protected Expression rightSide;

    //Evaluate the expression and return it's value as a double.
    public abstract double evaluate();

}

public class ParenExpression : Expression{
    public ParenExpression(Expression expr){
        leftSide = expr;
        rightSide = null;
    }

    public override double evaluate(){
        return leftSide.evaluate();
    }
}

public class AtomicExpression : Expression{
    double value;
    public AtomicExpression(double expr){
        value = expr;
    }

    public override double evaluate(){
        return value;
    }
}

public class ExponentExpression : Expression{
    public ExponentExpression(Expression left, Expression right){
        leftSide = left;
        rightSide = right;
    }

    public override double evaluate(){
        return Math.Pow(leftSide.evaluate(), rightSide.evaluate());
    }
}

public class DivideExpression : Expression{
    public DivideExpression(Expression left, Expression right){
        leftSide = left;
        rightSide = right;
    }

    public override double evaluate(){
        return leftSide.evaluate() / rightSide.evaluate();
    }
}

public class MultiplyExpression : Expression{
    public MultiplyExpression(Expression left, Expression right){
        leftSide = left;
        rightSide = right;
    }

    public override double evaluate(){
        return leftSide.evaluate() * rightSide.evaluate();
    }
}

public class AddExpression : Expression{
    public AddExpression(Expression left, Expression right){
        leftSide = left;
        rightSide = right;
    }

    public override double evaluate(){
        return leftSide.evaluate() + rightSide.evaluate();
    }
}

public class SubtractExpression : Expression{
    public SubtractExpression(Expression left, Expression right){
        leftSide = left;
        rightSide = right;
    }

    public override double evaluate(){
        return leftSide.evaluate() - rightSide.evaluate();
    }
}