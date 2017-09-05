<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png"/>

#### _Telerik Academy Season 2016-2017 Autumn / Data Structures and Algorithms Exam - 5 September 2017_
# Deduplication

## Description

In computer filesystems each file is represented as a list of blocks. When a new file is created, blocks must be allocated for its content.
There are several file systems that make use of the so called CoW technique (this is no cattle power, it's copy on write).
When you copy a block (e.g. when copying a file) you can just mark it so that it is known that the block is referenced from more than one place (this is called reference counting).
When you want to change the contents of a block only then you allocate a new one, so you do not disturb other references.

Implement several commands for a CoW powered filesystem:

- `append file BLOCKS`
  - appends the specified content to the file
    - create the file if it does not exist
	- blocks should be allocated
- `copy file1 file2`
  - makes a copy of `file1` named `file2`
    - new blocks should be allocated for `file2`
  - if `file1` does not exist create an empty file in its place
  - if `file2` already exist delete it first
- `cow file1 file2`
  - makes a CoW copy of `file1` named `file2`
    - the blocks of `file1` should be shared with `file2`
  - if `file1` does not exist create an empty file in its place
  - if `file2` already exist delete it first
- `remove file`
  - deletes `file`
  - unreferenced blocks should be deallocated
- `dedup`
  - scans the filesystem for repeating blocks and makes them CoW copies
- `usage`
  - shows the number of currently allocated blocks in the filesystem
    - e.g. `42 blocks are currently in use.`
- `size file`
  - shows the apparent size of the file
    - not allocated blocks count for the file
  - if the file does not exist, then its size is `0` blocks
  - e.g. `gosho.txt is 5 blocks large.`
- `exit`
  - do nothing
  - no more commands will follow `exit`

## Input
- Input is read from the console
  - One command will be given on each line

## Output
- Output should be printed on the console
 - Print all results of `usage` and `size` commands

## Constraints
- There will be at most `10000` commands
- Filenames will be consisted only of english letters, numbers, dashes (`-`), underscores (`_`) and dots (`.`)
- Filenames will be at most `32` symbols in length
- Each block is exactly `128` bytes large (`256` hex digits)
  - Each byte will be represented as two hex digits (`0123456789ABCDEF`)
- **See BGcoder for time and memory limits**

## Sample tests

### Sample test 1

#### Input
```
append gosho.txt 000102030405060708090A0B0C0D0E0F101112131415161718191A1B1C1D1E1F202122232425262728292A2B2C2D2E2F303132333435363738393A3B3C3D3E3F404142434445464748494A4B4C4D4E4F505152535455565758595A5B5C5D5E5F606162636465666768696A6B6C6D6E6F707172737475767778797A7B7C7D7E7F808182838485868788898A8B8C8D8E8F909192939495969798999A9B9C9D9E9FA0A1A2A3A4A5A6A7A8A9AAABACADAEAFB0B1B2B3B4B5B6B7B8B9BABBBCBDBEBFC0C1C2C3C4C5C6C7C8C9CACBCCCDCECFD0D1D2D3D4D5D6D7D8D9DADBDCDDDEDFE0E1E2E3E4E5E6E7E8E9EAEBECEDEEEFF0F1F2F3F4F5F6F7F8F9FAFBFCFDFEFF
usage
size gosho.txt
size pesho.txt
copy gosho.txt pesho.txt
usage
size gosho.txt
size pesho.txt
append pesho.txt 4242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242424242
usage
size gosho.txt
size pesho.txt
dedup
usage
size gosho.txt
size pesho.txt
cow pesho.txt tosho.txt
usage
size gosho.txt
size pesho.txt
size tosho.txt
remove pesho.txt
usage
size gosho.txt
size pesho.txt
size tosho.txt
exit
```

#### Output
```
2 blocks are currently in use.
gosho.txt is 2 blocks large.
pesho.txt is 0 blocks large.
4 blocks are currently in use.
gosho.txt is 2 blocks large.
pesho.txt is 2 blocks large.
5 blocks are currently in use.
gosho.txt is 2 blocks large.
pesho.txt is 3 blocks large.
3 blocks are currently in use.
gosho.txt is 2 blocks large.
pesho.txt is 3 blocks large.
3 blocks are currently in use.
gosho.txt is 2 blocks large.
pesho.txt is 3 blocks large.
tosho.txt is 3 blocks large.
3 blocks are currently in use.
gosho.txt is 2 blocks large.
pesho.txt is 0 blocks large.
tosho.txt is 3 blocks large.
```

#### Description
```
The first append command allocates 2 blocks for gosho.txt (usage is 2)
The copy command allocates 2 more for pesho.txt (usage is 4)
The second append command allocates on more block for pesho.txt (usage is 5)
dedup merges the shared blocks of gosho.txt and pesho.txt (usage is 3)
cow makes tosho.txt which shares all blocks of pesho.txt (usage is 3)
remove erases pesho.txt, but pesho.txt uses the same blocks (usage is 3)
```
