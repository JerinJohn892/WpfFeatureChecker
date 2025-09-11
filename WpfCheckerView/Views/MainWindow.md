# MainWindow Process Flow

The `MainWindow` class hosts the application's data-entry form and a Syncfusion `SfDataGrid` that displays employees.
This document outlines the high-level flow that occurs when the window is created and how the grid merges rows with
identical employee identifiers.

## Initialization
1. **Component setup** – WPF components are created and Syncfusion styles are applied.
2. **View model wiring** – A `MockDataService` supplies data to a `MainViewModel` which becomes the `DataContext`.
3. **Default focus** – The employee ID `TextBox` receives initial focus for quick input.
4. **Grid event subscription** – The grid subscribes to `ItemsSourceChanged` and `QueryCoveredRange` to enable
   reflection and cell merging.

## Event Flow
- `ItemsSourceChanged`: Captures an `IPropertyAccessProvider` used to read property values from grid records.
- `QueryCoveredRange`: Executes before each cell is drawn. The handler calls `GetMergeRange` which searches adjacent
  rows for matching IDs and returns a `CoveredCellInfo` so the grid renders a single merged cell.

## Cell Merging Algorithm
1. Skip processing if the column is marked as non-mergeable.
2. Determine the total number of visible rows and current record identifier.
3. Walk upward and downward from the current row gathering contiguous rows that share the same identifier.
4. If multiple rows are found, return a `CoveredCellInfo` describing the span; otherwise no merge is applied.

This flow keeps the UI responsive while clearly displaying groups of employees who share the same ID.
