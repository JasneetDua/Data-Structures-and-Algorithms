# Beach

Today Steve is minding his own business at the beach. His coordinates are `(sx; sy)`.
All of a sudden he saw his friend, Ellen, swimming at coordinates `(ex; ey)`.
The `y = 0` line separates the sand and the water.
All points with `y > 0` are on the sand and all points with `y < 0` are in the water.

Of course, Steve wants to go talk with Ellen about kitties. It is very important he gets to her as quickly as possible.
He can run with speed `v1` on the sand and swim with speed `v2` in the water.
Find the minimal amount of time Steve will need to get to Ellen.

Hints for calculating time:
  - Let's say we have to move from point `(0, 0)` to `(0, 6)`
  - The distance between them is `6` units
  - If we are moving with speed `2` it would take us `6 / 2 = 3` units of time

## Input
- Input is read from the console
  - Three numbers are read from the first line
    - `sx`, `sy`, `v1` separated by spaces
  - Three numbers are read from the second line
    - `ex`, `ey`, `v2` separated by spaces

## Output
- Output should be printed on the console
  - Print the answer on a single line
    - use **two** decimal digits of precision

## Constraints
- Coordinates will be in the range `[-1000; 1000]`
- Speeds will be in the range `[1; 100]`
- `sy > 0`
- `ey < 0`
- **Time limit**: **0.1s**
- **Memory limit**: **16 MB**

## Sample tests

### Sample test 1

#### Input
```
3 3 4
2 -4 1
```

#### Output
```
4.78
```

### Sample test 2

#### Input
```
-10 2 6
3 -5 6
```

#### Output
```
2.46
```
