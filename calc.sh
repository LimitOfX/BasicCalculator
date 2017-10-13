#!/bin/bash
mcs -out:calc.exe Parser/Parser.cs Expressions/Expressions.cs Interface/CalcInterface.cs Interface/CLInterface.cs
