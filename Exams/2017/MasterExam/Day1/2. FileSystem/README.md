<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png"/>

#### _Telerik Academy Season 2016-2017 Autumn / Data Structures and Algorithms Exam - 4 September 2017_
# File System

## Description

You are given a terminal supporting basic command line operations.

The possible operations are **7** as follows:
- `mk DIR_NAME`
  - Creates a directory at the specified location
- `mv SOURCE DESTINATION`
  - Moves an empty directory from `SOURCE` to `DESTINATION`
  - `DESTINATION` + the name of the directory must be non-existent
- `cp SOURCE DESTINATION`
  - Copy an empty directory from `SOURCE` to `DESTINATION`
  - `DESTINATION` + the name of the directory must be non-existent
- `cd DIR_NAME`
  - Change the current directory to specified location
- `ls`
  - Prints all the files and folders, currently in the file system
    - Sorted alphabetically
    - Based on the current directory
- `find PATTERN`
  - Same as print, but print only the paths to the directories with name that is a superstring of `PATTERN`
- `exit`
  - Closes the program`

For more clarifications, see the sample output


## Input

Read the input from the standard Input

- Read lines, until you find the `exit` operation

## Output

Print the output on the standard output

## Constraints

- The operations will always be less than 1025


## Sample Tests


<table>
  <tr>
    <th>Input</th>
    <th>Output</th>
  </tr>
  <tr>
    <td>mk /home/minkov/repos/dsa</td>
    <td></td>
  </tr>
  <tr>
    <td>mk /home/coki/dsa/graphs</td>
    <td></td>
  </tr>
  <tr>
    <td>mk /tmp/to-delete.tmp</td>
    <td></td>
  </tr>
  <tr>
    <td>find dsa</td>
    <td>
      <pre>/home/coki/dsa
/home/minkov/repos/dsa</pre>
    </td>
  </tr>
  <tr>
    <td>mk /home/vscode/globals</td>
    <td></td>
  </tr>
  <tr>
    <td>ls</td>
    <td>
    <pre>/
/home
/home/coki
/home/coki/dsa
/home/coki/dsa/graphs
/home/minkov
/home/minkov/repos
/home/minkov/repos/dsa
/home/vscode
/home/vscode/globals
/tmp
/tmp/to-delete.tmp</pre>
    </td>
  </tr>
  <tr>
    <td>cp /home/coki/dsa/graphs /home/minkov/repos</td>
    <td></td>
  </tr>
  <tr>
    <td>ls</td>
    <td>
      <pre>/
/home
/home/coki
/home/coki/dsa
/home/coki/dsa/graphs
/home/minkov
/home/minkov/repos
/home/minkov/repos/dsa
/home/minkov/repos/graphs
/home/vscode
/home/vscode/globals
/tmp

/tmp/to-delete.tmp</pre>
  </tr>
  <tr>
    <td>mv /home/minkov/repos/graphs /home/minkov/repos/dsa</td>
    <td></td>
  </tr>
  <tr>
    <td>ls</td>
    <td>
      <pre>/
/home
/home/coki
/home/coki/dsa
/home/coki/dsa/graphs
/home/minkov
/home/minkov/repos
/home/minkov/repos/dsa
/home/minkov/repos/dsa/graphs
/home/vscode
/home/vscode/globals
/tmp
/tmp/to-delete.tmp</pre>
    </td>
  </tr>
  <tr>
    <td>cd /home/minkov</td>
    <td></td>
  </tr>
  <tr>
    <td>ls</td>
    <td>
      <pre>/home/minkov
../home
../../
../../tmp
../../tmp/to-delete.tmp
../home/coki
../home/coki/dsa
../home/coki/dsa/graphs
../home/vscode
../home/vscode/globals
/home/minkov/repos
/home/minkov/repos/dsa
/home/minkov/repos/dsa/graphs</pre>
    </td>
  </tr>
  <tr>
    <td>print</td>
    <td>Error</td>
  </tr>
  <tr>
    <td>cp /does-not-exits /tmp</td>
    <td>Error</td>    
  </tr>
  <tr>
    <td>mv /tmp /tmp/test</td>
    <td>Error</td>    
  </tr>
  <tr>
    <td>mv /tmp/to-delete.tmp /home/minkov</td>
    <td>Error</td>
  </tr>
  <tr>
    <td>exit</td>
  </tr>
</table>
