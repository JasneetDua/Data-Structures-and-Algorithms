# The Rings of the Academy

## Description
Ah, the Rings.. they are round. They are numbered and attached to each other (see the image below).

![rings1](imgs/rings1.png)

There will be **N** rings numbered **from 1 to N**. Exactly one of the rings is on the top, all others are hanging from it.
Find the number of possible configurations of the rings so that the obey the hanging rules (see input).

_Example:_ If rings 2 and 3 are hanging from ring 1 there are 2 ways to order them (`2 left of 3` and `3 left of 2`).

## Input
- Input is read from the console
  - A number **N** is given on the first line
  - On each of the next **N** lines a number is given describing the hanging rules
    - which ring is ring 1 hanging from
    - which ring is ring 2 hanging from
	- ...
	- `0` means that the ring is on the top

## Output
- Output should be printed on the console
  - Print the number of ring configurations on a single line

## Constraints
- 1 <= **N** <= 21
- **Time limit**: **0.1s**
- **Memory limit**: **16 MB**

## Sample tests

### Sample test 1

#### Input
```
6
0
1
2
3
4
4
```

#### Output
```
2
```

### Description
```
Ring 5 and 6 can be swapped.
See image above.
```

### Sample test 2

#### Input
```
6
0
1
1
1
3
3
```

#### Output
```
12
```

### Sample test 3

#### Input
```
8
0
1
2
3
4
5
6
7
```

#### Output
```
1
```
