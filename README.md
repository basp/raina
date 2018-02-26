# raina
## description
Code metrics for .NET assemblies.

> Feminine form of Ray (Old German) "wise guardian".

> Strong and solid, with a touch of foreign intrigue.

>  The rain jokes are never ending and all at once no one will spell it right.

## setup
Currently, **Raina** is all about extension methods. There's basically three things you need to do:

1. Reference `Mono.Cecil` (available as a **nuget** package).
2. Reference the `Raina.dll` assembly (parked somewhere on your drive).
3. Include the appropriate namespace (`Raina` in this case and `Mono.Cecil`).

## basic usage
Find an interesting assembly that you want to scan. Let's say it's at `/foo/bar.dll` and we wanna find out some metrics.

First, start gentle, to be honest, **Raina** is not all that well prepared for all weird IL constructions so she sometimes might fail. However, getting lines of code **should** work well enough so let's try that first. And let's be daring and do **rank** as well.

We currently need `Mono.Cecil` to read our aassemblies since most of our metrics depend on it. Also, **assemblies** are pretty valuable resources so remember they are `IDisposable` so get rid of them aas soon as you can.
```
const string path = @"/foo/bar.dll";
using(var asm = AssemblyDefinition.ReadAssembly(@path))
{
    asm
        .SelectMany(x => x.Types)
        .SelectManay(x => x.Methods)
        .Select(x => new {
                DeclaringType = x.DeclaringType.Name,
                x.Name,
                Rank = x.Rank(),
                NbLinesOfCode = x.NbLineOfCod(),
        })
        .Dump();
}
```

This will select all types in the assembly, select all methods from those types and concatenate that into a long list of methods. It will then calculate the **rank** and **number of lines of code** for each method, store that into a sequence of anonymous objects and finally dump that enumerable into the **LINQPad** output.

Note that debug information (i.e. there has to be a 'pdb' file associated with your assembly in order for this to work).

## examples
* [Raina reporting about herself from LINQPad](https://imgur.com/yhzzqV5)
* [Raina reporting on Lina](https://i.imgur.com/2bmoP9P.png)
