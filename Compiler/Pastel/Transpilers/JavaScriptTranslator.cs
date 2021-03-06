﻿using Common;
using Pastel.Nodes;
using System;
using System.Collections.Generic;

namespace Pastel.Transpilers
{
    internal class JavaScriptTranslator : CurlyBraceTranslator
    {
        public JavaScriptTranslator() : base("\t", "\n", true)
        {
            this.UsesStructDefinitions = false;
        }

        public override void TranslateArrayGet(TranspilerContext sb, Expression array, Expression index)
        {
            this.TranslateExpression(sb, array);
            sb.Append('[');
            this.TranslateExpression(sb, index);
            sb.Append(']');
        }

        public override void TranslateArrayJoin(TranspilerContext sb, Expression array, Expression sep)
        {
            throw new NotImplementedException();
        }

        public override void TranslateArrayLength(TranspilerContext sb, Expression array)
        {
            this.TranslateExpression(sb, array);
            sb.Append(".length");
        }

        public override void TranslateArrayNew(TranspilerContext sb, PType arrayType, Expression lengthExpression)
        {
            sb.Append("C$common$createNewArray(");
            this.TranslateExpression(sb, lengthExpression);
            sb.Append(')');
        }

        public override void TranslateArraySet(TranspilerContext sb, Expression array, Expression index, Expression value)
        {
            this.TranslateExpression(sb, array);
            sb.Append('[');
            this.TranslateExpression(sb, index);
            sb.Append("] = ");
            this.TranslateExpression(sb, value);
        }

        public override void TranslateBase64ToString(TranspilerContext sb, Expression base64String)
        {
            sb.Append("C$common$base64ToString(");
            this.TranslateExpression(sb, base64String);
            sb.Append(')');
        }

        public override void TranslateCast(TranspilerContext sb, PType type, Expression expression)
        {
            this.TranslateExpression(sb, expression);
        }

        public override void TranslateCharConstant(TranspilerContext sb, char value)
        {
            sb.Append(Util.ConvertStringValueToCode(value.ToString()));
        }

        public override void TranslateCharToString(TranspilerContext sb, Expression charValue)
        {
            this.TranslateExpression(sb, charValue);
        }

        public override void TranslateChr(TranspilerContext sb, Expression charCode)
        {
            sb.Append("String.fromCharCode(");
            this.TranslateExpression(sb, charCode);
            sb.Append(')');
        }

        public override void TranslateCommandLineArgs(TranspilerContext sb)
        {
            sb.Append("C$common$commandLineArgs");
        }

        public override void TranslateConstructorInvocation(TranspilerContext sb, ConstructorInvocation constructorInvocation)
        {
            sb.Append('[');
            Expression[] args = constructorInvocation.Args;
            for (int i = 0; i < args.Length; ++i)
            {
                if (i > 0) sb.Append(", ");
                this.TranslateExpression(sb, args[i]);
            }
            sb.Append(']');
        }

        public override void TranslateConvertRawDictionaryValueCollectionToAReusableValueList(TranspilerContext sb, Expression dictionary)
        {
            this.TranslateExpression(sb, dictionary);
        }

        public override void TranslateCurrentTimeSeconds(TranspilerContext sb)
        {
            sb.Append("C$common$now()");
        }

        public override void TranslateDictionaryContainsKey(TranspilerContext sb, Expression dictionary, Expression key)
        {
            sb.Append("(");
            this.TranslateExpression(sb, dictionary);
            sb.Append('[');
            this.TranslateExpression(sb, key);
            sb.Append("] !== undefined)");
        }

        public override void TranslateDictionaryGet(TranspilerContext sb, Expression dictionary, Expression key)
        {
            this.TranslateExpression(sb, dictionary);
            sb.Append('[');
            this.TranslateExpression(sb, key);
            sb.Append(']');
        }

        public override void TranslateDictionaryKeys(TranspilerContext sb, Expression dictionary)
        {
            sb.Append("C$common$dictionaryKeys(");
            this.TranslateExpression(sb, dictionary);
            sb.Append(')');
        }

        public override void TranslateDictionaryKeysToValueList(TranspilerContext sb, Expression dictionary)
        {
            throw new NotImplementedException();
        }

        public override void TranslateDictionaryNew(TranspilerContext sb, PType keyType, PType valueType)
        {
            sb.Append("{}");
        }

        public override void TranslateDictionaryRemove(TranspilerContext sb, Expression dictionary, Expression key)
        {
            sb.Append("delete ");
            this.TranslateExpression(sb, dictionary);
            sb.Append('[');
            this.TranslateExpression(sb, key);
            sb.Append(']');
        }

        public override void TranslateDictionarySet(TranspilerContext sb, Expression dictionary, Expression key, Expression value)
        {
            this.TranslateExpression(sb, dictionary);
            sb.Append('[');
            this.TranslateExpression(sb, key);
            sb.Append("] = ");
            this.TranslateExpression(sb, value);
        }

        public override void TranslateDictionarySize(TranspilerContext sb, Expression dictionary)
        {
            sb.Append("Object.keys(");
            this.TranslateExpression(sb, dictionary);
            sb.Append(").length");
        }

        public override void TranslateDictionaryValues(TranspilerContext sb, Expression dictionary)
        {
            sb.Append("C$common$dictionaryValues(");
            this.TranslateExpression(sb, dictionary);
            sb.Append(')');
        }

        public override void TranslateDictionaryValuesToValueList(TranspilerContext sb, Expression dictionary)
        {
            throw new NotImplementedException();
        }

        public override void TranslateFloatBuffer16(TranspilerContext sb)
        {
            sb.Append("C$common$floatBuffer16");
        }

        public override void TranslateFloatDivision(TranspilerContext sb, Expression floatNumerator, Expression floatDenominator)
        {
            sb.Append('(');
            this.TranslateExpression(sb, floatNumerator);
            sb.Append(" / ");
            this.TranslateExpression(sb, floatDenominator);
            sb.Append(')');
        }

        public override void TranslateFloatToInt(TranspilerContext sb, Expression floatExpr)
        {
            sb.Append("Math.floor(");
            this.TranslateExpression(sb, floatExpr);
            sb.Append(')');
        }

        public override void TranslateFloatToString(TranspilerContext sb, Expression floatExpr)
        {
            sb.Append("'' + ");
            this.TranslateExpression(sb, floatExpr);
        }

        public override void TranslateGetProgramData(TranspilerContext sb)
        {
            sb.Append("C$common$programData");
        }

        public override void TranslateGetResourceManifest(TranspilerContext sb)
        {
            sb.Append("C$common$resourceManifest");
        }

        public override void TranslateGlobalVariable(TranspilerContext sb, Variable variable)
        {
            sb.Append("v_");
            sb.Append(variable.Name);
        }

        public override void TranslateIntBuffer16(TranspilerContext sb)
        {
            sb.Append("C$common$intBuffer16");
        }

        public override void TranslateIntegerDivision(TranspilerContext sb, Expression integerNumerator, Expression integerDenominator)
        {
            sb.Append("Math.floor(");
            this.TranslateExpression(sb, integerNumerator);
            sb.Append(" / ");
            this.TranslateExpression(sb, integerDenominator);
            sb.Append(')');
        }

        public override void TranslateIntToString(TranspilerContext sb, Expression integer)
        {
            sb.Append("('' + ");
            this.TranslateExpression(sb, integer);
            sb.Append(')');
        }

        public override void TranslateInvokeDynamicLibraryFunction(TranspilerContext sb, Expression functionId, Expression argsArray)
        {
            this.TranslateExpression(sb, functionId);
            sb.Append('(');
            this.TranslateExpression(sb, argsArray);
            sb.Append(')');
        }

        public override void TranslateIsValidInteger(TranspilerContext sb, Expression stringValue)
        {
            sb.Append("C$common$is_valid_integer(");
            this.TranslateExpression(sb, stringValue);
            sb.Append(')');
        }

        public override void TranslateListAdd(TranspilerContext sb, Expression list, Expression item)
        {
            this.TranslateExpression(sb, list);
            sb.Append(".push(");
            this.TranslateExpression(sb, item);
            sb.Append(')');
        }

        public override void TranslateListClear(TranspilerContext sb, Expression list)
        {
            sb.Append("C$common$clearList(");
            this.TranslateExpression(sb, list);
            sb.Append(')');
        }

        public override void TranslateListConcat(TranspilerContext sb, Expression list, Expression items)
        {
            this.TranslateExpression(sb, list);
            sb.Append(".concat(");
            this.TranslateExpression(sb, items);
            sb.Append(")");
        }

        public override void TranslateListGet(TranspilerContext sb, Expression list, Expression index)
        {
            this.TranslateExpression(sb, list);
            sb.Append('[');
            this.TranslateExpression(sb, index);
            sb.Append(']');
        }

        public override void TranslateListInsert(TranspilerContext sb, Expression list, Expression index, Expression item)
        {
            this.TranslateExpression(sb, list);
            sb.Append(".splice(");
            this.TranslateExpression(sb, index);
            sb.Append(", 0, ");
            this.TranslateExpression(sb, item);
            sb.Append(')');
        }

        public override void TranslateListJoinChars(TranspilerContext sb, Expression list)
        {
            this.TranslateExpression(sb, list);
            sb.Append(".join('')");
        }

        public override void TranslateListJoinStrings(TranspilerContext sb, Expression list, Expression sep)
        {
            this.TranslateExpression(sb, list);
            sb.Append(".join(");
            this.TranslateExpression(sb, sep);
            sb.Append(')');
        }

        public override void TranslateListNew(TranspilerContext sb, PType type)
        {
            sb.Append("[]");
        }

        public override void TranslateListPop(TranspilerContext sb, Expression list)
        {
            this.TranslateExpression(sb, list);
            sb.Append(".pop()");
        }

        public override void TranslateListRemoveAt(TranspilerContext sb, Expression list, Expression index)
        {
            this.TranslateExpression(sb, list);
            sb.Append(".splice(");
            this.TranslateExpression(sb, index);
            sb.Append(", 1)");
        }

        public override void TranslateListReverse(TranspilerContext sb, Expression list)
        {
            this.TranslateExpression(sb, list);
            sb.Append(".reverse()");
        }

        public override void TranslateListSet(TranspilerContext sb, Expression list, Expression index, Expression value)
        {
            this.TranslateExpression(sb, list);
            sb.Append('[');
            this.TranslateExpression(sb, index);
            sb.Append("] = ");
            this.TranslateExpression(sb, value);
        }

        public override void TranslateListShuffle(TranspilerContext sb, Expression list)
        {
            sb.Append("C$common$shuffle(");
            this.TranslateExpression(sb, list);
            sb.Append(')');
        }

        public override void TranslateListSize(TranspilerContext sb, Expression list)
        {
            this.TranslateExpression(sb, list);
            sb.Append(".length");
        }

        public override void TranslateListToArray(TranspilerContext sb, Expression list)
        {
            // TODO: go through and figure out which list to array conversions are necessary to copy and which ones are just ensuring that the type is compatible
            // For example, JS and Python can just no-op in situations where a throwaway list builder is being made.
            sb.Append("C$common$multiplyList(");
            this.TranslateExpression(sb, list);
            sb.Append(", 1)");
        }

        public override void TranslateMathArcCos(TranspilerContext sb, Expression ratio)
        {
            sb.Append("Math.acos(");
            this.TranslateExpression(sb, ratio);
            sb.Append(')');
        }

        public override void TranslateMathArcSin(TranspilerContext sb, Expression ratio)
        {
            sb.Append("Math.asin(");
            this.TranslateExpression(sb, ratio);
            sb.Append(')');
        }

        public override void TranslateMathArcTan(TranspilerContext sb, Expression yComponent, Expression xComponent)
        {
            sb.Append("Math.atan2(");
            this.TranslateExpression(sb, yComponent);
            sb.Append(", ");
            this.TranslateExpression(sb, xComponent);
            sb.Append(')');
        }

        public override void TranslateMathCos(TranspilerContext sb, Expression thetaRadians)
        {
            sb.Append("Math.cos(");
            this.TranslateExpression(sb, thetaRadians);
            sb.Append(')');
        }

        public override void TranslateMathLog(TranspilerContext sb, Expression value)
        {
            sb.Append("Math.log(");
            this.TranslateExpression(sb, value);
            sb.Append(')');
        }

        public override void TranslateMathPow(TranspilerContext sb, Expression expBase, Expression exponent)
        {
            sb.Append("Math.pow(");
            this.TranslateExpression(sb, expBase);
            sb.Append(", ");
            this.TranslateExpression(sb, exponent);
            sb.Append(')');
        }

        public override void TranslateMathSin(TranspilerContext sb, Expression thetaRadians)
        {
            sb.Append("Math.sin(");
            this.TranslateExpression(sb, thetaRadians);
            sb.Append(')');
        }

        public override void TranslateMathTan(TranspilerContext sb, Expression thetaRadians)
        {
            sb.Append("Math.tan(");
            this.TranslateExpression(sb, thetaRadians);
            sb.Append(')');
        }

        public override void TranslateMultiplyList(TranspilerContext sb, Expression list, Expression n)
        {
            sb.Append("C$common$multiplyList(");
            this.TranslateExpression(sb, list);
            sb.Append(", ");
            this.TranslateExpression(sb, n);
            sb.Append(')');
        }

        public override void TranslateNullConstant(TranspilerContext sb)
        {
            sb.Append("null");
        }

        public override void TranslateOrd(TranspilerContext sb, Expression charValue)
        {
            throw new NotImplementedException();
        }

        public override void TranslateParseFloatUnsafe(TranspilerContext sb, Expression stringValue)
        {
            sb.Append("parseFloat(");
            this.TranslateExpression(sb, stringValue);
            sb.Append(')');
        }

        public override void TranslateParseInt(TranspilerContext sb, Expression safeStringValue)
        {
            sb.Append("parseInt(");
            this.TranslateExpression(sb, safeStringValue);
            sb.Append(')');
        }

        public override void TranslatePrintStdErr(TranspilerContext sb, Expression value)
        {
            sb.Append("C$common$print(");
            this.TranslateExpression(sb, value);
            sb.Append(')');
        }

        public override void TranslatePrintStdOut(TranspilerContext sb, Expression value)
        {
            sb.Append("C$common$print(");
            this.TranslateExpression(sb, value);
            sb.Append(')');
        }

        public override void TranslateRandomFloat(TranspilerContext sb)
        {
            sb.Append("Math.random()");
        }

        public override void TranslateReadByteCodeFile(TranspilerContext sb)
        {
            sb.Append("C$bytecode");
        }

        public override void TranslateRegisterLibraryFunction(TranspilerContext sb, Expression libRegObj, Expression functionName, Expression functionArgCount)
        {
            sb.Append("C$common$registerLibraryFunction('");
            sb.Append(sb.UniquePrefixForNonCollisions);
            sb.Append("', ");
            this.TranslateExpression(sb, libRegObj);
            sb.Append(", ");
            this.TranslateExpression(sb, functionName);
            sb.Append(", ");
            this.TranslateExpression(sb, functionArgCount);
            sb.Append(')');
        }

        public override void TranslateResourceReadTextFile(TranspilerContext sb, Expression path)
        {
            sb.Append("C$common$readResourceText(");
            this.TranslateExpression(sb, path);
            sb.Append(')');
        }

        public override void TranslateSetProgramData(TranspilerContext sb, Expression programData)
        {
            sb.Append("C$common$programData = ");
            this.TranslateExpression(sb, programData);
        }

        public override void TranslateSortedCopyOfIntArray(TranspilerContext sb, Expression intArray)
        {
            sb.Append("C$common$sortedCopyOfArray(");
            this.TranslateExpression(sb, intArray);
            sb.Append(')');
        }

        public override void TranslateSortedCopyOfStringArray(TranspilerContext sb, Expression stringArray)
        {
            sb.Append("C$common$sortedCopyOfArray(");
            this.TranslateExpression(sb, stringArray);
            sb.Append(')');
        }

        public override void TranslateStringAppend(TranspilerContext sb, Expression str1, Expression str2)
        {
            this.TranslateExpression(sb, str1);
            sb.Append(" += ");
            this.TranslateExpression(sb, str2);
        }

        public override void TranslateStringBuffer16(TranspilerContext sb)
        {
            sb.Append("C$common$stringBuffer16");
        }

        public override void TranslateStringCharAt(TranspilerContext sb, Expression str, Expression index)
        {
            this.TranslateExpression(sb, str);
            sb.Append(".charAt(");
            this.TranslateExpression(sb, index);
            sb.Append(')');
        }

        public override void TranslateStringCharCodeAt(TranspilerContext sb, Expression str, Expression index)
        {
            this.TranslateExpression(sb, str);
            sb.Append(".charCodeAt(");
            this.TranslateExpression(sb, index);
            sb.Append(')');
        }

        public override void TranslateStringCompareIsReverse(TranspilerContext sb, Expression str1, Expression str2)
        {
            sb.Append("(");
            this.TranslateExpression(sb, str1);
            sb.Append(".localeCompare(");
            this.TranslateExpression(sb, str2);
            sb.Append(") > 0)");
        }

        public override void TranslateStringConcatAll(TranspilerContext sb, Expression[] strings)
        {
            sb.Append("[");
            for (int i = 0; i < strings.Length; ++i)
            {
                if (i > 0) sb.Append(", ");
                this.TranslateExpression(sb, strings[i]);
            }
            sb.Append("].join('')");
        }

        public override void TranslateStringConcatPair(TranspilerContext sb, Expression strLeft, Expression strRight)
        {
            this.TranslateExpression(sb, strLeft);
            sb.Append(" + ");
            this.TranslateExpression(sb, strRight);
        }

        public override void TranslateStringContains(TranspilerContext sb, Expression haystack, Expression needle)
        {
            sb.Append('(');
            this.TranslateExpression(sb, haystack);
            sb.Append(".indexOf(");
            this.TranslateExpression(sb, needle);
            sb.Append(") != -1)");
        }

        public override void TranslateStringEndsWith(TranspilerContext sb, Expression haystack, Expression needle)
        {
            sb.Append("C$common$stringEndsWith(");
            this.TranslateExpression(sb, haystack);
            sb.Append(", ");
            this.TranslateExpression(sb, needle);
            sb.Append(')');
        }

        public override void TranslateStringEquals(TranspilerContext sb, Expression left, Expression right)
        {
            this.TranslateExpression(sb, left);
            sb.Append(" == ");
            this.TranslateExpression(sb, right);
        }

        public override void TranslateStringFromCharCode(TranspilerContext sb, Expression charCode)
        {
            sb.Append("String.fromCharCode(");
            this.TranslateExpression(sb, charCode);
            sb.Append(')');
        }

        public override void TranslateStringIndexOf(TranspilerContext sb, Expression haystack, Expression needle)
        {
            this.TranslateExpression(sb, haystack);
            sb.Append(".indexOf(");
            this.TranslateExpression(sb, needle);
            sb.Append(')');
        }

        public override void TranslateStringIndexOfWithStart(TranspilerContext sb, Expression haystack, Expression needle, Expression startIndex)
        {
            this.TranslateExpression(sb, haystack);
            sb.Append(".indexOf(");
            this.TranslateExpression(sb, needle);
            sb.Append(", ");
            this.TranslateExpression(sb, startIndex);
            sb.Append(')');
        }

        public override void TranslateStringLength(TranspilerContext sb, Expression str)
        {
            this.TranslateExpression(sb, str);
            sb.Append(".length");
        }

        public override void TranslateStringReplace(TranspilerContext sb, Expression haystack, Expression needle, Expression newNeedle)
        {
            this.TranslateExpression(sb, haystack);
            sb.Append(".split(");
            this.TranslateExpression(sb, needle);
            sb.Append(").join(");
            this.TranslateExpression(sb, newNeedle);
            sb.Append(')');
        }

        public override void TranslateStringReverse(TranspilerContext sb, Expression str)
        {
            this.TranslateExpression(sb, str);
            sb.Append(".split('').reverse().join('')");
        }

        public override void TranslateStringSplit(TranspilerContext sb, Expression haystack, Expression needle)
        {
            this.TranslateExpression(sb, haystack);
            sb.Append(".split(");
            this.TranslateExpression(sb, needle);
            sb.Append(')');
        }

        public override void TranslateStringStartsWith(TranspilerContext sb, Expression haystack, Expression needle)
        {
            sb.Append('(');
            this.TranslateExpression(sb, haystack);
            sb.Append(".indexOf(");
            this.TranslateExpression(sb, needle);
            sb.Append(") == 0)");
        }

        public override void TranslateStringSubstring(TranspilerContext sb, Expression str, Expression start, Expression length)
        {
            this.TranslateExpression(sb, str);
            sb.Append(".substring(");
            this.TranslateExpression(sb, start);
            sb.Append(", ");
            this.TranslateExpression(sb, start);
            sb.Append(" + ");
            this.TranslateExpression(sb, length);
            sb.Append(')');
        }

        public override void TranslateStringSubstringIsEqualTo(TranspilerContext sb, Expression haystack, Expression startIndex, Expression needle)
        {
            throw new NotImplementedException();
        }

        public override void TranslateStringToLower(TranspilerContext sb, Expression str)
        {
            this.TranslateExpression(sb, str);
            sb.Append(".toLowerCase()");
        }

        public override void TranslateStringToUpper(TranspilerContext sb, Expression str)
        {
            this.TranslateExpression(sb, str);
            sb.Append(".toUpperCase()");
        }

        public override void TranslateStringTrim(TranspilerContext sb, Expression str)
        {
            this.TranslateExpression(sb, str);
            sb.Append(".trim()");
        }

        public override void TranslateStringTrimEnd(TranspilerContext sb, Expression str)
        {
            sb.Append("C$common$stringTrimOneSide(");
            this.TranslateExpression(sb, str);
            sb.Append(", false)");
        }

        public override void TranslateStringTrimStart(TranspilerContext sb, Expression str)
        {
            sb.Append("C$common$stringTrimOneSide(");
            this.TranslateExpression(sb, str);
            sb.Append(", true)");
        }

        public override void TranslateStrongReferenceEquality(TranspilerContext sb, Expression left, Expression right)
        {
            throw new NotImplementedException();
        }

        public override void TranslateStructFieldDereference(TranspilerContext sb, Expression root, StructDefinition structDef, string fieldName, int fieldIndex)
        {
            this.TranslateExpression(sb, root);
            sb.Append('[');
            sb.Append(fieldIndex);
            sb.Append(']');
        }

        public override void TranslateThreadSleep(TranspilerContext sb, Expression seconds)
        {
            throw new NotImplementedException();
        }

        public override void TranslateTryParseFloat(TranspilerContext sb, Expression stringValue, Expression floatOutList)
        {
            sb.Append("C$common$floatParseHelper(");
            this.TranslateExpression(sb, floatOutList);
            sb.Append(", ");
            this.TranslateExpression(sb, stringValue);
            sb.Append(')');
        }

        public override void TranslateVariableDeclaration(TranspilerContext sb, VariableDeclaration varDecl)
        {
            sb.Append(sb.CurrentTab);
            sb.Append("var v_");
            sb.Append(varDecl.VariableNameToken.Value);
            sb.Append(" = ");
            if (varDecl.Value == null)
            {
                sb.Append("null");
            }
            else
            {
                this.TranslateExpression(sb, varDecl.Value);
            }
            sb.Append(';');
            sb.Append(this.NewLine);
        }

        public override void TranslateVmDetermineLibraryAvailability(TranspilerContext sb, Expression libraryName, Expression libraryVersion)
        {
            sb.Append("C$common$determineLibraryAvailability(");
            this.TranslateExpression(sb, libraryName);
            sb.Append(", ");
            this.TranslateExpression(sb, libraryVersion);
            sb.Append(')');
        }

        public override void TranslateVmEnqueueResume(TranspilerContext sb, Expression seconds, Expression executionContextId)
        {
            sb.Append("C$common$enqueueVmResume(");
            this.TranslateExpression(sb, seconds);
            sb.Append(", ");
            this.TranslateExpression(sb, executionContextId);
            sb.Append(')');
        }

        public override void TranslateVmEndProcess(TranspilerContext sb)
        {
            // Specific app-like JS platforms can override.
        }

        public override void TranslateVmRunLibraryManifest(TranspilerContext sb, Expression libraryName, Expression libRegObj)
        {
            sb.Append("C$common$runLibraryManifest(");
            this.TranslateExpression(sb, libraryName);
            sb.Append(", ");
            this.TranslateExpression(sb, libRegObj);
            sb.Append(')');
        }

        public override void GenerateCodeForFunction(TranspilerContext sb, FunctionDefinition funcDef)
        {
            sb.Append("var v_");
            sb.Append(funcDef.NameToken.Value);
            sb.Append(" = function(");
            Token[] args = funcDef.ArgNames;
            for (int i = 0; i < args.Length; ++i)
            {
                if (i > 0) sb.Append(", ");
                sb.Append("v_");
                sb.Append(args[i].Value);
            }
            sb.Append(") {");
            sb.Append(this.NewLine);

            sb.TabDepth = 1;
            this.TranslateExecutables(sb, funcDef.Code);
            sb.TabDepth = 0;

            sb.Append("};");
            sb.Append(this.NewLine);
            sb.Append(this.NewLine);
        }

        public override void GenerateCodeForGlobalsDefinitions(TranspilerContext sb, IList<VariableDeclaration> globals)
        {
            foreach (VariableDeclaration global in globals)
            {
                this.TranslateVariableDeclaration(sb, global);
            }
        }

        public override void GenerateCodeForStruct(TranspilerContext sb, StructDefinition structDef)
        {
            throw new NotImplementedException();
        }
    }
}
