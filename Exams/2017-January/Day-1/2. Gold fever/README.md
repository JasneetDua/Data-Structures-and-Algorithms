# Gold fever

## Description

[Dim4ou](https://www.youtube.com/watch?v=r7jR_xf-kGw) is a famous BG rapper who was one day accidentally hit by a thunderbolt. From that day on Dim4ou started seeing everything in numbers, but not in black and green as Neo from the Matrix and instead in black and yellow (as [Wiz Khalifa](https://www.youtube.com/watch?v=UePtoxDhJSw)). What Dim4ou encountered is that these numbers are actually the price of gold ([$$$](https://www.youtube.com/watch?v=5cn_fdCkZlc)).

As he knows the price of gold ounce for the next **N** days you need to help him maximize the potential profit. What you can do on each day is to either buy one ounce, sell any number of ounces that you already own, or not make any transaction at all. Your end goal is to calculate the maximum profit you and Dim4ou can obtain with an optimal trading strategy.

## Input

- Input is read from the console
  - On the first line in the console is a number **N** denoting the **N** days for which you will know the price per ounce.
  - The second line contains **N** integers separated by white space, denoting the predicted price per gold ounce for the next **N** days.

## Output

- Output should be printed on the console
  - A single line denoting the maximum profit which can be obtained.

## Constraints

- 1 <= N <= 50000
- 1 <= price per ounce <= 100000
- **Time limit**: **0.1s**
- **Memory limit**: **16 MB**

## Sample tests

### Sample test 1

#### Input
```
4
1 2 1 2
```

#### Output
```
2
```

### Sample test 2

#### Input
```
3
10 7 5
```

#### Output
```
0
```

### Sample test 3

#### Input
```
3
1 3 200
```

#### Output
```
396
```
