<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png"/>

#### _Telerik Academy Season 2016-2017 Autumn / Data Structures and Algorithms Exam - 5 September 2017_
# Cheaters

## Description

You are given a set of dependencies. Each dependency has two people and a subject. That means the first person depends on the second in the subject.

You are also given a set of commands. Each command asks for a list of dependencies for a person for a subject.

Write a task, that by given the dependencies, prints the list of dependencies for each command.

## Input

Read from the standard input

- On the first line will be `N` - the number of dependencies
- On the next `N` lines, there will be the dependencies
  - Each dependency consists of three parts - `X Y Z`
    - The means "Person `X` depends on Person `Y` on subject `Z`
    - `X` and `Y` can contain any characters, except whitespace
    - `Z` can contain any characters
- On line `N`+ 2 there will `M` - the number of commands
- On the next `M` lines, there will be a commands
  - Each command consists of two parts - `X Z`
    - That means "Tell me the dependencies of person `X` on subject `Z`"
    - `X` can contain any characters, except whitespace
    - `Z` can contain any characters
    - All `X` and `Z` will be valid dependencies

## Output

Print to the standard output

- For each command, print the list of dependencies.
  - If more than 1 dependency is with the same priority, print them in alphabetical order
  - The name of the dependency should be printed at the rightmost

## Constraints

- The number of commands will be less than 2<super>20</super>
- The number of commands will be less than 2<super>10</super>
- All equals operations are case sensitive
  - i.e. `Dynamic Programming` is different that `dynamic programming`

## Sample tests

### input


```
7
Coki Doncho Math
Doncho Coki Graphs
Doncho Yana Math
Stamat Coki Graphs
Doncho Stamat Math
Doncho Coki Dynamic Programming
Stamat Yana Math
6
Coki Math
Doncho Math
Stamat Math
Stamat Graphs
Doncho Dynamic Programming
Coki Dynamic Programming
```

### Output

```
Yana, Stamat, Doncho, Coki
Yana, Stamat, Doncho
Yana, Stamat
Coki, Stamat
Coki, Doncho
Coki
```














</pre>
  </tr>  
</table>
