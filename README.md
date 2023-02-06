# Xplor Coding Challenge (.NET)

**Ismael J Lopez - ismaelopezandrade@gmail.com**

## Overview
Refer to https://github.com/ilopez5/XplorCodingChallengeJava for the primary
coding challenge solution. This project attempts to solve it in .NET 6. Some
discrepancies include me realizing that setting the card CVC number to a new
value requires validation. Thus, in the property's setter, I added a call to
the validate method. Additionally, unlike Java, C# `sealed` classes (like
`final` in Java) do
[lead to performance improvements](https://github.com/dotnet/runtime/issues/49944).
Thus, I tend to seal classes by default unless otherwise necessary. I do realize
that classes such as `Person` are basically begging to be inherited from, but
since my current design does not require this, best keep it sealed until that
changes (despite having to recompile that class). Not to mention, unsealing
classes will not break things while the opposite may certainly do so if they
are externally visible.

## How to Run
Clone the repository, open in Visual Studio, and MSBuild should take care of
the rest. Only dependency is NUnit3, which can be imported if necessary by
the NuGet Package manager, but from my experience, just **Build** the solution
and it will get included.