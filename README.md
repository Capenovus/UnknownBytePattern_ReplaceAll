# UnknownBytePattern_ReplaceAll

Replace all occurences of a byte pattern in a file with another pattern of the same length. May include unknowns, represented as "??".

# Example: 
  - File contains the bytes ``` {61, 62, 63, 61, 61, 63} ``` ("abcaac")
  ```
  Search pattern: 61 ?? 63
  Replace pattern: 61 63 63
  ```
  - The file will be overridden as ``` {61, 63, 63, 61, 63, 63} ``` ("accacc")
