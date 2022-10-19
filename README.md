# UnknownBytePattern_ReplaceAll

Replace all occurrences of a byte pattern in a file with another pattern of the same length. May include unknowns, represented as "??".

# Usage:

  - Drag and Drop a file on the .exe or supply the path as a command argument and input the search pattern as well as the replacement pattern
  - The Program will terminate unsuccessfully if:
    - the file does not exist or no arguments are given 
    - the search pattern and the replacement pattern aren't of the same length
    - an unknown error occurs

# Example: 
  - File contains the bytes ``` {61, 62, 63, 61, 61, 63} ``` ("abcaac")
  ```
  Search pattern: 61 ?? 63
  Replace pattern: 61 63 63
  ```
  - The file will be overridden as ``` {61, 63, 63, 61, 63, 63} ``` ("accacc")

# Sidenote

This is under no circumstance efficient. I recommend coding your own tool instead.
