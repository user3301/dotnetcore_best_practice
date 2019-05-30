![.Net Core Best Practice](/assets/logo_final.png?raw=true)

In this repository, you can find some coding and naming conventions in C# (.Net Core 1.x + specifically).

# Table of Contents
- [Table of Contents](#table-of-contents)
- [Introduction](#introduction)
- [Coding and Naming Conventions](#coding-and-naming-conventions)
  - [Naming](#naming)

# Introduction

![namingmeme](/assets/namingmeme.jpg)

Standardization has a positive impact on any business as well as in the Software industry. There are certain coding standards that are needed for a successful implementation of a program. Good quality software and code is not as easy as it seems to be. Often it  requires consistent efforts and sheer focus of the software development team to meet the quality goals. This repository is a C# programming language coding guid to producing readable, reusable and scalable code.

Inspired by [clean-code-javascript](https://github.com/ryanmcdermott/clean-code-javascript),  [clean-code-php](https://github.com/jupeter/clean-code-php) and [clean-code-dotnet](https://github.com/thangchung/clean-code-dotnet) lists.

# Coding and Naming Conventions

## Naming

<details>
  <summary><b>Give your variable a meaningful name</b></summary>
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