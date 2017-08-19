# Sticks

Today Steve got angry and threw `3` sticks on the ground. Why? Ask him :)

What is interesting is that the sticks could form a triangle and if they did we would want to find its area.

Each stick is defined by `4` numbers:
- `x` and `y` coordinates of one end ot the stick
- `x` and `y` coordinates of the other end

## Input
- Input is read from the console
  - Three lines, each describing a stick by `4` space separated numbers

## Output
- Output should be printed on the console
  - Print the answer on a single line
    - use **three** decimal digits of precision
	- if there is no triangle print `No triangle.`

## Constraints
- Coordinates will ba integers in the range `[-1000; 1000]`
- **Time limit**: **0.1s**
- **Memory limit**: **16 MB**

## Sample tests

### Sample test 1

#### Input
```
-1 0 8 0
0 -1 0 6
8 0 0 6
```

#### Output
```
24.000
```

### Sample test 2

#### Input
```
-3 -1 5 2
1 -1 3 -3
5 -2 4 5
```

#### Output
```
No triangle.
```

### Sample test 3

#### Input
```
-3 -1 5 -3
5 -4 -1 5
2 1 0 0
```

#### Output
```
10.004
```
