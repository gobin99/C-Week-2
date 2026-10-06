# Week 2 — Variables and Datatypes

**Module:** CS6004NP Application Development
**Week 2 of:** C# 14 on .NET 10

> **Toolchain:** same as Week 1 — the .NET 10 SDK with VS Code. See [CSharp-DotNet-Setup.md](../Week%201/CSharp-DotNet-Setup.md) if your machine is not set up yet. For a Java-to-C# translation table, see [CSharp-Java-Syntax-Cheatsheet.md](../Week%201/CSharp-Java-Syntax-Cheatsheet.md).

---

## Previously

In Week 1 we covered the platform and the toolchain:

- Introduction to .NET and C#
- .NET overview and ecosystem
- Key features of C# and .NET
- Required software (SDK, IDE, extensions)
- Working with VS Code and the .NET CLI — this is the only IDE used in the module

Full details are in [Week 1 Lecture Notes](../Week%201/Week%201%20Lecture%20Notes.md).

**The one thing to carry forward:** in C#, every piece of data lives in a **variable**, and every variable has a **type** that decides its size, its range, and where it is stored in memory. Week 2 is entirely about those two ideas.

---

## Overview of this week

- **C# Syntax Essentials** — comments, indentation, statements, blocks, expressions, top-level statements, identifiers
- **Variables & Memory** — declaring, initializing, value types vs reference types, nullable types, `const` vs `readonly`, `Guid`, `DateTime`, `TimeSpan`
- **Strings** — literals, verbatim strings, interpolated strings
- **Arrays** — single-dimensional arrays and the `Array` methods
- **Generic Collections** — `List<T>` and `Dictionary<TKey, TValue>`

---

## 1. C# Syntax Essentials

> **Analogy:** C# syntax is punctuation for your code. Comments are sticky notes you leave on the page, indentation is the shape of your handwriting, statements are single instructions, blocks are grouped steps, and expressions are the little calculations you do in the margin. The compiler ignores the notes and the handwriting; it only obeys the instructions.

### 1.1 Comments

Comments explain code, make it readable, or temporarily disable code while debugging. **The compiler ignores them completely** — they cost you nothing at run time.

| Kind | Syntax | Use it for |
| --- | --- | --- |
| Single-line | `// Comment text` | One line of explanation, or commenting out one line of code |
| Multi-line | `/* Comment text */` | Grouping related explanations, or disabling a block of code |
| Document | `/// <summary>Text</summary>` | Generating XML documentation for a class, method, or property |

```csharp
// This whole line is a comment: int x = 5;

/*
   This spans several lines.
   Use it to explain a block,
   or to switch code off temporarily.
*/

/// <summary>
/// Calculates the area of a circle.
/// </summary>
double Area(double radius) => Math.PI * radius * radius;
```

**Document comments** must sit immediately **before** the member they document, and use three slashes. They are what IntelliSense pops up when you hover over a method somewhere else in the project.

| Comment | Ignored by the compiler? | Visible to IntelliSense? |
| --- | --- | --- |
| `//` | Yes | No |
| `/* */` | Yes | No |
| `///` | Yes | Yes — becomes the tooltip text |

### 1.2 Indentation

Indentation means adding spaces or tabs at the beginning of lines to visually structure the program.

- **Why it matters:** readability. C# does **not** enforce indentation, so bad indentation still compiles — it just becomes unreadable for the next person.
- **Best practice:** 4 spaces (or 1 tab) per nesting level.

```csharp
if (score >= 60)
{
    Console.WriteLine("Pass");   // 4 spaces in from the brace
}
```

### 1.3 Statements and blocks

| Term | Meaning | Example |
| --- | --- | --- |
| **Statement** | An action that executes code. Always ends with `;` | `int x = 10;` |
| **Simple statement** | One action on its own | `Console.WriteLine("Hi");` |
| **Compound statement** | A group of statements inside `{ }` | A loop or an `if` body |
| **Block** | Groups multiple statements, e.g. loops and conditionals | `{ int a = 1; int b = 2; }` |

**Why it matters:** the semicolon is what tells C# "this instruction ends here". Miss one and you get `CS1002: ; expected`.

### 1.4 Expressions

An **expression** is a piece of code built from **operands** joined by **operators**. The operands are the *data*, the operators are the *actions*, and the whole thing produces **one value**.

**The three words**

| Word | What it is | In `5 + 3` |
| --- | --- | --- |
| **Operand** | The data you operate on — a literal, a variable, or the result of another expression | `5` and `3` |
| **Operator** | The symbol that combines operands | `+` |
| **Result** | The single value the expression produces, and its type | `8` (an `int`) |

> **The one rule:** every expression produces exactly **one** value, and that value has a **type**. If you can point at a piece of code and say "this gives me an `int`", it is an expression.

> **Analogy:** an expression is a **recipe**. The **operands are the ingredients** on the counter, the **operators are the actions** you perform on them — chop, mix, boil — and the **result is the finished dish** you take to the table. You can never have a recipe that produces nothing; if there is no dish at the end, it was not a recipe, it was just an instruction ("wash the rice").

### Worked example 1 — arithmetic

```csharp
int num = 5 + 3;
```

Read the line in two halves. Everything on the **left** of the `=` is where the answer goes. Everything on the **right** is the expression that produces the answer.

- The **target** is `num` — the container the result is stored into.
- The **operands** are `5` and `3` — the two pieces of data being combined.
- The **operator** is `+` — the action joining them.
- The **result** is `8`, so `num` now holds `8`.

| Part | Role | What it is |
| --- | --- | --- |
| `num` | operand | The target on the left of `=` |
| `5` | operand | A literal |
| `+` | operator | Addition |
| `3` | operand | A literal |
| `5 + 3` | **expression** | Evaluates to the `int` value `8` |

### Worked example 2 — comparison, used as an argument

```csharp
string name = "John";
Console.WriteLine(name == "John");
```

Here the expression has **no** `=` to sit on the right of. It sits inside the round brackets instead, which makes it an **argument** to `WriteLine`.

- The **operands** are `name` (a variable) and `"John"` (a string literal).
- The **operator** is `==`, which asks "are these two the same?".
- The **result** is a single `bool`: `True`.

| Part | Role | What it is |
| --- | --- | --- |
| `name` | operand | The variable, holding `"John"` |
| `==` | operator | Equality comparison |
| `"John"` | operand | A string literal |
| `name == "John"` | **expression** | Evaluates to `True` (`bool`) |

Two things to notice:

1. `WriteLine` never sees the text `name == "John"`. It sees only the `bool` value that the expression already produced.
2. The output is `True`, capitalised — that is how C# spells a boolean.

### Worked example 3 — object creation

```csharp
List<int> myList = new List<int>();
```

This looks like one long name, but it is two separate parts joined by the `new` keyword.

- The **operator** is the keyword `new` — it means "construct an object".
- The **operand** is `List<int>()`, which is the type `List<int>` together with its empty brackets.
- The **result** is one new, empty `List<int>` object sitting in heap memory.

| Part | Role | What it is |
| --- | --- | --- |
| `myList` | operand | The target on the left of `=` |
| `new` | operator | Object creation |
| `List<int>()` | operand | The type plus its (empty) arguments |
| `new List<int>()` | **expression** | Evaluates to a new empty `List<int>` |

### Worked example 4 — two operators, and precedence

```csharp
double price = 250.0;
double quantity = 3;
double shipping = 40.0;

double total = price * quantity + shipping;
```

This line has **three operands** — `price`, `quantity`, `shipping` — and **two operators** — `*` and `+`. Because there are two operators, C# does the work in two steps:

| Step | Expression | Operator used | Result |
| --- | --- | --- | --- |
| 1 | `price * quantity` | `*` multiplication | `750.0` |
| 2 | `750.0 + shipping` | `+` addition | `790.0` |

So `total` is `790.0`.

**Precedence matters.** Multiplication is performed before addition, exactly as in ordinary arithmetic. Parentheses override it:

| Expression | Read as | Result |
| --- | --- | --- |
| `2 + 3 * 4` | `2 + (3 * 4)` | `14`, not 20 |
| `(2 + 3) * 4` | force the grouping | `20` |

### Operator reference

| Operator | Name | Kind | Example | Result |
| --- | --- | --- | --- | --- |
| `+ - * /` | arithmetic | numeric | `10 / 3` | `3` (`int` division) |
| `+` | concatenation | string | `"Age: " + 22` | `"Age: 22"` (`string`) |
| `%` | remainder | numeric | `10 % 3` | `1` |
| `==` `!=` | equality | comparison | `score == 90` | `bool` |
| `<` `>` `<=` `>=` | relational | comparison | `score >= 60` | `bool` |
| `&&` `\|\|` | logical | logical | `age >= 18 && hasId` | `bool` |
| `!` | logical NOT | logical | `!isActive` | `bool` |
| `? :` | ternary conditional | conditional | `score >= 60 ? "P" : "F"` | `string` |
| `??` | null-coalescing | null handling | `name ?? "Guest"` | `string` |
| `new` | object creation | object creation | `new List<int>()` | `List<int>` |
| `=>` | lambda | function | `n => n * 2` | a function |

### Two traps worth knowing now

| Trap | What happens | Fix |
| --- | --- | --- |
| `=` vs `==` | `score = 90;` **assigns** 90 and evaluates to `90`. `score == 90;` **compares** | Use `==` to compare, `=` only to assign |
| `"5" + 3` | Produces the **string** `"53"`, not the number 8 — `+` concatenates when either side is a string | Convert first: `int.Parse("5") + 3` or `$"{5}"` only for display |

> **How to tell an operand from an operator at a glance:** operands are things that can hold a value (names, literals, `new` expressions), and operators are symbols or keywords that sit *between* them. If it can be replaced by a number on its own, it is an operand.

**Read from the outside in:** the `if` statement contains a block; the block contains statements; each statement contains an expression; and each expression is made of operands joined by operators.

### 1.5 Combined example

Comments, statements, blocks, and expressions all appear together in almost every real method:

```csharp
// Single-line comment
int score = 90;

/*
   Multi-line comment:
   Check if the score is passing
*/

if (score >= 60)
{
    string grade = score >= 96 ? "A" : score >= 80 ? "B" : "C";

    Console.WriteLine($"Grade: {grade}");
}
// Output: Grade: B  — score is 90, which is above 80 but below 96
```

Going through it piece by piece:

| Piece | What it is |
| --- | --- |
| `// Single-line comment` | A single-line comment — ignored by the compiler |
| `int score = 90;` | A statement. `90` is an expression (a literal), and `score = 90` is an **assignment expression** whose operator is `=`. The result is the value `90` |
| `/* ... */` | A multi-line comment |
| `if (score >= 60)` | A statement. Its condition `score >= 60` is an expression: two operands joined by the `>=` operator, giving a `bool` |
| `{ ... }` | The block belonging to that `if` |
| `score >= 96 ? "A" : ...` | One expression containing three smaller expressions: the two `>=` comparisons, then the `?:` operator using their results to pick a string |
| `$"Grade: {grade}"` | One expression — the whole interpolated string |

**Read it from the outside in:** the `if` statement contains a block, the block contains statements, each statement contains an expression, and each expression is operands joined by operators. The expression is always the innermost part that produces a value.

### 1.6 Top-level statements

**Top-level statements** are code written directly in a `.cs` file without being nested inside a class or method.

```csharp
// Top-level statements in a math utility file
int Add(int a, int b) => a + b;

double Average(params int[] numbers) => numbers.Average();

Console.WriteLine(Add(2, 3));   // Output: 5
```

- **Introduced in C# 9.0 (.NET 5+)** — it simplifies entry points and utility files.

**When to use them**

- Simple console apps
- Utility scripts, e.g. data processing
- Reducing boilerplate code

**Restrictions**

- Access modifiers like `public` and `private` cannot be used — there is no class to apply them to.
- You cannot spread top-level statements across multiple `.cs` files in the same project. Only one file may hold them.

> **Analogy:** a top-level program is a street-food cart. No signboard, no manager, no kitchen hierarchy — just the cooking. It is perfect for one-file scripts, but the moment you need staff (classes) or more than one stall (multiple files), you need a restaurant.

### 1.7 Identifiers and naming conventions

An **identifier** is the name used for a variable, method, class, namespace, interface, or any other program element.

**Rules for identifiers**

- Must start with a letter or an underscore. Cannot start with a digit. Valid: `_name`, `location`
- Can then include letters, digits, or underscores. Valid: `first_name1`
- Must not be a reserved keyword, e.g. `int`, `for`, `class`
- Are **case-sensitive**: `public` and `Public` are two different words

| Style | Example | Use for |
| --- | --- | --- |
| PascalCase | `CalculateTotal`, `MaxUsers` | Methods, classes, properties, constants |
| camelCase | `userName`, `totalMarks` | Variables, parameters |
| `_camelCase` | `_quote`, `_totalMarks` | Private fields |
| `UPPER_SNAKE` | `MAX_USERS` | Avoid — use PascalCase for constants in C# |

**Why it matters:** readability, maintainability, and less confusion. `UserName` and `username` in the same project is a bug waiting to happen.

**Quiz:** which is the correct naming convention for a **constant**?

| Option | Verdict |
| --- | --- |
| `maxUsers` | ✗ looks like a variable |
| `MAX_USERS` | ✗ that is Java/Python style |
| `MaxUsers` | ✓ **correct** — C# constants use PascalCase |
| `maximumUsers` | ✗ a perfectly good name, but not the convention |

> **Analogy:** think of naming like labelling drawers in a kitchen. `SugarJar` and `FlourJar` are obvious at a glance. `sugar`, `SUGAR`, and `sugar2` leave you guessing in the dark.

---

## 2. Variables & Memory

> **The whole section in one line:** a **variable** is a labelled box that holds a value, and its **type** decides what can go inside it.

### 2.1 What is a variable?

A variable is a **box with a name on it**. The name says what is inside.

```csharp
string name = "Sita Sharma";   // the box called "name" holds the text "Sita Sharma"
int age = 22;                  // the box called "age" holds the number 22
```

**Real example — a Facebook profile.** When you make an account, Facebook needs somewhere to keep your details. So it makes variables:

| Variable | Holds |
| --- | --- |
| `Name` | `"Sita Sharma"` |
| `Age` | `22` |
| `Email` | `"sita@example.com"` |

When you open your profile, Facebook reads those variables and shows them to you. Every app does this. The only difference between apps is the names they choose.

> **Analogy:** a variable is a **drawer in a kitchen**. The label on the front tells you what is inside — `Sugar`, `Flour`, `Spices`. You can open the drawer, use what is inside, and put something else in later.

### 2.2 How do you make one?

Three ways. All three end with a semicolon `;`.

```csharp
int age;              // 1. make an empty box
age = 16;             // 2. put a value in it later
int marks = 95;       // 3. make the box and fill it in one line
```

The rule is always the same: **type first, then name**.

| What you write | What it means |
| --- | --- |
| `int` | the type — what kind of value fits |
| `age` | the name — your label on the box |
| `= 16` | the value — what goes in the box |

If you forget the `;`, C# says `CS1002: ; expected`.

### 2.3 Where does the variable live?

So far every variable we made was **local** — it lived inside a method and disappeared when the method finished. A variable can live in other places too.

```csharp
class Student
{
    private string _name;              // kind: field          type: reference
    private int _rollNumber;           // kind: field          type: value

    private static int _count;         // kind: static field   type: value

    public Student(string name, int rollNumber)
    {
        _name = name;                  // the constructor fills the fields in
        _rollNumber = rollNumber;
        _count++;
    }

    public void Show()
    {
        int age = 22;                  // kind: local variable — lives in this method only
        Console.WriteLine($"{_name} {_rollNumber} {age} (student #{_count})");
    }
}
```

Running it:

```text
Sita 101 22 (student #1)
Ram  102 22 (student #2)
```

Each student printed their **own** `_name` and `_rollNumber`, but the number went `1` then `2` from the **same** `_count` — because there is only one `_count` in the whole program.

| Kind | You write it | How many exist | Dies when |
| --- | --- | --- | --- |
| **Local variable** | inside a method | one per call | the method finishes |
| **Parameter** | in the method's brackets | one per call | the method finishes |
| **Field** | in a class, no keyword | one per **object** | that object is gone |
| **Static field** | in a class, with `static` | **one for the whole class** | the program stops |
| **`const`** | in a class, with `const` | one for the whole class | the program stops |

Two things to notice in the code above:

- Every `Student` gets **its own** `_name` and `_rollNumber`. Those are fields.
- There is only **ever one** `_count`, no matter how many students you make. That is what `static` means — shared by everybody.

> **Analogy:** a **field** is the soap dispenser inside a washroom — one per room. A **static field** is the fire extinguisher on the corridor wall — one for the whole building, and everybody shares it.

**You have met both already.** In Week 1 you wrote `private readonly string _quote;` inside `MotivationalQuote` — that is a field. And the slides' `Array.Sort(numbers)` is a **static method**: it belongs to the `Array` class, not to your array.

**Every kind above can be a value type or a reference type.** `int age = 22;` and `private int _rollNumber;` are both value types. `string name = "Sita";` and `private string _name;` are both reference types. The next section explains the difference.

### 2.4 Value types and reference types

Every type in C# is one of two things. This is the **one** thing in this section you must not skip.

- A **value type** box holds the real thing.
- A **reference type** box holds an **address**. The real thing is somewhere else.

|  | Value type | Reference type |
| --- | --- | --- |
| The box holds | the value itself | an address pointing at the value |
| Where the value sits | stack memory | heap memory |
| When you copy it | each box gets its **own copy** | both boxes point at the **same** thing |
| If you change one | the other stays as it was | the other changes too |

**Which is which:**

| Value types | Reference types |
| --- | --- |
| `int`, `long`, `short`, `byte` | `string` |
| `float`, `double`, `decimal` | `object` |
| `bool`, `char`, `enum` | any `class` you write |
| `struct` | arrays, `List<T>`, `Dictionary<K,V>` |

**Here is the difference, in code:**

```csharp
int first = 10;
int second = first;      // second gets its OWN copy of 10
second = 20;
Console.WriteLine(first);   // Output: 10   — first did not change

User a = new User { Name = "Sita" };
User b = a;                 // b points at the SAME User object
b.Name = "Rina";
Console.WriteLine(a.Name);  // Output: Rina — a changed too, same object
```

> **Analogy:** a value type is a **sticky note with the number written on it**. You hand the note to someone and you no longer have it. A reference type is a **business card with an address on it**. Copy the card as many times as you like — everyone is still looking at the same room.

### 2.5 The basic data types

All of these are **value types** (from 2.4). Pick the smallest one that still fits your number.

**Whole numbers**

| Type | Size | Example |
| --- | --- | --- |
| `sbyte` | 8-bit | `sbyte temp = -15;` |
| `byte` | 8-bit | `byte alpha = 255;` |
| `short` | 16-bit | `short sensor = 30_000;` |
| `ushort` | 16-bit | `ushort port = 8_080;` |
| `int` | 32-bit | `int users = 1_000_000;` |
| `uint` | 32-bit | `uint id = 4_294_967_295;` |
| `long` | 64-bit | `long stars = 100_000_000_000;` |
| `ulong` | 64-bit | `ulong universe = 18_400_000_000_000_000_000;` |

Use them for counting, IDs, and loop counters. Use `byte` for a small value like an age, `int` for a user count, `long` for huge numbers.

**Numbers with decimals**

| Type | Size | Example |
| --- | --- | --- |
| `float` | 32-bit | `float val = 3.14f;` |
| `double` | 64-bit | `double val = 3.1415926535;` |
| `decimal` | 128-bit | `decimal val = 3.141592653589793238m;` |

**The ending letter is not decoration — it tells C# which type you meant:**

| You write | C# reads it as |
| --- | --- |
| `3.14f` | a `float` |
| `3.14` | a `double` |
| `3.14m` | a `decimal` |

Forget the `f` and C# reads `3.14` as a `double`, which will not fit into a `float`:

```csharp
float a = 3.14;    // error CS0266
float b = 3.14f;   // correct
```

**True/false, letters, and named sets**

| Type | Size | Example |
| --- | --- | --- |
| `bool` | 1-bit | `bool isActive = true;` |
| `char` | 16-bit | `char grade = 'A';` |
| `enum` | 32-bit (typically) | `enum Days { Sun, Mon, Tue }` |

Two traps:

- `char` uses **single** quotes, `'A'`. A `string` uses **double** quotes, `"A"`.
- `"5" + 3` gives you the **text** `"53"`, not the number 8. Convert first with `int.Parse("5") + 3`.

**Quiz:** why does C# have `byte`, `short`, `int` and `long` instead of just one number type?

> **Answer: B** — to let you choose a type based on the memory you need and the range of values. Using a `long` for an age wastes memory.

### 2.6 What if there is no value? (nullable types)

Normally an `int` cannot be empty — it must hold a number. But sometimes "no answer yet" is a real answer.

```csharp
int? age = null;          // a number that might be missing
bool? isActive = null;    // true/false that might be missing
age = 22;                 // now it has a value
```

This also applies to reference types:

```csharp
string name = null;     // warning CS8600 — this is allowed but risky
string? name = null;    // correct — says "null is expected here"
string title = "Hello"; // non-nullable — the compiler trusts you
```

|  | `int?` | `string?` |
| --- | --- | --- |
| Applies to | value types (`int`, `bool`) | reference types (`string`, classes) |
| Added in | C# 2.0 | C# 8.0 |
| Turned on by | writing the `?` | project setting, or `#nullable enable` |

**Why bother?** Because `NullReferenceException` normally crashes your program at run time. The `?` moves that mistake to **compile time**, where you see it immediately.

### 2.7 Values that never change: `const` and `readonly`

Both stop a value from being changed. They differ in **when** the value is fixed.

|  | `const` | `readonly` |
| --- | --- | --- |
| Fixed at | **compile time** (while building) | **run time** (e.g. in a constructor) |
| Changeable? | No, ever | Not after the constructor finishes |
| Use for | fixed values like π | values per object that you only learn later |

```csharp
class Circle
{
    public const double Pi = 3.14159;    // fixed while building
    public readonly int Diameter;        // fixed when the object is made

    public Circle(int diameter)
    {
        Diameter = diameter;
    }
}

Circle c = new Circle(10);
Console.WriteLine(c.Diameter);   // Output: 10
// Circle.Pi = 3.15;             // error CS0133: cannot assign to const
```

One limit on `const`: it can only hold a **primitive type, a `string`, an enum, or `null`**. That is why `const double` and `const string` are fine, but `const List<string>` is not — a list is only created at run time.

> **Analogy:** `const` is a number **carved into a stone monument**. It cannot be rubbed out. `readonly` is a **name badge printed at check-in** — printed once, then never changed for that person.

### 2.8 Three built-in types you will use a lot

| Type | What it holds | Example |
| --- | --- | --- |
| `Guid` | a unique 128-bit ID | `Guid id = Guid.NewGuid();` |
| `DateTime` | one exact moment in time | `DateTime now = DateTime.Now;` |
| `TimeSpan` | a length of time | `TimeSpan gap = DateTime.Now - start;` |

```csharp
Guid id = Guid.NewGuid();
Console.WriteLine(id);
// Example: 38d977a7-61e5-4f9e-8acd-9f5a9f8d1e4a

Guid empty = Guid.Empty;
// 00000000-0000-0000-0000-000000000000

DateTime now = DateTime.Now;                       // your local time
DateTime utcNow = DateTime.UtcNow;                 // UTC
DateTime specific = new DateTime(2025, 4, 5, 10, 30, 0);
Console.WriteLine(now.ToString("yyyy-MM-dd HH:mm"));

TimeSpan interval = new TimeSpan(2, 30, 0);         // 2 hours 30 minutes
DateTime start = new DateTime(2020, 1, 1);
TimeSpan gap = DateTime.Now - start;                // subtract two dates
Console.WriteLine(gap.TotalMinutes);
```

- `DateTime` covers `0001-01-01` to `9999-12-31`.
- Use `Guid` for keys, session IDs, and anything that must be unique across systems.

> **Analogy:** a `Guid` is a **fingerprint** — no two will ever match. A `DateTime` is a **page in a calendar**. A `TimeSpan` is the **ruler you lay across two pages** to measure the gap. You need the page *and* the ruler to work out an age.

---

## 3. Strings

### 3.1 What is a string

- A **built-in data type in C#** used to represent text.
- An **immutable reference type** that stores a sequence of Unicode characters (`char`).
- Declared with the `string` keyword, which is an alias for `System.String`.

```csharp
string a = "Bikram";
string b = "Bishal";
string c = "Apple";
```

> **Analogy:** a string is **text sealed inside plastic**. You cannot edit the letters inside — you take out a fresh copy, change that, and use the new one. The original is untouched, and that is exactly why strings are called *immutable*.

#### So is `string` a value type or a reference type?

§2.4 said `string` is a **reference type**. Here is the proof, and it also shows immutability at the same time:

```csharp
string a = "Bikram";
string b = a;             // b now points at the SAME text as a
b = b + "!";              // builds a BRAND NEW string from scratch

Console.WriteLine(a);     // Output: Bikram   — a was never touched
Console.WriteLine(b);     // Output: Bikram!
```

`b = b + "!"` looks like it should change `a` too, because they point at the same text. It does not, because strings cannot be edited — C# threw the old text away and built a new one.

You can even check the sharing directly with `ReferenceEquals`:

```csharp
string x = "Bishal";
string y = x;
Console.WriteLine(ReferenceEquals(x, y));   // Output: True  - one object, two names

x += "?";
Console.WriteLine(ReferenceEquals(x, y));   // Output: False - x is now a new object
```

This is the difference from `int` in one line: two `int`s holding 10 are separate boxes, while two `string`s holding `"Bishal"` are two labels on one box.

**Common use cases**

- Names, addresses, messages
- File paths, URLs
- User input and output
- Data formatting and display

### 3.2 String literals

A **literal** is text written straight into the code. Usually you just use double quotes:

```csharp
string name = "Hello World";
string path = @"C:\Users\John\Documents";   // Verbatim — no escaping needed
string multiline = "Line 1\nLine 2";        // Escape sequences work here
```

| Feature | Detail |
| --- | --- |
| Verbatim strings | Prefix with `@` — use it to avoid escaping backslashes |
| Escape sequences | `\n`, `\t`, `\"`, `\\` |
| Raw string literals | Triple quotes in C# 11+: `"""text"""` for multi-line text |

#### Why `@` exists

**Step 1 — in a normal string, `\` is a command character.** It does not mean "backslash". It means *"the next character is special, do something clever with it"*:

| You write | C# gives you | Called |
| --- | --- | --- |
| `\n` | a newline | escape sequence |
| `\t` | a tab | escape sequence |
| `\r` | a carriage return | escape sequence |
| `\\` | one `\` | escaped backslash |
| `\"` | one `"` | escaped quote |
| `\0` | a null character | escape sequence |
| `\u263A` | `☺` | Unicode escape — 4 hex digits |
| `\U0001F600` | `😀` | Unicode escape — 8 hex digits |

**Step 2 — Windows paths are built out of backslashes.** So the path breaks at the very first folder. The compiler reads `\U`, expects 8 hex digits, and finds the letters `sersJoh`:

```csharp
string p = "C:\Users\John\Documents";
// error CS1009: Unrecognized escape sequence
```

You get that error **three times** — once each for `\U`, `\J` and `\D`, because all three are invalid escapes.

**Step 3 — the dangerous version does not complain at all.**

```csharp
string p = "C:\temp\test";   // compiles. runs. silently wrong.
```

`\t` is a real tab, so what you actually built is `C:` `<TAB>` `emp` `<TAB>` `est`:

```text
C:<TAB>emp<TAB>est
```

| | What you typed | What you actually got |
| --- | --- | --- |
| Number of characters | 12 | **10** |
| Contains a tab | no | **yes** |
| `File.Exists(p)` | — | `false`, with no clue why |

> This is the failure worth remembering. A compile error tells you where to look. A path that quietly turns into a tab character just makes your program stop finding files, and there is nothing in the error list to point at it.

**Step 4 — three ways to write the same path.**

| Fix | Write it like this | Verdict |
| --- | --- | --- |
| Double every backslash | `"C:\\Users\\John\\Documents"` | works, but ugly, and easy to miss one |
| **Verbatim** | `@"C:\Users\John\Documents"` | **best for paths, regex and JSON** |
| Raw (C# 11+) | `"""C:\Users\John\Documents"""` | newest, no escapes at all |

All three produce the exact same string:

```text
1 doubled  : C:\Users\John\Documents
2 verbatim : C:\Users\John\Documents
3 raw      : C:\Users\John\Documents
all three equal? True
```

**The one extra rule — a `"` inside the text.** `@` saves you from escaping backslashes, but a `"` still ends the string, so it has to be dealt with too:

| | Write it like this | Result |
| --- | --- | --- |
| Normal | `"say \"hi\" now"` | say "hi" now |
| Verbatim | `@"say ""hi"" now"` | say "hi" now |
| Raw | `"""say "hi" now"""` | say "hi" now |

All three produce the identical string. Note the pattern: normal **doubles** the quote with a backslash, verbatim **doubles** the quote character, and a raw string needs nothing at all.

That last one is what makes raw strings worth knowing — JSON and XML become readable, because you write the quotes exactly as they appear in the data:

```csharp
string json = """{"name": "Sita", "course": "CS6004NP"}""";
```

> **Trap:** `""` inside a **raw** string means two quote characters, not one. Only verbatim strings collapse `""` into a single `"`.

> **Analogy:** a normal string is a **recipe** — `\n` means "put a line break here". A verbatim string is the **page as actually written**: the text stands exactly as typed, backslashes and all. The `@` means *read this one as handwriting, not as instructions*.

### 3.3 Interpolated strings

Interpolated strings let you **embed expressions directly in strings** using `$`. Syntax: `$"{expression}"`.

```csharp
string name = "Alice";
int age = 30;

string message = $"Hello, {name}! You are {age} years old.";
Console.WriteLine(message);
// Output: Hello, Alice! You are 30 years old.
```

| You can embed | Example | Output |
| --- | --- | --- |
| A variable | `$"{name}"` | `Alice` |
| An expression | `$"{age * 2}"` | `60` |
| A method call | `$"{name.ToUpper()}"` | `ALICE` |
| A format specifier | `$"{DateTime.Now:yyyy-MM-dd}"` | today's date, e.g. `2026-04-05` |

> **Analogy:** an interpolated string is a **form with blanks that a machine fills in for you**. You write `$"Hello, {name}"` once and the braces are the blanks — no `+` signs, no `ToString()`, no worrying about spaces around the value.

---

## 4. Arrays

### 4.1 Single-dimensional arrays

A **single-dimensional array** is a list of items stored in a **single row**, where each item is reached by its position number — the **index**.

In simple words: it is a row of boxes, and each box holds one value that you reach by its number. This is the most commonly used array type in C#.

> **Analogy:** a row of **numbered lockers**. The locker number is the index, and it starts at `0` — so in a 5-element array the valid numbers are `0` to `4`.

### 4.2 Declaration and initialization

```csharp
// 1. Declare, assign later — 5 integers, all default to 0
int[] numbers = new int[5];

// 2. Initialize with values
string[] names = { "Alice", "Bob", "Charlie" };

// 3. Using 'new' with explicit size and values
double[] prices = new double[3] { 10.99, 20.50, 30.00 };
```

| Form | When to use |
| --- | --- |
| `new int[5]` | You know the size but not the values yet |
| `{ "Alice", "Bob" }` | You know the values |
| `new double[3] { ... }` | You know both, and want the size stated explicitly |

### 4.3 Accessing elements

```csharp
Console.WriteLine(names[0]);   // Output: Alice
numbers[2] = 42;               // Set value at index 2
```

> **Analogy:** `numbers[2]` means "locker number 2". The compiler will not check whether the locker exists, so reading `numbers[10]` in a 5-element array throws `IndexOutOfRangeException`.

### 4.4 Iterating through an array

```csharp
// Using a for loop
for (int i = 0; i < names.Length; i++)
{
    Console.WriteLine(names[i]);
}

// Using foreach
foreach (string name in names)
{
    Console.WriteLine(name);
}
```

`Length` is the array's size, so the loop condition is always `i < names.Length` — never a hard-coded number, or the loop breaks the moment the array size changes.

### 4.5 Common array methods

C# provides powerful **static methods on the `Array` class** to work with arrays.

| Method | Purpose | Example |
| --- | --- | --- |
| `Array.Sort()` | Sorts elements in ascending order | `Array.Sort(numbers);` |
| `Array.Reverse()` | Reverses the order of elements | `Array.Reverse(numbers);` |
| `Array.IndexOf()` | Returns the index of the first occurrence, or `-1` if not found | `int pos = Array.IndexOf(names, "Bob");` |
| `Array.Find()` | Finds the first element matching a condition (uses a lambda) | `string match = Array.Find(names, n => n.StartsWith("A"));` |
| `Array.Clear()` | Sets a range of elements to the default value | `Array.Clear(numbers, 0, 2);` |

---

## 5. Generic Collections

### 5.1 What are generic collections

- Part of **`System.Collections.Generic`**.
- **Type-safe** collections that work with any data type, specified at design time.
- Eliminate the need for casting and reduce runtime errors.
- Example: `List<string>`

| Benefit | Why it helps |
| --- | --- |
| Type safety | Compile-time checking while inserting data |
| Reusability | The same logic works for `int`, `string`, or custom objects |

> **Analogy:** a non-generic collection is a **mystery box** — you put anything in and have to check what came out, every single time. A generic collection is a **box with the label taped on it**: `List<string>` only accepts strings, so the compiler stops you before the program ever runs.

### 5.2 Common generic collections

| Type | Purpose |
| --- | --- |
| `List<T>` | Dynamic array — add/remove items freely, and **keeps them in order** |
| `Dictionary<TKey, TValue>` | Key-value pairs — fast lookup by key, but **order is not guaranteed** |
| `Queue<T>` | FIFO (First-In, First-Out) structure |
| `Stack<T>` | LIFO (Last-In, First-Out) structure — last in, first out |

### 5.3 `List<T>`

- A **resizable, ordered** collection of elements of type `T`.
- Similar to an array, but it **grows and shrinks dynamically**.
- Found in `System.Collections.Generic`.

```csharp
List<int> numbers = new();                                  // Empty list
List<string> names = new() { "Alice", "Bob" };              // With initial values
List<double> prices = new List<double>();                    // Alternative syntax
```

| Method | Purpose |
| --- | --- |
| `.Add(item)` | Adds an item to the end |
| `.Remove(item)` | Removes the first occurrence |
| `.RemoveAt(index)` | Removes the item at an index |
| `.Count` | Returns the number of elements |
| `.Contains(item)` | Checks whether an item exists |
| `.Clear()` | Removes all items |

**Example usage**

```csharp
List<string> fruits = new();

fruits.Add("Apple");
fruits.Add("Banana");
fruits.Remove("Apple");

foreach (string fruit in fruits)
{
    Console.WriteLine(fruit);
}
// Output: Banana
```

> **Analogy:** `List<T>` is a **shopping trolley**. You can add anything that fits, take things back out, check whether the milk is still in there, and the trolley's size changes itself. An array, by contrast, is a shelf with a fixed number of slots.

### 5.4 `Dictionary<TKey, TValue>`

- Stores data as **key-value pairs**.
- Enables **fast retrieval** using a unique key.
- **Keys must be unique and not null.**
- Iteration order is **not guaranteed**. A `Dictionary` often *looks* ordered, and it usually is for a simple `Add`-only loop — but remove one key and it can reuse the freed slot, and the order changes.

```csharp
Dictionary<int, string> employeeNames = new();
Dictionary<string, double> prices = new();

// With initial data
var settings = new Dictionary<string, object>
{
    { "Volume", 80 },
    { "Fullscreen", true },
    { "Brightness", 75.5 }
};
```

| Method | Purpose |
| --- | --- |
| `.Add(key, value)` | Inserts a new key-value pair |
| `.Remove(key)` | Removes an entry by its key |
| `.ContainsKey(key)` | Checks whether a key exists |
| `.TryGetValue(key, out value)` | Safe get without exceptions |
| `.Count` | Number of key-value pairs |

```csharp
Dictionary<int, string> fruits = new()
{
    { 1, "Apple" },
    { 2, "Banana" },
    { 3, "Cherry" }
};

fruits.Add(4, "Mango");

foreach (KeyValuePair<int, string> pair in fruits)
{
    Console.WriteLine($"{pair.Key}: {pair.Value}");
}
// Output:
// 1: Apple
// 2: Banana
// 3: Cherry
// 4: Mango
```

> **Analogy:** a `Dictionary` is a **phone book** — you look someone up by a unique key and get the value instantly, instead of reading every entry. `Queue<T>` is the queue at a ticket counter (first in, first out); `Stack<T>` is a pile of plates (last in, first out).

---

## 6. If you know Java

Only the two ideas that Week 2 is actually built around. For everything else — naming, collections, methods, control flow — see the [Java-to-C# cheatsheet](../Week%201/CSharp-Java-Syntax-Cheatsheet.md).

**The type axis — Java splits into two, C# splits differently**

| Java | C# |
| --- | --- |
| primitives (`int`, `double`) vs references | **value types** vs **reference types** |
| 8 primitives, all value types | **a wider group** — `struct` and `enum` are value types too, along with every type you declare yourself using `struct` |
| `null` allowed on any reference, never checked | Reference types can be `null`, and the compiler **warns** if you did not mean it (C# 8+) |

**The declaration axis — mostly a rename**

| Java | C# |
| --- | --- |
| local variable, parameter | **identical** |
| **instance variable** `private int age;` | **instance field** `private int _age;` — renamed, and `_` marks private |
| **static / class variable** `static int count;` | **static field** `static int _count;` — same meaning: one copy for the class |
| a mutable instance variable | a plain field — mutable unless you add `readonly` |
| `final double PI = 3.14;` | `const double Pi = 3.14;` (compile-time), or `readonly` for run time |
| `static final` | `static readonly` — set once at run time, not baked in |
| `Optional<T>` | Nullable types: `T?` |

> The one to stop assuming: Java's split is **primitive versus reference**, decided by which of eight types you picked. C#'s split is **value versus reference**, and it is a property of the type itself — so `struct` counts as a value type, and a variable's *kind* (local, field, `static`) is a completely separate question from its type.

---

## 7. Common build errors

Errors and warnings you will meet most often. Every message below was checked against the compiler — note that the two conversion errors are easy to mix up.

| Code and message | Error or warning | Cause | Fix |
| --- | --- | --- | --- |
| `CS0103: The name 'x' does not exist in the current context` | error | Typo, or the variable was never declared | Check the spelling and the declaration |
| `CS0266: Cannot implicitly convert type 'double' to 'float'` | error | A floating literal with no suffix | Write `3.14f` |
| `CS0029: Cannot implicitly convert type 'string' to 'int'` | error | Wrong type entirely, or a missing `int.Parse` | Convert first: `int.Parse(s)` |
| `CS0131: The left-hand side of an assignment must be a variable, property or indexer` | error | You assigned to a `const` | Change the value inside the declaration, or use `readonly` and set it once |
| `CS0133: The expression being assigned to 'X' must be constant` | error | A `const` given a value only known at run time, e.g. `const List<string> x = new();` | `const` accepts only primitives, `string`, enums and `null` — use a `static readonly` field instead |
| `CS0165: Use of unassigned local variable 'age'` | error | Declared `int age;` and read it too early | Initialise it: `int age = 0;` |
| `CS1002: ; expected` | error | A missing semicolon at the end of a statement | Add the `;` |
| `CS1009: Unrecognized escape sequence` | error | A `\` inside a normal string, e.g. `"C:\temp"` | Use `@"C:\temp"`, or double the backslash — see [§3.2](#32-string-literals) |
| `CS1503: Argument 1: cannot convert from 'int' to 'string'` | error | Wrong type in an `Add(...)` call | Check the generic type: `List<string>` will not take an `int` |
| `CS1061: 'string' does not contain a definition for 'Add'` | error | You called a `List<T>` method on something that is not a list | Check what the variable really is — a `string` has `.Length`, a `List<T>` has `.Count` and `.Add` |
| `CS8600: Converting null literal or possible null value to non-nullable type` | warning | Assigning `null` to a plain `string` | Write `string?` or give it a real value |
| `CS8602: Dereference of a possibly null reference` | warning | Using a `string?` without checking | Add a `null` check, or `!` if you are certain |
| `CS0169: The field 'X' is never used` | warning | You declared a field but never read or wrote it | Use it, or remove it |
| `System.IndexOutOfRangeException` | run-time | Array index outside `0` to `Length - 1` | Check the bounds, remember indexes start at 0 |
| `System.ArgumentOutOfRangeException` from `List.RemoveAt` | run-time | `RemoveAt` on an empty list or a bad index | Check `.Count` first |

> **Remember the difference:** a **red** `error` stops the build and nothing runs. An orange **warning** still compiles and runs — the compiler is only asking you to double-check something.

---

## 8. Summary

- **Syntax:** `//` for one line, `/* */` for a block, `///` for documentation. Statements end with `;`, blocks use `{ }`, expressions evaluate to a result.
- **Variables:** declare, then fill in, or both on one line — `<dataType> name = value;`. Always end with `;`.
- **A variable has a *kind* and a *type*, and they are two separate things.** The kind says **where it lives** — local, parameter, field, static field, or `const`. The type says **what can go in it** — value type or reference type. Any kind can be either type.
- **`static` means one copy for the whole class**, shared by everyone using it.
- **Value types** (`int`, `double`, `bool`, `char`, `struct`) hold the value itself, and each variable owns a copy. **Reference types** (`string`, classes, arrays, collections) hold an address, so two variables can point at the same thing.
- **Pick the smallest type that fits** — `byte` for small values, `int` for everyday numbers, `long` for huge ones, `decimal` for money.
- **Nullable types** allow "no value": `int?` and `string?`. This turns `NullReferenceException` crashes into compile-time warnings.
- **`const` is fixed while building; `readonly` is fixed once at run time.**
- **Strings** cannot be changed; use `@"..."` for file paths and `$"..."` to insert values.
- **Arrays** are fixed-length and counted from `0`; **`List<T>`** grows and shrinks; **`Dictionary<K,V>`** looks things up by a key.
- **All collections are generic** — say what goes inside them and the compiler catches mistakes before you run.

---

## References

- [Week 1 Lecture Notes](../Week%201/Week%201%20Lecture%20Notes.md)
- [Java-to-C# syntax cheatsheet](../Week%201/CSharp-Java-Syntax-Cheatsheet.md)
- [C# and .NET setup guide](../Week%201/CSharp-DotNet-Setup.md)
- [C# variables and data types](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/variables)
- [Built-in types](https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/types)
- [Interpolated strings](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interpolated-strings)
- [Arrays in C#](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/)
- [List\<T\> class](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)
- [Dictionary\<TKey, TValue\> class](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2)
- [Nullable reference types](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-reference-types)