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
![screenshot](https://i.imgur.com/gR7ZqPP.png)
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