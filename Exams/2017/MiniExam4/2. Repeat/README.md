# Repeat

You are given a sequence of **N** numbers. The sequence could be consisted of a smaller subsequence repeated several times.
Your task is to find the shortest subsequence that when repeated enough times is the same as the **N** numbers.

## Input
- Input is read from the console
  - The first line is consisted of **N** numbers
    - separated by spaces

## Output
- Output should be printed to the console
  - The subsequence of numbers on a single line
    - separate the numbers by spaces

## Constraints
- 1 <= **N** <= 1 000 000
- **Time limit**: **0.8s**
- **Memory limit**: **128 MB**

## Sample tests

### Sample test 1

#### Input
```
1 2 3 3 4 1 2 3 3 4 1 2 3 3 4
```

#### Output
```
1 2 3 3 4
```

### Sample test 2

#### Input
```
4 2 1 2 7 1 5 11 4 2 1 2 7 1 5 11 4 2 1
```

#### Output
```
4 2 1 2 7 1 5 11 4 2 1 2 7 1 5 11 4 2 1
```

### Sample test 3

#### Input
```
3 2 5 9 3 2 5 3 2 5 9 3 2 5
```

#### Output
```
3 2 5 9 3 2 5
```

### Sample test 4

#### Input
```
1 2 1 2 1 2 1 2 1 2 1 2 1 2 1 2 1 2 1 2 3 3
```

#### Output
```
1 2 1 2 1 2 1 2 1 2 1 2 1 2 1 2 1 2 1 2 3 3
```
