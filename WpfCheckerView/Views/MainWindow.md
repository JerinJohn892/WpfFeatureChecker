# MainWindow Process Flow

The `MainWindow` class hosts the application's data-entry form and a `SfDataGridExt`
that displays employees. The extended grid merges rows based on declarative
configuration and requires no code-behind logic.

## Initialization
1. **Component setup** – WPF components are created and Syncfusion styles are applied.
2. **View model wiring** – A `MockDataService` supplies data to a `MainViewModel` which becomes the `DataContext`.
3. **Default focus** – The employee ID `TextBox` receives initial focus for quick input.
4. **Grid configuration** – `SfDataGridExt` exposes `AllowRowMerging`, `MergeColumnName`, and
   `MergeIgnoredColumns`. In XAML, the merge column and ignored columns are marked with
   `MergeColumn="True"` or `MergeIgnored="True"` attached properties.

## Row Merging
When `AllowRowMerging` is enabled the control merges adjacent rows that share the
same value in the configured merge column. Columns flagged with `MergeIgnored` are
excluded from the span. This encapsulation keeps the UI responsive while clearly
displaying groups of employees who share the same identifier.
