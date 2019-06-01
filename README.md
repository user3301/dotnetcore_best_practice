![.Net Core Best Practice](/assets/logo_final.png?raw=true)

[![License: GPL](https://img.shields.io/badge/License-GPL-blue.svg)](https://github.com/user3301/dotnetcore_best_practice/blob/master/LICENSE)

In this repository, you can find some coding and naming conventions in C# (.Net Core 1.x + specifically).

# Contents
- [Contents](#contents)
- [Introduction](#introduction)
- [Coding and Naming Conventions](#coding-and-naming-conventions)
  - [Naming](#naming)
  - [Variables](#variables)
  - [Functions](#functions)
  - [Classes](#classes)
  - [Unit Testing](#unit-testing)

# Introduction

![namingmeme](/assets/namingmeme.jpg)

Standardization has a positive impact on any business as well as in the Software industry. There are certain coding standards that are needed for a successful implementation of a program. Good quality software and code is not as easy as it seems to be. Often it  requires consistent efforts and sheer focus of the software development team to meet the quality goals. This repository is a C# programming language coding guide to producing readable, reusable and scalable code.

Inspired by [clean-code-javascript](https://github.com/ryanmcdermott/clean-code-javascript),  [clean-code-php](https://github.com/jupeter/clean-code-php) and [clean-code-dotnet](https://github.com/thangchung/clean-code-dotnet) lists.

# Coding and Naming Conventions

## Naming

<details>
  <summary><b>Use intention-revealing names</b></summary>
A good name does not only improve the readability of the code but also enhance working efficiency as it helps other team members to understand your code.

**Bad:**

This is a bad naming of variable as it does not reflect what it means in the given context, or at last we need to read other parts of the code to find out.

```csharp
int d;
```

**Good:**

```csharp
int elapsedTimeInDays;
int daySinceModification;
int daysSinceCreation;
int fileAgeInDays;
```
These names are good practice as it reveal your intentions.

**[⬆ Back to top](#table-of-contents)**

</details>


<details>
  <summary><b> Avoid disinformation</b></summary>

Sometimes coders need to "hide" some implementation in the back stage, however they tend also to create confusing parts of code.

**Bad:**

```csharp
int[] randomNumberList;
```
"randomNumberList" is not actually a list type data structure. 


**Good:**

```csharp
int[] randomNumbers;
```

**[⬆ Back to top](#table-of-contents)**

</details>


<details>
  <summary><b> Good names length</b></summary>

Long variable names are no longer a problem in modern software development as we have powerful IDEs to help us navigate in code. Nevertheless the problem is that this still can introduce a naming chaos in code.

**Bad:**

```csharp
Account[] theUserAccountArrayIncludesBothActivatedAndDeactivated;
```

**Good:**

```csharp
Account[] allAccounts;
```

**[⬆ Back to top](#table-of-contents)**

</details>


<details>
  <summary><b> Keep notation consistent</b></summary>

Notation means a programming language's own "style". Coders should cook code that matches this notation because other programmers probably know it and use it. 

**Bad:**

```csharp
const int threshold = 100;
public string USERNAME;
private string Name;
void printname();
```

**Good:**

```csharp
const int THRESHOLD = 100;
public string UserName;
private string _name;
void PrintName();
```
C# variable & function naming conventions:

| Object Name               | Notation   | Length | Plural | Prefix | Suffix | Abbreviation | Char Mask          | Underscores |
|:--------------------------|:-----------|-------:|:-------|:-------|:-------|:-------------|:-------------------|:------------|
| Class name                | PascalCase |    128 | No     | No     | Yes    | No           | [A-z][0-9]         | No          |
| Constructor name          | PascalCase |    128 | No     | No     | Yes    | No           | [A-z][0-9]         | No          |
| Method name               | PascalCase |    128 | Yes    | No     | No     | No           | [A-z][0-9]         | No          |
| Method arguments          | camelCase  |    128 | Yes    | No     | No     | Yes          | [A-z][0-9]         | No          |
| Local variables           | camelCase  |     50 | Yes    | No     | No     | Yes          | [A-z][0-9]         | No          |
| Constants name            | PascalCase |     50 | No     | No     | No     | No           | [A-z][0-9]         | No          |
| Field name                | camelCase  |     50 | Yes    | No     | No     | Yes          | [A-z][0-9]         | Yes         |
| Properties name           | PascalCase |     50 | Yes    | No     | No     | Yes          | [A-z][0-9]         | No          |
| Delegate name             | PascalCase |    128 | No     | No     | Yes    | Yes          | [A-z]              | No          |
| Enum type name            | PascalCase |    128 | Yes    | No     | No     | No           | [A-z]              | No          |

**[⬆ Back to top](#table-of-contents)**

</details>


<details>
  <summary><b>Use pronounceable names</b></summary>

Human are good at memorizing pronounceable words. So make variable names pronounceable. 

**Bad:**

```csharp
public class DtaRcrd102
{
    public Datetime genymdhms { get; set; } // what the programmer want to tell is generation timestamp in yy-mm-dd-hh-mm-ss format
    public Datetime modymdhms { get; set; } // modeification timestamp in yy-mm-dd-hh-mm-ss format
}
```

**Good:**

```csharp
public class Customer
{
    public Datetime GenerationTimestamp { get; set; }
    public Datetime ModificationTimestamp { get; set; }
}
```

**[⬆ Back to top](#table-of-contents)**

</details>


<details>
  <summary><b>Use domain name</b></summary>

Remember that the people who read your code will be programmers. So go ahead and use CS terms, algorithm names, math terms and pattern names and so on so that when will know the concept by seeing the names.

**Bad:**

```csharp
 public int Fibonacci(int N) {
        var arr = new int[N]; // bad 

        if(N==0) return 0;
        if(N==1 || N == 2) return 1;
            arr[0] = 1;
            arr[1] = 1;

            for (int i = 2; i < N; i++)
            {
                arr[i] = arr[i-1] + arr[i-2];
            }
            return arr[N-1];
    }

```


**Good:**

```csharp
public int Fibonacci(int N) {
        var dp = new int[N]; // good. Programmers with algorithm knowledge will know dynamic programming is used in this function and will understand this array is used to cache previous calculated solution of a sub-problem

        if(N==0) return 0;
        if(N==1 || N == 2) return 1;
            dp[0] = 1;
            dp[1] = 1;

            for (int i = 2; i < N; i++)
            {
                dp[i] = dp[i-1] + dp[i-2];
            }
            return dp[N-1];
    }

```

**Bad:**

```csharp
 class GumballMachine
 {
     public IEntity Sold;
     public IEntity SoldOut;
 }

```


**Good:**

```csharp
class GumballMachine
 {
     // State pattern is used here
     public IState SoldState;
     public IState SoldOutState;
 }

```


**[⬆ Back to top](#table-of-contents)**

</details>

## Variables

<details>
  <summary><b>Avoid mental mapping</b></summary>

Clean code should be easy to read, understand and should leave no room for guesswork. The following code checks if a user can withdraw a certain amount of money from his/her bank account. It's messy as there is a lengthy condition statement.

**Bad:**

```csharp
public bool Withdraw(User user, double amount)
{
    if(user.Balance > amount && user.ActiveLoan == 0)
    {
        user.Balance -= amount;
        return true;
    }
    else return false;
}
```

**Good:**

```csharp
public bool Withdraw(User user, double amount)
{
    if(HasNoActiveLoan(user) && CanWithdrawAmount(double amount))
    {
        user.Balance -= amount;
        return true;
    }
    else false;
}

private bool HasNoActiveLoan(User user) => user.ActiveLoan ==0;
private bool HasNoActiveLoan(double amount) => user.Balance > amount;
```

This is not only easier to understand but also easier to test.


**Bad:**

```csharp
var a = FruitBasket.GetApple();
var o = FruitBasket.GetOrange();
var s = Blender.MakeSmoothie(a,o);
```

**Good:**

```csharp
var apple = FruitBasket.GetApple();
var orange = FruitBasket.GetOrange();
var smoothie = Blender.MakeSmoothie(apple, orange);
```

**[⬆ back to top](#table-of-contents)**

</details>


<details>
  <summary><b>Avoid using "magic" number or string</b></summary>

A magic number or string is basically a hard-coded value that might change at a later stage. Since it has the chances of changing at a later stage, it can be said that the number is hard to update.

**Bad**

```csharp
public class Foo {
    public void SetPassword(string password) {
         // 7 is the magic number
         if (password.Length() > 7) {
              throw new InvalidArgumentException("password");
         }
    }
}
```

**Good**

```csharp
public class Foo {
    public const int MAX_PASSWORD_SIZE = 7;

    public void SetPassword(string password) {
         if (password.Length() > MAX_PASSWORD_SIZE) {
              throw new InvalidArgumentException("password");
         }
    }
}
```

It improves readability of the code and it's easier to maintain. Once there are multiple places that the length of the password needs to be checked, when the max size is changed, programmers need to change in all code locations with that magic number. Missing any one will lead to inconsistencies.

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Don't add gratuitous context</b></summary>

Shorter names are generally better than longer ones, so long as they are clear. Add no more context to a name than is necessary. 

**Bad:**

```csharp
public class User
{
    public string UserEmail { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }

    //...
}
```

Imagine you type 'U' and press the completion key and are rewarded with all the properties in this object. Does this make your life easier?

**Good:**

```csharp
public class User
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    //...
}
```

**[⬆ back to top](#table-of-contents)**

</details>


<details>
  <summary><b>Use searchable names</b></summary>

One might easily grep for `DAYS_IN_KNUCKLE_MONTH`, but the number 31 could be more troublesome. Searches may turn up the digit as part of file names, other constant definition, and in various expressions where the value is used with different intent.

**Bad:**

```csharp
int s = 0;
for(int i =1; i<= 31; ++i)
{
  s += (t[i]*4)
}
```

**Good:**

```csharp
int realDaysPerIdealDay = 4;
public const int WORK_DAYS_PER_WEEK = 5;
int sum = 0;

for(int i=1; i<= NUMBER_OF_TASKS;++i)
{
  int realTaskDays = taskEstimate[i] * realDaysPerIdealDay;
  int realTaskWeeks = (realdays / WORK_DAYS_PER_WEEK);
  sum += realTaskWeeks;
}
```

**Bad:**

It's hard to navigate to the location where `transcriptionStatus` is `error` and see what happens unless 0 is mentally "mapped" to `error`.
```csharp
var transcriptionStatus = DocumentDB.GetTranscriptStatus();
if(transcriptionStatus < 0) return StatusCode(500);
```

**Good:**

```csharp
public enum TranscriptionStatusEnum:short
{
   error = -1,
   analyzing = 1,
   done = 2,
   received = 3
}

var transcriptionStatus = DocumentDB.GetTranscriptStatus();
if(transcriptionStatus == TranscriptionStatusEnum.error) return StatusCode(500);
```


**[⬆ Back to top](#table-of-contents)**

</details>


## Functions

<details>
  <summary><b>Keep indentation consistent</b></summary>
Keep your indentation style consistent is a good way to improve your code readability and keep it nice and concise.

**Style 1:**

```csharp
void Foo() {
  if(condition) {
    //do something
  } else {
    //do something
  }
}
```

**Style 2:**

```csharp
void Foo()
{
  if(condition)
  {
    //do something
  }
  else
  {
    //do something
  }
}
```

**Style 3:**

```csharp
void Foo()
{ if(condition)
  { //do something
  }
  else
  { //do something
  }
}
```

Indentation of choice is only a matter of preference unless your language of choice has a strict rule of indentation(Golang enforce curly bracket to not be on the next line). Based on my personal experience `Style 2` is preferred by .Net and .Net Core developer whereas `Style 1` is more for Java guys.

**[⬆ Back to top](#table-of-contents)**

</details>


<details>
  <summary><b>Use local functions when necessary</b></summary>
C# supports local functions since C# 7.0. Local functions are private methods of a type that are nested in another member. They can only be called from their containing member. Local functions can be declared in and called from:

  1. Methods, especially iterator methods and async methods;
   
  2. Constructors;
   
  3. Property accessors;
   
  4. Event accessors;
   
  5. Anonymous expressions;
    
  6.  Finalizers;
    
  7.  Other local functions; 

**Bad:**

```csharp
public static partial class Utility
{
  #region  private method
  private static string GetText(string path, string filename)
  {
    var sr = File.OpenText(AppendPathSeparator(path) + filename);
         var text = sr.ReadToEnd();
         return text;
  }

// this method is only called inside GetText method
  private static string AppendPathSeparator(string filepath)
  {
    if (! filepath.EndsWith(@"\"))
               filepath += @"\";

            return filepath;   
  }
  #endregion
}
```

As method `GetText` is a private method in the `Utility` class, The `AppendPathSeparator` method is only used inside of `GetText` method. We could move `AppendPathSeparator` method declaration into `GetText` method to avoid contaminate the global environment.

**Good:**

```csharp
 private static string GetText(string path, string filename)
    {
         var sr = File.OpenText(AppendPathSeparator(path) + filename);
         var text = sr.ReadToEnd();
         return text;
         
         // Declare a local function.
         string AppendPathSeparator(string filepath)
         {
            if (! filepath.EndsWith(@"\"))
               filepath += @"\";

            return filepath;   
         }
    } 
```

**[⬆ Back to top](#table-of-contents)**

</details>


<details>
  <summary><b>Replace conditional with polymorphism when possible</b></summary>
 

**Bad:**

```csharp
class Car 
{
  public MakeEnum Make {get; set;}
  //...
  double GetSpeed()
  {
    switch(Make)
    {
      case MakeEnum.European:
        return GetBaseSpeed();
      case MakeEnum.Asian:
        return GetBaseSpeed() + GetCylinders() * MAXSPEEDPERCYLINDER;
      case MakeEnum.American:
        return (Is4WD)? 100: GetBaseSpeed();
    }
    throw new NotImplementedException();
  }
}
```



**Good:**
```csharp
abstract class Car
{
  abstract double GetSpeed();
}

class European: Car
{
  public double GetBaseSpeed() => 100d;

  override double GetSpeed()
  {
    return GetBaseSpeed();
  }
}

class Asian:Car
{
  public int Cylinders {get; set;}

  public double GetBaseSpeed()=> 110d;

  public const double MAXSPEEDPERCYLINDER = 20;

  override double GetSpeed()
  {
    return GetBaseSpeed() + Cylinders * MAXSPEEDPERCYLINDER;
  }
}

class American:Car
{
  public double GetBaseSpeed() => 90d;

  override double GetSpeed()
  {
    return Is4WD? 100: GetBaseSpeed();
  }
}


//somewhere in client side's code

var speed = car.GetSpeed();

```

**[⬆ Back to top](#table-of-contents)**

</details>

## Classes

## Unit Testing