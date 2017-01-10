# Documentation

## Description

Coki is a developer who loves doing pranks. The newest one he wants to try is to transform the documentations which his colleagues write into [palindromes](https://en.wikipedia.org/wiki/Palindrome) (from Wikipedia: A palindrome is a word, phrase, number, or other sequence of characters which reads the same backward or forward, such as madam or kayak.).

To do this he follows three rules:
1. He can increase/reduce the value of a letter, e.g. he can change **d** to **e** or change **e** to **d** (the border cases **a** to **z** and **z** to **a** are also allowed).
1. Capital letters are treated like non-capital letters, e.g. he can change **A** to **b** or change **b** to **A**.
1. Special characters such as **" "** (white space), **","**, **"."**, **"!"**, **"?"** are disregarded.

Each increase/reduction in the value of a letter is counted as a single operation. Your task is to help Coki find the minimum number of operations required to convert a given documentation text into a palindrome.

## Input

- Input is read from the console
  - On the single line in the console is the string to be converted.

## Output

- Output should be printed on the console
  - A single line denoting the number of minimum operations required to convert the string into a palindrome.

## Constraints

- 1 <= length of string <= 1500000
- All characters are upper/lower case English letters and the following special characters - **" "** (white space), **","**, **"."**, **"!"**, **"?"**.
- **Time limit**: **0.07s**
- **Memory limit**: **32 MB**

## Sample tests

### Sample test 1

#### Input
```
abc
```

#### Output
```
2
```

### Sample test 2

#### Input
```
AZ!x
```

#### Output
```
3
```

### Sample test 3

#### Input
```
No x in Nixon
```

#### Output
```
0
```
