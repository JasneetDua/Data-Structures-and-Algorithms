<!-- section start -->
<!-- attr: { class:'slide-title', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Searching Algorithms
<div class="signature">
    <p class="signature-course">Data Structures and Algorithms</p>
    <p class="signature-initiative">Telerik Software Academy</p>
    <a href = "http://academy.telerik.com " class="signature-link">http://academy.telerik.com </a>
</div>


<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Table of Contents
* Searching
  * Linear search
  * Binary search
  * Interpolation search
* Shuffling


<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Searching


<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Search Algorithm
* An algorithm for finding an item with specified properties among a collection of items
* Different types of searching algorithms
  * For virtual search spaces
    * satisfy specific mathematical equations
    * try to exploit partial knowledge about structure
  * For sub-structures of a given structure
    * graph, a string, a finite group
  * Search for the max (min) of a function
  * etc.

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Linear Search

* Method for finding a particular value in a list
  * Checking every one of the elements
  * One at a time in sequence
  * Until the desired one is found
* Worst and average performance: `O(n)`

```cs
 for each item in the list:
     if that item has the desired value,
         stop the search and return the location.
 return nothing.
```

<!-- section start -->

<!-- attr: {class: 'slide-section'} -->
# Binary search
##  Searching in an ordered collection

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Binary Search

* Finds the position of a specified value within an **ordered** data structure
* In each step, compare the input with the middle
  * The algorithm repeats its action to the left or right sub-structure
* Average performance: `O(log(n))`

<!-- attr: { showInPresentation:true, style:'' } -->
# Recursive Binary Search

* _Example:_ Recursive binary search

```cs
function binarySearch(int items[], int key, int from, int to)
  if (to < from):
    // set is empty, so return value showing not found
    return KEY_NOT_FOUND;
  // calculate midpoint to cut set in half
  int middle = midpoint(from, to);
  if (a[middle] > key):
    // key is in lower subset
    return binarySearch(a, key, from, middle - 1);
  else if (a[middle] < key):
    // key is in upper subset
    return binarySearch(a, key, middle + 1, to);
  else:
    // key has been found
    return middle;
```

<!-- attr: { showInPresentation:true, style:'' } -->
# Iterative Binary Search

* _Example:_ Iterative binary search
```cs
int binarySearch(int a[], int key, int from, int to)
  // continue searching while [imin,imax] is not empty
  while (from <= to):
    //calculate the midpoint for roughly equal partition x/
    int middle = midpoint(from, to);
    // determine which subarray to search
    if (a[middle] < key)
      // change from index to search upper subarray
       from = middle + 1;
    else if (a[middle] > key)
      // change to index to search lower subarray
       to = middle - 1
    else
      // key found at index middle
      return middle;
  return KEY_NOT_FOUND;
```

<!-- attr: {class: 'slide-section'} -->

<!-- section start -->

<!-- attr: {class: 'slide-section'} -->
# Interpolation Search

<!-- attr: { showInPresentation:true, style:'' } -->
# Interpolation Search
* An algorithm for searching for a given key value in an indexed array that has been ordered by the values of the key
  * Parallels how humans search through a telephone book
  * Calculates where in the remaining search space the sought item might be
    * Binary search always chooses the middle element
* Average case: `log(log(n))`, Worst case: `O(n)`
* http://youtube.com/watch?v=l1ed_bTv7Hw

<!-- attr: { showInPresentation:true, style:'' } -->
# Interpolation SearchSample Implementation

```cs
public int interpolationSearch(int[] sortedArray, int toFind){
  // Returns index of toFind in sortedArray, or -1 if not found
  int low = 0;
  int high = sortedArray.length - 1;
  int mid;
  while(sortedArray[low] <= toFind && sortedArray[high] >= toFind) {
    mid = low + ((toFind - sortedArray[low]) x (high - low)) /
                (sortedArray[high] - sortedArray[low]);
                // out of range   is possible here
    if (sortedArray[mid] < toFind)
      low = mid + 1;
    else if (sortedArray[mid] > toFind)
      high = mid - 1;
    else
      return mid;
  }
  if (sortedArray[low] == toFind) return low;
    else return -1; // Not found
}
```

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Shuffling

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Shuffling
* A procedure used to randomize the order of items in a collection
  * Generating random permutation
* http://en.wikipedia.org/wiki/Shuffling

<!-- attr: { showInPresentation:true, style:'' } -->
# Fisher–Yates shuffle algorithm

```cs
public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
{
    var array = source.ToArray();
    var n = array.Length;
    for (var i = 0; i < n; i++)
    {
*         // Exchange a[i] with random element in a[i..n-1]
        int r = i + RandomProvider.Instance.Next(0, n - i);
        var temp = array[i];
        array[i] = array[r];
        array[r] = temp;
    }
    return array;
}
public static class RandomProvider
{
    private static Random Instance = new Random();
}
```

<!-- attr: { showInPresentation:true, style:'' } -->
# Sorting and Searching Algorithms
* http://academy.telerik.com
