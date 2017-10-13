#!/bin/bash
mcs -out:test.exe Parser/Parser.cs Expressions/Expressions.cs Testing/*.cs Interface/CalcInterface.cs
