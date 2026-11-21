# CsvDataPatcher

CsvDataPatcher is a small Windows desktop tool for appending a row of data to an existing CSV file without opening the file in a text editor.

It is useful when a CSV file is used as an append-only backup or data store and a new record needs to be added quickly and safely.

## Features

- Browse for a CSV file on your computer.
- Enter the data to append.
- Append the data as a new line in the selected file.
- Display clear success and error messages.
- Automatically hide status messages after five seconds.

## Requirements

- Windows
- .NET Framework 4.8

## How to use

1. Start **CsvDataPatcher**.
2. Click **Browse...** and select a `.csv` file.
3. Enter the new row in **Data to Append**.
4. Click **Append Data**.
5. Check the status message to confirm whether the operation succeeded.

The application adds a line ending after the entered data. If entering multiple CSV columns, separate the values with commas, for example:

```text
123,Jane Doe,jane@example.com
```

## Build from source

Open the solution in Visual Studio and build the `CsvDataPatcher` project, or run:

```powershell
dotnet build CsvDataPatcher/CsvDataPatcher.csproj
```

## Important note

CsvDataPatcher appends data to the selected file; it does not edit or replace existing rows. Create a backup of important CSV files before making changes.
