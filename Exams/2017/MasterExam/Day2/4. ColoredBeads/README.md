<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png"/>

#### _Telerik Academy Season 2016-2017 Autumn / Data Structures and Algorithms Exam - 5 September 2017_
# Colored beads

## Description

Steve is a color maniac. He has **R** amount of red beads, **G** amount of green beads and **B** amount of blue beads in his possession.
He noticed that he can arrange all of them in sequence without having consecutive beads of the same color in several ways.

Write program which reads **R**, **G**, **B**, and an **index** and finds the **index**th possible sequence if they were sorted lexicographically.

_Note_: **index** is zero based.

## Input
- Input is read from the console
  - Three numbers are read from the first line
    - **R**, **G** and **B** separated by spaces
  - **index** is read from the second line

## Output
- Output should be printed on the console
  - Print the correct sequence of beads on a single line

## Constraints
- 0 <= **R**, **G**, **B** <= 128
- 0 <= **index** < possible combinations
- **See BGcoder for time and memory limits**

## Sample tests

### Sample test 1

#### Input
```
1 1 1
3
```

#### Output
```
GRB
```

#### Description
```
All combinations in order:
0 -> BGR
1 -> BRG
2 -> GBR
3 -> GRB
4 -> RBG
5 -> RGB
```

### Sample test 2

#### Input
```
2 2 2
17
```

#### Output
```
GRBRBG
```

### Sample test 3

#### Input
```
3 4 5
42
```

#### Output
```
BGBGRBRBGRGB
```
