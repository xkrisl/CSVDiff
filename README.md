# CSVDiff
 Tool to compare differences between two generated .csv files. Provides text output for logging and an HTML report for visual comparison.

## Demonstration
#### Application
 ![screenshot](https://i.imgur.com/lN5yuED.png)
#### Text Report Build
```bash
################################################################
Original:
"laura@example.com","2070","Laura","Grey",

Modified:
"laura@domain.com","2070","Laura","Grey",

################################################################
Original:
"craig@example.com","4081","Craig","Johnson",

Modified:
"craig@example.com","4091","Craig","Johnson",

################################################################
Original:
"jamie@example.com","5079","Jamie","Smith",

Modified:
"jamie@example.com","5079","Jamie","Doe",
```
#### HTML Report Build
<html><body><table border='1' style='border-collapse:collapse; width:100%;'><tr><th style='width:17px;'>"Login email"</th><th style='width:10px;'>"Identifier"</th><th style='width:10px;'>"First name"</th><th style='width:9px;'>"Last name"</th><th style='width:0px;'></th></tr><tr><td style='background-color:red;'>laura@example.com</td><td style='background-color:white;'>2070</td><td style='background-color:white;'>Laura</td><td style='background-color:white;'>Grey</td><td style='background-color:white;'></td></tr><tr><td style='background-color:green;'>laura@domain.com</td><td style='background-color:white;'>2070</td><td style='background-color:white;'>Laura</td><td style='background-color:white;'>Grey</td><td style='background-color:white;'></td></tr><tr><td colspan='100%' style='height:45px;'></td></tr><tr><td style='background-color:white;'>craig@example.com</td><td style='background-color:red;'>4081</td><td style='background-color:white;'>Craig</td><td style='background-color:white;'>Johnson</td><td style='background-color:white;'></td></tr><tr><td style='background-color:white;'>craig@example.com</td><td style='background-color:green;'>4091</td><td style='background-color:white;'>Craig</td><td style='background-color:white;'>Johnson</td><td style='background-color:white;'></td></tr><tr><td colspan='100%' style='height:45px;'></td></tr><tr><td style='background-color:white;'>jamie@example.com</td><td style='background-color:white;'>5079</td><td style='background-color:white;'>Jamie</td><td style='background-color:red;'>Smith</td><td style='background-color:white;'></td></tr><tr><td style='background-color:white;'>jamie@example.com</td><td style='background-color:white;'>5079</td><td style='background-color:white;'>Jamie</td><td style='background-color:green;'>Doe</td><td style='background-color:white;'></td></tr><tr><td colspan='100%' style='height:45px;'></td></tr></table></body></html>

## Information
This tool is designed to work with a specific type of report generated as a .csv file, but the code and formatting can be easily modified to suit your needs. Below is an example of a .csv file that this application typically uses:

```bash
"Login email","Identifier","First name","Last name",
"laura@example.com","2070","Laura","Grey",
"craig@example.com","4081","Craig","Johnson",
"mary@example.com","9346","Mary","Jenkins",
"jamie@example.com","5079","Jamie","Smith",
```
## Key Features
CSV File Comparison: 
- The application checks for differences between the content of two CSV files. It verifies that both files are structurally compatible before proceeding with the comparison.

Asynchronous File Operations:
- The tool is optimized with asynchronous file reading and writing, ensuring smooth performance, especially with large datasets.

Flexible Output Options:
- Users can choose between generating:
HTML reports, which visualize differences using a clean, color-coded table format.
Text reports, which log the differences in a structured manner.