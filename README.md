![.Net Core Best Practice](/assets/logo_final.png?raw=true)

[![License: GPL](https://img.shields.io/badge/License-GPL-blue.svg)](https://github.com/user3301/dotnetcore_best_practice/blob/master/LICENSE)

In this repository, you can find some coding and naming conventions in C# (.Net Core 1.x + specifically).

# Table of Contents
- [Table of Contents](#Table-of-Contents)
- [Introduction](#Introduction)
- [Coding and Naming Conventions](#Coding-and-Naming-Conventions)
  - [Naming](#Naming)
  - [Variables](#Variables)
  - [Functions](#Functions)
  - [Classes](#Classes)
  - [Unit Testing](#Unit-Testing)
  - [Tools](#Tools)

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

**Real-life example:**
```java
//from Netty, use `group` as the naming convention for a collection of objects, it avoid causing misleading and also hide the implementation of actual data structure
NioEventLoopGroup workerGroup = new NioEventLoopGroup();
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


<details>
  <summary><b>Final words</b></summary>
Here are some `Do` s and `Don't` s that may help you name variable better:

1. `Do` use PascalCasing for class names and method names;
Example:

```csharp
public class Foo
{
    public void GetFooDetails()
    {
      //...
    }
}
```

2. `Do` use camelCasing for method arguments and local variables;
Example:
```csharp
public class FooBar
{
  public void Save(FooBar fooBar)
   {
       // ...
   }
} 
```

3. `Don't` use Abbreviations;
Example:
```csharp
// Correct
DocumentProfile documentProfile;
 
// Avoid
DocumentProfile docProf;

```

4. `Don't` use Underscores in identifiers;
Example:
```csharp
// Correct
FooBar fooBar;
 
// Avoid
FooBar foo_Bar; 
```

5. `Do` prefix interfaces with letter `I`;
Example:
```csharp
//Correct
public interface IFooBar{}

//Avoid
public interface FooBar{};
```

6. `Do` declare all member variables at the top of a class, with static variables at very top;
```csharp
public class Contact
{
  public static string Name;

  public string Address{set;get;}
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
  <summary><b>Keep function arguments as fewer as possible</b></summary>
The ideal number of arguments for a function is zero. Next comes one, followed closely by two. Three arguments should be avoided where possible.

**Bad:**

```csharp
DataBase.InitializeConnection(string endpointURL, string authorizationKey, string databaseGuid, string collectionName)
{
  // establish database connection
}
```

**Good:**

```csharp
var dbConfig = new DatabaseConfiguration
{
  EndpointURL = "http:://azure.com:443",
  authorizationKey = "sdasdasd24nsodfj1o234sadn",
  DatabaseGuid = "213d-3dfsdf-12asdd-123a",
  CollectionName = "UserDocument"
}

DataBase.InitialieConnection(DatabaseConfiguration dbConfig)
{
  // establish database connection
}
```

**[⬆ Back to top](#table-of-contents)**

</details>


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
  <summary><b>Function should do one thing</b></summary>


**Bad:**


```csharp
public void SendEmailToClients(int[] groupsOfClientIds)
{
  foreach(var clientId in groupsOfClientIds)
  {
      var record = DocumentEngine.FindRecordById(clientId)
      if(record.Status == RecordStatusEnum.Active) SendEmail(record.Email);      
  }
}
```

**Good:**

```csharp
public void SendEmailToClients(int[] groupsOfClientIds)
{
  foreach(var clientId in groupsOfClientIds)
  {
      var record = DatabaseClient.FindRecordById(clientId)
      var emails = GetActiveClientIds(groupsOfClientIds);
      foreach(var email in emails) SendEmail(email);     
  }
}

private string[] GetActiveClientIds(int[] groupsOfClientIds)
{
   return DocumentEngine.FindAllRecords(groupsOfClientIds).Where(s=>s.Status == RecordStatusEnum.Active).Select(x=>x.Email);
} 

```

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


<details>
  <summary><b>Use named argument when method argument list is long</b></summary>


**Bad:**

```csharp
PrintEmailDetails("Kanye West", "Jay-Z", "Dr.Dre")

static void PrintEmailDetails(string sender, string recipient, string cc)
{
  Console.WriteLine($"Sender:{sender}, Recipient: {recipient}, CC: {cc}");
}
```

**Good:**

```csharp
PrintEmailDetails(sender:"Kanye West", recipient:"Jay-Z", cc:"Dr.Dre")

static void PrintEmailDetails(string sender, string recipient, string cc)
{
  Console.WriteLine($"Sender:{sender}, Recipient: {recipient}, CC: {cc}");
}
```
Named arguments free you from the need to remember or to look up the order of parameter in the parameter lists of called methods.

**[⬆ Back to top](#table-of-contents)**

</details>


<details>
  <summary><b>Use default arguments to reduce conditionals in code block </b></summary>
The definition of a method, constructor, indexer, or delegate can specify that its parameters are required or that they are optional. Any call must provide arguments for all required parameters, but can omit arguments for optional parameters.

Each optional parameter has a default value as part of its definition. If no argument is sent for that parameter, the default value is used. 

**Bad:**

```csharp
public class Contact
{
  public string Name{get;set;}
  public string Address{get; set;}
  public string Email{get;set;}
  
  public Contact(string name, string address, string email)
  {
    if(string.IsNullOrWhiteSpace(name)) throw new ArgumentException(message: "Name cannot be null or empty.", paramName: nameof(name));
    else Name = name;

    if(string.IsNullOrWhiteSpace(address)) throw new ArgumentException(message: "Address cannot be null or empty.", paramName: nameof(address));
    else Address = address;

    email = string.IsNullOrEmpty(email)? "Not Available": email; 
  }
}


```

**Good:**

```csharp
public class Contact
{
  public string Name{get;set;}
  public string Address{get; set;}
  public string Email{get;set;}
  
  public Contact(string name, string address, string optionalEmail = "Not Available")
  {
    if(string.IsNullOrWhiteSpace(name)) throw new ArgumentException(message: "Name cannot be null or empty.", paramName: nameof(name));
    else Name = name;

    if(string.IsNullOrWhiteSpace(address)) throw new ArgumentException(message: "Address cannot be null or empty.", paramName: nameof(address));
    else Address = address;

    email = optionalEmail;
  }
}
```

**[⬆ Back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Use Async and Await for IO bound functions</b></summary>

**Summary of Asynchronous Programming Guidelines**

| Name              | Description                                       | Exceptions                      |
| ----------------- | ------------------------------------------------- | ------------------------------- |
| Avoid async void  | Prefer async Task methods over async void methods | Event handlers                  |
| Async all the way | Don't mix blocking and async code                 | Console main method (C# <= 7.0) |
| Configure context | Use `ConfigureAwait(false)` when you can          | Methods that require con­text   |

**The Async Way of Doing Things**

| To Do This ...                           | Instead of This ...        | Use This             |
| ---------------------------------------- | -------------------------- | -------------------- |
| Retrieve the result of a background task | `Task.Wait or Task.Result` | `await`              |
| Wait for any task to complete            | `Task.WaitAny`             | `await Task.WhenAny` |
| Retrieve the results of multiple tasks   | `Task.WaitAll`             | `await Task.WhenAll` |
| Wait a period of time                    | `Thread.Sleep`             | `await Task.Delay`   |

**Best practice** 

The async/await is the best for IO bound tasks (networking communication, database communication, http request, etc.) but it is not good to apply on computational bound tasks (traverse on the huge list, render a hugge image, etc.). Because it will release the holding thread to the thread pool and CPU/cores available will not involve to process those tasks. Therefore, we should avoid using Async/Await for computional bound tasks.

For dealing with computational bound tasks, prefer to use `Task.Factory.CreateNew` with `TaskCreationOptions` is `LongRunning`. It will start a new background thread to process a heavy computational bound task without release it back to the thread pool until the task being completed.

**Know Your Tools**

There's a lot to learn about async and await, and it's natural to get a little disoriented. Here's a quick reference of solutions to common problems.

**Solutions to Common Async Problems**

| Problem                                         | Solution                                                                          |
| ----------------------------------------------- | --------------------------------------------------------------------------------- |
| Create a task to execute code                   | `Task.Run` or `TaskFactory.StartNew` (not the `Task` constructor or `Task.Start`) |
| Create a task wrapper for an operation or event | `TaskFactory.FromAsync` or `TaskCompletionSource<T>`                              |
| Support cancellation                            | `CancellationTokenSource` and `CancellationToken`                                 |
| Report progress                                 | `IProgress<T>` and `Progress<T>`                                                  |
| Handle streams of data                          | TPL Dataflow or Reactive Extensions                                               |
| Synchronize access to a shared resource         | `SemaphoreSlim`                                                                   |
| Asynchronously initialize a resource            | `AsyncLazy<T>`                                                                    |
| Async-ready producer/consumer structures        | TPL Dataflow or `AsyncCollection<T>`                                              |

Read the [Task-based Asynchronous Pattern (TAP) document](http://www.microsoft.com/download/en/details.aspx?id=19957).
It is extremely well-written, and includes guidance on API design and the proper use of async/await (including cancellation and progress reporting).

There are many new await-friendly techniques that should be used instead of the old blocking techniques. If you have any of these Old examples in your new async code, you're Doing It Wrong(TM):

| Old                | New                                  | Description                                                   |
| ------------------ | ------------------------------------ | ------------------------------------------------------------- |
| `task.Wait`        | `await task`                         | Wait/await for a task to complete                             |
| `task.Result`      | `await task`                         | Get the result of a completed task                            |
| `Task.WaitAny`     | `await Task.WhenAny`                 | Wait/await for one of a collection of tasks to complete       |
| `Task.WaitAll`     | `await Task.WhenAll`                 | Wait/await for every one of a collection of tasks to complete |
| `Thread.Sleep`     | `await Task.Delay`                   | Wait/await for a period of time                               |
| `Task` constructor | `Task.Run` or `TaskFactory.StartNew` | Create a code-based task                                      |

> Source https://gist.github.com/jonlabelle/841146854b23b305b50fa5542f84b20c

**[⬆ back to top](#table-of-contents)**

</details>


## Classes

## Unit Testing

## Tools


<details>
  <summary><b>Source control</b></summary>

Source control is an absolute necessity for any software development project. If you are not using one yet, start using one.

 * [GitHub](https://github.com/) - allows for unlimited public repositories, and unlimited private repositories with up to 3 collaborators.
 * [Bitbucket](https://bitbucket.org/) - allows for unlimited private repositories with up to 5 collaborators, for free.
 * [SourceForge](http://sourceforge.net/) - open source hosting only.
 * [GitLab](https://gitlab.com/) - allows for unlimited public and private repositories, unlimited CI Runners included, for free.
 * [Visual Studio Online](https://visualstudio.com) (http://www.visualstudio.com/what-is-visual-studio-online-vs) - allows for unlimited public repositories, must pay for private repository. Repositories can be git or TFVC. Additionally: Issue tracking, project planning (multiple Agile templates, such as SCRUM), integrated hosted builds, integration of all this into Microsoft Visual Studio. Windows only.
 * [Gitee](https://gitee.com) - allows for unlimited private repositiories up to 5G file storage

**[⬆ Back to top](#table-of-contents)**

</details>

<details>
  <summary><b>Continuous integration</b></summary>

Once you have picked your build tool, set up a continuous integration environment.

Continuous Integration (CI) tools automatically build the source code as changes are pushed to the repository. These can be hosted privately or with a CI host.

 * [Travis CI](http://travis-ci.org)
   * works well with C#
   * designed for use with GitHub
   * free for public repositories on GitHub
 * [AppVeyor](http://www.appveyor.com/)
   * supports Windows, MSVC and MinGW
   * free for public repositories on GitHub
 * [Hudson CI](http://hudson-ci.org/) / [Jenkins CI](https://jenkins-ci.org/)
   * Java Application Server is required
   * supports Windows, OS X, and Linux
   * extendable with a lot of plugins
 * [TeamCity](https://www.jetbrains.com/teamcity) 
   * has a free option for open source projects
 * [Decent CI](https://github.com/lefticus/decent_ci)
   * simple ad-hoc continuous integration that posts results to GitHub
   * supports Windows, OS X, and Linux
   * used by [ChaiScript](http://chaiscript.com/ChaiScript-BuildResults/full_dashboard.html)
 * [Visual Studio Online](https://visualstudio.com) (http://www.visualstudio.com/what-is-visual-studio-online-vs)
   * Tightly integrated with the source repositories from Visual Studio Online
   * Uses MSBuild (Visual Studio's build engine), which is available on Windows, OS X and Linux
   * Provides hosted build agents and also allows for user-provided build agents
   * Can be controlled and monitored from within Microsoft Visual Studio
   * On-Premise installation via Microsoft Team Foundation Server
 * [GitLab](https://gitlab.com)
   * has free shared runners
   * has trivial processing of result of coverage analyze

If you have an open source, publicly-hosted project on GitHub:

 * go enable Travis Ci and AppVeyor integration right now. We'll wait for you to come back. For a simple example of how to enable it for your C# application, see here: https://docs.travis-ci.com/user/languages/csharp/
 * enable one of the coverage tools listed below (Codecov or Coveralls)
 * enable [Coverity Scan](https://scan.coverity.com)
  
These tools are all free and relatively easy to set up. Once they are set up you are getting continuous building, testing, analysis and reporting of your project. For free.

**[⬆ Back to top](#table-of-contents)**

</details>