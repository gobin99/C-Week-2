# Workshop 2 — Variables and Datatypes

**Module:** CS6004NP Application Development
**Duration:** 45 minutes

Six tasks, all in one project. You will declare variables, meet a constant, convert between types, sort an array, work out your age, and use two generic collections. Later tasks build on the file you edited in the task before, so keep it open.

| Task | Topic | Time |
| --- | --- | --- |
| 1 | Variables and interpolated strings | 5 min |
| 2 | Constants and a class of your own | 5 min |
| 3 | Data types and type conversion | 5 min |
| 4 | Arrays and the `Array` methods | 10 min |
| 5 | `DateTime` and `TimeSpan` | 10 min |
| 6 | `List<T>` and `Dictionary<K,V>` | 10 min |

---

## Before you start

Create the project once. Every task below adds to it.

```bash
dotnet new console -n VariablesAndDatatypes
cd VariablesAndDatatypes
```

This creates `VariablesAndDatatypes.csproj` and `Program.cs`. Open the project folder in VS Code with `code .` if you have not already.

---

## Task 1 — Variables and interpolated strings

**Goal:** declare two variables and print them in a single line using string interpolation.

### Step 1 — Replace `Program.cs`

Put this skeleton in `Program.cs` and fill in the three TODOs. Task comments like `// ---- Task 1 ----` are there to help you find your way back later — leave them in.

```csharp
namespace VariablesAndDatatypes
{
    class Program
    {
        static void Main()
        {
            // ---- Task 1: variables and interpolated strings ----

            // TODO 1: declare a variable called userName that holds your name.
            //         Text needs the type string.

            // TODO 2: declare a variable called luckyNumber holding your
            //         favourite single-digit number. A whole number is int.

            // TODO 3: print ONE line that reads exactly:
            //         Hello, <your name>! Your lucky number is <the number>.
            //         Use string interpolation, not the + operator.
        }
    }
}
```

<details>
<summary>Hint</summary>

- A variable is written `type name = value;` — the type comes first, then the name, then a semicolon.
- Text needs `string`. A single-digit whole number needs `int`.
- An interpolated string starts with `$` before the opening quote: `$"Hello, {userName}!"`. The braces are where the value drops in. Change the word inside the braces to print a different variable.
- Leave a space before `!` and before `Your`, or the words run together.

</details>

### Step 2 — Build and run

```bash
dotnet run
```

Expected output — your name and your number will differ:

```text
Hello, Sita! Your lucky number is 7.
```

### Check your work

- ☐ The build reports **0 errors, 0 warnings**.
- ☐ Both values come from variables — nothing is typed straight into the `WriteLine`.
- ☐ The string starts with `$` and you used `{ }` rather than `+`.

---

## Task 2 — Constants and a class of your own

**Goal:** write a class containing a constant, then deliberately break it and read the compiler's complaint.

### Step 1 — Create the class file

In VS Code, right-click the project folder and choose **New File**. Name it exactly `Circle.cs` and save it inside the project folder.

### Step 2 — Write the class

```csharp
namespace VariablesAndDatatypes
{
    public class Circle
    {
        // TODO 1: declare a constant named PI, initialised to 3.14.
        //         A constant needs the keyword const and the type double.

        // Stretch: add a method Area that takes one double radius and
        // returns PI * radius * radius.
        // Stretch: add a method Perimeter that takes one double radius and
        // returns 2 * PI * radius.
    }
}
```

### Step 3 — Use it from `Main`

Add these lines **inside** `Main`, below your Task 1 code:

```csharp
            // ---- Task 2: constants ----

            // TODO 2: create a Circle object and print Circle.PI.
            //         PI is a constant, so you read it through the class
            //         name rather than through an object.

            // TODO 3: now write this on a line of its own:
            //             Circle.PI = 3.15;
            //         then build and read the error.
            //         When you have read it, delete the line again so the
            //         remaining tasks still run.
```

```bash
dotnet build
```

Expected output — the build **fails on purpose**:

```text
error CS0131: The left-hand side of an assignment must be a variable, property or indexer
```

<details>
<summary>Hint</summary>

- **The constant.** It is written `public const double PI = 3.14;` — `const` goes after the access modifier, and the name is in **PascalCase** because it is a constant.
- **Creating the object.** `Circle circle = new Circle();` builds one. You do not need the object to read `PI`, but you do need it to call `Area` or `Perimeter`.
- **Why CS0131?** The left side of an `=` must be something that can *hold* a new value. A `const` is fixed while the program is being built, so `Circle.PI` is not a legal target. If you had used `static readonly` instead of `const`, the assignment would be legal here and would fail later instead — which is the difference between the two.
- The stretch methods need a return type of `double`, and `=>` gives you a one-line body: `public double Area(double radius) => PI * radius * radius;`

</details>

### Check your work

- ☐ `Circle.cs` exists as its own file, outside the `class Program` braces.
- ☐ `PI` is declared with `const` and reads `3.14`.
- ☐ You can explain the CS0131 error in one sentence: *PI is a constant, so it cannot be assigned to.*
- ☐ You deleted the `Circle.PI = 3.15;` line, so the build passes again.

---

## Task 3 — Data types and type conversion

**Goal:** declare one variable of each basic type, convert in both directions, and print everything with labels.

### Step 1 — Declare and convert

Add these **inside** `Main`. Two variables and two print lines are given as a model — copy their shape for the rest.

```csharp
            // ---- Task 3: data types and type conversion ----

            byte tiny = 200;
            short small = 30000;

            // TODO 4: declare one variable for each of these types and give
            //         it a sensible value:
            //             int, long, float, double, decimal, char, bool

            // TODO 5: convert the number 42 into a string, storing the
            //         result in a new variable.

            // TODO 6: convert the string "3.14" into a double, storing the
            //         result in a new variable.

            // These two lines are done for you as a model.
            Console.WriteLine($"byte   = {tiny}      (type: byte)");
            Console.WriteLine($"short  = {small}     (type: short)");

            // TODO 7: print one labelled line for each of the remaining
            //         variables, including the two you converted.
            //         Keep the spacing so the columns line up.
```

```bash
dotnet run
```

<details>
<summary>Hint</summary>

- The type for each: `int` (whole), `long` (very large whole), `float` and `double` (decimals), `decimal` (money), `char` (a single character), `bool` (`true` or `false`).
- **Number to text:** call `ToString()` on the number — `42.ToString()` gives `"42"`.
- **Text to number:** call `Parse` on the string — `double.Parse("3.14")` gives `3.14`. There is also `int.Parse` if you stored `"42"` instead.
- A `char` needs **single** quotes (`'A'`) and a `string` needs **double** quotes (`"A"`).
- A `float` literal needs an `f` on the end, or the compiler will complain when it tries to fit a `double` into a `float`.
- **Bonus, if you want the type printed automatically:** `{tiny.GetType().Name}` writes `Byte` for you. Be warned — it prints the runtime name, so `int` comes out as `Int32` and `string` as `String`. That is why the model lines spell the type out by hand.

</details>

### Check your work

- ☐ You have a variable for all nine types, and every one is used somewhere.
- ☐ Both conversions work — you can print `42` as text and `3.14` as a number.
- ☐ `char` uses single quotes, `string` uses double quotes.
- ☐ Every print line names its type.

---

## Task 4 — Arrays and the `Array` methods

**Goal:** sort five numbers, reverse them, print them by index, and look one up.

### Step 1 — Write the code

Add this **inside** `Main`. The array itself is given — the five TODOs are yours.

```csharp
            // ---- Task 4: arrays and Array methods ----
            int[] numbers = { 42, 7, 19, 3, 88 };

            // TODO 8: print the numbers in their original order on one
            //         line, separated by commas.

            // TODO 9: sort them ascending with Array.Sort, then print the
            //         line again.

            // TODO 10: reverse them with Array.Reverse, then print again.

            // TODO 11: print each element on its own line using a for loop,
            //          showing the index as well as the value.

            // TODO 12: use Array.IndexOf to find the position of 19 and
            //          print it. Then look up 100 and print that too.
```

<details>
<summary>Hint</summary>

- To print an array on one line with commas, use `string.Join(", ", numbers)`. It saves you a loop.
- `Array.Sort(numbers);` and `Array.Reverse(numbers);` both change the array **in place** and return nothing — you do not assign the result anywhere.
- The for loop must count from `0` to `numbers.Length - 1`. Write `i < numbers.Length`, not `<=`.
- Inside the loop, the element is `numbers[i]`. Interpolate both: `$"  [{i}] = {numbers[i]}"`.
- `Array.IndexOf` returns the **index** if it finds the value, and `-1` if it does not. Try both 19 and 100.

</details>

### Step 2 — Build and run

Expected output for the numbers above:

```text
Original : 42, 7, 19, 3, 88
Sorted   : 3, 7, 19, 42, 88
Reversed : 88, 42, 19, 7, 3
  [0] = 88
  [1] = 42
  [2] = 19
  [3] = 7
  [4] = 3
IndexOf(19)  = 2
IndexOf(100) = -1
```

### Check your work

- ☐ The array is declared once and every later step uses that same array.
- ☐ Sorting and reversing change the array in place — no `numbers = ...` anywhere.
- ☐ The for loop uses `numbers.Length`, not a typed-in `5`.
- ☐ `IndexOf` returns `2` for 19 and `-1` for 100.

---

## Task 5 — `DateTime` and `TimeSpan`

**Goal:** hold a birth date, subtract it from today to get a `TimeSpan`, and turn that into an age in years.

### Step 1 — Write the code

Add this **inside** `Main`. The birth date is given so everyone gets a working result — change the numbers to your own.

```csharp
            // ---- Task 5: DateTime and TimeSpan ----
            DateTime birthDate = new DateTime(2004, 3, 15);

            // TODO 13: declare a DateTime holding the current date and time,
            //          called today.

            // TODO 14: subtract birthDate from today. The result is a
            //          TimeSpan — name it ageSpan.
            //          Subtracting two DateTimes gives you a TimeSpan, so
            //          there is nothing to convert explicitly.

            // TODO 15: work out the age in whole years from the TimeSpan and
            //          store it in an int called years.
            //          ageSpan.TotalDays / 365.25 gives a decimal number of
            //          years — cast it to int to drop the fraction.

            // TODO 16: print your birth date, today's date, your age in
            //          years, and your birth date plus 10 days.
```

<details>
<summary>Hint</summary>

- Today's date and time comes from `DateTime.Now`. (There is also `DateTime.UtcNow` if you ever need UTC.)
- Subtracting dates with `-` gives you the `TimeSpan` directly: `TimeSpan ageSpan = today - birthDate;`
- A `TimeSpan` has `.Days`, `.TotalDays`, `.TotalHours`, `.TotalMinutes` and `.TotalSeconds`. You want `.TotalDays` here, because `.Days` alone caps at 365.
- For the cast, write `(int)` in front of the whole calculation.
- Adding days or years is a method on the date: `birthDate.AddDays(10)` or `birthDate.AddYears(22)`. Neither one changes the original variable — it returns a **new** date.
- To print a date in a readable shape, give it a format: `birthDate.ToString("yyyy-MM-dd")`.

</details>

### Step 2 — Build and run

Expected output for a birth date of 15 March 2004:

```text
Birth date : 2004-03-15
Today      : 2026-10-03
Total days : 8238
Age        : 22 years
Birth + 10 days : 2004-03-25
```

### Check your work

- ☐ `ageSpan` really is a `TimeSpan`, obtained with `-` and no manual conversion.
- ☐ You used `.TotalDays`, not `.Days`.
- ☐ The age is a whole number of years, not `22.4`.
- ☐ `birthDate` still holds `2004-03-15` after you printed the `+10 days` date.

---

## Task 6 — `List<T>` and `Dictionary<TKey, TValue>`

**Goal:** use both collections from the lecture — a list you add to and remove from, and a dictionary you look things up in.

### Step 1 — Write the code

Add this **inside** `Main`. The list is given; the rest is yours.

```csharp
            // ---- Task 6: List<T> and Dictionary<K,V> ----
            List<string> fruits = new() { "Apple", "Mango", "Banana" };

            // TODO 17: add one more fruit to the end of the list.

            // TODO 18: remove one fruit from the list.

            // TODO 19: print every remaining fruit on its own line using a
            //          foreach loop.

            // TODO 20: declare a Dictionary<int, string> called byId whose
            //          keys are 1, 2 and 3 and whose values are fruit names.

            // TODO 21: add a fourth entry, then print every key-value pair
            //          using a foreach loop over the dictionary.
```

<details>
<summary>Hint</summary>

- `.Add(item)` appends to the end. `.Remove(item)` deletes the **first** matching value, and `.RemoveAt(index)` deletes by position.
- A `foreach` over a list gives you the item directly, so `foreach (string fruit in fruits)` and then use `fruit`.
- A `foreach` over a dictionary gives you a **pair**, so you need the type `KeyValuePair<int, string>` — and then read `.Key` and `.Value` off it. This is the one place a foreach variable has two names to choose from.
- Building a dictionary with values in one go uses curly braces with `{ }` inside the brackets:
  `new Dictionary<int, string> { {1, "Apple"}, {2, "Mango"}, {3, "Banana"} };`
- `Dictionary.Count` counts the **pairs**, not the keys and values separately.

</details>

### Step 2 — Build and run

Expected output for the list and dictionary above:

```text
  Apple
  Banana
  Orange
  1 -> Apple
  2 -> Mango
  3 -> Banana
  4 -> Orange
```

### Check your work

- ☐ The list ended with **three** fruits — one added, one removed.
- ☐ The `foreach` over the list prints fruit names only, with no indices.
- ☐ The dictionary ends with **four** pairs.
- ☐ The dictionary `foreach` prints both the key and the value.

---

## If you know Java

Only the differences that bite in these six tasks. The [Java-to-C# cheatsheet](../Week%201/CSharp-Java-Syntax-Cheatsheet.md) covers the rest.

| Java | C# |
| --- | --- |
| `String name = "Sita";` | `string name = "Sita";` — lowercase `string` |
| `int` / `long` / `double` | Same names, same widths. But `boolean` becomes `bool` |
| `final double PI = 3.14;` | `const double Pi = 3.14;` — and PascalCase, because it is a constant |
| `public static void main(String[] args)` | `static void Main()` — capital `M` |
| `System.out.println(...)` | `Console.WriteLine(...)` |
| `"Name: " + name` | `$"Name: {name}"` — interpolation |
| `int[] a = {42, 7, 19};` | `int[] a = {42, 7, 19};` — identical |
| `Arrays.sort(a);` | `Array.Sort(a);` |
| `new ArrayList<String>()` | `new List<string>()` |
| `list.size()` | `list.Count` — a **property**, capitalised, no brackets |
| `new HashMap<Integer, String>()` | `new Dictionary<int, string>()` |
| `map.containsKey(k)` | `map.ContainsKey(k)` |
| `new Date();` / `System.currentTimeMillis()` | `DateTime.Now` / `DateTime.UtcNow` |
| `String.format("%s", x)` | `$"{x}"` |
| `final` on a local variable | `const` — and it must be assigned where it is declared |

---

## If the program does not build

| Error | Fix |
| --- | --- |
| `CS0131: The left-hand side of an assignment must be a variable...` | Expected in Task 2 — you assigned to the `const PI`. Delete that line to carry on. |
| `CS1002: ; expected` | A statement is missing its semicolon. |
| `CS1009: Unrecognized escape sequence` | A `\` inside a normal string. Write `"3.14f"` not `"3.14f\"`, and for a file path use `@"C:\temp"`. |
| `CS0266: Cannot implicitly convert type 'double' to 'float'` | A `float` literal needs its `f` suffix — `3.14f`. |
| `CS0029: Cannot implicitly convert type 'string' to 'int'` | You assigned text to a number. Convert first with `int.Parse` or `ToString`. |
| `CS0165: Use of unassigned local variable` | You read a variable before giving it a value. |
| `CS0246: The type or namespace name 'Circle' could not be found` | `Circle.cs` is misspelled, saved outside the project folder, or uses a different `namespace`. |
| `CS0116: A namespace cannot directly contain members` | The class or method was written directly inside `namespace { }`. It needs to be inside a class. |
| `CS0246: The type or namespace name 'List' could not be found` | Add `using System.Collections.Generic;` at the very top of the file, above the `namespace`. |
| `dotnet : command not found` | Close the terminal completely, open a new one, and try again. |