# Introduction to Crayon for Beginners

This tutorial is intended for anyone that wants to start learning programming who currently has absolutely no previous programming experience.

If you do have some programming experience, you may be interested in the [intermediate tutorial](https://github.com/blakeohare/crayon/blob/master/Tutorials/intro-intermediate/index.md) which introduces Crayon in terms of concepts you probably know from other languages.

## Why learn Crayon? Why not another language?
I'll address this question by giving a quick rundown of what the modern programming language options are and why you would or wouldn't want to learn those languages as a first programming language. 

Generally programming languages fall along a continuous spectrum that ranges from what we call "high level languages" and "low level languages". In a nutshell, this refers to how much the programming language resemble what the CPU actually understands. A language that is designed to be a low level language can be executed by your computer extremely fast because it's pretty close to what it knows and understands. A language that is very abstract and requires several translations before it can be understood by the computer is going to run slower. Given this, it may seem like low-level languages are more ideal, but this is a double-edged sword. A high level language can be designed to more closely resemble programmer intent and practices. It can also offer safety protections that can make identifying issues quicker and easier. 

So which one should people use? There's a common saying in software engineering: "Right tool for the right job". Here's a sample of modern programming languages and where they fall on the spectrum:

### Low level languages - C & C++
These offer few protections from programmer error, are difficult to identify problems, but run extremely fast. These days, these languages are typically only used when needed (direct hardware interaction, high performance games, and dependency-free programs).

### Mid level languages - Java & C#
These offer a lot of protections, but are also somewhat restrictive to maintain program structure. This is generally burdensome for small programs, but makes larger programs easier to maintain. They run pretty fast.

### High level languages - Python, Ruby, & JavaScript
These offer lots of protections, but at the same time are so high level, that they lack structure and have a malleable feel to them. This makes them extremely efficient for making small programs, but larger programs become brittle and difficult to maintain. Since it's generally easiest to get started in these languages, they are frequently cited as ideal first programming languages for beginners.

### Where does Crayon fit in?
Crayon was designed to be at the low end of the high level languages. It enforces some of the structure similar to the mid level languages in the above list, but at its core, it's a high level language that was initially based off of Python's behaviors. 

As a side note, C had a great deal of influence in the design of the syntax of many of the languages that follow it. You'll notice that of the languages listed here, all of them (except for Python and Ruby) are about 90% similar to C in the way they look. For the sake of consistency and adhering to common industry practices, Crayon is no different. This means a lot of the information you learn in this tutorial will actually be transferable to other languages and vice-versa. If you already know one of these other languages, you may be more interested in the [intermediate tutorial](https://github.com/blakeohare/crayon/blob/master/Tutorials/intro-intermediate/index.md) which quickly goes over various Crayon concepts in terms of programming concepts you already know from other languages. 

## Lesson 1 - Setting up Crayon and Hello World

The way to set up Crayon is slightly different depending on whether you're using Windows or Mac. How to set up Crayon is outlined in [this walkthrough](https://github.com/blakeohare/crayon/blob/master/Docs/installation/index.md). Once you've gotten set up, open the command line and type "crayon" (without the quotes) and hit enter. If you haven't used the command line before, there's a [command line tutorial here](https://github.com/blakeohare/crayon/blob/master/Tutorials/command-line/index.md). Once you type crayon and hit enter, you should see something like this:

```
Usage:
  crayon BUILD-FILE -target BUILD-TARGET-NAME [OPTIONS...]

(...and some other stuff as well)
```

If you see that, then you're good to go. If not, please reach out to the [mailing list](https://groups.google.com/forum/#!forum/crayon-lang) for help. 

To create a new project use the command line and navigate to the directory where you'd like to create a project. I'll be working in C:\Users\Blake\Documents in this example. Once you've navigated there, run the following command:

```
C:\Users\Blake\Documents> crayon -genDefaultProject HelloWorld
```

This will generate a new directory called HelloWorld. This will create a couple of files. 

* **HelloWorld/HelloWorld.build** - this is the build configuration file. This configures things for when you want to export your project when you want to release it somewhere. We won't do too much with this for now. The defaults values in this file are good enough for the time being.
* **HelloWorld/source/main.cry** - this is the main source code file for the project. We'll mostly be working with this in this tutorial.
* **HelloWorld/.gitignore** - this is useful if you plan on committing your code to a git repository. If you don't plan on doing that, it's safe to just ignore or even delete this file.

Open up the *source/main.cry* file in a text editor such as notepad. If you have a text editor that's designed for editing code, use that. Otherwise, Notepad will work for now. I highly recommend Notepad++ for Windows users or sublime for other platforms. Do not use something like wordpad or any other word-processing style text editor. These editors are generally not capable nor designed to edit plain text (formatting-free) documents and will ruin the file.
 
Once you open the file, you'll see the following:

```csharp
function main(args) {
    print("Hello, World!");
}
```

Don't panic. Here's a super quick rundown of what this is and what it means. We'll talk about everything in much more detail in later sections. But for now this is all you need to know:

* A **function** is just a collection of code. The word `function` here declares that you are about to define a function and its name in this case is `main`.
* Don't worry about the `(args)` yet. I'll talk about that more later.
* The `{` and `}` characters group lines of code together. In this case, this is saying that the next line is the code that belongs to this function.
* `print` has nothing to do with your printer. This will simply display text on the screen. We'll be running this from the command line and so this text will also appear on the command line when we run it.
* `"Hello, World"` is the text that will be displayed on the screen.
* The semicolon indicates that this is the end of this line of code.

When a program runs, it'll start by running the code in the main function. It'll run each line, one by one, and then once it gets to the end, the program will quit. In this case there's only one line. 

Go ahead and give it a try. Make sure the command line is currently pointed to the HelloWorld folder and then run this command:

```
C:\Users\Blake\Documents\HelloWorld> crayon HelloWorld.build
Hello, World!
```

That pretty much concludes this lesson. If you saw `Hello, World!` appear when you ran that command, it means you're completely set up and ready to do some more complicated stuff.

### A quick safety demonstration before we start our flight:
If at any point in this tutorial you accidentally create a program that won't close, you can always press `Ctrl + C` in the command line to force it to close.

## Lesson 2 - Variables and Operators
Programs are all about moving data around, changing it, and using it in a meaningful way. Even in games. But before we start writing Tetris, we'll need to start with the basic verbs.

In this section I'll talk about variables and equations. With the exception of order of operations, please forget everything you learned in high school math. Variables and equations in programming are entirely different than math variables aside from their name. 

Modify your original HelloWorld program so that the main function looks like this:

```csharp
function main(args) {
    x = 1;
    x = 2 * x;
    x = x + 10;
    print(x);
}
```

Run this and you'll see the following:

```
C:\...> crayon HelloWorld.build
12
```

If you're confused it's probably because you paid attention in high school math, where you probably saw something like this:

```
x = 10 + 2 * x
```

Your instincts will probably tell you to subtract one `x` from each side leaving you with `0 = 10 + x`, do some other stuff, and then realize `x` is equal to `-10`. ***Please forget this process entirely***. In programming, variables are nothing more than little buckets of memory that hold some sort of value, such as a number. Solving equations does not exist in programming and often the `=` is somewhat confusing to first time programmers. Instead of a `=`, you can imagine that this is actually an arrow pointing to the left. This means store the value on the right side of the "equation" into the variable on the left side. The lines are executed in order from top to bottom. If we look back at the example code, it starts to make more sense:

"Store the number 1 into a bucket called x":

```csharp
x = 1;
```

"Take the value out of the bucket, multiply it by 2, and then put it back into that same bucket.":

```csharp
x = 2 * x;
```

"Take the value out of the bucket again, this time add 10 to it, and then put it back.":

```csharp
x = x + 10;
```

As you can see, it's a very orderly, unambiguous, mechanical process and there is no "solving for x". 

However, one thing does still apply from what you learned in high school math, and that is order of operations. Multiplication and division are applied first before addition and subtraction. 

```csharp
print(1 + 2 * 3);
```

This prints 7, not 9. 
When in doubt, just add parenthesis to things. Parenthesis never hurt:

```csharp
print((1 + 2) * 3);
```

Now this prints 9 instead of 7. 

Variables can be named anything. Not just algebraic-style single letter names like "x". There's just a few rules:

* Letters, numbers, and the underscore `_` characters can be used in the name.
* The variable name cannot begin with a number.
* The name cannot be the same as a built-in programming language keyword. For example, you can't use `function` as a variable name.
* The following are not rules, but guidelines to follow:
* The variable name should be specific and clearly understandable. Long names are okay. They don't make your program slower. 
* One letter variable names are generally discouraged except for one specific case that I'll talk about in the section about loops. 
* Variables should begin with a lowercase letter. While this makes no technical difference, there are other things that generally begin with uppercase letters and sticking to this convention makes code easier to read.

## Lesson 3 - Conditions and Command Line Input

Programs that do the same thing every time are kind of boring. Let's mix things up a bit. Change your main function definition to look like this:

```csharp
function main(args) {
    x = parseInt(args[0]);
    xSquared = x * x;
    print(xSquared);
}
```
    
Notice the `args` between the parenthesis after the name of the function. This is called function **arguments**. But because this is the main function, these are also known as command line arguments. Like its name implies, these are set from the command line when you execute your program. When you run your program, put a number at the end and this will happen:

```
C:\...> crayon HelloWorld.build 9
81
```

The next line of the program introduces a few other things that we won't worry too much about right now aside from a quick temporary explanation.

```csharp
x = parseInt(args[0]);
```

Numbers and operators aren't the only thing you can put on the right side of an equation. args is a variable, but instead of holding a number, it is actually a list of pieces of text. Specifically the list of things you typed at the end of the command line command. The `[0]` tells it that you'd like to access the first item in that list (computers count starting from 0, not 1). In the example above, this would mean that it would be the text `9`. As far as computers are concerned, text and numbers are not the same. You could have easily typed `kitty-cat` or `Orbeez` instead of a number. The `parseInt` thing is a function that converts text into an actual number such that the variable `x` actually contains the number `9` instead of the text that has the symbol "`9`" in it. If you use `parseInt` on things that aren't numbers, bad-ish things will happen, but that's out of scope of this section.

Programs that have the same behavior no matter what sort of input you give it are somewhat boring. Let's mix things up a bit and talk about conditional code.

```csharp
function main(args) {
    x = parseInt(args[0]);
    xSquared = x * x;
    print(xSquared);

    if (xSquared > 9000) {
        print("That's big");
    } else {
        print("That's small");
    }
}
```

This introduces the `if` statement and its optional counterpart, `else`. 

We haven't talked about the `{` and `}` characters much yet, but basically they are a way to group lines of code together. These are often referred to as "blocks" of code. While it is possible to distinguish blocks of code by how much they are indented, this is simply a convention and is not enforced. You can write your entire program without any indention or even write the entire thing on one line if you want to (as long as your semicolons are still applied correctly). Curly braces `{` and `}` are a way of strictly declaring where a block begins and ends.

The `if` statement is followed by parenthesis which contains a statement that is either true or false. If it is true, then the block of code following it will run. If it is false, then the block of code following the else statement will run. 

```
C:\...> crayon HelloWorld.build 9
81
That's small

C:\...> crayon HelloWorld.build 210
44100
That's big
```

Furthermore, the `else` is entirely optional. The following is also valid:

```csharp
function main(args) {
    x = parseInt(args[0]);
    xSquared = x * x;
    print(xSquared);

    if (xSquared > 9000) {
        print("That's big");
    }
}
```

You can also chain them together to create lists of possibilities:

```csharp
function main(args) {
    x = parseInt(args[0]);
    xSquared = x * x;
    print(xSquared);

    if (xSquared > 9000) {
        print("That's big");
    } else if (xSquared == 9000) {
        print("That is exactly 9000");
    } else {
        print("That's small");
    }
}
```

**Note:** `==` was not a typo. Comparing two things to see if they're equal is done with two equal signs: `==`. This is to distinguish it from the single `=` which is used to assign values. 

Because the conditions in a series of `if`/`else` statements are checked sequentially, only the first applicable condition will run. Here's yet another example that illustrates this distinction more clearly:

```csharp
function main(args) {
    x = parseInt(args[0]);
    xSquared = x * x;
    print(xSquared);

    if (xSquared < 100) {
        print("That's small");
    } else if (xSquared < 10000) {
        print("That medium-sized");
    } else {
        print("That's big");
    }
}
```

If you were to pass in `2`, the square would be `4`, which is both less than `100` and less than `10000`. However, this code will only show `That's very small`. This is because in a chain of `if`/`else` statements, only the first applicable one will be applied and the remaining ones will be skipped. 

## Lesson 4 - Loops

Another aspect of more complicated programs is making them do more than run from top to bottom. A loop will make a program run a block of code some number of times. How many times and why depends on the kind of loop, of which there are 4.

### While loops
A `while` loop is the simplest kind of loop and resembles an `if` statement without an `else` in many ways.

```csharp
function main(args) {
    x = 1;
    while (x < 1000) {
        print(x);
        x = x * 2;
    }
    print("All done.");
}
```

Think of a `while` loop as an `if` statement except instead of running the block of code once, it'll keep running it repeatedly until the condition is no longer true. In this case, it will double the value of `x` until the value is no longer less than 1000.

If you run this, you'll see the following:

```
C:\...> crayon HelloWorld.build
1
2
4
8
16
32
64
128
256
512
All done.
```

The condition is always checked before the block of code runs. The first time through, the value of `x` was 1, which is less than 1000, and so it printed 1, doubled it, and then went back to the condition. The last time through `x` was 512. It got doubled, and the loop went back to the condition. Now x was 1024 which is greater than 1000 and so the block did not run and instead it proceeded to the code after the while statement, which prints `All done`. 

The `while` loop is the most versatile loop, but as you start using it more frequently, you'll notice a common recurring usage pattern. Generally, when creating loops, you have some sort of line of code that sets up the loop, and another line of code that moves the state of your program closer to finishing the loop. Take a look at the `while` loop from the example again: 

```csharp
x = 1;
while (x < 1000) {
    print(x);
    x = x * 2;
}
```

Here we have `x = 1;`, which is the setup. We also have `x = x * 2;` which steadily moves the value closer to the ending conditions. The existence of these two extra components are so common that there's another kind of loop called a `for` loop which works much like a `while` loop, except it lets you express these concepts more compactly. The above `while` loop could have equally been expressed like this:

```csharp
for (x = 1; x < 1000; x = x * 2) {
    print(x);
}
```

The parenthesis after the word `for` has 3 components separated by semicolons. The first is the setup (`x = 1`), the middle is the condition (`x < 1000`), and the last part is the step (`x = x * 2`). This code is 100% equivalent to the while loop version, but because we have expressed the setup and step as part of the loop, it is easier to read and understand since it is a way of syntactically labelling these lines with their intended purpose in the program. 

In the beginning of this section I stated that there were 4 kinds of loops. One of the others is called a `do-while` loop and is used so seldomly that I will omit it from this tutorial. The fourth kind is called a `for-each` loop and I cannot talk about it until we've talked about lists a little more. 

## Lesson 5 - Functions

So far we've been using functions without really talking about them. A simple definition of a function is that it's a chunk of code with a name. We've been using one function called `main`. We've also used two other functions so far: `print` and `parseInt`. 

To define your own function, use the keyword `function`. Your *main.cry* file can have multiple function definitions, not just the `main` function. To invoke a function, use the name of the function followed by parentheses:

```csharp
function main() {
    sayHello();
}

function sayHello() {
    print("Hello, World!");
}
```

The order that you define the functions does not matter. The `main()` function will always run first. When the `main` function ends, the program ends. In this case, the main function calls another function, `sayHello`, which we have defined below. Then `sayHello` in turn calls another function called `print`. `sayHello` has no arguments. You can just call it and it needs no extra information in order to run. 

Here's a more complicated example:

```csharp
function main(args) {
    x = parseInt(args[0]);
    xSquared = square(x);
    print("The square of " + x + " is " + xSquared);
}

function square(value) {
    result = value * value;
    return result;
}
```

You can use the `+` to add text and numbers together. This will result in a longer piece of text that includes the values concatenated together.

More significantly, the square function uses the `return` keyword. Notice how `square` is used on the right side of an equals sign. This means that the function needs to generate some sort of value that will be assigned to `xSquared`. What that value is is determined by the value that is `return`ed. 

Here are some example functions of common math operations:

```csharp
function absoluteValue(value) {
    if (value < 0) {
        value = -1 * value;
    }
    return value;
}

function factorial(value) {
    accumulatedValue = 1;
    for (n = 1; n <= value; n = n + 1) {
        accumulatedValue = accumulatedValue * n;
    }
    return accumulatedValue;
}

function average(a, b) {
    return (a + b) / 2.0;
}
```

Notice in the last example, a function can have multiple arguments separated by commas. This would be invoked from another function like this:

```csharp
average(10, 20);
```

And would give the result `15.0`. The reason why I used `2.0` instead of `2` and the result having a decimal in it will be covered in the next section.

Another important note is that when a program executes a function, variables names in one function will not interfere with variables in another function even if they have the same name. In fact, every invocation of a function runs in its own separate copy. To illustrate this concept, here's a function that calculates the n<sup>th</sup> number in the fibonacci sequence. For a refresher, the [fibonacci sequence](https://en.wikipedia.org/wiki/Fibonacci_number) is the sequence of numbers where each number is the sum of the previous 2. It looks like this:

```
1, 1, 2, 3, 5, 8, 13, 21, 34, 55, ...
```

```csharp
function fib(n) {
    if (n < 2) {
        return 1;
    }
    value = fib(n - 1) + fib(n - 2);
    return value;
}

function main() {
    n5 = fib(5);
    print(n5);
}
```

If you were to draw a timeline diagram of the computer executing this program, it would look something like the diagram below. Every time you invoke the `fib` function, it will return `1` if the argument is less than `2`, but it will invoke itself twice for every other argument. Each invocation is a separate copy of the function, and it knows which copy to return to when it's done. It's as though each copy keeps a breadcrumb pointing back to its origin. 

```TODO: copy the table from the google doc```

At any given moment, the computer is executing exactly one function at a time. But that function has a parent that originally called it. And that function has a parent that called it, and so on until you get all the way up to `main()`. This is called the **call stack**. In this case, calling `fib(5)` will ultimately cause the `fib` function to run 15 times, but at any given moment, at most 5 versions are present in the call stack.

This is called **recursion** and we'll talk about it more later in lesson 15.

## Lesson 6 - More Types and Operators

Up to this point, types have only informally been introduced. So far, you've seen numbers, text, and a list. In this section I'll talk a little more about the ones we've used so far and also the ones we haven't.

This section will seem a little information-dense since I'll be filling in a lot of the holes that we've skipped over up until this point. 

### Numbers aren't just numbers

While it's true that we've been using numbers up to this point, there are actually two kinds of numbers. Whole numbers, and decimals. In programming, these are usually referred to as **integers** and **floats** (which is short for "floating point decimal"). However, in Crayon (and also in most programming languages), there's a few twists. In normal math, adding `.5` and `.5` will give you `1`, a whole number. But in code, adding these together will give you `1.0`, a float. 

That's right. Even if the part after the decimal is a 0, this number is still considered to be a float by the computer. This is because there are strict rules that govern the interactions between numbers while doing math operations:

* Any operator (such as addition, subtraction, multiplication, division) that is applied between two integers will result in an integer.
  * `3 + 3` is `6`.
* Any operator that is applied between two numbers where one or both of them are floats will result in a float. 
  * `1.0 + 1.0` results in `2.0`
  * `0.0 + 3` results in `3.0`
* If the true mathematical result of an operation between integers will result in a decimal, the decimal is always rounded DOWN so that the result can stay an integer. 
  * `7 / 2` results in `3`
  * `49 / 10` results in `4`

This is why the average function from the previous lesson divided the sum of the two numbers by `2.0` instead of `2`. 

### Strings: Not just for cheese

We've been using pieces of text here and there so far. The word *Text* is a valid term, but the term **string** is used to refer specifically to the text type. The term originates from the idea that text is comprised of a "string of characters". 

I've also shown strings being combined with numbers by using the `+` operator. It's not just numbers, though. You can combine a string with any other type to generate a new string. This is useful when using the `print` statement. 

You can also use the `*` operator to multiply strings by integers. This will result in a new string that is the old string repeated that many times.

```csharp
function showATriangle() {
    for (width = 1; width < 10; width = width + 1) {
        print("@" * width);
    }
}
```

In this example, the for loop will run 10 times, where the variable `width` will go from 1 to 10. Each time, a string consisting of `width` `@` characters will be shown.

### Booleans

**Booleans** are another type that only have two possible values: `true` and `false`. You have been implicitly using booleans each time you use an `if` or `while` statement with something like `==` or `<`. These operators take two numbers and create a boolean from it. The `if` (or `while`) statement itself consumes a boolean in parenthesis. Therefore it is equally acceptable to do something like this:

```csharp
isSmall = x < 5;
if (isSmall) {
    print("x is small");
    print("x is " + x);
    print("isSmall is " + isSmall);
}
```

If you were to run this and `x` was `3`, then you'd see something like this:

```
x is small
x is 3
isSmall is true
```

You can literally assign a boolean value to a variable by using the keywords `true` and `false`.

```
x = true;
y = false;
```

### Lists

We've used lists once before since that's how the command line arguments are passed into the main function. You can create your own lists by using square bracket characters `[` and `]` and storing the result in a variable. You can then access the items in the list by using square brackets again at the end of the variable (we've done this before using `args[0]`) and putting the offset from the beginning of the list into the brackets as an integer. This is called **indexing** into a list. Just keep in mind that the index in a list counts from 0 because it's an offset, not the n<sup>th</sup> item in the list.

```csharp
someList = [1, 2, 3, 4, 5];
print("The 2nd item in the list is " + someList[1]);
```

For convenience, you can also pass in negative numbers as the index of the list. This will count from the end of the list where `-1` is the last item in the list.

```csharp
print("The 2nd to last item in the list is " + someList[-2]);
```

### Fields and dot notation

Certain types of values have something called **fields**. These are extra bits of information that can be accessed by using a dot `.` character followed by the name of the field. For strings and lists, there are several built-in fields. For example, you can get the length of a list by adding a `.length` to the end of any list value. This will result in the length of the list as an integer. 

```csharp
function printTheListLineByLine(someList) {
    for (i = 0; i < someList.length; i = i + 1) {
        print(someList[i]);
    }
}
```

Sometimes these fields can be built-in functions. These are called **methods**. For example, there is a method on each list called `.add` which will add an item to the end of the list.

```csharp
function buildAListOfSizeN(n) {
    output = []; // An empty list. 0 items.
    for (i = 1; i <= n; i = i + 1) {
        output.add(i);
    }
    return output;
}
```

There's another list method called `.shuffle` which will shuffle the items in a list in a random order.

```csharp
function rollADice() {
    outcomes = [1, 2, 3, 4, 5, 6];
    outcomes.shuffle();
    return outcomes[0];
}
```

Like a function, a method generally must be followed by parentheses to invoke it. However, fields that are not methods do not need this. For now, `.length` is the only field that isn't a method that you should know about.

### Operators

So far we've only used the four basic math operators: addition `+`, subtraction `-`, multiplication `*`, and division `/`. 

These operators work between two numbers. Additionally, there is also exponents `**` and modulo `%`. Usually exponents are notated in text with the `^` character, but this is already used for another purpose, and so Crayon uses double-asterisk for exponents.

2<sup>10</sup> is notated as:
```
x = 2 ** 10;
```

If you haven't heard of modulo before, it's basically a fancy name for remainder. While `/` will divide two numbers and return a result that is rounded down, `%` will divide two numbers and give you the remainder. For example, 10 divided by 7 is 1 remainder 3.

```
a = 10 / 7;
b = 10 % 7;
```

`a` will be 1 while `b` will be 3.

### Incremental operators

There are several situations where you would like to modify a variable's current value by adding a number to it. Generally it looks something like this...

```
x = x + 5;
```

Because this is so common, you can use shorthand for it:

```
x += 5;
```

This will get the value of x, add 5 to it, and store it back into the variable x. This is completely equivalent to `x = x + 5;` from before.

Furthermore, adding and subtracting 1 from a variable is so common, there's even a more compact way of notating this, using ++ and -- operators.

```
x = x + 1;
```

...is this same as...

```
x++;
```

Similarly you can use `--` to subtract 1 from a variable. The `++` and `--` operators can appear before or after the variable name. So `++x` will work as well. There's a subtle difference between "prefix" and "postfix" usages of `++` and `--` but it's okay to not worry about that for now.

### Operators for non number types

So far all these operators have been for numbers. There are also operators for other types as well, particularly booleans.

You can combine two booleans together using `&&` or `||`. These mean "and" and "or" respectively.

You most commonly see these used inside if statements which check for multiple conditions to see if all of them are true.

```
if (x > 5 && y > 5) {
    print("x and y are both greater than 5");
}
```

You could have used two if statements nested inside each other to achieve the same effect.

The `||` operator checks to see if either of the values are true. If both of them are true, then that still counts.

```
if (x > 5 || y > 5) {
    print("x or y are greater than 5, possibly both, but definitely at least one of them");
}
```

| Expression | Value of A | Value of B | Result  |
| ---------- | ---------- | ---------- | ------- |
| `A && B`   | `true`     | `true`     | `true`  |
| `A && B`   | `true`     | `false`    | `false` |
| `A && B`   | `false`    | `true`     | `false` |
| `A && B`   | `false`    | `false`    | `false` |
| `A || B`   | `true`     | `true`     | `true`  |
| `A || B`   | `true`     | `false`    | `true`  |
| `A || B`   | `false`    | `true`     | `true`  |
| `A || B`   | `false`    | `false`    | `false` |

You can also put a `!` in front of any boolean to flip its value.

```
theOppositeCondition = !someCondition;
```

So for example, if you have two booleans, `a` and `b` and wanted to have an if statement that would run if one of them was true but not both of them, you could do this:

```
if ((a || b) && !(a && b)) {
    print("Either a or b is true, but not both");
}
```

### More comparison operators
We've been using `==`, `<`, and `>` but there is actually a handful more.

You can check to see if a number is **greater than or equal** by using `>=` instead of just `>`. Likewise, you can use `<=` for **less than or equal**. 

In addition to these, there's also `!=` which is **not equal**. `a != b` is equivalent to `!(a == b)`.

## Lesson 7 - Imports and Libraries

A **library** is a packaged set of existing code either written by yourself or someone else. This package of code is intended to serve some sort of standalone or themed purpose. You can import a library into your code and use the functions defined in it using the `import` statement. An import statement goes at the top of the file where you want to call the library's code. One simple example of a library is the `Math` library which is built in to Crayon. 

```csharp
import Math;

function main(args) {
    value = Math.abs(-4);
    print("The absolute value of -4 is " + value);
}
```

To access functions inside a library, you can use dot notation. There are quite a few libraries that are built in to Crayon and the documentation for each can be found here. However, it is out of scope to go over each in this tutorial. In the next section, we'll start making something that looks like a game by using some of the graphics and game-related libraries. 

## Lesson 8 - A box on the screen

In this section and the ones that follow, we'll finally start working with 2D graphics and the disparate concepts I've been throwing at you thus far will start coalescing into something useful. This is also a pretty good review section since it uses almost everything introduced so far.

```csharp
import Game;
import Graphics2D;

function main() {
    // Open a window that has the title of "A Box". This
    // window shall be 600 pixels wide and 400 pixels tall.
    // The graphics pipeline should run at 30 frames per second.
    window = new Game.GameWindow("A Box", 30, 600, 400);

    gameRunning = true;
    while (gameRunning) {
        // Gather a list of events that happened since
        // the last time clockTick was called.
        eventList = window.pumpEvents();

        // Loop through the events and look for a quit
        // event. 
        for (i = 0; i < eventList.length; i++) {
            event = eventList[i];
            // A QUIT event is generated if the user
            // attempts to close the window.
            if (event.type == Game.EventType.QUIT) {
                // This will cause the while loop
                // to end, which will cause main()
                // to finish, thus ending the program.
                gameRunning = false;
            }
        }
        
        // Fill the screen with black
        Graphics2D.Draw.fill(0, 0, 0);

        // Draw a 100 x 100 red rectangle with 10 pixel gap
        // between the top and left sides of the window.
        Graphics2D.Draw.rectangle(10, 10, 100, 100, 255, 0, 0);

        // pause the game for a split second so that the 
        // framerate of 30 frames per second is maintained.
        window.clockTick();
    }
}
```

There's quite a bit going on here. First of all, this is the first time we've shown something to the user by using something other than `print`. 

The window itself is generated by invoking `new Game.GameWindow(...)` and saving the result in the variable `window`. This variable contains the game window and you can do various with it. You can think of the game window as another type, like a list or string, which has some methods built in to it. Don't worry too much about the `new` keyword that's used to create it. We'll go into more details about that in Lesson 14.

Next, this code introduces the notion of the **game loop**. A computer game is like a movie. It shows an image on the screen very briefly. Then it shows a different image. And then another. These create animations. The rate at which these animations are shown is known as the **frame rate**. The game loop in this code is literally just a `while` loop. You can think of the game loop as being divided into 3 sections. 

* The first section analyzes any input received by the user and updates the state of the game accordingly. This game doesn't really do anything aside from quit when you close the window, so this part is somewhat limited in this version of our "game". In a real game, this would, for example, take the state of the arrow keys, and update the coordinates of a character.
* The next section draws to the screen based on the current state of the game. Each image shown to the user must be generated from scratch at the beginning of each frame. In this simple game, we clear out the screen with a black background and then draw a red rectangle. 
* The last section is the invocation of `window.clockTick()`. This will pause the game for several milliseconds. The exact duration is determined in a way that will make your game run at exactly a rate of 30 frames per second. However, if your game code is too slow and it cannot run that fast, the game will slow down. You can choose what the frame rate will be when you create the window (it's the first number that's passed into the creation of GameWindow). 60 is a common frame rate for most action or aesthetically intensive games. However 30 frames per second is also common for more casual games and is gentler on your user's batteries if using a laptop or mobile device. 

### A closer look at specifics

Here's a breakdown of the new things that appear in this snippet...

* The **window** variable contains a reference to the actual window and has two methods that are shown in the example. 
* **window.pumpEvents()** - This will generate a list of events that have occurred since the last time you called this function. The actual items in this list are also custom types called event objects, which also have more fields and methods on them. Various events will come from this function including mouse, keyboard, and gamepad input, and also any attempt to close the window will also appear as an event (which is the only kind of event that is checked for in this example).
* **window.clockTick()** - as explained above, this will pause the game for a few milliseconds to maintain the frame rate. Additionally it will update the screen with the graphical operations you performed during the frame. Most importantly it will also query the underlying framework or operating system to figure out which events have occurred and will hand them off to the event queue which will appear as events in pumpEvents. If you do not call window.clockTick(), these events will accumulate and it is possible to cause the window to freeze since it will seem like an unresponsive window to the operating system.
* **event.type == Game.EventType.QUIT** - the variable event contains an event object. This object has a field called type which indicates which type of event this object is. If you were to print this value, unfortunately you'd see an arbitrary integer. However, there is another value defined in the Game library called EventType.QUIT which matches that value. You can use == to check to see if the types match. 
* **Graphics2D.Draw.fill(red, green, blue)** - This will fill the entire window with one color. In this case, we use black. The numbers that you pass in are integers that range from 0 to 255 that describe the intensity of that color component. 0 for all three values is black whereas 255 for all three will be white. If you haven't worked with red/green/blue color component values before, here's a quick tutorial. 
* **Graphics2D.Draw.rectangle(left, top, width, height, red, green, blue)** - This draws a rectangle to the screen at the given location with the given color. The first number is the distance the left side of the rectangle is from the left side of the window. The second number is the distance the top is from the top of the window. The next two are width and height and the final 3 numbers are red/green/blue color components that work the same way as Draw.fill(r, g, b).

![red square](./images/square.png)



## Lesson 9 - Interactivity and state
In this lesson I'll use the previous code as a foundation to create things that are a little more interesting.

* A circle that chases the mouse
* A circle that shoots out small squares in random directions when you press the spacebar

Obviously this will reveal how to use the mouse and keyboard, but more importantly, I'd like to introduce the concept of persistent state. State is any information that is saved (such as in a variable) and used across multiple frames.

### Example 1 - Circle chasing the mouse.

```csharp
import Game;
import Graphics2D;

function main() {
    window = new Game.GameWindow("A circle that wants a mouse", 30, 600, 400);

    // These are the coordinates of the center of the circle.
    circleX = 300;
    circleY = 200;

    // This is the last known position of the mouse that the circle will
    // move towards. Since we don't know what it is at first, just start
    // it with the same coordinates as the circle.
    mouseX = circleX;
    mouseY = circleY;

    // These are the red-green-blue color definitions for green and blue.
    // These will be used for the color of the circle.
    green = [0, 255, 0];
    blue = [0, 0, 255];

    gameRunning = true;
    while (gameRunning) {
        eventList = window.pumpEvents();

        for (i = 0; i < eventList.length; i++) {
            event = eventList[i];
            if (event.type == Game.EventType.QUIT) {
                gameRunning = false;
            } else if (event.type == Game.EventType.MOUSE_MOVE) {
                // The mouse coordinates are in fields called .x and .y
                // Put these numbers into the mouseX and mouseY variables
                // so we can track it.
                mouseX = event.x;
                mouseY = event.y;
            }
        }
        
        // Remember the old coordinates before udpating them.
        oldX = circleX;
        oldY = circleY;
        
        // Move the circle towards the last known mouse coordinates.
        // We do this by taking the weighted average of the current
        // circle location and the mouse location. Because this will
        // happen 30 times per second, it will move constantly.
        // Eventually the difference will be small enough that the
        // circle will no longer move.
        circleX = (circleX * 14 + mouseX) / 15;
        circleY = (circleY * 14 + mouseY) / 15;
        
        // If the circle moved, color it with green.
        // If it was stationary during this frame, use blue.
        if (circleX != oldX || circleY != oldY) {
            color = green;
        } else {
            color = blue;
        }
        
        Graphics2D.Draw.fill(0, 0, 0);
        
        radius = 30; // The radius is 30 pixels.
        diameter = radius * 2;
        left = circleX - radius; // circleX is the center, so the left side is circleX - radius.
        top = circleY - radius; // circleY is the center, so the top side is circleY - radius.
        Graphics2D.Draw.ellipse(left, top, diameter, diameter, color[0], color[1], color[2]);

        window.clockTick();
    }
}
```

Blue stationary circle:

![blue circle](./images/circle1.png)

Green moving circle (it's moving, trust me):

![green circle](./images/circle2.png)

This introduces the concept of maintaining **state** across multiple frames.

You can think of state as basically any information that survives beyond the time/place it is generated and is used across several frames.

There are two pieces of state here:

* The circle's location
* The mouse's most recent location.

The variables `circleX`, `circleY`, `mouseX`, and `mouseY` are declared outside of the game loop with some initial values and are updated slightly during each frame. The circle coordinates are adjusted to move close to the mouse coordinates in each frame. But the mouse coordinates are updated every time the mouse moves. 

Why don't I consider `green` or `blue` a form of persistent state? Because they are values that do not get updated. While it's true that they're variables declared outside of the loop and are used inside the loop, they are declared for convenience and readability, but they are not updated. However, suppose I hypothetically made it so that the circle turned red when it moved, and then slowly faded to black over time when it was stationary. Then the color would be considered state because it is being updated based on factors over time.

### Example 2 - Circle shooting out tiny squares.

This next example is a little more complicated, it introduces the Random library, using the keyboard, but more importantly, it introduces how to track state across multiple objects.

```csharp
import Game;
import Graphics2D;
import Math;
import Random;

function main() {
    window = new Game.GameWindow("A circle with an attitude", 30, 600, 400);

    bullets = [];
    
    circleX = 300;
    circleY = 200;
    
    purple = [128, 0, 128];
    white = [255, 255, 255];

    gameRunning = true;
    while (gameRunning) {
        eventList = window.pumpEvents();

        shoot = false;
        for (i = 0; i < eventList.length; i++) {
            event = eventList[i];
            if (event.type == Game.EventType.QUIT) {
                gameRunning = false;
            } else if (event.type == Game.EventType.KEY_DOWN && event.key == Game.KeyboardKey.SPACE) {
                shoot = true;
            }
        }
        
        if (shoot) {
            // choose a random angle. randomFloat() generates a random float between 0 and 1.
            // Multiplying this value by 2 * pi will generate a random angle in any direction.
            angle = Random.randomFloat() * 2 * Math.PI;
            
            // Create a list with 3 numbers in it. This list will represent a single bullet.
            // Note that adding a list to a list will literally add that list as an item,
            // rather than add those 3 items to the end. This is list-of-lists where each sub-list
            // always has 3 items in it and represents a bullet.
            bullets.add([circleX, circleY, angle]);
        }
        
        // The velocity of the bullet. This is how many pixels it will travel each frame.
        velocity = 7;
        
        // Loop through the list of bullets and update each one.
        for (i = 0; i < bullets.length; i++) {
        
            // Grab the i-th bullet
            bullet = bullets[i];
            
            // extract the 3 numbers from the bullet descriptor.
            x = bullet[0];
            y = bullet[1];
            angle = bullet[2];
            
            // convert the velocity and the angle into a change in x and y.
            dx = Math.cos(angle) * velocity;
            dy = Math.sin(angle) * velocity;
            
            // Add the new offsets to the old coordinates.
            x += dx;
            y += dy;

            // Save the new coordinates back into the bullet.
            bullet[0] = x;
            bullet[1] = y;
            
            // If the bullet goes off the edge of the screen, remove it from the list.
            if (x < 0 || y < 0 || x > 600 || y > 400) {
                bullets.remove(i);
                
                // Because we're removing this bullet from the list, the
                // next bullet shifts ahead in the list. Since we don't
                // want to skip it, subtract 1 from i.
                i--;
            }
        }
        
        Graphics2D.Draw.fill(0, 0, 0);
        
        radius = 30;
        Graphics2D.Draw.ellipse(
            circleX - radius, circleY - radius, radius * 2, radius * 2,
            purple[0], purple[1], purple[2]);
        
        bulletSize = 6;
        for (i = 0; i < bullets.length; i++) {
            bullet = bullets[i];
            x = bullet[0];
            y = bullet[1];
            Graphics2D.Draw.rectangle(
                x - bulletSize / 2, y - bulletSize / 2, bulletSize, bulletSize,
                white[0], white[1], white[2]);
        }
        
        window.clockTick();
    }
}
```

![circle with an attitude](./images/circle-attitude.png)

## Lesson 10 - Objects

The previous example with the purple circle shooting white bullets was done only using programming concepts you already know. However, the way this is implemented is not ideal and kind of hard to read. In this example, I'll be re-implementing the same program but this time I'll be using something called Object oriented programming to make it easier to read and maintain.

Object-oriented programming is a vast and deep subject that encompasses lots of theory, best-practices, and conventions. However, this section will only cover some super-high level concepts and how to use them in Crayon. 

You've been working with objects a little bit so far. The GameWindow and the events that you loop through are both objects. An object is basically just a custom type that has its own fields and methods on it. The event object had a `.type` field. It also had `.x` and `.y` fields for the mouse location. The GameWindow object has `.clockTick()` and `.pumpEvents()` methods. You too, can define your own object type and use it to make your code more readable.

You should never use a list to represent structured data. For example, the bullets in the previous example were lists of 3 items, where the first two items were the x and y coordinates, and the last item was the angle that the bullet was travelling at. The technical term for this is a travesty of readability.

Instead, we can define a `Bullet` object which has fields called `.x`, `.y`, and `.angle`. This will make things much easier to read and also less error-prone. We do this using the `class` keyword. A **class** is a definition of an object type. 

```csharp
class Bullet {
    field x;
    field y;
    field angle;
    
    constructor(x, y, angle) {
        this.x = x;
        this.y = y;
        this.angle = angle;
    }
    
    function update() {
        velocity = 7;
        this.x = this.x + Math.cos(this.angle) * velocity;
        this.y = this.y + Math.sin(this.angle) * velocity;
    }
    
    function isOffScreen(width, height) {
        return this.x < 0 || this.y < 0 || this.x > width || this.y > height;
    }
    
    function draw() {
        size = 6;
        Graphics2D.Draw.rectangle(
            this.x - size / 2, this.y - size / 2, size, size,
            255, 255, 255); // white
    }
}
```

Here you can see a definition of a Bullet type. This type will have 3 fields, x, y, and angle. When we create a bullet object (or more commonly referred to as a Bullet **instance**) these fields will be referenced with dot notation. Furthermore, I've defined two functions *inside* the class. These will be methods that you can access using `.update()`, `.isOnScreen(600, 400)`, and `.draw()`. 

By moving the complicated parts of our code into the Bullet class as methods, the game code will be a lot easier to read now. The concept of hiding away complexity into object definitions is called **Encapsulation**. 

There's a few new syntax things you'll notice in the above class definition. 

### Constructor
You'll notice that I have something that looks like a function definition, but instead of the keyword `function` followed by the name of the function, it simply says `constructor`. The constructor of a class is a nameless function that automatically gets run when you create an instance of an object. Remember when you create a new GameWindow object, you used the keyword `new`?

```csharp
window = new Game.GameWindow("A Box", 30, 600, 400);
```

The `new` keyword will create a new instance of the object and run the constructor like a function. The output of the constructor function is always the instance of the function, therefore a return statement in the constructor is never necessary. 

### this
Another thing you may have noticed is the keyword `this`. `this` is basically an implicitly declared variable where the value of `this` is the current object. This is how you refer to the fields on the current object. For example in update, `this.x` is used, which will read from or write to the field x of the current object that this method was called on.

You may be tempted to create objects for just concrete concepts that you can see on the screen. But you can also create objects for more abstract concepts that may make your code easier to read. For example, there seems to be a lot of logic related to creating and managing the bullets as a collection. So let's create an object called BulletCollection.

```csharp
class BulletCollection {

    // You can initialize fields with a default starting value.
    field bullets = [];
    
    // Because the field is already initialized, the constructor can be empty.
    constructor() { }
    
    function addNewBullet(x, y) {
        angle = Random.randomFloat() * 2 * Math.PI;
        
        // Here we use the 'new' keyword to create a new Bullet.
        this.bullets.add(new Bullet(x, y, angle));
    }
    
    function update(screenWidth, screenHeight) {
        for (i = 0; i < this.bullets.length; i++) {
            bullet = this.bullets[i];
            bullet.update();
            if (bullet.isOffScreen(screenWidth, screenHeight)) {
                this.bullets.remove(i);
                i--;
            }
        }
    }
    
    function draw() {
        for (i = 0; i < this.bullets.length; i++) {
            bullets[i].draw();
        }
    }
}
```

If we include the above class definitions at the end of our code, we can trim our code down to something much simpler and more readable:

```csharp
import Game;
import Graphics2D;
import Math;
import Random;

function main() {
    window = new Game.GameWindow("A circle with an attitude", 30, 600, 400);

    bullets = new BulletCollection();
    
    circleX = 300;
    circleY = 200;
    
    purple = [128, 0, 128];

    gameRunning = true;
    while (gameRunning) {
        eventList = window.pumpEvents();

        for (i = 0; i < eventList.length; i++) {
            event = eventList[i];
            if (event.type == Game.EventType.QUIT) {
                gameRunning = false;
            } else if (event.type == Game.EventType.KEY_DOWN && event.key == Game.KeyboardKey.SPACE) {
                bullets.addNewBullet(circleX, circleY);
            }
        }
        
        bullets.update(600, 400);
        
        Graphics2D.Draw.fill(0, 0, 0);
        
        radius = 30;
        Graphics2D.Draw.ellipse(
            circleX - radius, circleY - radius, radius * 2, radius * 2,
            purple[0], purple[1], purple[2]);
        
        bullets.draw();
        
        window.clockTick();
    }
}
```

I would include a screenshot but it looks exactly the same as before.

## Lesson 11 - Images

## Lesson 12 - References vs Values

## Lesson 13 - Dictionaries

## Lesson 14 - Exceptions

## Lesson 15 - Recursion and traversal
