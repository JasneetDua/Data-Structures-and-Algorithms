# Bridges

Steve is an experienced bus driver.
Today he has to pass through **N** destinations (named from **1** to **N**).
There will be **M** bridges connecting them.
It will be possible to go from one destination to every other using the bridges.

The problem with buses and bridges is that they can weigh more than a bridge can sustain.
So Steve can not use every bridge.
**Find the minimum number of bridges** that need to be upgraded in order for Steve to be happy and to be able to go everywhere with his bus.

## Input
- Input is read from the console
  - The first line contains the numbers **N** and **M**
    - separated by a space
  - Each of the next lines contains three numbers separated by spaces
    - name of the first end of the bridge
	- name of the second end of the bridge
	- maximum sustainable weight by the bridge
  - The last line contains a number
    - the weight of Steve's bus

## Output
- Output should be printed on the console
  - Print the answer on a single line

## Constraints
- 1 < **N** <= 1000
- 1 < **M** <= 100000
- Weights will be integer numbers
- 1 <= **each weight** <= 200
- **Time limit**: **0.1s**
- **Memory limit**: **32 MB**

## Sample tests

#### Input
```
6 9
1 6 1
1 2 2
1 4 3
2 3 3
2 5 2
3 4 4
3 6 2
4 5 5
5 6 4
4
```

#### Output
```
2
```
