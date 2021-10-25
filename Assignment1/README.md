# C# File Parser
## Description
This repo contains the solution for Assignment-1 of MCDA5510 course.

The task is to traverse each directory recursively, parse all the .csv files and collate the information into a single .csv file. Log invalid / skipped records during each iteration while parsing the files and also the total execution time of the program. The final delivarable is the log file and a .csv file with all valid records.

## Approach
- Open the output file and add the headers.
- Loop through each .csv file in the nested directory structure.
- Parse the .csv file one row at a time, ignoring the header.
- Read each field within a row to determine if the row is valid.
    - Row is valid if it has all fields.
    - Row is skipped if it has any one of the fields missing.
- Log skipped rows.
- Row is written to the .csv file as soon as it is identified as a valid row.

## Downloading the Source Code

You can just clone the repository:

```sh
git clone https://github.com/A00457249/A00457249_MCDA5510.git
```
## Output Details
```
Total number of valid rows: 200,355
Total number of skipped rows: 82,554

Execution Time (in milliseconds): 10,723 
```

 
