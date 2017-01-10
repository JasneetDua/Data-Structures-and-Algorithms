# Swapping

## Description

Don't you like to swap? You are starting with a sequence of numbers **from 1 to N**.
A swap around number **X** transforms the sequence:

```
<left numbers> X <right numbers>
```

to:

```
<right numbers> X <left numbers>
```

Your task is to perform several swap arounds.

## Input
- Input is read from the console
  - A number **N** is read from the first input line
  - A sequence of numbers - swap around each of them from left to right

## Output
- Output should be printed on the console
  - Print the sequence after all the swapping
    - Separate numbers by spaces

## Constraints
- **N** <= 100 000
- **number of swaps** <= 100 000
- **Time limit**: **0.2s**
- **Memory limit**: **48 MB**

## Sample tests

### Sample test 1

#### Input
```
6
3
```

#### Output
```
4 5 6 3 1 2
```

### Description
```
1 2 (3) 4 5 6 -> 4 5 6 (3) 1 2
```

### Sample test 2

#### Input
```
8
5 4 7
```

#### Output
```
8 5 1 2 3 7 4 6
```

### Description
```
1 2 3 4 (5) 6 7 8 -> 6 7 8 (5) 1 2 3 4
6 7 8 5 1 2 3 (4) -> (4) 6 7 8 5 1 2 3
4 6 (7) 8 5 1 2 3 -> 8 5 1 2 3 (7) 4 6
```

### Sample test 3

#### Input
```
12
11 5 10 6 9 10
```

#### Output
```
9 7 8 10 6 5 12 11 1 2 3 4
```

### Description
```
1 2 3 4 5 6 7 8 9 10 (11) 12 -> 12 (11) 1 2 3 4 5 6 7 8 9 10
12 11 1 2 3 4 (5) 6 7 8 9 10 -> 6 7 8 9 10 (5) 12 11 1 2 3 4
6 7 8 9 (10) 5 12 11 1 2 3 4 -> 5 12 11 1 2 3 4 (10) 6 7 8 9
5 12 11 1 2 3 4 10 (6) 7 8 9 -> 7 8 9 (6) 5 12 11 1 2 3 4 10
7 8 (9) 6 5 12 11 1 2 3 4 10 -> 6 5 12 11 1 2 3 4 10 (9) 7 8
6 5 12 11 1 2 3 4 (10) 9 7 8 -> 9 7 8 (10) 6 5 12 11 1 2 3 4
```
