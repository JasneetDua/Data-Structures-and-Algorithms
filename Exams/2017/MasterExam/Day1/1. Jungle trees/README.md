<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png"/>

#### _Telerik Academy Season 2016-2017 Autumn / Data Structures and Algorithms Exam - 4 September 2017_
# Jungle trees

## Description

Steve is tired of people. He is going to live in the jungle.

His preferred way of moving is by jumping from one tree to another.
There will be **N** trees in the jungle. Each tree will have `X` coordinate and height `H`.
Steve will not be able to jump between trees whose `X` coordinate difference is more than **MJ** or height difference is more than **MH**.
He will need your help to get **from the leftmost tree** (lowest `X` coordinate) **to rightmost one** (highest `X` coordinate).
Write a program which finds the minimal amount of jumps needed or prints `-1` if it is impossible.

## Input
- Input is read from the console
  - Three numbers are read from the first line
    - **N**, **MJ** and **MH** separated by spaces
  - Each of the next **N** lines describes a tree by two space separated numbers
    - `X` - coordinate of the tree
	- `H` - height of the tree

## Output
- Output should be printed on the console
  - Print the minimal amount of jumps needed on a single line
    - If it is impossible to reach the rightmost tree print `-1`

## Constraints
- 2 <= **N** <= 8 000
- 1 <= **MJ** <= 1 000 000
- 1 <= **MH** <= 1 000 000
- For each tree:
  - -1 000 000 <= `X` <= 1 000 000
  - 1 <= `H` <= 1 000 000
- **See BGcoder for time and memory limits**

## Sample tests

### Sample test 1

#### Input
```
5 10 3
13 1
9 4
4 7
18 5
20 8
```

#### Output
```
3
```

### Sample test 2

#### Input
```
2 8 5
-4 9
7 9
```

#### Output
```
-1
```
