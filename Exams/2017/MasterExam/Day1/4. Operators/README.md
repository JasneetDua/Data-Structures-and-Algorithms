<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png"/>

#### _Telerik Academy Season 2016-2017 Autumn / Data Structures and Algorithms Exam - 4 September 2017_
# Operators


## Description

Coki loves numbers. Yet, he cannot use them. Alas, he is that smart...

Now he has a simple task with digits and operators. He is given a sequence of digits and a number. The operators '+', '-' and '\*' can be inserted at any position (except the leftmost and rightmost).

His task is to find all possible combinations with this digits and operators, that result in the provided number.

## Input

The input will be on the standart input

- On the first line of the input you will find the sequence of digits
- On the second line of the input, you will find the number

The input will be valid and there is no need to check it explicitly


## Output

- Print the output on the standart output

- On the first line print the number `K`
    -   The count of possible valid expressions
- On the next `K` lines print the valid expressions
    -   The order does not matter

## Constraints
- **See BGcoder for time and memory limits**
- The digits will always be at most 14

## Sample tests


### Input


```
123
6
```

### Output

```
2
1+2+3
1*2*3
```

### Input

```
105
5
```
### Output

```
2
1*0+5
10-5
```

### Input

```
000
0
```

### Output

```
9
0+0+0
0+0-0
0+0*0
0-0+0
0-0-0
0-0*0
0*0+0
0*0-0
0*0*0
```


### Input

```
1111
1
```

### Output
   
```
7
1+1-1*1
1+1*1-1
1-1+1*1
1-1*1+1
1*1+1-1
1*1-1+1
1*1*1*1

```
