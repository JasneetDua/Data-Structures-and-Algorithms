# Lazy Recursion

Let's work with the `System.Lazy<T>` type. Also, `for` and `while` loops will be unnecessary, let's use recursion.

Some data types may be of help:
- `Pair<T1, T2>` - each of the two values can be lazy evaluated
- `Optional<T>` - like a nullable type, but with some helper methods
- `List<T>` - a singly linked list, we are going to keep only its head and iterate the whole list recursively
- `SideEffect<T>` - we are going to use this to call arbitrary `C#` code (e.g. `Console.ReadLine()`, `Console.WriteLine()`)

_Optional:_ Implement more data types (e.g. trees)

## Methods to implement

Does not matter if those are member methods, static methods or extension methods.
_Note:_ Use lazy types!
_Note:_ Examples are in loose syntax for simplicity

- `Length(list)` - should find the length of a list
  - _Examples:_
    - `Length [1,2,3,4] = 4`
	- `Length [] = 0`
- `Head(list)`, `Tail(list)`, `Last(list)`, `Init(list)`
  - `Head(list)` - returns the first element of a list
  - `Tail(list)` - returns a list with the first element removed
  - `Last(list)` - returns the last element of a list
  - `Init(list)` - returns a list with the last element removed
  - You can throw exceptions or return an `Optional` value if called on an empty list
  - Here is a helpful picture: [https://s3.amazonaws.com/lyah/listmonster.png]()
  - _Examples:_
    - `Head [3,7,1] = 3`
	- `Tail [3,7,1] = [7,1]`
	- `Last [4,5,6] = 6`
	- `Init [4,5,6] = [4,5]`
- `AtIndex(list, index)` - returns the element at the given index in the list
  - _Example:_m
    - `AtIndexm [1,2,5,3,5,6] 4 = 5`
  - You can throw exceptions if or return an `Optional` value if `index` is invalid
  - _Think about running time complexity_
- `Take(count, list)` - takes the first `count` elements of the list or all of them if there are less than `count`
  - _Examples:_
    - `Take 3 [1,2,6,4,9,8] = [1,2,6]`
	- `Take 10 [8,8] = [8,8]`
- `Drop(count, list)` - drops (skips) the first `count` elements of the list or all of them if there are less than `count`
  - _Examples:_
    - `Drop 3 [1,2,6,4,9,8] = [4,9,8]`
	- `Drop 10 [8,8] = []`
- `TakeWhile(f, list)` - takes elements of the list while `f` is `true`
  - _Examples:_
    - `TakeWhile (x => x<3) [1,2,6,4,9,8] = [1,2]`
	- `TakeWhile (x => true) [8,8] = [8,8]`
- `DropWhile(f, list)` - drops (skips) elements of the list while `f` is `true`
  - _Examples:_
    - `DropWhile (x => x<3) [1,2,6,4,9,8] = [6,4,9,8]`
	- `DropWhile (x => true) [8,8] = []`
- `Map(f, list)` - applies the function `f` to each value in the list
  - _Examples:_
    - `Map (x => x*2) [1,2,3,4] = [2,4,6,8]`
- `Filter(f, list)` - `f` is a function that returns a boolean, keep the elements for which `f` is `true`
  - _Examples:_
    - `Filter (x => x > 3) [1,2,7,3,4] = [7,4]`
- `Zip(list1, list2)` - zips the two lists into a list of pairs
  - _Example:_
    - `Zip [1,2,3] [4,5,6] = [(1,4), (2,5), (3,6)]`
- `ZipWith(f, list1, list2)` - zips the two lists into a list using the function `f`
  - _Example:_
    - `ZipWith ((x,y) => x+y) [1,2,3] [4,5,6] = [5, 7, 9]`
- `Concat(list1, list2)` - returns the concatenation of the two lists
  - _Example:_
    - `Concat [1,2,3] [4,5,6] = [1,2,3,4,5,6]`
  - _Think about running time complexity_
- `Reverse(list)` - returns the reverse of `list`
  - `Reverse [1,3,4,9] = [9,4,3,1]`
  - _Think about running time complexity_
- `FoldLeft(f, initial, list), FoldRight(f, initial, list)` - also called Reduce or Aggregate
  - _Examples:_
    - `FoldLeft ((x,y) => x+y) 0 [1,2,3] = 6` (((0+1)+2)+3)
    - `FoldRight ((x,y) => x+y) 0 [1,2,3] = 6` (0+(1+(2+3)))
  - You can implement more functions using folds (e.g. `Sum`, `Product`, `All`, `Any`)
- `ScanLeft(f, initial, list), ScanRight(f, initial, list)` - like folds but they keep they keep all middle values
  - _Examples:_
    - `ScanLeft ((x,y) => x+y) 0 [1,2,3,4] = [0,1,3,6,10]`
    - `ScanRight ((x,y) => x+y) 0 [1,2,3,4] = [10,9,7,4,0]`
- `Flatten(list of lists)` - concatenates all lists
  - _Example:_
    - `Flatten [[1,2,3],[4,5],[],[6,8],[7]] = [1,2,3,4,5,6,8,7]`
  - _Think about running time complexity_

- `QuickSort(list)` - sorts the list using the quick sort algorithm
- `MergeSort(list)` - sorts the list using the merge sort algorithm
  - `Sort [5,4,7,6,1,2,8,3] = [1,2,3,4,5,6,7,8]`
- `QuickSortBy(f, list)` - sorts the list using the quick sort algorithm, use `f` as compare function
- `MergeSortBy(f, list)` - sorts the list using the merge sort algorithm, use `f` as compare function
  - `SortBy ((x,y) => x>y) [5,4,7,6,1,2,8,3] = [8,7,6,5,4,3,2,1]`

_Optional:_ Implement more methods.
