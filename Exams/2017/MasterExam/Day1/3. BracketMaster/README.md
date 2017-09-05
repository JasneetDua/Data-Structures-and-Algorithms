<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png"/>

#### _Telerik Academy Season 2016-2017 Autumn / Data Structures and Algorithms Exam - 4 September 2017_
# Bracket master

## Description

Steve likes several kinds of brackets and parenthesis - `()`, `[]`, `{}`, `<>` - **8 symbols** in total.

He wants to use his knowledge to become the next bracket master.
In order to do that, he should be able to count all possible valid bracket expressions consisted of **N** symbols.

In valid expressions each opening bracket (`([{<`) should be closed with a matching bracket (`)]}>`).

*Examples:*
  - `()[]` - **valid**
  - `<{}>` - **valid**
  - `<(>)` - ~~**invalid**~~

Write a program which can be used to check his abilities.

## Input
- Input is read from the console
  - A number **N** is read from the first line

## Output
- Output should be printed on the console
  - Print the answer on a single line

## Constraints
- 0 <= **N** <= 1024
- **See BGcoder for time and memory limits**

## Sample tests

### Sample test 1

#### Input
```
2
```

#### Output
```
4
```

### Sample test 2

#### Input
```
4
```

#### Output
```
32
```

### Sample test 3

#### Input
```
3
```

#### Output
```
0
```
