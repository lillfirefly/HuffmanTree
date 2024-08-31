# Huffman-coding written in C#
# Original Author

## Attribution

This project was originally authored by [Mennatullah] ([GitHub Profile](https://github.com/lillfirefly)) on [December 2023]. Contributions have been made by other developers; however, the original implementation and concept belong to [Mennatullah]. If you use or modify this code, please provide proper attribution to the original author.


A simple implementation of huffamn-coding written in C#

## Usage

After you have compiled the program, you can use the following CLI arguments to compress and decomress file.

To compress a file:
```
$./program <path/to/my/file> <desired/output/path.bin>

# Example:
$./program file.txt compressed_data.bin
```

To decompress a file:
```
$./program d <path/to/my/file.bin> <desired/output/path>

# Example:
$./program d compress_data.bin results.txt
```
