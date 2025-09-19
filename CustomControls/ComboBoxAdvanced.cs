using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;

namespace CustomControls;

public class ComboBoxAdvanced : ComboBoxAdv
{
    //private Point lastMousePosition;

    //internal bool IsGotKeyBoardFocus;

    //internal object oldItem;

    //internal object newItem;

    //internal Window MainWindow;

    //internal int itemcount;

    //internal bool removeFlag;

    //internal bool internalSelect;

    //private ItemsControl selectedItems;

    //internal ScrollViewer DropDownScrollBar;

    //private ContentPresenter selectedContent;

    //internal TextBlock defaultText;

    //internal TextBox IsEditDefaultText;

    //private ToggleButton toggleButton;

    //internal ComboBoxItemAdv SelectAllItem;

    //internal Button OKButton;

    //internal Button CancelButton;

    //internal bool isKeyDown;

    //private bool isFilter;

    //public string searchText = "";

    //private TextBox Part_IsEdit;

    //private int charindex;

    ////
    //// Summary:
    ////     Holds the token items on MultiSelection
    //private ItemsControl tokenItemsControl;

    ////
    //// Summary:
    ////     Root border holding token items
    //private Border tokenBorder;

    ////
    //// Summary:
    ////     Index of last token item to calculate textbox size
    //private int lastRowTokenItemIndex;

    ////
    //// Summary:
    ////     Displayed while there is no suggested items
    //private TextBlock NoRecords;

    ////
    //// Summary:
    ////     Specifies the pressed key
    //private Key KeyPressed;

    ////
    //// Summary:
    ////     It tells whether token closed while using EnableOkCancel
    //internal bool IsTokenRemoved;

    ////
    //// Summary:
    ////     Contains the filter text for validation with current text on key up validation
    ////     while using suggest
    //private string oldFilter = string.Empty;

    ////
    //// Summary:
    ////     List contains the added token items to reset on lostfocus while pressing esc
    ////     key. Applicable only when Syncfusion.Windows.Tools.Controls.ComboBoxAdv.EnableOKCancelProperty
    ////     value is true.
    //private List<string> AddedTokenItems = new List<string>();

    //private DispatcherTimer timer = new DispatcherTimer
    //{
    //    Interval = TimeSpan.FromSeconds(0.5)
    //};

    ////
    //// Summary:
    ////     Represents ComboBoxAdv added as SfTextInputLayout child or not.
    //private bool isTextInputLayoutChild;

    //internal Popup popup;

    //internal new SelectionChangedEventArgs SelectionChangedEvent;

    ////
    //// Summary:
    ////     Used to notify about the checked items on EnableOkCancel
    //internal bool internalChange;

    //private bool _keypressed;

    //private bool isBackspaceOrDeleteKeyPressed;

    ////
    //// Summary:
    ////     Using a DependencyProperty as the backing store for InactiveBrush. This enables
    ////     animation, styling, binding, etc...
    //internal static readonly DependencyProperty InactiveBrushProperty;

    ////
    //// Summary:
    ////     Using a DependencyProperty as the backing store for IsEditable. This enables
    ////     animation, styling, binding, etc...
    //public static readonly DependencyProperty IsEditableProperty;

    ////
    //// Summary:
    ////     Using a DependencyProperty as the backing store for IsEditable. This enables
    ////     animation, styling, binding, etc...
    //public static readonly DependencyProperty EnableTokenProperty;

    ////
    //// Summary:
    ////     Using a DependencyProperty as the backing store for AutocompleteMode. This enables
    ////     animation, styling, binding, etc...
    //public static readonly DependencyProperty AutoCompleteModeProperty;

    //private bool isReadOnly;

    //public static readonly DependencyProperty IsReadOnlyProperty;

    ////
    //// Summary:
    ////     Using a DependencyProperty as the backing store for MaxDropDownHeight. This enables
    ////     animation, styling, binding, etc...
    //public static readonly DependencyProperty MaxDropDownHeightProperty;

    ////
    //// Summary:
    ////     Using a DependencyProperty as the backing store for IsDropDownOpen. This enables
    ////     animation, styling, binding, etc...
    //public static readonly DependencyProperty IsDropDownOpenProperty;

    ////
    //// Summary:
    ////     Using a DependencyProperty as the backing store for SelectionBoxItemTemplate.
    ////     This enables animation, styling, binding, etc...
    //public static readonly DependencyProperty SelectionBoxItemTemplateProperty;

    ////
    //// Summary:
    ////     Using a DependencyProperty as the backing store for SelectionBoxItem. This enables
    ////     animation, styling, binding, etc...
    //public static readonly DependencyProperty SelectionBoxItemProperty;

    ////
    //// Summary:
    ////     Using a DependencyProperty as the backing store for SelectionBoxItemStringFormat.
    ////     This enables animation, styling, binding, etc...
    //public static readonly DependencyProperty SelectionBoxItemStringFormatProperty;

    ////
    //// Summary:
    ////     Using a DependencyProperty as the backing store for AllowMultiSelect. This enables
    ////     animation, styling, binding, etc...
    //public static readonly DependencyProperty AllowMultiSelectProperty;

    ////
    //// Summary:
    ////     Identifies the Syncfusion.Windows.Tools.Controls.ComboBoxAdv.EnableSelectAll
    ////     dependency property.
    //public static readonly DependencyProperty AllowSelectAllProperty;

    ////
    //// Summary:
    ////     Identifies the Syncfusion.Windows.Tools.Controls.ComboBoxAdv.EnableOkCancel dependency
    ////     property.
    //public static readonly DependencyProperty EnableOKCancelProperty;

    ////
    //// Summary:
    ////     Using a DependencyProperty as the backing store for SelItems. This enables animation,
    ////     styling, binding, etc...
    //public static readonly DependencyProperty SelectedItemsProperty;

    ////
    //// Summary:
    ////     Using a DependencyProperty as the backing store for SelectedValueDelimiter. This
    ////     enables animation, styling, binding, etc...
    //public static readonly DependencyProperty SelectedValueDelimiterProperty;

    ////
    //// Summary:
    ////     Using a DependencyProperty as the backing store for SelectionBoxTemplate. This
    ////     enables animation, styling, binding, etc...
    //public static readonly DependencyProperty SelectionBoxTemplateProperty;

    ////
    //// Summary:
    ////     Using a DependencyProperty as the backing store for DefaultText. This enables
    ////     animation, styling, binding, etc...
    //public static readonly DependencyProperty DefaultTextProperty;

    //public static readonly DependencyProperty DropDownContentTemplateProperty;

    ////
    //// Summary:
    ////     Using a DependencyProperty as the backing store for Text. This enables animation,
    ////     styling, binding, etc...
    //public static readonly DependencyProperty TextProperty;

    //public char? oldTempChar { get; set; }

    //public char newTempChar { get; set; }

    ////
    //// Summary:
    ////     Boolean value that indicates the parent is SfTextInputLayout or not.
    //bool ITextInputLayoutSelector.IsTextInputLayoutChild
    //{
    //    get
    //    {
    //        return isTextInputLayoutChild;
    //    }
    //    set
    //    {
    //        isTextInputLayoutChild = value;
    //    }
    //}

    ////
    //// Summary:
    ////     Used to set the Background brush when a ComboBoxItemAdv is selected and AllowMultiSelect
    ////     is True
    //internal Brush InactiveBrush
    //{
    //    get
    //    {
    //        return (Brush)GetValue(InactiveBrushProperty);
    //    }
    //    set
    //    {
    //        SetValue(InactiveBrushProperty, value);
    //    }
    //}

    //public bool IsEditable
    //{
    //    get
    //    {
    //        return (bool)GetValue(IsEditableProperty);
    //    }
    //    set
    //    {
    //        SetValue(IsEditableProperty, value);
    //    }
    //}

    ////
    //// Summary:
    ////     Gets or sets a value that indicates whether the Token support is enabled or not.
    ////
    ////
    //// Value:
    ////     true if EnableToken option is enabled; otherwise, false. The default value is
    ////     false.
    ////
    //// Remarks:
    ////     This property is applicable only for Multiselection Syncfusion.Windows.Tools.Controls.ComboBoxAdv.AllowMultiSelect
    //public bool EnableToken
    //{
    //    get
    //    {
    //        return (bool)GetValue(EnableTokenProperty);
    //    }
    //    set
    //    {
    //        SetValue(EnableTokenProperty, value);
    //    }
    //}

    ////
    //// Summary:
    ////     Gets or sets the Syncfusion.Windows.Tools.Controls.AutoCompleteModes that specifies
    ////     how auto complete should be performed.
    ////
    //// Remarks:
    ////     AutoCompleteModes – Describes the AutoComplete mode
    ////     None – Autocomplete not performed
    ////     Suggest – Suggest the items based on entered text
    //public AutoCompleteModes AutoCompleteMode
    //{
    //    get
    //    {
    //        return (AutoCompleteModes)GetValue(AutoCompleteModeProperty);
    //    }
    //    set
    //    {
    //        SetValue(AutoCompleteModeProperty, value);
    //    }
    //}

    //public bool IsReadOnly
    //{
    //    get
    //    {
    //        return isReadOnly;
    //    }
    //    set
    //    {
    //        isReadOnly = value;
    //    }
    //}

    //public double MaxDropDownHeight
    //{
    //    get
    //    {
    //        return (double)GetValue(MaxDropDownHeightProperty);
    //    }
    //    set
    //    {
    //        SetValue(MaxDropDownHeightProperty, value);
    //    }
    //}

    //public bool IsDropDownOpen
    //{
    //    get
    //    {
    //        return (bool)GetValue(IsDropDownOpenProperty);
    //    }
    //    set
    //    {
    //        SetValue(IsDropDownOpenProperty, value);
    //    }
    //}

    //public DataTemplate SelectionBoxItemTemplate
    //{
    //    get
    //    {
    //        return (DataTemplate)GetValue(SelectionBoxItemTemplateProperty);
    //    }
    //    internal set
    //    {
    //        SetValue(SelectionBoxItemTemplateProperty, value);
    //    }
    //}

    //public object SelectionBoxItem => GetValue(SelectionBoxItemProperty);

    //public string SelectionBoxItemStringFormat
    //{
    //    get
    //    {
    //        return (string)GetValue(SelectionBoxItemStringFormatProperty);
    //    }
    //    internal set
    //    {
    //        SetValue(SelectionBoxItemStringFormatProperty, value);
    //    }
    //}

    ////
    //// Summary:
    ////     Gets or sets a value indicating whether [allow multi select].
    ////
    //// Value:
    ////     true if [allow multi select]; otherwise, false.
    //public bool AllowMultiSelect
    //{
    //    get
    //    {
    //        return (bool)GetValue(AllowMultiSelectProperty);
    //    }
    //    set
    //    {
    //        SetValue(AllowMultiSelectProperty, value);
    //    }
    //}

    ////
    //// Summary:
    ////     Gets or sets a value that indicates whether the SelectAll option is enabled or
    ////     not.
    ////
    //// Value:
    ////     true if the SelectAll option is enabled; otherwise, false. The default value
    ////     is false.
    ////
    //// Remarks:
    ////     The SelectAll option is only available when the MultiSelect option is enabled.
    //public bool AllowSelectAll
    //{
    //    get
    //    {
    //        return (bool)GetValue(AllowSelectAllProperty);
    //    }
    //    set
    //    {
    //        SetValue(AllowSelectAllProperty, value);
    //    }
    //}

    ////
    //// Summary:
    ////     Gets or sets a value that indicates whether the OkCancel option is enabled or
    ////     not.
    ////
    //// Value:
    ////     true if the OkCancel option is enabled; otherwise, false. The default value is
    ////     false.
    ////
    //// Remarks:
    ////     The OkCancel option is only available when the MultiSelect option is enabled.
    //public bool EnableOKCancel
    //{
    //    get
    //    {
    //        return (bool)GetValue(EnableOKCancelProperty);
    //    }
    //    set
    //    {
    //        SetValue(EnableOKCancelProperty, value);
    //    }
    //}

    //public IEnumerable SelectedItems
    //{
    //    get
    //    {
    //        return (IEnumerable)GetValue(SelectedItemsProperty);
    //    }
    //    set
    //    {
    //        if (value == null)
    //        {
    //            value = new ObservableCollection<object>();
    //        }

    //        SetValue(SelectedItemsProperty, value);
    //    }
    //}

    //internal IList SelItemsInternal { get; set; }

    //internal List<object> ChangedItems { get; set; }

    //public string SelectedValueDelimiter
    //{
    //    get
    //    {
    //        return (string)GetValue(SelectedValueDelimiterProperty);
    //    }
    //    set
    //    {
    //        SetValue(SelectedValueDelimiterProperty, value);
    //    }
    //}

    //public DataTemplate SelectionBoxTemplate
    //{
    //    get
    //    {
    //        return (DataTemplate)GetValue(SelectionBoxTemplateProperty);
    //    }
    //    set
    //    {
    //        SetValue(SelectionBoxTemplateProperty, value);
    //    }
    //}

    //public string DefaultText
    //{
    //    get
    //    {
    //        return (string)GetValue(DefaultTextProperty);
    //    }
    //    set
    //    {
    //        SetValue(DefaultTextProperty, value);
    //    }
    //}

    //public DataTemplate DropDownContentTemplate
    //{
    //    get
    //    {
    //        return (DataTemplate)GetValue(DropDownContentTemplateProperty);
    //    }
    //    set
    //    {
    //        SetValue(DropDownContentTemplateProperty, value);
    //    }
    //}

    //public string Text
    //{
    //    get
    //    {
    //        return (string)GetValue(TextProperty);
    //    }
    //    set
    //    {
    //        SetValue(TextProperty, value);
    //    }
    //}

    ////
    //// Summary:
    ////     Occurs when the drop-down list of the combo box closes.
    //public event EventHandler DropDownClosed;

    ////
    //// Summary:
    ////     Occurs when the drop-down list of the combo box opens.
    //public event EventHandler DropDownOpened;

    //static ComboBoxAdv()
    //{
    //    InactiveBrushProperty = DependencyProperty.Register("InactiveBrush", typeof(Brush), typeof(ComboBoxAdv), new PropertyMetadata(null));
    //    IsEditableProperty = DependencyProperty.Register("IsEditable", typeof(bool), typeof(ComboBoxAdv), new UIPropertyMetadata(false, OnIsEditableChanged));
    //    EnableTokenProperty = DependencyProperty.Register("EnableToken", typeof(bool), typeof(ComboBoxAdv), new PropertyMetadata(false, OnEnableTokenChanged));
    //    AutoCompleteModeProperty = DependencyProperty.Register("AutoCompleteMode", typeof(AutoCompleteModes), typeof(ComboBoxAdv), new PropertyMetadata(AutoCompleteModes.None, OnAutoCompleteModeChanged));
    //    IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(ComboBoxAdv), new UIPropertyMetadata(false));
    //    MaxDropDownHeightProperty = DependencyProperty.Register("MaxDropDownHeight", typeof(double), typeof(ComboBoxAdv), new PropertyMetadata(SystemParameters.MaximizedPrimaryScreenHeight / 3.0));
    //    IsDropDownOpenProperty = DependencyProperty.Register("IsDropDownOpen", typeof(bool), typeof(ComboBoxAdv), new PropertyMetadata(false, OnIsDropDownOpenChanged));
    //    SelectionBoxItemTemplateProperty = DependencyProperty.Register("SelectionBoxItemTemplate", typeof(DataTemplate), typeof(ComboBoxAdv), new PropertyMetadata(null));
    //    SelectionBoxItemProperty = DependencyProperty.Register("SelectionBoxItem", typeof(object), typeof(ComboBoxAdv), new PropertyMetadata(null));
    //    SelectionBoxItemStringFormatProperty = DependencyProperty.Register("SelectionBoxItemStringFormat", typeof(string), typeof(ComboBoxAdv));
    //    AllowMultiSelectProperty = DependencyProperty.Register("AllowMultiSelect", typeof(bool), typeof(ComboBoxAdv), new PropertyMetadata(false, OnAllowMultiSelectChanged));
    //    AllowSelectAllProperty = DependencyProperty.Register("AllowSelectAll", typeof(bool), typeof(ComboBoxAdv), new PropertyMetadata(false));
    //    EnableOKCancelProperty = DependencyProperty.Register("EnableOKCancel", typeof(bool), typeof(ComboBoxAdv), new PropertyMetadata(false));
    //    SelectedItemsProperty = DependencyProperty.Register("SelectedItems", typeof(IEnumerable), typeof(ComboBoxAdv), new PropertyMetadata(null, OnSelectedItemsChanged));
    //    SelectedValueDelimiterProperty = DependencyProperty.Register("SelectedValueDelimiter", typeof(string), typeof(ComboBoxAdv), new PropertyMetadata(" - ", OnSelectedValueDelimiterChanged));
    //    SelectionBoxTemplateProperty = DependencyProperty.Register("SelectionBoxTemplate", typeof(DataTemplate), typeof(ComboBoxAdv), new PropertyMetadata(null, OnSelectionBoxTemplateChanged));
    //    DefaultTextProperty = DependencyProperty.Register("DefaultText", typeof(string), typeof(ComboBoxAdv), new PropertyMetadata(string.Empty));
    //    DropDownContentTemplateProperty = DependencyProperty.Register("DropDownContentTemplate", typeof(DataTemplate), typeof(ComboBoxAdv), new PropertyMetadata(null));
    //    TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(ComboBoxAdv), new PropertyMetadata(string.Empty, OnTextChanged));
    //    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ComboBoxAdv), new FrameworkPropertyMetadata(typeof(ComboBoxAdv)));
    //}

    ////
    //// Summary:
    ////     Initializes a new instance of the Syncfusion.Windows.Tools.Controls.ComboBoxAdv
    ////     class.
    //public ComboBoxAdv()
    //{
    //    if (SelItemsInternal == null)
    //    {
    //        SelItemsInternal = new ObservableCollection<object>();
    //    }

    //    if (ChangedItems == null)
    //    {
    //        ChangedItems = new List<object>();
    //    }

    //    EventManager.RegisterClassHandler(typeof(ComboBoxAdv), Mouse.MouseWheelEvent, new MouseWheelEventHandler(OnMouseWheel), handledEventsToo: true);
    //    EventManager.RegisterClassHandler(typeof(ComboBoxAdv), Mouse.MouseDownEvent, new MouseButtonEventHandler(OnMouseButtonDown), handledEventsToo: true);
    //    EventManager.RegisterClassHandler(typeof(TextBox), Mouse.MouseDownEvent, new MouseButtonEventHandler(OnMouseLeftButtonDown), handledEventsToo: true);
    //    LicenseHelper.ValidateLicense(isInternalDependentControl: true);
    //}

    //
    // Parameters:
    //   e:
    protected override void OnLostFocus(RoutedEventArgs e)
    {
        base.OnLostFocus(e);
        //if (Part_IsEdit != null && !IsDropDownOpen && !Part_IsEdit.IsVisible)
        //{
        //    timer.Stop();
        //    searchText = "";
        //}

        //if (popup != null && !popup.IsKeyboardFocusWithin)
        //{
        //    IsDropDownOpen = false;
        //}
    }

    //
    // Summary:
    //     Override Method for DisplayMemberPath
    //
    // Parameters:
    //   oldDisplayMemberPath:
    //
    //   newDisplayMemberPath:
    protected override void OnDisplayMemberPathChanged(string oldDisplayMemberPath, string newDisplayMemberPath)
    {
        base.OnDisplayMemberPathChanged(oldDisplayMemberPath, newDisplayMemberPath);
        //UpdateSelectionBox();
    }

    //
    // Summary:
    //     Determines if the specified item is (or is eligible to be) its own ItemContainer.
    //
    //
    // Parameters:
    //   item:
    //     Specified item.
    //
    // Returns:
    //     true if the item is its own ItemContainer; otherwise, false.
    protected override bool IsItemItsOwnContainerOverride(object item)
    {
        return item is ComboBoxItemAdv;
    }

    //
    // Summary:
    //     Creates or identifies the element used to display the specified item.
    //
    // Returns:
    //     A System.Windows.Controls.ComboBoxItem.
    protected override DependencyObject GetContainerForItemOverride()
    {
        return new ComboBoxItemAdv();
    }

    //
    // Summary:
    //     Prepares the specified element to display the specified item.
    //
    // Parameters:
    //   element:
    //     Element used to display the specified item.
    //
    //   item:
    //     Specified item.
    protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
    {
        ComboBoxItemAdv comboBoxItemAdv = element as ComboBoxItemAdv;
        base.PrepareContainerForItemOverride(element, item);
        //if (base.ItemsSource != null && base.ItemTemplate != null)
        //{
        //    comboBoxItemAdv.ContentTemplate = base.ItemTemplate;
        //    if (SelectionBoxItemTemplate == null)
        //    {
        //        SelectionBoxItemTemplate = base.ItemTemplate;
        //    }
        //}

        //if (comboBoxItemAdv.CheckBox != null)
        //{
        //    UpdateCheckBoxVisibility(comboBoxItemAdv);
        //}
        //else if (!AllowMultiSelect && !IsDropDownOpen)
        //{
        //    UpdateSelectionOnDropDownOpen(this);
        //}

        //if (base.ItemsSource != null && base.ItemTemplateSelector != null)
        //{
        //    comboBoxItemAdv.ContentTemplateSelector = base.ItemTemplateSelector;
        //}

        //if (item is ComboBoxItemAdv)
        //{
        //    base.PrepareContainerForItemOverride((DependencyObject)comboBoxItemAdv, item);
        //}
        //else
        //{
        //    comboBoxItemAdv.Content = item;
        //}

        //if (popup != null && popup.Child is FrameworkElement frameworkElement && frameworkElement.ActualWidth > frameworkElement.MinWidth)
        //{
        //    frameworkElement.MinWidth = frameworkElement.ActualWidth;
        //}

        //if (popup != null && !AllowMultiSelect && base.SelectedIndex >= 0 && base.SelectedItem != null && base.SelectedItem == item)
        //{
        //    comboBoxItemAdv.IsHighlighted = true;
        //}
    }



  

    protected override void OnSelectionChanged(SelectionChangedEventArgs e)
    {
        base.OnSelectionChanged(e);
        if (!IsEditable && !AllowMultiSelect)
        {
            //CommitNonEditableSelection();
        }
        //if (isFilter && AllowMultiSelect)
        //{
        //    return;
        //}

        //if (!internalChange)
        //{
        //    base.OnSelectionChanged(e);
        //}

        //if (base.SelectedItem == null || base.SelectedIndex < 0)
        //{
        //    base.SelectedItem = null;
        //    base.SelectedIndex = -1;
        //    SetSelectionBoxItem(null);
        //    if (Part_IsEdit != null && IsEditable && !internalSelect && !isBackspaceOrDeleteKeyPressed)
        //    {
        //        Text = string.Empty;
        //    }

        //    isBackspaceOrDeleteKeyPressed = false;
        //    if (selectedContent != null && selectedContent.Content != null)
        //    {
        //        selectedContent.Content = null;
        //    }
        //}

        //if (base.SelectedItem != null && SelItemsInternal != null && SelItemsInternal.Count <= 0)
        //{
        //    UpdateText();
        //    if (!SelItemsInternal.Contains(base.SelectedItem))
        //    {
        //        SelItemsInternal.Add(base.SelectedItem);
        //    }

        //    if (SelectedItems == null && SelItemsInternal.Count > 0)
        //    {
        //        SelectedItems = SelItemsInternal;
        //    }
        //}

        //UpdateSelectAllItemState();
        //SelectionChangedEvent = e;
    }

    //
    // Summary:
    //     To determine the popup location while combobox height changed
    //
    // Parameters:
    //   sizeInfo:
    //     Item size info
    protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
    {
        base.OnRenderSizeChanged(sizeInfo);
        //if (popup != null && popup.IsOpen)
        //{
        //    popup.VerticalOffset += 1.0;
        //    popup.VerticalOffset = 0.0;
        //}
    }

    protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
    {

        //if (base.IsLoaded && AutoCompleteMode == AutoCompleteModes.Suggest && ((EnableToken && AllowMultiSelect && IsEditable) || (IsEditable && !AllowMultiSelect)))
        //{
        //    if (newValue != null)
        //    {
        //        ICollectionView defaultView = CollectionViewSource.GetDefaultView(newValue);
        //        defaultView.Filter = (Predicate<object>)Delegate.Combine(defaultView.Filter, new Predicate<object>(FilterItem));
        //    }

        //    if (oldValue != null)
        //    {
        //        ICollectionView defaultView2 = CollectionViewSource.GetDefaultView(oldValue);
        //        if (defaultView2 != null)
        //        {
        //            defaultView2.Filter = (Predicate<object>)Delegate.Remove(defaultView2.Filter, new Predicate<object>(FilterItem));
        //        }
        //    }
        //}

        base.OnItemsSourceChanged(oldValue, newValue);
        if (base.IsLoaded && newValue != null)
        {
            SelectedItems = null;
            base.SelectedItem = null;
        }
    }

    ////
    //// Summary:
    ////     To filter the item based on the search text
    ////
    //// Parameters:
    ////   value:
    ////     Each value in item source
    //private bool FilterItem(object value)
    //{
    //    if (base.SelectedItem != null && !AllowMultiSelect)
    //    {
    //        return true;
    //    }

    //    if (!string.IsNullOrEmpty(base.DisplayMemberPath))
    //    {
    //        value = GetDisplayMemberValue(value);
    //        if (Part_IsEdit != null && Part_IsEdit.Text.Length == 0)
    //        {
    //            return value.ToString().ToLower().Contains(Part_IsEdit.Text.ToLower());
    //        }
    //    }

    //    if (value == null || Part_IsEdit == null || Part_IsEdit.Text == null)
    //    {
    //        return false;
    //    }

    //    return value.ToString().ToLower().Contains(Part_IsEdit.Text.ToLower());
    //}


    //
    // Summary:
    //     When overridden in a derived class, is invoked whenever application code or internal
    //     processes call System.Windows.FrameworkElement.ApplyTemplate.
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        //selectedItems = GetTemplateChild("PART_SelectedItems") as ItemsControl;
        //selectedContent = GetTemplateChild("ContentPresenter") as ContentPresenter;
        //defaultText = GetTemplateChild("PART_DefaultText") as TextBlock;
        //popup = GetTemplateChild("PART_Popup") as Popup;
        //toggleButton = GetTemplateChild("PART_ToggleButton") as ToggleButton;
        //IsEditDefaultText = GetTemplateChild("PART_IsEditDefaultText") as TextBox;
        //SelectAllItem = GetTemplateChild("PART_SelectAll") as ComboBoxItemAdv;
        //OKButton = GetTemplateChild("PART_OKButton") as Button;
        //CancelButton = GetTemplateChild("PART_CancelButton") as Button;
        //DropDownScrollBar = GetTemplateChild("DropDownScrollViewer") as ScrollViewer;
        //NoRecords = GetTemplateChild("No_Records") as TextBlock;
        //tokenItemsControl = GetTemplateChild("PART_TokenItems") as ItemsControl;
        //tokenBorder = GetTemplateChild("PART_Border") as Border;
        //if (isTextInputLayoutChild && toggleButton != null)
        //{
        //    toggleButton.Visibility = Visibility.Collapsed;
        //}

        //if (DropDownScrollBar != null)
        //{
        //    DropDownScrollBar.PanningMode = PanningMode.Both;
        //}

        //if (tokenItemsControl != null)
        //{
        //    Part_IsEdit = tokenItemsControl.ItemContainerGenerator.ContainerFromIndex(tokenItemsControl.Items.Count - 1) as TextBox;
        //}
        //else
        //{
        //    Part_IsEdit = GetTemplateChild("PART_Editable") as TextBox;
        //}

        //MainWindow = VisualUtils.FindAncestor(this, typeof(Window)) as Window;
        //UpdateText();
        //UpdateToken();
        //UpdateSelectionBox();
        //UpdateSelectMode();
        //WireEvent();
        //UpdateNoRecords();
    }

    ////
    //// Summary:
    ////     Handler to focus the textbox while clicking token items container
    ////
    //// Parameters:
    ////   sender:
    ////     sender
    ////
    ////   e:
    ////     MouseButtonEventArgs
    //private void TokenBorder_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    //{
    //    if (Part_IsEdit != null)
    //    {
    //        Part_IsEdit.Focus();
    //    }
    //}

    ////
    //// Summary:
    ////     Method to invoke events for control
    //private void WireEvent()
    //{
    //    if (Part_IsEdit != null)
    //    {
    //        Part_IsEdit.TextChanged += Part_IsEdit_TextChanged;
    //        Part_IsEdit.PreviewKeyDown += Part_IsEdit_PreviewKeyDown;
    //        Part_IsEdit.LostFocus += Part_IsEdit_LostFocus;
    //        Part_IsEdit.GotFocus += Part_IsEdit_GotFocus;
    //    }

    //    if (tokenItemsControl != null)
    //    {
    //        tokenItemsControl.SizeChanged += TokenItemsControl_SizeChanged;
    //    }

    //    if (tokenBorder != null)
    //    {
    //        tokenBorder.PreviewMouseDown += TokenBorder_PreviewMouseDown;
    //    }

    //    base.GotFocus -= ComboBoxAdv_GotFocus;
    //    base.GotFocus += ComboBoxAdv_GotFocus;
    //    base.LostFocus += ComboBoxAdv_LostFocus;
    //    if (popup != null)
    //    {
    //        popup.Opened += Popup_Opened;
    //        popup.Closed -= popup_Closed;
    //        popup.Closed += popup_Closed;
    //    }

    //    if (MainWindow != null)
    //    {
    //        MainWindow.LocationChanged -= MainWindow_LocationChanged;
    //        MainWindow.LocationChanged += MainWindow_LocationChanged;
    //        MainWindow.Deactivated -= MainWindow_Deactivated;
    //        MainWindow.Deactivated += MainWindow_Deactivated;
    //    }

    //    base.Unloaded -= ComboBoxAdv_Unloaded;
    //    base.Unloaded += ComboBoxAdv_Unloaded;
    //    base.Loaded += ComboBoxAdv_Loaded;
    //    base.SelectionChanged += ComboBoxAdv_SelectionChanged;
    //    if (OKButton != null)
    //    {
    //        OKButton.Click -= OnOKButtonClick;
    //        OKButton.Click += OnOKButtonClick;
    //    }

    //    if (CancelButton != null)
    //    {
    //        CancelButton.Click -= OnCancelButtonClick;
    //        CancelButton.Click += OnCancelButtonClick;
    //    }

    //    timer.Tick += timer_Tick;
    //}

    ////
    //// Summary:
    ////     Called while ComboBox loaded
    ////
    //// Parameters:
    ////   sender:
    ////     Sender of the event
    ////
    ////   e:
    ////     Event argument
    //private void ComboBoxAdv_Loaded(object sender, RoutedEventArgs e)
    //{
    //    if (tokenItemsControl != null && Part_IsEdit == null)
    //    {
    //        Part_IsEdit = tokenItemsControl.ItemContainerGenerator.ContainerFromIndex(tokenItemsControl.Items.Count - 1) as TextBox;
    //        if (Part_IsEdit != null)
    //        {
    //            Part_IsEdit.TextChanged += Part_IsEdit_TextChanged;
    //            Part_IsEdit.PreviewKeyDown += Part_IsEdit_PreviewKeyDown;
    //            Part_IsEdit.LostFocus += Part_IsEdit_LostFocus;
    //            Part_IsEdit.GotFocus += Part_IsEdit_GotFocus;
    //        }
    //    }

    //    if (IsDropDownOpen && IsEditable && !AllowMultiSelect && AutoCompleteMode == AutoCompleteModes.Suggest)
    //    {
    //        OnFilterApplied();
    //    }
    //}

    ////
    //// Summary:
    ////     To determine the text area while add and remove the tokens
    ////
    //// Parameters:
    ////   sender:
    ////     Sender of the event
    ////
    ////   e:
    ////     Event argument
    //private void TokenItemsControl_SizeChanged(object sender, SizeChangedEventArgs e)
    //{
    //    if (tokenItemsControl.Items.Count <= 0 || !(e.NewSize.Height > 0.0))
    //    {
    //        return;
    //    }

    //    if (Part_IsEdit == null)
    //    {
    //        Part_IsEdit = tokenItemsControl.ItemContainerGenerator.ContainerFromIndex(tokenItemsControl.Items.Count - 1) as TextBox;
    //    }

    //    double num = tokenBorder.ActualWidth - tokenBorder.BorderThickness.Left - tokenBorder.BorderThickness.Right;
    //    double num2 = 0.0;
    //    double num3 = 0.0;
    //    lastRowTokenItemIndex = Math.Max(0, lastRowTokenItemIndex);
    //    for (int i = lastRowTokenItemIndex; i < tokenItemsControl.Items.Count - 1; i++)
    //    {
    //        num3 = (tokenItemsControl.ItemContainerGenerator.ContainerFromIndex(i) as ComboBoxTokenItem).ActualWidth;
    //        num2 += num3;
    //    }

    //    double num4 = ((num > num2) ? (num - num2) : (num - num3));
    //    if (num4 > 75.0)
    //    {
    //        if (num < num2)
    //        {
    //            lastRowTokenItemIndex = tokenItemsControl.Items.Count - 2;
    //        }

    //        Part_IsEdit.MinWidth = num4;
    //    }
    //    else
    //    {
    //        lastRowTokenItemIndex = tokenItemsControl.Items.Count - 2;
    //        Part_IsEdit.MinWidth = num;
    //    }
    //}

    ////
    //// Summary:
    ////     Called while combobox lost its focus
    ////
    //// Parameters:
    ////   sender:
    ////     Sender of this event
    ////
    ////   e:
    ////     event arugumet
    //private void ComboBoxAdv_LostFocus(object sender, RoutedEventArgs e)
    //{
    //    if (EnableToken && IsEditable && !IsDropDownOpen && ShowDefaultText())
    //    {
    //        IsEditDefaultText.Visibility = Visibility.Visible;
    //    }

    //    if (NoRecords != null && NoRecords.Visibility == Visibility.Visible && !IsDropDownOpen)
    //    {
    //        NoRecords.Visibility = Visibility.Collapsed;
    //    }
    //}

    ////
    //// Summary:
    ////     Helper method to update token items based on selected items collection
    //private void UpdateToken()
    //{
    //    if (AddedTokenItems != null)
    //    {
    //        AddedTokenItems.Clear();
    //    }

    //    if (!EnableToken || SelItemsInternal == null)
    //    {
    //        return;
    //    }

    //    foreach (object item in SelItemsInternal)
    //    {
    //        string text = ((base.ItemsSource == null && item is ComboBoxItemAdv && (item as ComboBoxItemAdv).Content != null) ? (item as ComboBoxItemAdv).Content.ToString() : ((!string.IsNullOrEmpty(base.DisplayMemberPath)) ? GetDisplayMemberValue(item).ToString() : item.ToString()));
    //        if (text != null)
    //        {
    //            if (tokenItemsControl != null && !tokenItemsControl.Items.Contains(text))
    //            {
    //                AddToken(text, Key.Enter);
    //            }

    //            if (EnableOKCancel && AddedTokenItems != null && !AddedTokenItems.Contains(text))
    //            {
    //                AddedTokenItems.Add(text);
    //            }
    //        }
    //    }
    //}

    //private void SetSelectionBoxItem(object item)
    //{
    //    if (item is UIElement)
    //    {
    //        Rectangle rectangle = new Rectangle();
    //        rectangle.Stretch = Stretch.Fill;
    //        rectangle.SetBinding(FrameworkElement.WidthProperty, new Binding("ActualWidth")
    //        {
    //            Source = item
    //        });
    //        rectangle.SetBinding(FrameworkElement.HeightProperty, new Binding("ActualHeight")
    //        {
    //            Source = item
    //        });
    //        rectangle.Fill = new VisualBrush(item as Visual)
    //        {
    //            Stretch = Stretch.None
    //        };
    //        SetValue(SelectionBoxItemProperty, rectangle);
    //    }
    //    else
    //    {
    //        SetValue(SelectionBoxItemProperty, item);
    //    }
    //}

    ////
    //// Summary:
    ////     Updates the edit mode Text based on the selected item
    //private void UpdateText()
    //{
    //    if (base.SelectedItem != null)
    //    {
    //        if (base.SelectedItem is ComboBoxItemAdv)
    //        {
    //            if ((base.SelectedItem as ComboBoxItemAdv).Parent != null && SelItemsInternal.Count <= 0)
    //            {
    //                (base.SelectedItem as ComboBoxItemAdv).UpdateSelection();
    //            }

    //            SetSelectionBoxItem((base.SelectedItem as ComboBoxItemAdv).Content);
    //            if (Part_IsEdit != null && Part_IsEdit.Visibility == Visibility.Visible)
    //            {
    //                Part_IsEdit.Text = searchText;
    //                if (searchText != null)
    //                {
    //                    if (SelectionBoxItem == null)
    //                    {
    //                        Part_IsEdit.Text = SelectionBoxItem.ToString().Remove(searchText.Count(), SelectionBoxItem.ToString().Count() - searchText.Count());
    //                        Part_IsEdit.CaretIndex = searchText.Count();
    //                        Part_IsEdit.AppendText(base.SelectedItem.ToString().Remove(0, searchText.Count()));
    //                        Part_IsEdit.SelectionStart = searchText.Count();
    //                        Part_IsEdit.SelectionLength = base.SelectedItem.ToString().Count() - searchText.Count();
    //                    }
    //                    else
    //                    {
    //                        Part_IsEdit.Text = SelectionBoxItem.ToString().Remove(searchText.Count(), SelectionBoxItem.ToString().Count() - searchText.Count());
    //                        Part_IsEdit.CaretIndex = searchText.Count();
    //                        Part_IsEdit.AppendText(SelectionBoxItem.ToString().Remove(0, searchText.Count()));
    //                        Part_IsEdit.SelectionStart = searchText.Count();
    //                        Part_IsEdit.SelectionLength = SelectionBoxItem.ToString().Count() - searchText.Count();
    //                    }
    //                }
    //            }
    //            else if (!AllowMultiSelect && !SelectionBoxItem.ToString().Equals(Text))
    //            {
    //                Text = SelectionBoxItem.ToString();
    //            }
    //        }
    //        else
    //        {
    //            SetSelectionBoxItem(base.SelectedItem);
    //            if (base.SelectedItem != null && base.ItemContainerGenerator.ContainerFromItem(base.SelectedItem) != null && selectedContent != null)
    //            {
    //                if (selectedContent.Content != null && string.IsNullOrEmpty(selectedContent.Content.ToString()) && base.ItemContainerGenerator.ContainerFromItem(base.SelectedItem) is ComboBoxItemAdv)
    //                {
    //                    selectedContent.Content = (base.ItemContainerGenerator.ContainerFromItem(base.SelectedItem) as ComboBoxItemAdv).ToString();
    //                }

    //                if (base.ItemContainerGenerator.ContainerFromItem(base.SelectedItem) is ComboBoxItemAdv)
    //                {
    //                    (base.ItemContainerGenerator.ContainerFromItem(base.SelectedItem) as ComboBoxItemAdv).UpdateSelection();
    //                }
    //            }

    //            if (Part_IsEdit != null && Part_IsEdit.Visibility == Visibility.Visible)
    //            {
    //                if (string.IsNullOrEmpty(base.DisplayMemberPath))
    //                {
    //                    if (!string.IsNullOrEmpty(searchText))
    //                    {
    //                        Part_IsEdit.Text = SelectionBoxItem.ToString().Remove(searchText.Count(), SelectionBoxItem.ToString().Count() - searchText.Count());
    //                        Part_IsEdit.CaretIndex = searchText.Count();
    //                        Part_IsEdit.AppendText(SelectionBoxItem.ToString().Remove(0, searchText.Count()));
    //                        Part_IsEdit.SelectionStart = searchText.Count();
    //                        Part_IsEdit.SelectionLength = SelectionBoxItem.ToString().Count() - searchText.Count();
    //                    }
    //                    else
    //                    {
    //                        Part_IsEdit.Text = SelectionBoxItem.ToString();
    //                        Part_IsEdit.SelectAll();
    //                    }
    //                }
    //                else
    //                {
    //                    object displayMemberValue = GetDisplayMemberValue(SelectionBoxItem);
    //                    if (displayMemberValue != null)
    //                    {
    //                        if (!string.IsNullOrEmpty(searchText))
    //                        {
    //                            int length = displayMemberValue.ToString().Length;
    //                            int length2 = searchText.Length;
    //                            if (length >= length2)
    //                            {
    //                                Part_IsEdit.Text = displayMemberValue.ToString().Remove(length2, length - length2);
    //                                Part_IsEdit.CaretIndex = length2;
    //                                Part_IsEdit.AppendText(displayMemberValue.ToString().Remove(0, length2));
    //                                Part_IsEdit.SelectionStart = length2;
    //                                Part_IsEdit.SelectionLength = length - length2;
    //                            }
    //                        }
    //                        else
    //                        {
    //                            Part_IsEdit.Text = displayMemberValue.ToString();
    //                            Part_IsEdit.SelectAll();
    //                        }
    //                    }
    //                }
    //            }
    //            else if (!AllowMultiSelect)
    //            {
    //                if (string.IsNullOrEmpty(base.DisplayMemberPath))
    //                {
    //                    if (!SelectionBoxItem.ToString().Equals(Text))
    //                    {
    //                        Text = SelectionBoxItem.ToString();
    //                    }
    //                }
    //                else
    //                {
    //                    PropertyInfo property = SelectionBoxItem.GetType().GetProperty(base.DisplayMemberPath);
    //                    object obj = null;
    //                    if (property != null && property.GetGetMethod() != null)
    //                    {
    //                        obj = property.GetValue(SelectionBoxItem, null);
    //                    }

    //                    if (obj != null && !obj.ToString().Equals(Text))
    //                    {
    //                        Text = obj.ToString();
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    else if (Part_IsEdit != null && Part_IsEdit.Visibility == Visibility.Visible && !Part_IsEdit.Text.Equals(Text))
    //    {
    //        Part_IsEdit.Text = Text;
    //    }

    //    if (IsEditDefaultText != null)
    //    {
    //        if (ShowDefaultText() && defaultText.Visibility != 0)
    //        {
    //            IsEditDefaultText.Visibility = Visibility.Visible;
    //        }
    //        else
    //        {
    //            IsEditDefaultText.Visibility = Visibility.Collapsed;
    //        }
    //    }
    //}

    //private void Popup_Opened(object sender, EventArgs e)
    //{
    //    if (IsEditable && Part_IsEdit != null && Part_IsEdit.IsVisible)
    //    {
    //        Part_IsEdit.Focus();
    //    }
    //}

    //private void ComboBoxAdv_GotFocus(object sender, RoutedEventArgs e)
    //{
    //    if (IsEditDefaultText != null && IsEditDefaultText.IsVisible)
    //    {
    //        IsEditDefaultText.Visibility = Visibility.Collapsed;
    //    }

    //    if (Part_IsEdit != null && Part_IsEdit.IsVisible && !IsDropDownOpen)
    //    {
    //        Part_IsEdit.Focus();
    //    }
    //}

    //private void Part_IsEdit_GotFocus(object sender, RoutedEventArgs e)
    //{
    //    if (base.SelectedItem != null && sender is TextBox)
    //    {
    //        if (KeyPressed == Key.Enter && !AllowMultiSelect)
    //        {
    //            (sender as TextBox).SelectionStart = base.SelectedItem.ToString().Count();
    //            return;
    //        }

    //        (sender as TextBox).SelectionStart = 0;
    //        (sender as TextBox).SelectionLength = base.SelectedItem.ToString().Count();
    //    }
    //}

    //private void Part_IsEdit_LostFocus(object sender, RoutedEventArgs e)
    //{
    //    if (IsEditable && KeyPressed != Key.Up && KeyPressed != Key.Down && KeyPressed != Key.Home && KeyPressed != Key.End && KeyPressed != Key.Escape)
    //    {
    //        ValidateItem(Key.Enter);
    //    }

    //    if (Part_IsEdit != null && string.IsNullOrEmpty(Part_IsEdit.Text) && IsEditDefaultText != null && IsEditDefaultText.Visibility == Visibility.Collapsed)
    //    {
    //        if (EnableToken && tokenItemsControl != null && tokenItemsControl.Items.Count != 0)
    //        {
    //            IsEditDefaultText.Visibility = Visibility.Collapsed;
    //        }
    //        else
    //        {
    //            IsEditDefaultText.Visibility = Visibility.Visible;
    //        }
    //    }

    //    if (sender is TextBox)
    //    {
    //        searchText = "";
    //    }
    //}

    //private void Part_IsEdit_PreviewKeyDown(object sender, KeyEventArgs e)
    //{
    //    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key == Key.Tab)
    //    {
    //        if (!AllowMultiSelect && IsEditable)
    //        {
    //            base.Focusable = false;
    //        }
    //    }
    //    else if (e.Key != Key.Back && e.Key != Key.Delete)
    //    {
    //        if (char.IsLetter(e.Key.ToString().ToCharArray()[0]))
    //        {
    //            _keypressed = true;
    //        }
    //    }
    //    else
    //    {
    //        _keypressed = false;
    //        isBackspaceOrDeleteKeyPressed = true;
    //        base.SelectedItem = null;
    //    }
    //}

    //private void Part_IsEdit_TextChanged(object sender, TextChangedEventArgs e)
    //{
    //    if (Part_IsEdit != null && Part_IsEdit.Visibility == Visibility.Visible)
    //    {
    //        OnTextChanged(Part_IsEdit.Text);
    //        if (!Part_IsEdit.Text.Equals(Text))
    //        {
    //            Text = Part_IsEdit.Text;
    //        }

    //        if (IsEditDefaultText != null && IsEditDefaultText.IsVisible && !string.IsNullOrEmpty(Part_IsEdit.Text))
    //        {
    //            IsEditDefaultText.Visibility = Visibility.Collapsed;
    //        }
    //    }
    //}

    //private void MainWindow_Deactivated(object sender, EventArgs e)
    //{
    //    if (IsDropDownOpen)
    //    {
    //        IsDropDownOpen = false;
    //    }
    //}

    //private void MainWindow_LocationChanged(object sender, EventArgs e)
    //{
    //    if (IsDropDownOpen)
    //    {
    //        IsDropDownOpen = false;
    //    }
    //}

    //private void popup_Closed(object sender, EventArgs e)
    //{
    //    if (IsDropDownOpen)
    //    {
    //        IsDropDownOpen = false;
    //    }
    //}

    //private void ComboBoxAdv_Unloaded(object sender, RoutedEventArgs e)
    //{
    //    if (VisualUtils.FindAncestor(this, typeof(Window)) is Window window)
    //    {
    //        window.LocationChanged -= MainWindow_LocationChanged;
    //        window.Deactivated -= MainWindow_Deactivated;
    //    }
    //}

    //private void OnCancelButtonClick(object sender, RoutedEventArgs e)
    //{
    //    if (EnableToken && IsTokenRemoved)
    //    {
    //        if (AutoCompleteMode == AutoCompleteModes.Suggest)
    //        {
    //            RefreshFilter();
    //        }

    //        ResetTokenItems();
    //    }

    //    IsTokenRemoved = false;
    //    IsDropDownOpen = false;
    //}

    //private void OnOKButtonClick(object sender, RoutedEventArgs e)
    //{
    //    UpdateSelectedItems();
    //    IsDropDownOpen = false;
    //}

    ////
    //// Summary:
    ////     Updates the SelectAllCheckBox state when changing the value to other items.
    //protected internal void UpdateSelectAllItemState()
    //{
    //    if (!internalSelect && AllowMultiSelect && AllowSelectAll && SelectAllItem != null && SelectAllItem.CheckBox != null && SelItemsInternal != null)
    //    {
    //        int count = SelItemsInternal.Count;
    //        internalSelect = true;
    //        if (count == 0)
    //        {
    //            SelectAllItem.CheckBox.IsThreeState = false;
    //            SelectAllItem.IsSelected = false;
    //            SelectAllItem.CheckBox.IsChecked = false;
    //        }
    //        else if (count == base.Items.Count)
    //        {
    //            SelectAllItem.CheckBox.IsThreeState = false;
    //            SelectAllItem.IsSelected = true;
    //            SelectAllItem.CheckBox.IsChecked = true;
    //        }
    //        else
    //        {
    //            SelectAllItem.CheckBox.IsThreeState = true;
    //            SelectAllItem.IsSelected = false;
    //            SelectAllItem.CheckBox.IsChecked = null;
    //        }

    //        internalSelect = false;
    //    }
    //}

    //protected internal void ResetSelectedItems()
    //{
    //    if (ChangedItems.Count == 0)
    //    {
    //        return;
    //    }

    //    internalChange = true;
    //    ChangedItems.ForEach(delegate (object item)
    //    {
    //        if (SelItemsInternal.Contains(item))
    //        {
    //            SelItemsInternal.Remove(item);
    //        }
    //        else if (!SelItemsInternal.Contains(item))
    //        {
    //            SelItemsInternal.Add(item);
    //        }
    //    });
    //    internalChange = false;
    //}

    //protected internal void UpdateSelectedItems()
    //{
    //    internalChange = true;
    //    List<object> addedItems = new List<object>();
    //    List<object> removedItems = new List<object>();
    //    ChangedItems.ForEach(delegate (object item)
    //    {
    //        if (SelItemsInternal.Contains(item))
    //        {
    //            addedItems.Add(item);
    //        }
    //        else
    //        {
    //            removedItems.Add(item);
    //        }
    //    });
    //    if (SelItemsInternal.Count > 0)
    //    {
    //        ComboBoxItemAdv comboBoxItemAdv = base.ItemContainerGenerator.ContainerFromItem(SelItemsInternal[0]) as ComboBoxItemAdv;
    //        int selectedIndex = -1;
    //        if (comboBoxItemAdv != null)
    //        {
    //            selectedIndex = base.ItemContainerGenerator.IndexFromContainer(comboBoxItemAdv);
    //        }

    //        base.SelectedIndex = selectedIndex;
    //        if (EnableOKCancel && EnableToken && IsEditable && AllowMultiSelect)
    //        {
    //            UpdateToken();
    //        }

    //        if (base.ItemsSource != null)
    //        {
    //            if (comboBoxItemAdv != null && comboBoxItemAdv.DataContext != null)
    //            {
    //                base.SelectedItem = comboBoxItemAdv.DataContext;
    //            }
    //            else
    //            {
    //                base.SelectedItem = comboBoxItemAdv;
    //            }
    //        }
    //        else if (comboBoxItemAdv != null)
    //        {
    //            SetSelectionBoxItem(comboBoxItemAdv.Content);
    //        }
    //        else
    //        {
    //            SetSelectionBoxItem(comboBoxItemAdv);
    //        }
    //    }
    //    else
    //    {
    //        if (EnableToken && Part_IsEdit != null)
    //        {
    //            Part_IsEdit.Text = string.Empty;
    //        }

    //        base.SelectedItem = null;
    //    }

    //    internalChange = false;
    //    FireOnSelectionChanged(removedItems, addedItems);
    //    UpdateSelectionBox();
    //    ChangedItems.Clear();
    //}

    ////
    //// Summary:
    ////     Called while press cancel button or esc key after remove the token
    //private void ResetTokenItems()
    //{
    //    ICollectionView collectionView;
    //    if (base.ItemsSource == null || AutoCompleteMode != AutoCompleteModes.Suggest)
    //    {
    //        ICollectionView items = base.Items;
    //        collectionView = items;
    //    }
    //    else
    //    {
    //        collectionView = CollectionViewSource.GetDefaultView(base.ItemsSource);
    //    }

    //    ICollectionView collectionView2 = collectionView;
    //    List<string> list = new List<string>();
    //    foreach (object item in SelItemsInternal)
    //    {
    //        string text = ((base.ItemsSource != null && !string.IsNullOrEmpty(base.DisplayMemberPath)) ? GetDisplayMemberValue(item).ToString() : ((base.ItemsSource == null && item is ComboBoxItemAdv) ? (item as ComboBoxItemAdv).Content.ToString() : item.ToString()));
    //        if (text != null)
    //        {
    //            list.Add(text);
    //        }
    //    }

    //    foreach (object item2 in collectionView2)
    //    {
    //        string text2 = ((base.ItemsSource == null && item2 is ComboBoxItemAdv) ? (item2 as ComboBoxItemAdv).Content.ToString() : ((!string.IsNullOrEmpty(base.DisplayMemberPath)) ? GetDisplayMemberValue(item2).ToString() : item2.ToString()));
    //        if (!list.Contains(text2) && AddedTokenItems.Contains(text2.ToString()))
    //        {
    //            SelItemsInternal.Add(item2);
    //        }
    //    }

    //    if (IsEditDefaultText != null)
    //    {
    //        if (ShowDefaultText())
    //        {
    //            IsEditDefaultText.Visibility = Visibility.Visible;
    //        }
    //        else
    //        {
    //            IsEditDefaultText.Visibility = Visibility.Collapsed;
    //        }
    //    }
    //}

    ////
    //// Summary:
    ////     Called to show and hide the Default text while it is enabled
    //private bool ShowDefaultText()
    //{
    //    if (Part_IsEdit != null && string.IsNullOrEmpty(Part_IsEdit.Text) && IsEditDefaultText != null && !string.IsNullOrEmpty(IsEditDefaultText.Text) && SelItemsInternal.Count == 0)
    //    {
    //        return base.SelectedItem == null;
    //    }

    //    return false;
    //}

    //private static void OnMouseButtonDown(object sender, MouseButtonEventArgs e)
    //{
    //    if (sender is ComboBoxAdv comboBoxAdv)
    //    {
    //        if (!comboBoxAdv.IsKeyboardFocusWithin)
    //        {
    //            comboBoxAdv.Focus();
    //        }

    //        e.Handled = true;
    //        if (e.OriginalSource == comboBoxAdv)
    //        {
    //            comboBoxAdv.Close();
    //        }
    //    }
    //}

    ////
    //// Summary:
    ////     Called while mouse left button click on Part_IsEdit textbox
    ////
    //// Parameters:
    ////   sender:
    ////
    ////   e:
    //private static void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    //{
    //    if (sender is TextBox textBox && textBox.TemplatedParent is ComboBoxAdv && textBox.TemplatedParent is ComboBoxAdv comboBoxAdv)
    //    {
    //        comboBoxAdv.Dispatcher.Invoke(new Action(comboBoxAdv.CloseDropDown), DispatcherPriority.Normal, new object[0]);
    //    }
    //}

    ////
    //// Summary:
    ////     Method used to close the dropdown while clicking on the Part_IsEdit textbox.
    //private void CloseDropDown()
    //{
    //    if (IsDropDownOpen)
    //    {
    //        IsDropDownOpen = false;
    //    }
    //}

    //private static void OnMouseWheel(object sender, MouseWheelEventArgs e)
    //{
    //    ComboBoxAdv comboBoxAdv = sender as ComboBoxAdv;
    //    if (comboBoxAdv != null && comboBoxAdv.IsKeyboardFocusWithin)
    //    {
    //        comboBoxAdv.IsGotKeyBoardFocus = true;
    //        e.Handled = true;
    //    }

    //    if (comboBoxAdv != null && comboBoxAdv.IsDropDownOpen)
    //    {
    //        e.Handled = true;
    //    }
    //}

    //internal void Close()
    //{
    //    if (IsDropDownOpen)
    //    {
    //        ClearValue(IsDropDownOpenProperty);
    //        if (IsDropDownOpen)
    //        {
    //            IsDropDownOpen = false;
    //            popup.IsOpen = false;
    //        }
    //    }
    //}

    //private void ComboBoxAdv_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //{
    //    if (base.SelectedIndex >= 0 && base.SelectedItem != null && !AllowMultiSelect)
    //    {
    //        SelItemsInternal.Clear();
    //        bool? isSynchronizedWithCurrentItem = base.IsSynchronizedWithCurrentItem;
    //        if (isSynchronizedWithCurrentItem.HasValue && isSynchronizedWithCurrentItem == false)
    //        {
    //            SelItemsInternal.Add(base.SelectedItem);
    //        }
    //    }

    //    UpdateSelectionBox();
    //    if (DropDownContentTemplate != null && sender is ComboBoxAdv { SelectedItem: null } comboBoxAdv && e.RemovedItems.Count > 0)
    //    {
    //        comboBoxAdv.SelectedItem = e.RemovedItems[0];
    //    }
    //}

    //internal void UpdateSelectMode()
    //{
    //    if (selectedItems != null && selectedContent != null)
    //    {
    //        if (AllowMultiSelect)
    //        {
    //            if (EnableToken && IsEditable)
    //            {
    //                selectedItems.Visibility = Visibility.Collapsed;
    //            }
    //            else
    //            {
    //                selectedItems.Visibility = Visibility.Visible;
    //            }

    //            selectedContent.Visibility = Visibility.Collapsed;
    //        }
    //        else
    //        {
    //            selectedItems.Visibility = Visibility.Collapsed;
    //            if (!IsEditable && Part_IsEdit != null && !Part_IsEdit.IsVisible)
    //            {
    //                selectedContent.Visibility = Visibility.Visible;
    //            }
    //        }
    //    }

    //    for (int i = 0; i < base.Items.Count; i++)
    //    {
    //        ComboBoxItemAdv item = base.ItemContainerGenerator.ContainerFromIndex(i) as ComboBoxItemAdv;
    //        UpdateCheckBoxVisibility(item);
    //    }
    //}

    //private void UpdateCheckBoxVisibility(ComboBoxItemAdv item)
    //{
    //    if (item != null && item.CheckBox != null)
    //    {
    //        if (AllowMultiSelect)
    //        {
    //            item.CheckBox.Visibility = Visibility.Visible;
    //        }
    //        else
    //        {
    //            item.CheckBox.Visibility = Visibility.Collapsed;
    //        }
    //    }
    //}

    //internal void UpdateItemSelectMode(ComboBoxItemAdv item)
    //{
    //    if (selectedItems != null && selectedContent != null)
    //    {
    //        if (AllowMultiSelect)
    //        {
    //            if (EnableToken && IsEditable)
    //            {
    //                selectedItems.Visibility = Visibility.Collapsed;
    //            }
    //            else
    //            {
    //                selectedItems.Visibility = Visibility.Visible;
    //            }

    //            selectedContent.Visibility = Visibility.Collapsed;
    //        }
    //        else
    //        {
    //            selectedItems.Visibility = Visibility.Collapsed;
    //            if (!IsEditable && Part_IsEdit != null && !Part_IsEdit.IsVisible)
    //            {
    //                selectedContent.Visibility = Visibility.Visible;
    //            }
    //        }
    //    }

    //    UpdateCheckBoxVisibility(item);
    //}

    //internal void UpdateDefaultTextVisibility()
    //{
    //    ObservableCollection<object> observableCollection = null;
    //    if (SelectedItems != null)
    //    {
    //        observableCollection = new ObservableCollection<object>(SelectedItems.Cast<object>());
    //    }

    //    if (defaultText == null)
    //    {
    //        return;
    //    }

    //    if (AllowMultiSelect)
    //    {
    //        if (observableCollection != null && observableCollection.Count == 0 && (!IsEditable || !EnableToken))
    //        {
    //            defaultText.Visibility = Visibility.Visible;
    //        }
    //        else
    //        {
    //            defaultText.Visibility = Visibility.Collapsed;
    //        }
    //    }
    //    else
    //    {
    //        if (IsEditable)
    //        {
    //            return;
    //        }

    //        if (base.SelectedItem == null)
    //        {
    //            defaultText.Visibility = Visibility.Visible;
    //            if (Part_IsEdit != null && string.IsNullOrEmpty(Part_IsEdit.Text) && IsEditable && defaultText != null && !defaultText.Text.Equals(Part_IsEdit.Text))
    //            {
    //                defaultText.Visibility = Visibility.Collapsed;
    //            }
    //        }
    //        else
    //        {
    //            defaultText.Visibility = Visibility.Collapsed;
    //        }
    //    }
    //}

    //internal void UpdateSelectionBox()
    //{
    //    if (SelectionBoxTemplate == null && base.ItemsSource != null && base.ItemTemplate != null)
    //    {
    //        SelectionBoxTemplate = base.ItemTemplate;
    //    }

    //    if (base.SelectedItem == null && selectedContent != null && SelectionBoxTemplate != null)
    //    {
    //        selectedContent.ContentTemplate = null;
    //    }
    //    else if (base.SelectedItem != null && selectedContent != null && SelectionBoxTemplate != null)
    //    {
    //        selectedContent.ContentTemplate = SelectionBoxTemplate;
    //    }

    //    if (SelectedItems == null)
    //    {
    //        return;
    //    }

    //    internalChange = false;
    //    ObservableCollection<object> observableCollection = new ObservableCollection<object>(SelectedItems.Cast<object>());
    //    if (AllowMultiSelect)
    //    {
    //        if ((base.SelectedItem == null || base.SelectedIndex < 0) && SelItemsInternal != null && SelItemsInternal.Count > 0)
    //        {
    //            for (int j = 0; j < SelItemsInternal.Count; j++)
    //            {
    //                if (base.SelectedItem != SelItemsInternal[j])
    //                {
    //                    base.SelectedItem = SelItemsInternal[j];
    //                    if (base.SelectedItem != null)
    //                    {
    //                        break;
    //                    }
    //                }
    //            }

    //            if (base.SelectedItem is ComboBoxItemAdv)
    //            {
    //                if ((base.SelectedItem as ComboBoxItemAdv).Content != null)
    //                {
    //                    SetSelectionBoxItem((base.SelectedItem as ComboBoxItemAdv).Content);
    //                }
    //            }
    //            else if (SelectionBoxItem == null || SelectionBoxItem != base.SelectedItem)
    //            {
    //                SetSelectionBoxItem(base.SelectedItem);
    //            }
    //        }

    //        if (selectedItems != null && SelectedItems != null)
    //        {
    //            ItemsControl itemsControl = null;
    //            if (IsEditable && EnableToken && tokenItemsControl != null)
    //            {
    //                itemsControl = tokenItemsControl;
    //                while (itemsControl.Items.Count > 1)
    //                {
    //                    itemsControl.Items.RemoveAt(0);
    //                }
    //            }
    //            else
    //            {
    //                itemsControl = selectedItems;
    //                itemsControl.Items.Clear();
    //            }

    //            foreach (object item in SelItemsInternal)
    //            {
    //                ContentControl contentControl = new ContentControl();
    //                contentControl.ContentTemplate = SelectionBoxTemplate;
    //                contentControl.IsTabStop = false;
    //                if (item == null || (AutoCompleteMode != AutoCompleteModes.Suggest && !base.Items.Contains(item)))
    //                {
    //                    continue;
    //                }

    //                if (item is ComboBoxItemAdv)
    //                {
    //                    ComboBoxItemAdv comboBoxItemAdv = item as ComboBoxItemAdv;
    //                    SelectItems();
    //                    contentControl.Content = comboBoxItemAdv.Content;
    //                }
    //                else if (!string.IsNullOrEmpty(base.DisplayMemberPath))
    //                {
    //                    Type type = item.GetType();
    //                    PropertyInfo property = type.GetProperty(base.DisplayMemberPath, BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);
    //                    if (property == null && base.DisplayMemberPath.Contains('.'))
    //                    {
    //                        string text = string.Empty;
    //                        string text2 = string.Empty;
    //                        PropertyInfo propertyInfo = null;
    //                        if (!string.IsNullOrEmpty(base.DisplayMemberPath.Split('.')[0]))
    //                        {
    //                            text = base.DisplayMemberPath.Split('.')[0];
    //                        }

    //                        if (!string.IsNullOrEmpty(base.DisplayMemberPath.Split('.')[1]))
    //                        {
    //                            text2 = base.DisplayMemberPath.Split('.')[1];
    //                        }

    //                        if (!string.IsNullOrEmpty(text))
    //                        {
    //                            object value = type.GetProperty(text, BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty).GetValue(item, null);
    //                            if (value != null)
    //                            {
    //                                Type type2 = value.GetType();
    //                                if (!string.IsNullOrEmpty(text2))
    //                                {
    //                                    propertyInfo = type2.GetProperty(text2, BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);
    //                                    contentControl.Content = propertyInfo.GetValue(value, null);
    //                                }
    //                            }
    //                        }
    //                    }
    //                    else if (null != property)
    //                    {
    //                        Binding binding = new Binding(base.DisplayMemberPath)
    //                        {
    //                            Source = item,
    //                            Mode = ((!(property.GetSetMethod() != null)) ? BindingMode.OneWay : BindingMode.TwoWay),
    //                            UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
    //                        };
    //                        contentControl.SetBinding(ContentControl.ContentProperty, binding);
    //                    }
    //                    else if (item is DataRowView)
    //                    {
    //                        int num = -1;
    //                        foreach (DataColumn column in (item as DataRowView).DataView.Table.Columns)
    //                        {
    //                            num++;
    //                            if (column.Caption == base.DisplayMemberPath)
    //                            {
    //                                contentControl.Content = (item as DataRowView).Row[num];
    //                            }
    //                        }
    //                    }
    //                    else
    //                    {
    //                        if (!(item is ExpandoObject))
    //                        {
    //                            throw new InvalidOperationException("DisplayMemberPath has invalid property name");
    //                        }

    //                        contentControl.Content = (item as ExpandoObject).Where<KeyValuePair<string, object>>((KeyValuePair<string, object> i) => i.Key == base.DisplayMemberPath).FirstOrDefault().Value;
    //                    }
    //                }
    //                else
    //                {
    //                    contentControl.Content = item;
    //                }

    //                if (IsEditable && EnableToken && tokenItemsControl != null)
    //                {
    //                    itemsControl.Items.Insert((itemsControl.Items.Count > 0) ? (itemsControl.Items.Count - 1) : 0, new ComboBoxTokenItem
    //                    {
    //                        Content = contentControl
    //                    });
    //                }
    //                else
    //                {
    //                    itemsControl.Items.Add(contentControl);
    //                }

    //                if (SelItemsInternal.IndexOf(item) < observableCollection.Count - 1 && (!EnableToken || !IsEditable))
    //                {
    //                    itemsControl.Items.Add(SelectedValueDelimiter);
    //                }
    //            }

    //            if (itemsControl.Items.Count > 0 && (!EnableToken || !IsEditable))
    //            {
    //                for (int k = 0; k < itemsControl.Items.Count; k++)
    //                {
    //                    if (SelectedValueDelimiter == itemsControl.Items[k].ToString() && itemsControl.Items.Count == k + 1)
    //                    {
    //                        itemsControl.Items.RemoveAt(k);
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    else
    //    {
    //        if (base.SelectedItem != null)
    //        {
    //            if (base.SelectedItem is ComboBoxItemAdv)
    //            {
    //                SetSelectionBoxItem((base.SelectedItem as ComboBoxItemAdv).Content);
    //            }
    //            else if (SelectionBoxItem == null || SelectionBoxItem != base.SelectedItem)
    //            {
    //                SetSelectionBoxItem(base.SelectedItem);
    //            }
    //        }

    //        if (selectedContent != null && base.SelectedItem != null && SelectionBoxTemplate != null)
    //        {
    //            selectedContent.ContentTemplate = SelectionBoxTemplate;
    //            if (base.DisplayMemberPath == string.Empty)
    //            {
    //                selectedContent.Content = base.SelectedItem;
    //            }
    //            else
    //            {
    //                PropertyInfo property2 = base.SelectedItem.GetType().GetProperty(base.DisplayMemberPath, BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);
    //                if (!(null != property2))
    //                {
    //                    throw new InvalidOperationException("DisplayMemberPath has invalid property name");
    //                }

    //                selectedContent.Content = property2.GetValue(base.SelectedItem, null);
    //            }
    //        }
    //    }

    //    UpdateDefaultTextVisibility();
    //}

    //
    // Parameters:
    //   e:
    protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
    {
        //if (isFilter && AllowMultiSelect)
        //{
        //    return;
        //}

        base.OnItemsChanged(e);
        //UpdateNoRecords();
        //if (AllowMultiSelect && AllowSelectAll)
        //{
        //    UpdateSelectAllItemState();
        //}

        //UpdateSelectionBox();
        //if (e.Action != NotifyCollectionChangedAction.Remove || e.OldItems == null || e.OldItems.Count <= 0 || SelItemsInternal == null || SelItemsInternal.Count <= 0)
        //{
        //    return;
        //}

        //foreach (object oldItem in e.OldItems)
        //{
        //    if (oldItem != null && SelItemsInternal.Contains(oldItem))
        //    {
        //        SelItemsInternal.Remove(oldItem);
        //    }
        //}
    }

    //
    // Summary:
    //     Override TextInput
    //
    // Parameters:
    //   e:
    protected override void OnTextInput(TextCompositionEventArgs e)
    {
        //if (base.IsTextSearchEnabled && ((base.ItemsSource != null && AutoCompleteMode == AutoCompleteModes.None) || base.ItemsSource == null))
        //{
        //    if (e.Text.Count() > 0)
        //    {
        //        newTempChar = e.Text[0];
        //        ReadOnlySpan<char> readOnlySpan = searchText;
        //        char reference = newTempChar;
        //        searchText = string.Concat(readOnlySpan, new ReadOnlySpan<char>(ref reference));
        //    }

        //    OnTextChanged(searchText);
        //    oldTempChar = newTempChar;
        //    timer.Start();
        //    _keypressed = false;
        //}

        base.OnTextInput(e);
    }

    //
    // Summary:
    //     Invoked on PreviewKeyDown
    //
    // Parameters:
    //   e:
    protected override void OnPreviewKeyDown(KeyEventArgs e)
    {
        //ComboBoxItemAdv comboBoxItemAdv = null;
        //int num = -1;
        //if (e.OriginalSource is ComboBoxItemAdv)
        //{
        //    comboBoxItemAdv = e.OriginalSource as ComboBoxItemAdv;
        //    if (comboBoxItemAdv == null)
        //    {
        //        comboBoxItemAdv = base.ItemContainerGenerator.ContainerFromItem(e.OriginalSource) as ComboBoxItemAdv;
        //    }

        //    num = base.ItemContainerGenerator.IndexFromContainer(comboBoxItemAdv);
        //}
        //else if (e.OriginalSource is ComboBoxAdv && (e.OriginalSource as ComboBoxAdv).SelectedItem != null)
        //{
        //    comboBoxItemAdv = (e.OriginalSource as ComboBoxAdv).SelectedItem as ComboBoxItemAdv;
        //    if (!AllowMultiSelect)
        //    {
        //        if (comboBoxItemAdv == null)
        //        {
        //            comboBoxItemAdv = GetItemContainer((e.OriginalSource as ComboBoxAdv).SelectedItem);
        //        }

        //        num = base.SelectedIndex;
        //    }
        //    else if (SelItemsInternal != null && SelItemsInternal.Count > 0 && base.Items.Count > 0)
        //    {
        //        if (comboBoxItemAdv == null)
        //        {
        //            comboBoxItemAdv = GetItemContainer(SelItemsInternal[SelItemsInternal.Count - 1]);
        //        }

        //        num = base.Items.IndexOf(SelItemsInternal[SelItemsInternal.Count - 1]);
        //    }
        //}
        //else if (IsEditable && !AllowMultiSelect)
        //{
        //    if (base.SelectedItem is ComboBoxItemAdv)
        //    {
        //        comboBoxItemAdv = base.SelectedItem as ComboBoxItemAdv;
        //    }
        //    else if (base.SelectedIndex != -1 && base.ItemContainerGenerator.ContainerFromIndex(base.SelectedIndex) is ComboBoxItemAdv)
        //    {
        //        comboBoxItemAdv = base.ItemContainerGenerator.ContainerFromIndex(base.SelectedIndex) as ComboBoxItemAdv;
        //    }
        //}

        //if (e.KeyboardDevice.Modifiers == ModifierKeys.Alt && (e.SystemKey == Key.Down || e.SystemKey == Key.Up))
        //{
        //    if (Part_IsEdit != null)
        //    {
        //        Part_IsEdit.Focus();
        //    }

        //    IsDropDownOpen = !IsDropDownOpen;
        //    if (!AllowMultiSelect && IsEditable && Part_IsEdit != null && base.SelectedIndex != -1 && string.IsNullOrEmpty(Part_IsEdit.Text))
        //    {
        //        UpdateSelectedText(base.SelectedItem);
        //        Part_IsEdit.SelectionStart = Part_IsEdit.Text.Length;
        //    }

        //    DropDownScrollBar.ScrollToVerticalOffset(base.SelectedIndex);
        //}

        //if (e.Key == Key.Up || (!IsEditable && e.Key == Key.Left))
        //{
        //    isKeyDown = true;
        //    KeyPressed = e.Key;
        //    if (Part_IsEdit != null && Part_IsEdit.IsVisible && !IsDropDownOpen && base.SelectedIndex != 0)
        //    {
        //        Part_IsEdit.Text = "";
        //        searchText = "";
        //        if (base.SelectedItem != null)
        //        {
        //            num = base.Items.IndexOf(base.SelectedItem);
        //        }
        //    }
        //    else if (base.SelectedItem != null && num == -1)
        //    {
        //        num = base.Items.IndexOf(base.SelectedItem);
        //    }

        //    if (num == 0 && AllowMultiSelect && AllowSelectAll && !SelectAllItem.IsHighlighted)
        //    {
        //        SelectAllItem.Focus();
        //        e.Handled = true;
        //        base.OnPreviewKeyDown(e);
        //        return;
        //    }

        //    if (num == 0)
        //    {
        //        num = 0;
        //    }
        //    else if (num < 0)
        //    {
        //        num = -1;
        //    }
        //    else
        //    {
        //        int num2 = num;
        //        while (num2 < base.Items.Count && num2 > 0)
        //        {
        //            if (base.Items[num2 - 1] != null)
        //            {
        //                if (!(base.Items[num2 - 1] is ComboBoxItemAdv))
        //                {
        //                    num = num2 - 1;
        //                    break;
        //                }

        //                if ((base.Items[num2 - 1] as ComboBoxItemAdv).IsEnabled)
        //                {
        //                    num = num2 - 1;
        //                    break;
        //                }
        //            }

        //            num2--;
        //        }
        //    }

        //    if (num >= 0)
        //    {
        //        if (!IsDropDownOpen && !AllowMultiSelect)
        //        {
        //            if (base.SelectedIndex != -1)
        //            {
        //                if (base.SelectedItem is ComboBoxItemAdv)
        //                {
        //                    (base.SelectedItem as ComboBoxItemAdv).IsSelected = false;
        //                }
        //                else if (base.ItemContainerGenerator.ContainerFromItem(base.SelectedItem) != null && base.ItemContainerGenerator.ContainerFromItem(base.SelectedItem) is ComboBoxItemAdv comboBoxItemAdv2)
        //                {
        //                    comboBoxItemAdv2.IsSelected = false;
        //                }
        //            }

        //            base.SelectedIndex = num;
        //            ClearSelection();
        //        }
        //        else
        //        {
        //            ComboBoxItemAdv comboBoxItemAdv3 = base.ItemContainerGenerator.ContainerFromIndex(num) as ComboBoxItemAdv;
        //            comboBoxItemAdv3?.Focus();
        //            if (comboBoxItemAdv3 != null && IsEditable)
        //            {
        //                if (base.SelectedIndex >= 0 && base.ItemContainerGenerator.ContainerFromIndex(base.SelectedIndex) is ComboBoxItemAdv comboBoxItemAdv4 && !AllowMultiSelect)
        //                {
        //                    comboBoxItemAdv4.IsSelected = false;
        //                }

        //                if (!AllowMultiSelect)
        //                {
        //                    if (Part_IsEdit != null)
        //                    {
        //                        if (base.ItemsSource != null)
        //                        {
        //                            UpdateSelectedText(comboBoxItemAdv3.Content);
        //                        }
        //                        else
        //                        {
        //                            UpdateSelectedText(comboBoxItemAdv3);
        //                        }
        //                    }

        //                    comboBoxItemAdv3.IsHighlighted = true;
        //                }
        //            }
        //        }
        //    }

        //    RaiseValueChangedEvent();
        //    isKeyDown = false;
        //    e.Handled = true;
        //}
        //else if (e.Key == Key.Down || (!IsEditable && e.Key == Key.Right))
        //{
        //    KeyPressed = e.Key;
        //    isKeyDown = true;
        //    if (Part_IsEdit != null && Part_IsEdit.IsVisible && !IsDropDownOpen)
        //    {
        //        if (base.SelectedIndex == base.Items.Count - 1)
        //        {
        //            num = base.SelectedIndex;
        //        }
        //        else
        //        {
        //            Part_IsEdit.Text = "";
        //            searchText = "";
        //            if (base.SelectedItem != null && base.Items != null)
        //            {
        //                num = base.Items.IndexOf(base.SelectedItem);
        //            }
        //        }
        //    }
        //    else if (base.Items != null && base.SelectedItem != null && num == -1)
        //    {
        //        num = base.Items.IndexOf(base.SelectedItem);
        //    }

        //    if (num == -1 && AllowMultiSelect && AllowSelectAll && !SelectAllItem.IsHighlighted)
        //    {
        //        SelectAllItem.Focus();
        //        e.Handled = true;
        //        base.OnPreviewKeyDown(e);
        //        return;
        //    }

        //    if (num == base.Items.Count - 1)
        //    {
        //        num = base.Items.Count - 1;
        //    }
        //    else
        //    {
        //        for (int i = num; i + 1 < base.Items.Count; i++)
        //        {
        //            if (base.Items[i + 1] != null)
        //            {
        //                if (!(base.Items[i + 1] is ComboBoxItemAdv))
        //                {
        //                    num = i + 1;
        //                    break;
        //                }

        //                if ((base.Items[i + 1] as ComboBoxItemAdv).IsEnabled)
        //                {
        //                    num = i + 1;
        //                    break;
        //                }
        //            }
        //        }
        //    }

        //    if (num >= 0)
        //    {
        //        if (!IsDropDownOpen && !AllowMultiSelect)
        //        {
        //            if (base.SelectedIndex != -1)
        //            {
        //                if (base.SelectedItem is ComboBoxItemAdv)
        //                {
        //                    (base.SelectedItem as ComboBoxItemAdv).IsSelected = false;
        //                }
        //                else if (base.ItemContainerGenerator.ContainerFromItem(base.SelectedItem) != null && base.ItemContainerGenerator.ContainerFromItem(base.SelectedItem) is ComboBoxItemAdv comboBoxItemAdv5)
        //                {
        //                    comboBoxItemAdv5.IsSelected = false;
        //                }
        //            }

        //            base.SelectedIndex = num;
        //            ClearSelection();
        //        }
        //        else
        //        {
        //            if (AllowMultiSelect && AllowSelectAll && SelectAllItem.IsHighlighted && base.Items.Count > 0)
        //            {
        //                num = 0;
        //            }

        //            ComboBoxItemAdv comboBoxItemAdv6 = base.ItemContainerGenerator.ContainerFromIndex(num) as ComboBoxItemAdv;
        //            comboBoxItemAdv6?.Focus();
        //            if (comboBoxItemAdv6 != null && IsEditable)
        //            {
        //                if (base.SelectedIndex >= 0 && base.ItemContainerGenerator.ContainerFromIndex(base.SelectedIndex) is ComboBoxItemAdv comboBoxItemAdv7 && !AllowMultiSelect)
        //                {
        //                    comboBoxItemAdv7.IsSelected = false;
        //                }

        //                if (!AllowMultiSelect)
        //                {
        //                    if (Part_IsEdit != null)
        //                    {
        //                        if (base.ItemsSource != null)
        //                        {
        //                            UpdateSelectedText(comboBoxItemAdv6.Content);
        //                        }
        //                        else
        //                        {
        //                            UpdateSelectedText(comboBoxItemAdv6);
        //                        }
        //                    }

        //                    comboBoxItemAdv6.IsHighlighted = true;
        //                }
        //            }
        //        }
        //    }

        //    RaiseValueChangedEvent();
        //    isKeyDown = false;
        //    e.Handled = true;
        //}
        //else if (e.Key == Key.Back)
        //{
        //    if (EnableToken && AllowMultiSelect && IsEditable && Part_IsEdit != null && Part_IsEdit.Text == string.Empty)
        //    {
        //        IsTokenRemoved = true;
        //        if (SelItemsInternal.Count > 0)
        //        {
        //            SelItemsInternal.Remove(SelItemsInternal[SelItemsInternal.Count - 1]);
        //        }

        //        UpdateSelectionBox();
        //        Part_IsEdit.Focus();
        //    }

        //    if (Part_IsEdit != null && string.IsNullOrEmpty(Part_IsEdit.Text) && AutoCompleteMode == AutoCompleteModes.Suggest && IsEditable)
        //    {
        //        RefreshFilter();
        //        Part_IsEdit.Focus();
        //    }
        //}
        //else if (e.Key == Key.Enter)
        //{
        //    KeyPressed = e.Key;
        //    if (IsDropDownOpen && (comboBoxItemAdv != null || (EnableOKCancel && Part_IsEdit != null && string.IsNullOrEmpty(Part_IsEdit.Text))))
        //    {
        //        if (!AllowMultiSelect)
        //        {
        //            ClearSelection();
        //            if (base.SelectedIndex != -1)
        //            {
        //                if (base.SelectedItem is ComboBoxItemAdv)
        //                {
        //                    (base.SelectedItem as ComboBoxItemAdv).IsSelected = false;
        //                }
        //                else if (base.ItemContainerGenerator.ContainerFromItem(base.SelectedItem) != null && base.ItemContainerGenerator.ContainerFromItem(base.SelectedItem) is ComboBoxItemAdv comboBoxItemAdv8)
        //                {
        //                    comboBoxItemAdv8.IsSelected = false;
        //                }
        //            }

        //            if (comboBoxItemAdv != null)
        //            {
        //                comboBoxItemAdv.IsSelected = true;
        //            }
        //        }
        //        else if (IsDropDownOpen && !EnableOKCancel && comboBoxItemAdv != null)
        //        {
        //            comboBoxItemAdv.IsSelected = !comboBoxItemAdv.IsSelected;
        //        }

        //        if (AllowMultiSelect && EnableOKCancel)
        //        {
        //            UpdateSelectedItems();
        //        }

        //        e.Handled = true;
        //    }

        //    if (comboBoxItemAdv == null)
        //    {
        //        if (Part_IsEdit != null && Part_IsEdit.Text.Length > 0 && base.Items.Count < 1)
        //        {
        //            Part_IsEdit.SelectionStart = Part_IsEdit.Text.Length;
        //        }
        //        else
        //        {
        //            IsDropDownOpen = false;
        //            if (Part_IsEdit != null)
        //            {
        //                Part_IsEdit.SelectionStart = 0;
        //            }
        //        }
        //    }
        //    else if (comboBoxItemAdv != null)
        //    {
        //        IsDropDownOpen = false;
        //        if (Part_IsEdit != null)
        //        {
        //            Part_IsEdit.SelectionStart = 0;
        //        }
        //    }

        //    if (Part_IsEdit != null)
        //    {
        //        Part_IsEdit.Focus();
        //    }

        //    if (IsEditable && !AllowMultiSelect)
        //    {
        //        object obj = null;
        //        for (int j = 0; j < base.Items.Count; j++)
        //        {
        //            string text = ((base.ItemsSource == null) ? (base.Items[j] as ComboBoxItemAdv).Content.ToString() : ((!string.IsNullOrEmpty(base.DisplayMemberPath)) ? GetDisplayMemberValue(base.Items[j]).ToString() : base.Items[j].ToString()));
        //            if (Part_IsEdit != null && (Part_IsEdit.Text == text || Part_IsEdit.Text.ToLower() == text.ToLower()))
        //            {
        //                obj = base.Items[j];
        //                break;
        //            }
        //        }

        //        if (obj == null || base.SelectedItem != obj)
        //        {
        //            if (SelItemsInternal != null)
        //            {
        //                if (SelItemsInternal.Count > 0)
        //                {
        //                    SelItemsInternal.Clear();
        //                }

        //                if (obj != null)
        //                {
        //                    SelItemsInternal.Add(obj);
        //                }

        //                if (SelectedItems == null && SelItemsInternal.Count > 0)
        //                {
        //                    SelectedItems = SelItemsInternal;
        //                }
        //            }

        //            base.SelectedItem = ((obj != null) ? obj : null);
        //        }

        //        Part_IsEdit.SelectionStart = Part_IsEdit.Text.Length;
        //        if (comboBoxItemAdv == null && AutoCompleteMode == AutoCompleteModes.Suggest && base.Items.Count < 1)
        //        {
        //            IsDropDownOpen = true;
        //        }
        //    }

        //    GetBindingExpression(TextProperty)?.UpdateSource();
        //}
        //else if (e.Key == Key.Escape)
        //{
        //    KeyPressed = e.Key;
        //    if (IsDropDownOpen)
        //    {
        //        IsDropDownOpen = false;
        //        e.Handled = true;
        //    }

        //    if (Part_IsEdit != null && IsEditable)
        //    {
        //        if (!AllowMultiSelect)
        //        {
        //            if (base.SelectedIndex == -1)
        //            {
        //                Part_IsEdit.Text = string.Empty;
        //            }
        //            else
        //            {
        //                UpdateSelectedText(base.SelectedItem);
        //            }

        //            if (!string.IsNullOrEmpty(Part_IsEdit.Text))
        //            {
        //                Part_IsEdit.SelectionStart = Part_IsEdit.Text.Length;
        //            }
        //            else
        //            {
        //                Part_IsEdit.SelectionStart = 0;
        //            }
        //        }
        //        else if (AllowMultiSelect && EnableToken)
        //        {
        //            Part_IsEdit.Text = string.Empty;
        //            if (IsTokenRemoved && EnableOKCancel)
        //            {
        //                ResetTokenItems();
        //            }
        //        }

        //        Keyboard.Focus(Part_IsEdit);
        //    }

        //    IsTokenRemoved = false;
        //}
        //else if (e.Key == Key.Tab && e.KeyboardDevice.Modifiers == ModifierKeys.None)
        //{
        //    KeyPressed = Key.Enter;
        //    if (IsDropDownOpen)
        //    {
        //        IsDropDownOpen = false;
        //    }

        //    if (Part_IsEdit != null)
        //    {
        //        if (IsEditable)
        //        {
        //            ValidateItem(KeyPressed);
        //        }

        //        if (!AllowMultiSelect)
        //        {
        //            if (!string.IsNullOrEmpty(Part_IsEdit.Text))
        //            {
        //                Part_IsEdit.SelectionStart = Part_IsEdit.Text.Length;
        //            }

        //            Part_IsEdit.Focus();
        //        }
        //    }
        //}
        //else if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key == Key.Tab)
        //{
        //    if (AllowMultiSelect && IsEditable && EnableToken)
        //    {
        //        base.Focusable = false;
        //    }
        //}
        //else if (e.Key == Key.Space)
        //{
        //    if (IsDropDownOpen && AllowMultiSelect && e.OriginalSource is ComboBoxItemAdv)
        //    {
        //        if (AllowSelectAll && SelectAllItem.IsHighlighted)
        //        {
        //            SelectAllItem.IsSelected = !SelectAllItem.CheckBox.IsChecked.GetValueOrDefault();
        //        }
        //        else
        //        {
        //            ComboBoxItemAdv comboBoxItemAdv9 = (comboBoxItemAdv9 = base.ItemContainerGenerator.ContainerFromIndex(num) as ComboBoxItemAdv);
        //            if (comboBoxItemAdv9 != null && comboBoxItemAdv9.CheckBox != null)
        //            {
        //                comboBoxItemAdv9.CheckBox.IsChecked = !comboBoxItemAdv9.CheckBox.IsChecked;
        //            }
        //        }
        //    }
        //}
        //else if (e.Key == Key.F4)
        //{
        //    if ((e.KeyboardDevice.Modifiers & ModifierKeys.Alt) == 0)
        //    {
        //        IsDropDownOpen = !IsDropDownOpen;
        //        e.Handled = true;
        //    }
        //}
        //else if (e.Key == Key.Home && IsDropDownOpen)
        //{
        //    KeyPressed = e.Key;
        //    ComboBoxItemAdv comboBoxItemAdv10 = base.ItemContainerGenerator.ContainerFromIndex(0) as ComboBoxItemAdv;
        //    if (!AllowMultiSelect && base.Items.Count > 0 && IsEditable && Part_IsEdit != null)
        //    {
        //        if (base.ItemsSource != null)
        //        {
        //            UpdateSelectedText(comboBoxItemAdv10.Content);
        //        }
        //        else
        //        {
        //            UpdateSelectedText(comboBoxItemAdv10);
        //        }

        //        comboBoxItemAdv10.IsHighlighted = true;
        //    }

        //    if (AllowSelectAll && AllowMultiSelect)
        //    {
        //        SelectAllItem.Focus();
        //    }
        //    else
        //    {
        //        ClearSelection();
        //        comboBoxItemAdv10?.Focus();
        //    }
        //}
        //else if (e.Key == Key.End && IsDropDownOpen)
        //{
        //    KeyPressed = e.Key;
        //    DropDownScrollBar.ScrollToEnd();
        //    DropDownScrollBar.UpdateLayout();
        //    ComboBoxItemAdv comboBoxItemAdv11 = null;
        //    if (base.Items.Count > 0)
        //    {
        //        comboBoxItemAdv11 = base.ItemContainerGenerator.ContainerFromIndex(base.Items.Count - 1) as ComboBoxItemAdv;
        //    }

        //    if (!AllowMultiSelect && IsEditable && Part_IsEdit != null && comboBoxItemAdv11 != null)
        //    {
        //        if (base.ItemsSource != null)
        //        {
        //            UpdateSelectedText(comboBoxItemAdv11.Content);
        //        }
        //        else
        //        {
        //            UpdateSelectedText(comboBoxItemAdv11);
        //        }

        //        comboBoxItemAdv11.IsHighlighted = true;
        //    }

        //    ClearSelection();
        //    comboBoxItemAdv11?.Focus();
        //}
        //else if (char.IsLetter(e.Key.ToString().ToCharArray()[0]) && ((base.ItemsSource != null && AutoCompleteMode == AutoCompleteModes.None) || base.ItemsSource == null))
        //{
        //    if (!IsDropDownOpen && Part_IsEdit != null && !Part_IsEdit.IsVisible && base.IsTextSearchEnabled)
        //    {
        //        if (timer != null)
        //        {
        //            timer.Stop();
        //        }

        //        _keypressed = true;
        //    }

        //    if (IsDropDownOpen && base.IsTextSearchEnabled && base.ItemContainerGenerator.ContainerFromIndex(0) is ComboBoxItemAdv comboBoxItemAdv12)
        //    {
        //        comboBoxItemAdv12.Focus();
        //    }
        //}

        //if (AutoCompleteMode == AutoCompleteModes.Suggest && IsEditable && Part_IsEdit != null)
        //{
        //    isFilter = true;
        //    oldFilter = Part_IsEdit.Text;
        //}
        if (e.Key == Key.Return)
        {

        }

        //KeyPressed = Key.None;
        base.OnPreviewKeyDown(e);
    }

    //
    // Summary:
    //     Called on key press in combobox
    //
    // Parameters:
    //   e:
    //     Event argument
    protected override void OnKeyUp(KeyEventArgs e)
    {
        //if (e.Key == Key.Enter && IsEditable)
        //{
        //    KeyPressed = Key.Enter;
        //    if (Part_IsEdit != null && !string.IsNullOrEmpty(Part_IsEdit.Text))
        //    {
        //        ValidateItem(KeyPressed);
        //    }

        //    if (Part_IsEdit != null)
        //    {
        //        Part_IsEdit.Focus();
        //        if (AllowMultiSelect && EnableToken)
        //        {
        //            Part_IsEdit.SelectionStart = Part_IsEdit.Text.Length;
        //        }
        //    }
        //}

        //if (base.ItemsSource != null && AutoCompleteMode == AutoCompleteModes.Suggest && IsEditable && Part_IsEdit != null && Part_IsEdit.Text != oldFilter)
        //{
        //    RefreshFilter();
        //    IsDropDownOpen = true;
        //    Part_IsEdit.SelectionStart = int.MaxValue;
        //}
        if (e.Key == Key.Return)
        {

        }
        //KeyPressed = Key.None;
        base.OnKeyUp(e);

    
    }

    ////
    //// Summary:
    ////     To refresh the item source while suggest an item from dropdown
    //internal void RefreshFilter()
    //{
    //    if (base.ItemsSource != null)
    //    {
    //        ICollectionView defaultView = CollectionViewSource.GetDefaultView(base.ItemsSource);
    //        defaultView.Filter = (Predicate<object>)Delegate.Remove(defaultView.Filter, new Predicate<object>(FilterItem));
    //        defaultView.Filter = (Predicate<object>)Delegate.Combine(defaultView.Filter, new Predicate<object>(FilterItem));
    //        defaultView.Refresh();
    //        UpdateNoRecords();
    //    }
    //}

    //private void UpdateNoRecords()
    //{
    //    if (NoRecords == null)
    //    {
    //        return;
    //    }

    //    if (base.Items.Count == 0)
    //    {
    //        NoRecords.Visibility = Visibility.Visible;
    //        if (AllowMultiSelect && AllowSelectAll)
    //        {
    //            SelectAllItem.Visibility = Visibility.Collapsed;
    //        }
    //    }
    //    else
    //    {
    //        NoRecords.Visibility = Visibility.Collapsed;
    //        if (AllowMultiSelect && AllowSelectAll)
    //        {
    //            SelectAllItem.Visibility = Visibility.Visible;
    //        }
    //    }
    //}

    ////
    //// Summary:
    ////     Remove the existing items from token panel while press ok button
    ////
    //// Parameters:
    ////   tokenItem:
    ////     Item need to be removed
    //internal void RemoveToken(object tokenItem)
    //{
    //    int num = -1;
    //    for (int i = 0; i < SelItemsInternal.Count; i++)
    //    {
    //        string value = ((base.ItemsSource == null) ? (SelItemsInternal[i] as ComboBoxItemAdv).Content.ToString() : ((!string.IsNullOrEmpty(base.DisplayMemberPath)) ? GetDisplayMemberValue(SelItemsInternal[i]).ToString() : SelItemsInternal[i].ToString()));
    //        if ((tokenItem as ContentControl).Content.ToString().Equals(value))
    //        {
    //            num = i;
    //            break;
    //        }
    //    }

    //    IsTokenRemoved = true;
    //    lastRowTokenItemIndex = 0;
    //    if (num < SelItemsInternal.Count)
    //    {
    //        SelItemsInternal.RemoveAt(num);
    //    }

    //    UpdateSelectionBox();
    //    if (Part_IsEdit != null)
    //    {
    //        Part_IsEdit.Text = string.Empty;
    //        if (!IsDropDownOpen)
    //        {
    //            Part_IsEdit.Focus();
    //            Part_IsEdit.SelectionStart = 0;
    //        }
    //    }
    //}

    ////
    //// Summary:
    ////     Populate the display member path items
    ////
    //// Returns:
    ////     List of display member items
    //internal IList GetDisplayMemberItems()
    //{
    //    IList list = new List<string>();
    //    if (!string.IsNullOrEmpty(base.DisplayMemberPath))
    //    {
    //        foreach (object item in (IEnumerable)base.Items)
    //        {
    //            object displayMemberValue = GetDisplayMemberValue(item);
    //            if (displayMemberValue != null && !list.Contains(displayMemberValue.ToString()))
    //            {
    //                list.Add(displayMemberValue.ToString());
    //            }
    //        }
    //    }

    //    return list;
    //}

    ////
    //// Summary:
    ////     Method to get display member value based on provided object
    ////
    //// Parameters:
    ////   item:
    ////     Item
    //internal object GetDisplayMemberValue(object item)
    //{
    //    PropertyInfo property = item.GetType().GetProperty(base.DisplayMemberPath);
    //    if (!(property == null))
    //    {
    //        return property.GetValue(item, null);
    //    }

    //    return null;
    //}

    ////
    //// Summary:
    ////     To add the token in combobox
    ////
    //// Parameters:
    ////   text:
    ////     Actual search text
    ////
    ////   pressedkey:
    ////     Pressed key value
    //internal void AddToken(string text, Key pressedkey)
    //{
    //    List<string> list = new List<string>();
    //    if (base.ItemsSource == null)
    //    {
    //        foreach (object item in (IEnumerable)base.Items)
    //        {
    //            list.Add((item as ComboBoxItemAdv).Content.ToString());
    //        }
    //    }

    //    IList list2;
    //    if (base.ItemsSource != null)
    //    {
    //        if (string.IsNullOrEmpty(base.DisplayMemberPath))
    //        {
    //            IList items = base.Items;
    //            list2 = items;
    //        }
    //        else
    //        {
    //            list2 = GetDisplayMemberItems();
    //        }
    //    }
    //    else
    //    {
    //        IList items = list;
    //        list2 = items;
    //    }

    //    IList list3 = list2;
    //    if (list3.Contains(text) && pressedkey == Key.Enter)
    //    {
    //        foreach (object item2 in (IEnumerable)base.Items)
    //        {
    //            string text2 = ((base.ItemsSource == null) ? (item2 as ComboBoxItemAdv).Content.ToString() : ((!string.IsNullOrEmpty(base.DisplayMemberPath)) ? GetDisplayMemberValue(item2).ToString() : item2.ToString()));
    //            if (text2 == null)
    //            {
    //                continue;
    //            }

    //            foreach (string item3 in list3)
    //            {
    //                if (item3.Equals(text) && text.Equals(text2) && !SelItemsInternal.Contains(item2))
    //                {
    //                    SelItemsInternal.Add(item2);
    //                }
    //            }

    //            if (EnableOKCancel && text.Equals(text2) && AddedTokenItems != null && !AddedTokenItems.Contains(text2))
    //            {
    //                AddedTokenItems.Add(text2.ToString());
    //            }
    //        }

    //        SelectedItems = SelItemsInternal;
    //    }

    //    if (Part_IsEdit != null)
    //    {
    //        Part_IsEdit.Text = string.Empty;
    //    }
    //}

    //private void timer_Tick(object sender, EventArgs e)
    //{
    //    if (sender is DispatcherTimer)
    //    {
    //        (sender as DispatcherTimer).Stop();
    //        searchText = "";
    //    }
    //}

    ////
    //// Summary:
    ////     Used to validate the provided text while textbox lost its focus
    ////
    //// Parameters:
    ////   pressedkey:
    ////     Pressed key value
    //private void ValidateItem(Key pressedkey)
    //{
    //    for (int i = 0; i < base.Items.Count; i++)
    //    {
    //        ComboBoxItemAdv comboBoxItemAdv = base.Items[i] as ComboBoxItemAdv;
    //        string text = ((base.ItemsSource == null && comboBoxItemAdv != null) ? comboBoxItemAdv.Content.ToString() : (string.IsNullOrEmpty(base.DisplayMemberPath) ? base.Items[i].ToString() : ((GetDisplayMemberValue(base.Items[i]) != null) ? GetDisplayMemberValue(base.Items[i]).ToString() : null)));
    //        if (text != null && ((AutoCompleteMode == AutoCompleteModes.Suggest && !base.IsKeyboardFocusWithin) || AutoCompleteMode != AutoCompleteModes.Suggest) && Part_IsEdit != null && (Part_IsEdit.Text == text || Part_IsEdit.Text.ToLower() == text.ToLower()))
    //        {
    //            if (!AllowMultiSelect)
    //            {
    //                base.SelectedIndex = i;
    //                break;
    //            }

    //            AddToken(text, pressedkey);
    //        }
    //    }

    //    if (Part_IsEdit != null && !AllowMultiSelect && IsEditable && base.SelectedIndex != -1)
    //    {
    //        Part_IsEdit.Text = ((base.ItemsSource == null && base.Items[base.SelectedIndex] is ComboBoxItemAdv) ? (base.Items[base.SelectedIndex] as ComboBoxItemAdv).Content.ToString() : (string.IsNullOrEmpty(base.DisplayMemberPath) ? base.Items[base.SelectedIndex].ToString() : ((GetDisplayMemberValue(base.Items[base.SelectedIndex]) != null) ? GetDisplayMemberValue(base.Items[base.SelectedIndex]).ToString() : string.Empty)));
    //    }

    //    if (!AllowMultiSelect || SelectedItems != null || SelItemsInternal.Count <= 0)
    //    {
    //        return;
    //    }

    //    ObservableCollection<object> observableCollection = new ObservableCollection<object>();
    //    foreach (object item in SelItemsInternal)
    //    {
    //        observableCollection.Add(item);
    //    }

    //    SelectedItems = observableCollection;
    //}

    ////
    //// Summary:
    ////     Used to set the textbox's text for each item source
    ////
    //// Parameters:
    ////   item:
    //private void UpdateSelectedText(object item)
    //{
    //    if (Part_IsEdit == null)
    //    {
    //        return;
    //    }

    //    if (base.ItemsSource != null)
    //    {
    //        if (!string.IsNullOrEmpty(base.DisplayMemberPath))
    //        {
    //            Part_IsEdit.Text = GetDisplayMemberValue(item).ToString();
    //        }
    //        else
    //        {
    //            Part_IsEdit.Text = item.ToString();
    //        }
    //    }
    //    else if (item is ComboBoxItemAdv)
    //    {
    //        Part_IsEdit.Text = (item as ComboBoxItemAdv).Content.ToString();
    //    }
    //}

    ////
    //// Summary:
    ////     Handle the selected items when the item is checked.
    ////
    //// Parameters:
    ////   checkedItem:
    ////     checked item.
    ////
    ////   selectedItems:
    ////     Selected items.
    ////
    //// Returns:
    ////     The selected items.
    //protected internal override ObservableCollection<object> OnItemChecked(object checkedItem, ObservableCollection<object> selectedItems)
    //{
    //    return selectedItems;
    //}

    ////
    //// Summary:
    ////     Handle the selected items when the item is unchecked.
    ////
    //// Parameters:
    ////   unCheckedItem:
    ////     un checked item.
    ////
    ////   SelectedItems:
    ////     Selected Items
    //protected internal override ObservableCollection<object> OnItemUnchecked(object unCheckedItem, ObservableCollection<object> selectedItems)
    //{
    //    return selectedItems;
    //}

    //private void ClearSelection()
    //{
    //    if (AllowMultiSelect && AllowSelectAll && SelectAllItem != null && SelectAllItem.IsHighlighted)
    //    {
    //        SelectAllItem.IsHighlighted = false;
    //    }

    //    int count = base.Items.Count;
    //    for (int i = 0; i < count; i++)
    //    {
    //        object obj = base.Items[i];
    //        if (obj is ComboBoxItemAdv && (obj as ComboBoxItemAdv).IsHighlighted)
    //        {
    //            (obj as ComboBoxItemAdv).IsHighlighted = false;
    //        }
    //        else if (GetItemContainer(obj) != null && GetItemContainer(obj).IsHighlighted)
    //        {
    //            GetItemContainer(obj).IsHighlighted = false;
    //        }
    //    }
    //}

    //private static void OnAllowMultiSelectChanged(object sender, DependencyPropertyChangedEventArgs args)
    //{
    //    ComboBoxAdv comboBoxAdv = sender as ComboBoxAdv;
    //    comboBoxAdv.Focusable = true;
    //    if (comboBoxAdv != null && comboBoxAdv.SelItemsInternal != null)
    //    {
    //        if (!comboBoxAdv.AllowMultiSelect)
    //        {
    //            if (comboBoxAdv.SelectedItem == null && comboBoxAdv.SelectedIndex < 0 && comboBoxAdv.SelItemsInternal.Count > 0)
    //            {
    //                comboBoxAdv.SelectedItem = comboBoxAdv.SelItemsInternal[0];
    //                if (comboBoxAdv.SelectedItem is ComboBoxItemAdv)
    //                {
    //                    comboBoxAdv.SetSelectionBoxItem((comboBoxAdv.SelectedItem as ComboBoxItemAdv).Content);
    //                }
    //                else
    //                {
    //                    comboBoxAdv.SetSelectionBoxItem(comboBoxAdv.SelectedItem);
    //                }
    //            }

    //            if (comboBoxAdv.SelectedItem != null && comboBoxAdv.SelectedIndex < 0 && comboBoxAdv.SelItemsInternal.Count <= 0)
    //            {
    //                comboBoxAdv.SelectedItem = null;
    //            }

    //            comboBoxAdv.SelItemsInternal.Clear();
    //            foreach (object item in (IEnumerable)comboBoxAdv.Items)
    //            {
    //                if (comboBoxAdv.ItemContainerGenerator.ContainerFromItem(item) is ComboBoxItemAdv comboBoxItemAdv && comboBoxAdv.SelectedItem != null && comboBoxItemAdv.Content != null && !comboBoxItemAdv.Content.Equals(comboBoxAdv.SelectedItem))
    //                {
    //                    comboBoxItemAdv.IsSelected = false;
    //                }
    //            }

    //            if (comboBoxAdv.SelectedItem is ComboBoxItemAdv)
    //            {
    //                comboBoxAdv.SetSelectionBoxItem((comboBoxAdv.SelectedItem as ComboBoxItemAdv).Content);
    //            }
    //            else
    //            {
    //                comboBoxAdv.SetSelectionBoxItem(comboBoxAdv.SelectedItem);
    //            }

    //            if (comboBoxAdv.EnableToken)
    //            {
    //                comboBoxAdv.MinHeight = (double.IsNaN(comboBoxAdv.Height) ? 0.0 : comboBoxAdv.Height);
    //            }
    //        }

    //        if (comboBoxAdv.SelectedItem != null && comboBoxAdv.SelItemsInternal.Count <= 0)
    //        {
    //            comboBoxAdv.SelItemsInternal.Add(comboBoxAdv.SelectedItem);
    //        }

    //        comboBoxAdv.IsDropDownOpen = false;
    //        comboBoxAdv.UpdateSelectionBox();
    //        comboBoxAdv.UpdateDefaultTextVisibility();
    //        comboBoxAdv.UpdateSelectMode();
    //        comboBoxAdv.IsTokenRemoved = false;
    //    }

    //    if (comboBoxAdv.IsLoaded)
    //    {
    //        comboBoxAdv.OnFilterApplied();
    //    }
    //}

    ////
    //// Summary:
    ////     Called while AutoComplete mode is changed
    ////
    //// Parameters:
    ////   sender:
    ////     Sender of this event
    ////
    ////   e:
    ////     Event argument
    //private static void OnAutoCompleteModeChanged(object sender, DependencyPropertyChangedEventArgs e)
    //{
    //    ComboBoxAdv comboBoxAdv = sender as ComboBoxAdv;
    //    if (comboBoxAdv.IsLoaded)
    //    {
    //        if (comboBoxAdv.IsEditable && comboBoxAdv.AutoCompleteMode == AutoCompleteModes.Suggest && comboBoxAdv.ItemsSource != null)
    //        {
    //            ICollectionView defaultView = CollectionViewSource.GetDefaultView(comboBoxAdv.ItemsSource);
    //            defaultView.Filter = (Predicate<object>)Delegate.Remove(defaultView.Filter, new Predicate<object>(comboBoxAdv.FilterItem));
    //            defaultView.Filter = (Predicate<object>)Delegate.Combine(defaultView.Filter, new Predicate<object>(comboBoxAdv.FilterItem));
    //        }

    //        if (comboBoxAdv.AutoCompleteMode == AutoCompleteModes.None && comboBoxAdv.EnableOKCancel)
    //        {
    //            comboBoxAdv.RefreshFilter();
    //        }

    //        if (comboBoxAdv.AutoCompleteMode != AutoCompleteModes.Suggest && comboBoxAdv.ItemsSource != null)
    //        {
    //            ICollectionView defaultView2 = CollectionViewSource.GetDefaultView(comboBoxAdv.ItemsSource);
    //            defaultView2.Filter = (Predicate<object>)Delegate.Remove(defaultView2.Filter, new Predicate<object>(comboBoxAdv.FilterItem));
    //        }
    //    }
    //}

    ////
    //// Summary:
    ////     Called while changing the value of EnableToken at run time
    ////
    //// Parameters:
    ////   sender:
    ////     Sender of this event
    ////
    ////   e:
    ////     Event argument
    //private static void OnEnableTokenChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    //{
    //    ComboBoxAdv comboBoxAdv = sender as ComboBoxAdv;
    //    comboBoxAdv.Focusable = true;
    //    if (comboBoxAdv.EnableToken)
    //    {
    //        if (comboBoxAdv.AllowMultiSelect && comboBoxAdv.IsEditable)
    //        {
    //            if (comboBoxAdv.Part_IsEdit != null)
    //            {
    //                comboBoxAdv.Part_IsEdit.Text = string.Empty;
    //            }

    //            comboBoxAdv.UpdateToken();
    //            comboBoxAdv.UpdateSelectMode();
    //            if (comboBoxAdv.IsEditDefaultText != null)
    //            {
    //                comboBoxAdv.IsEditDefaultText.Visibility = Visibility.Collapsed;
    //            }
    //        }
    //    }
    //    else
    //    {
    //        if (comboBoxAdv.AutoCompleteMode == AutoCompleteModes.Suggest)
    //        {
    //            comboBoxAdv.RefreshFilter();
    //        }

    //        comboBoxAdv.UpdateSelectionBox();
    //        comboBoxAdv.UpdateSelectMode();
    //        comboBoxAdv.MinHeight = (double.IsNaN(comboBoxAdv.Height) ? 0.0 : comboBoxAdv.Height);
    //    }

    //    if (comboBoxAdv.IsEditDefaultText != null && comboBoxAdv.AllowMultiSelect)
    //    {
    //        if (!comboBoxAdv.EnableToken)
    //        {
    //            comboBoxAdv.IsEditDefaultText.Visibility = Visibility.Collapsed;
    //        }
    //        else if (comboBoxAdv.ShowDefaultText() && comboBoxAdv.IsEditable)
    //        {
    //            comboBoxAdv.IsEditDefaultText.Visibility = Visibility.Visible;
    //        }
    //    }

    //    comboBoxAdv.UpdateDefaultTextVisibility();
    //    if (comboBoxAdv.IsLoaded)
    //    {
    //        comboBoxAdv.OnFilterApplied();
    //    }
    //}

    ////
    //// Summary:
    ////     Called while changing the IsEditable value at run time
    ////
    //// Parameters:
    ////   sender:
    ////     Sender of this event
    ////
    ////   e:
    ////     Event argument
    //private static void OnIsEditableChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    //{
    //    ComboBoxAdv comboBoxAdv = sender as ComboBoxAdv;
    //    comboBoxAdv.Focusable = true;
    //    if (comboBoxAdv.AllowMultiSelect && comboBoxAdv.EnableToken && !comboBoxAdv.IsEditable)
    //    {
    //        comboBoxAdv.UpdateSelectMode();
    //        comboBoxAdv.MinHeight = (double.IsNaN(comboBoxAdv.Height) ? 0.0 : comboBoxAdv.Height);
    //    }
    //    else if (comboBoxAdv.AllowMultiSelect && comboBoxAdv.EnableToken && comboBoxAdv.IsEditable)
    //    {
    //        comboBoxAdv.UpdateToken();
    //        if (comboBoxAdv.IsEditDefaultText != null)
    //        {
    //            comboBoxAdv.IsEditDefaultText.Visibility = Visibility.Collapsed;
    //        }

    //        comboBoxAdv.UpdateSelectMode();
    //    }
    //    else if (!comboBoxAdv.AllowMultiSelect && comboBoxAdv.IsEditable && comboBoxAdv.SelectedIndex != -1)
    //    {
    //        comboBoxAdv.UpdateSelectedText(comboBoxAdv.SelectedItem);
    //    }

    //    comboBoxAdv.UpdateSelectionBox();
    //    if (comboBoxAdv.IsEditDefaultText != null)
    //    {
    //        if (!comboBoxAdv.IsEditable)
    //        {
    //            comboBoxAdv.IsEditDefaultText.Visibility = Visibility.Collapsed;
    //        }
    //        else if (comboBoxAdv.ShowDefaultText() && (comboBoxAdv.EnableToken || (!comboBoxAdv.AllowMultiSelect && !comboBoxAdv.EnableToken && comboBoxAdv.IsEditable)))
    //        {
    //            comboBoxAdv.IsEditDefaultText.Visibility = Visibility.Visible;
    //        }
    //    }

    //    if (comboBoxAdv.IsLoaded)
    //    {
    //        comboBoxAdv.OnFilterApplied();
    //    }
    //}

    ////
    //// Summary:
    ////     Called while applying filtering for ItemSource
    //private void OnFilterApplied()
    //{
    //    if (base.ItemsSource != null)
    //    {
    //        if (!IsEditable || (AllowMultiSelect && !EnableToken && AutoCompleteMode == AutoCompleteModes.Suggest))
    //        {
    //            ICollectionView defaultView = CollectionViewSource.GetDefaultView(base.ItemsSource);
    //            defaultView.Filter = (Predicate<object>)Delegate.Remove(defaultView.Filter, new Predicate<object>(FilterItem));
    //        }
    //        else if (IsEditable && AutoCompleteMode == AutoCompleteModes.Suggest)
    //        {
    //            ICollectionView defaultView2 = CollectionViewSource.GetDefaultView(base.ItemsSource);
    //            defaultView2.Filter = (Predicate<object>)Delegate.Remove(defaultView2.Filter, new Predicate<object>(FilterItem));
    //            defaultView2.Filter = (Predicate<object>)Delegate.Combine(defaultView2.Filter, new Predicate<object>(FilterItem));
    //        }
    //    }
    //}

    //private void UpdateSelectionOnDropDownOpen(ComboBoxAdv instance)
    //{
    //    if (instance == null || !IsDropDownOpen)
    //    {
    //        return;
    //    }

    //    instance.ClearSelection();
    //    if (instance.popup != null && !instance.AllowMultiSelect && instance.SelectedIndex >= 0)
    //    {
    //        DropDownScrollBar.ScrollToVerticalOffset(instance.SelectedIndex);
    //        if (instance.SelectedItem != null)
    //        {
    //            ComboBoxItemAdv comboBoxItemAdv = instance.SelectedItem as ComboBoxItemAdv;
    //            if (comboBoxItemAdv == null)
    //            {
    //                comboBoxItemAdv = instance.GetItemContainer(instance.SelectedItem);
    //            }

    //            if (comboBoxItemAdv != null && comboBoxItemAdv != null)
    //            {
    //                comboBoxItemAdv.IsHighlighted = true;
    //                comboBoxItemAdv.Focus();
    //            }
    //        }
    //    }
    //    else if (instance.SelItemsInternal != null && instance.SelItemsInternal.Count > 0)
    //    {
    //        if (instance.AllowMultiSelect && instance.AllowSelectAll)
    //        {
    //            SelectAllItem.Focus();
    //            return;
    //        }

    //        int index = instance.SelItemsInternal.Count - 1;
    //        DropDownScrollBar.ScrollToVerticalOffset(instance.Items.IndexOf(instance.SelItemsInternal[index]));
    //        if (instance.SelItemsInternal != null)
    //        {
    //            ComboBoxItemAdv comboBoxItemAdv = instance.SelItemsInternal[index] as ComboBoxItemAdv;
    //            if (comboBoxItemAdv == null)
    //            {
    //                comboBoxItemAdv = instance.GetItemContainer(instance.SelItemsInternal[index]);
    //            }

    //            if (comboBoxItemAdv != null)
    //            {
    //                comboBoxItemAdv?.Focus();
    //            }
    //        }
    //    }

    //    instance.RaiseValueChangedEvent();
    //}

    //private void OnDropDownClosed()
    //{
    //    if (this.DropDownClosed != null)
    //    {
    //        this.DropDownClosed(this, new EventArgs());
    //    }
    //}

    //private static void OnIsDropDownOpenChanged(object sender, DependencyPropertyChangedEventArgs args)
    //{
    //    ComboBoxAdv comboBoxAdv = sender as ComboBoxAdv;
    //    if (comboBoxAdv != null)
    //    {
    //        comboBoxAdv.UpdateSelectionOnDropDownOpen(comboBoxAdv);
    //        if (comboBoxAdv.IsDropDownOpen && comboBoxAdv.DropDownOpened != null)
    //        {
    //            comboBoxAdv.DropDownOpened(sender, new EventArgs());
    //        }
    //    }

    //    if ((bool)args.NewValue)
    //    {
    //        Mouse.Capture(comboBoxAdv, CaptureMode.SubTree);
    //        if (!comboBoxAdv.AllowMultiSelect)
    //        {
    //            if (comboBoxAdv.SelectAllItem != null)
    //            {
    //                comboBoxAdv.SelectAllItem.Visibility = Visibility.Collapsed;
    //            }

    //            if (comboBoxAdv.OKButton != null)
    //            {
    //                comboBoxAdv.OKButton.Visibility = Visibility.Collapsed;
    //            }

    //            if (comboBoxAdv.CancelButton != null)
    //            {
    //                comboBoxAdv.CancelButton.Visibility = Visibility.Collapsed;
    //            }
    //        }
    //        else if (comboBoxAdv.AllowSelectAll && comboBoxAdv.SelectAllItem != null)
    //        {
    //            if (comboBoxAdv.Items.Count == 0)
    //            {
    //                comboBoxAdv.SelectAllItem.Visibility = Visibility.Collapsed;
    //            }
    //            else
    //            {
    //                comboBoxAdv.SelectAllItem.Visibility = Visibility.Visible;
    //            }

    //            if (comboBoxAdv.DropDownClosed != null && !comboBoxAdv.IsDropDownOpen)
    //            {
    //                comboBoxAdv.OnDropDownClosed();
    //            }
    //        }

    //        if (comboBoxAdv.Part_IsEdit != null && !comboBoxAdv.AllowMultiSelect && comboBoxAdv.IsEditable && comboBoxAdv.Part_IsEdit.Text != string.Empty)
    //        {
    //            if (comboBoxAdv.IsLoaded)
    //            {
    //                comboBoxAdv.OnFilterApplied();
    //            }

    //            comboBoxAdv.Part_IsEdit.SelectionStart = 0;
    //            comboBoxAdv.Part_IsEdit.SelectionLength = comboBoxAdv.Part_IsEdit.Text.Length;
    //        }

    //        if (comboBoxAdv.Part_IsEdit != null && !comboBoxAdv.AllowMultiSelect && comboBoxAdv.IsEditable && !comboBoxAdv.EnableToken && comboBoxAdv.AutoCompleteMode == AutoCompleteModes.Suggest)
    //        {
    //            comboBoxAdv.RefreshFilter();
    //        }

    //        if (comboBoxAdv.AllowMultiSelect && comboBoxAdv.IsEditable && comboBoxAdv.EnableToken && comboBoxAdv.AutoCompleteMode == AutoCompleteModes.Suggest)
    //        {
    //            comboBoxAdv.RefreshFilter();
    //        }

    //        return;
    //    }

    //    if (comboBoxAdv.popup != null && comboBoxAdv.popup.Child is FrameworkElement frameworkElement && frameworkElement.MinWidth != comboBoxAdv.ActualWidth)
    //    {
    //        frameworkElement.MinWidth = comboBoxAdv.ActualWidth;
    //    }

    //    if (comboBoxAdv.AllowMultiSelect && comboBoxAdv.EnableOKCancel)
    //    {
    //        if (comboBoxAdv.KeyPressed == Key.Enter)
    //        {
    //            comboBoxAdv.SelectedItems = comboBoxAdv.SelItemsInternal;
    //            if (comboBoxAdv.EnableToken)
    //            {
    //                comboBoxAdv.UpdateToken();
    //            }

    //            comboBoxAdv.UpdateSelectionBox();
    //        }

    //        if (comboBoxAdv.KeyPressed != Key.Enter || comboBoxAdv.KeyPressed == Key.None)
    //        {
    //            comboBoxAdv.ResetSelectedItems();
    //        }

    //        comboBoxAdv.SelectItems();
    //    }

    //    if (comboBoxAdv.DropDownClosed != null && !comboBoxAdv.IsDropDownOpen)
    //    {
    //        comboBoxAdv.OnDropDownClosed();
    //    }

    //    comboBoxAdv.ChangedItems.Clear();
    //    if (comboBoxAdv != null && comboBoxAdv.IsKeyboardFocusWithin)
    //    {
    //        comboBoxAdv.Focus();
    //    }

    //    if (comboBoxAdv != null && Mouse.Captured == comboBoxAdv)
    //    {
    //        Mouse.Capture(null);
    //    }

    //    if (comboBoxAdv != null && comboBoxAdv.IsDropDownOpen)
    //    {
    //        comboBoxAdv.OnDropDownClosed();
    //    }

    //    if (comboBoxAdv.Part_IsEdit != null && !comboBoxAdv.AllowMultiSelect && comboBoxAdv.IsEditable && comboBoxAdv.AutoCompleteMode == AutoCompleteModes.Suggest)
    //    {
    //        if (comboBoxAdv.SelectedItem != null)
    //        {
    //            comboBoxAdv.UpdateSelectedText(comboBoxAdv.SelectedItem);
    //            comboBoxAdv.RefreshFilter();
    //        }
    //        else
    //        {
    //            comboBoxAdv.RefreshFilter();
    //        }
    //    }
    //}

    //private static void OnSelectedValueDelimiterChanged(object sender, DependencyPropertyChangedEventArgs args)
    //{
    //    if (sender is ComboBoxAdv comboBoxAdv)
    //    {
    //        comboBoxAdv.UpdateSelectionBox();
    //        comboBoxAdv.UpdateSelectMode();
    //    }
    //}

    //private void OnTextChanged(string searchText)
    //{
    //    if (!base.IsTextSearchEnabled || ((base.ItemsSource == null || AutoCompleteMode != 0) && base.ItemsSource != null))
    //    {
    //        return;
    //    }

    //    List<object> list = new List<object>();
    //    object obj = null;
    //    if (base.Items.Count > 0)
    //    {
    //        obj = base.Items[0];
    //    }

    //    bool flag = obj is string;
    //    bool flag2 = base.DisplayMemberPath.Equals(string.Empty);
    //    if (!_keypressed)
    //    {
    //        return;
    //    }

    //    if (Part_IsEdit != null && IsEditable && !string.IsNullOrEmpty(searchText))
    //    {
    //        this.searchText = Part_IsEdit.Text;
    //    }

    //    if (base.Items == null)
    //    {
    //        return;
    //    }

    //    if (base.ItemsSource == null && base.Items.Count > 0)
    //    {
    //        if (searchText != "")
    //        {
    //            IEnumerable<ComboBoxItemAdv> source = ((!base.IsTextSearchCaseSensitive) ? (from item in base.Items.OfType<ComboBoxItemAdv>()
    //                                                                                        where item.Content.ToString().ToUpper().StartsWith(searchText, StringComparison.OrdinalIgnoreCase)
    //                                                                                        select item) : (from item in base.Items.OfType<ComboBoxItemAdv>()
    //                                                                                                        where item.Content.ToString().StartsWith(searchText, StringComparison.Ordinal)
    //                                                                                                        select item));
    //            if (!IsEditable && oldTempChar == newTempChar)
    //            {
    //                if (source.Count() > 0)
    //                {
    //                    if (charindex + 1 >= source.Count())
    //                    {
    //                        charindex = -1;
    //                    }

    //                    base.SelectedIndex = base.Items.IndexOf(source.ToList()[++charindex]);
    //                }
    //            }
    //            else if (source.Count() > 0)
    //            {
    //                _keypressed = false;
    //                base.SelectedItem = null;
    //                base.SelectedIndex = base.Items.IndexOf(source.ToList()[0]);
    //            }
    //            else
    //            {
    //                base.SelectedItem = null;
    //            }
    //        }
    //        else
    //        {
    //            _keypressed = false;
    //        }
    //    }
    //    else
    //    {
    //        if (base.ItemsSource == null)
    //        {
    //            return;
    //        }

    //        int num = 0;
    //        if (flag)
    //        {
    //            foreach (object item in (IEnumerable)base.Items)
    //            {
    //                if (item != null)
    //                {
    //                    list.Add((string)item + "," + num);
    //                }
    //            }
    //        }
    //        else
    //        {
    //            foreach (object item2 in (IEnumerable)base.Items)
    //            {
    //                if (!flag2)
    //                {
    //                    PropertyInfo property = item2.GetType().GetProperty(base.DisplayMemberPath);
    //                    object obj2 = ((property == null) ? null : property.GetValue(item2, null));
    //                    if (obj2 != null)
    //                    {
    //                        list.Add(obj2.ToString() + "," + num);
    //                    }
    //                }
    //                else if (!base.SelectedValuePath.Equals(""))
    //                {
    //                    object value = item2.GetType().GetProperty(base.SelectedValuePath).GetValue(item2, null);
    //                    if (value != null)
    //                    {
    //                        list.Add(value.ToString() + "," + num);
    //                    }
    //                }
    //                else
    //                {
    //                    list.Add(item2?.ToString() + "," + num);
    //                }

    //                num++;
    //            }
    //        }

    //        IEnumerable<object> source2 = ((!base.IsTextSearchCaseSensitive) ? (from object item in list
    //                                                                            where searchText != null && item.ToString().StartsWith(searchText, StringComparison.OrdinalIgnoreCase)
    //                                                                            select item) : (from object item in list
    //                                                                                            where searchText != null && item.ToString().StartsWith(searchText, StringComparison.Ordinal)
    //                                                                                            select item));
    //        if (!IsEditable && oldTempChar == newTempChar)
    //        {
    //            if (source2.Count() > 0)
    //            {
    //                if (charindex + 1 >= source2.Count())
    //                {
    //                    charindex = -1;
    //                }

    //                int selectedIndex = int.Parse(source2.ToList()[++charindex].ToString().Split(',')[1]);
    //                base.SelectedIndex = selectedIndex;
    //            }
    //        }
    //        else if (!IsEditable && source2.Count() > 0)
    //        {
    //            charindex = 0;
    //            int selectedIndex2 = int.Parse(source2.ToList()[charindex].ToString().Split(',')[1]);
    //            base.SelectedIndex = selectedIndex2;
    //        }
    //        else
    //        {
    //            if (source2.Count() <= 0)
    //            {
    //                return;
    //            }

    //            charindex = 0;
    //            string[] array = source2.ToList()[charindex].ToString().Split(',');
    //            int selectedIndex3 = -1;
    //            for (int i = 0; i < array.Count(); i++)
    //            {
    //                if (int.TryParse(array[i], out var result))
    //                {
    //                    selectedIndex3 = result;
    //                    break;
    //                }
    //            }

    //            oldTempChar = newTempChar;
    //            timer.Start();
    //            _keypressed = false;
    //            base.SelectedItem = null;
    //            base.SelectedIndex = selectedIndex3;
    //        }
    //    }
    //}

    ////
    //// Summary:
    ////     Called when Text changes.
    ////
    //// Parameters:
    ////   sender:
    ////     Sender of this event
    ////
    ////   arg:
    ////     The event data.
    //private static void OnTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs arg)
    //{
    //    ComboBoxAdv comboBoxAdv = sender as ComboBoxAdv;
    //    if (comboBoxAdv.Part_IsEdit != null && string.IsNullOrEmpty((string)arg.NewValue))
    //    {
    //        comboBoxAdv.Part_IsEdit.Text = string.Empty;
    //    }
    //    else if (comboBoxAdv.Part_IsEdit != null && !comboBoxAdv.Part_IsEdit.Text.Equals(arg.NewValue.ToString()))
    //    {
    //        comboBoxAdv.Part_IsEdit.Text = arg.NewValue.ToString();
    //    }
    //}

    //private static void OnSelectionBoxTemplateChanged(object sender, DependencyPropertyChangedEventArgs args)
    //{
    //    ComboBoxAdv comboBoxAdv = sender as ComboBoxAdv;
    //    if (comboBoxAdv.DisplayMemberPath != null && comboBoxAdv.DisplayMemberPath != "" && comboBoxAdv.SelectionBoxTemplate != null)
    //    {
    //        throw new XamlParseException("Cannot set both DisplayMemberPath and SelectionBoxTemplate");
    //    }
    //}

    //internal void NotifyComboBoxItemAdvEnter(ComboBoxItemAdv item, bool state)
    //{
    //    if (!IsDropDownOpen)
    //    {
    //        return;
    //    }

    //    if (!AllowMultiSelect)
    //    {
    //        ComboBoxItemAdv itemContainer = GetItemContainer(base.SelectedItem);
    //        if (itemContainer != null && !itemContainer.Equals(item) && itemContainer.IsHighlighted && !itemContainer.IsMouseOver)
    //        {
    //            itemContainer.IsHighlighted = false;
    //        }
    //    }
    //    else if (SelItemsInternal != null && SelItemsInternal.Count - 1 >= 0)
    //    {
    //        ComboBoxItemAdv itemContainer = GetItemContainer(SelItemsInternal[SelItemsInternal.Count - 1]);
    //        if (itemContainer != null && SelItemsInternal != null && SelItemsInternal.Count > 0 && itemContainer.IsHighlighted && !itemContainer.IsMouseOver)
    //        {
    //            itemContainer.IsHighlighted = false;
    //        }
    //    }

    //    item.IsHighlighted = state;
    //    if (!IsEditable && !item.IsKeyboardFocusWithin && state && IsMouseMove())
    //    {
    //        item.Focus();
    //    }
    //}

    //internal bool IsMouseMove()
    //{
    //    Point position = Mouse.GetPosition(this);
    //    if (position != lastMousePosition)
    //    {
    //        lastMousePosition = position;
    //        return true;
    //    }

    //    return false;
    //}

    ////
    //// Summary:
    ////     Gets the selected items collection.
    ////
    //// Returns:
    ////     SelectedItems collection
    //private ObservableCollection<ComboBoxItemAdv> GetSelectedItems()
    //{
    //    ObservableCollection<ComboBoxItemAdv> observableCollection = new ObservableCollection<ComboBoxItemAdv>();
    //    if (SelectedItems != null)
    //    {
    //        foreach (object selectedItem in SelectedItems)
    //        {
    //            if (base.ItemContainerGenerator.ContainerFromItem(selectedItem) is ComboBoxItemAdv item)
    //            {
    //                observableCollection.Add(item);
    //            }
    //        }
    //    }

    //    return observableCollection;
    //}

    //private void coll_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    //{
    //    if (!AllowMultiSelect || internalChange)
    //    {
    //        return;
    //    }

    //    ObservableCollection<ComboBoxItemAdv> observableCollection = GetSelectedItems();
    //    if (SelItemsInternal != null && SelItemsInternal.Count <= 0)
    //    {
    //        internalSelect = true;
    //        base.SelectedItem = null;
    //        internalSelect = false;
    //    }

    //    if (observableCollection.Count > 0 && observableCollection[0] != null)
    //    {
    //        internalChange = true;
    //        int num = base.ItemContainerGenerator.IndexFromContainer(observableCollection[0]);
    //        if (base.SelectedIndex != num)
    //        {
    //            isFilter = false;
    //            base.SelectedIndex = num;
    //        }

    //        FireOnSelectionChanged(e);
    //        if (observableCollection[0] != null && observableCollection[0].DataContext != null && base.ItemsSource != null)
    //        {
    //            base.SelectedItem = observableCollection[0].DataContext;
    //        }
    //        else
    //        {
    //            base.SelectedItem = observableCollection[0];
    //        }

    //        if (base.SelectedItem is ComboBoxItemAdv)
    //        {
    //            SetSelectionBoxItem((base.SelectedItem as ComboBoxItemAdv).Content);
    //        }
    //        else
    //        {
    //            SetSelectionBoxItem(base.SelectedItem);
    //        }
    //    }
    //    else if (SelItemsInternal != null && SelItemsInternal.Count <= 0)
    //    {
    //        internalChange = false;
    //        base.SelectedIndex = -1;
    //    }
    //    else
    //    {
    //        FireOnSelectionChanged(e);
    //    }

    //    removeFlag = false;
    //    if (e.OldItems != null)
    //    {
    //        oldItem = e.OldItems[0];
    //        if (base.Items.Contains(e.OldItems[0]) && base.ItemContainerGenerator.ContainerFromItem(e.OldItems[0]) is ComboBoxItemAdv { CheckBox: not null } comboBoxItemAdv)
    //        {
    //            internalSelect = true;
    //            comboBoxItemAdv.CheckBox.IsChecked = false;
    //            internalSelect = false;
    //        }
    //    }
    //    else if (e.NewItems != null && base.Items.Contains(e.NewItems[0]))
    //    {
    //        newItem = e.NewItems[0];
    //        if (SelItemsInternal != null)
    //        {
    //            foreach (object item in SelItemsInternal)
    //            {
    //                foreach (object item2 in (IEnumerable)base.Items)
    //                {
    //                    if (item2 == null || !item2.Equals(item) || !newItem.Equals(item2))
    //                    {
    //                        continue;
    //                    }

    //                    if (itemcount >= 1)
    //                    {
    //                        ComboBoxItemAdv comboBoxItemAdv2 = base.ItemContainerGenerator.ContainerFromItem(newItem) as ComboBoxItemAdv;
    //                        if ((comboBoxItemAdv2 != null && comboBoxItemAdv2.IsSelected) || comboBoxItemAdv2 == null)
    //                        {
    //                            removeFlag = true;
    //                        }
    //                    }

    //                    itemcount++;
    //                }
    //            }

    //            if (removeFlag && SelItemsInternal.Count > 0)
    //            {
    //                SelItemsInternal.Remove(e.NewItems[0]);
    //            }

    //            SelectItems();
    //            itemcount = 0;
    //        }
    //    }
    //    else
    //    {
    //        if (SelItemsInternal != null && SelItemsInternal.Count > 0)
    //        {
    //            SelItemsInternal.Remove(e.NewItems[0]);
    //        }

    //        SelectItems();
    //    }

    //    UpdateSelectionBox();
    //    if (Part_IsEdit != null && !string.IsNullOrEmpty(Part_IsEdit.Text) && EnableToken)
    //    {
    //        Part_IsEdit.Text = string.Empty;
    //    }

    //    UpdateSelectMode();
    //    UpdateSelectAllItemState();
    //}

    //private void FireOnSelectionChanged(NotifyCollectionChangedEventArgs e)
    //{
    //    List<object> list = new List<object>();
    //    List<object> list2 = new List<object>();
    //    if (e.Action == NotifyCollectionChangedAction.Add)
    //    {
    //        if (base.Items.Count > e.NewStartingIndex && e.NewItems != null)
    //        {
    //            foreach (object newItem in e.NewItems)
    //            {
    //                list.Add(newItem);
    //            }
    //        }

    //        list2.Clear();
    //    }
    //    else if (e.Action == NotifyCollectionChangedAction.Remove)
    //    {
    //        if (base.Items.Count > e.OldStartingIndex && e.OldItems != null)
    //        {
    //            foreach (object oldItem in e.OldItems)
    //            {
    //                list2.Add(oldItem);
    //            }
    //        }

    //        list.Clear();
    //    }

    //    FireOnSelectionChanged(list2, list);
    //}

    //internal void SelectItems()
    //{
    //    foreach (object item in (IEnumerable)base.Items)
    //    {
    //        ComboBoxItemAdv comboBoxItemAdv = null;
    //        comboBoxItemAdv = ((base.ItemsSource == null) ? (item as ComboBoxItemAdv) : (base.ItemContainerGenerator.ContainerFromItem(item) as ComboBoxItemAdv));
    //        internalSelect = true;
    //        if (comboBoxItemAdv != null && comboBoxItemAdv.CheckBox != null)
    //        {
    //            if (SelItemsInternal != null && !SelItemsInternal.Contains(item))
    //            {
    //                comboBoxItemAdv.CheckBox.IsChecked = false;
    //            }
    //            else
    //            {
    //                comboBoxItemAdv.CheckBox.IsChecked = true;
    //            }
    //        }

    //        internalSelect = false;
    //    }

    //    UpdateSelectAllItemState();
    //}

    //private static void OnSelectedItemsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    //{
    //    (sender as ComboBoxAdv).OnSelectedItemsChanged(args);
    //}

    //private void FireOnSelectionChanged(List<object> removedItems, List<object> addedItems)
    //{
    //    if (SelectionChangedEvent != null)
    //    {
    //        SelectionChangedEvent = new SelectionChangedEventArgs(SelectionChangedEvent.RoutedEvent, removedItems, addedItems);
    //        base.OnSelectionChanged(SelectionChangedEvent);
    //    }
    //}

    //internal void OnSelectedItemsChanged(DependencyPropertyChangedEventArgs args)
    //{
    //    INotifyCollectionChanged notifyCollectionChanged = (INotifyCollectionChanged)args.NewValue;
    //    if (notifyCollectionChanged != null)
    //    {
    //        notifyCollectionChanged.CollectionChanged -= coll_CollectionChanged;
    //        notifyCollectionChanged.CollectionChanged += coll_CollectionChanged;
    //    }

    //    SelItemsInternal = (IList)notifyCollectionChanged;
    //    if (EnableToken && !EnableOKCancel && AllowMultiSelect && IsEditable && Part_IsEdit != null)
    //    {
    //        Part_IsEdit.Text = string.Empty;
    //        UpdateToken();
    //    }

    //    if (EnableOKCancel && SelItemsInternal != null && SelItemsInternal.Count <= 0)
    //    {
    //        SelectItems();
    //    }

    //    if (AllowMultiSelect && SelItemsInternal != null)
    //    {
    //        foreach (object item in SelItemsInternal)
    //        {
    //            if (item != null && base.Items.Contains(item))
    //            {
    //                SelectItems();
    //                continue;
    //            }

    //            newItem = item;
    //            SelectItems();
    //        }

    //        UpdateSelectAllItemState();
    //    }

    //    if (internalChange)
    //    {
    //        return;
    //    }

    //    UpdateSelectionBox();
    //    if (!AllowMultiSelect || EnableOKCancel)
    //    {
    //        if (SelItemsInternal != null && SelItemsInternal.Count <= 0)
    //        {
    //            SelectItems();
    //        }

    //        if (SelItemsInternal == null)
    //        {
    //            SelectedItems = null;
    //            SelectItems();
    //            UpdateSelectionBox();
    //        }
    //    }
    //}

    protected override AutomationPeer OnCreateAutomationPeer()
    {
        return new ComboBoxAdvAutomationPeer(this);
    }

    //internal void RaiseValueChangedEvent()
    //{
    //    if (AutomationPeer.ListenerExists(AutomationEvents.PropertyChanged))
    //    {
    //        AutomationPeer automationPeer = UIElementAutomationPeer.FromElement(this);
    //        if (automationPeer != null)
    //        {
    //            (automationPeer as ComboBoxAdvAutomationPeer).RaiseValueChangedEvent();
    //        }
    //    }
    //}

    //public void Dispose()
    //{
    //    if (popup != null)
    //    {
    //        popup.Opened -= Popup_Opened;
    //        popup.Closed -= popup_Closed;
    //        popup = null;
    //    }

    //    Part_IsEdit = GetTemplateChild("PART_Editable") as TextBox;
    //    if (Part_IsEdit != null)
    //    {
    //        Part_IsEdit.TextChanged -= Part_IsEdit_TextChanged;
    //        Part_IsEdit.PreviewKeyDown -= Part_IsEdit_PreviewKeyDown;
    //        Part_IsEdit.LostFocus -= Part_IsEdit_LostFocus;
    //        Part_IsEdit.GotFocus -= Part_IsEdit_GotFocus;
    //        RemoveLogicalChild(Part_IsEdit);
    //        Part_IsEdit = null;
    //    }

    //    if (tokenItemsControl != null)
    //    {
    //        tokenItemsControl.SizeChanged -= TokenItemsControl_SizeChanged;
    //        tokenItemsControl = null;
    //    }

    //    if (tokenBorder != null)
    //    {
    //        tokenBorder.PreviewMouseDown -= TokenBorder_PreviewMouseDown;
    //        tokenBorder = null;
    //    }

    //    SelectedItems = null;
    //    if (MainWindow != null)
    //    {
    //        MainWindow.LocationChanged -= MainWindow_LocationChanged;
    //        MainWindow.Deactivated -= MainWindow_Deactivated;
    //    }

    //    if (DropDownScrollBar != null)
    //    {
    //        DropDownScrollBar = null;
    //    }

    //    if (toggleButton != null)
    //    {
    //        toggleButton = null;
    //    }

    //    if (selectedContent != null)
    //    {
    //        selectedContent = null;
    //    }

    //    if (DropDownScrollBar != null)
    //    {
    //        DropDownScrollBar = null;
    //    }

    //    if (IsEditDefaultText != null)
    //    {
    //        IsEditDefaultText = null;
    //    }

    //    if (defaultText != null)
    //    {
    //        defaultText = null;
    //    }

    //    if (selectedItems != null)
    //    {
    //        selectedItems = null;
    //    }

    //    internalChange = false;
    //    internalSelect = false;
    //    if (oldItem != null)
    //    {
    //        oldItem = null;
    //    }

    //    if (newItem != null)
    //    {
    //        newItem = null;
    //    }

    //    itemcount = 0;
    //    removeFlag = false;
    //    if (OKButton != null)
    //    {
    //        OKButton = null;
    //    }

    //    if (CancelButton != null)
    //    {
    //        CancelButton = null;
    //    }

    //    if (searchText != null)
    //    {
    //        searchText = null;
    //    }

    //    if (ChangedItems != null)
    //    {
    //        ChangedItems = null;
    //    }

    //    if (SelItemsInternal != null)
    //    {
    //        SelItemsInternal = null;
    //    }

    //    lastMousePosition = new Point(0.0, 0.0);
    //    if (timer != null)
    //    {
    //        timer.Tick -= timer_Tick;
    //        timer = null;
    //    }

    //    base.SelectionChanged -= ComboBoxAdv_SelectionChanged;
    //    base.Loaded -= ComboBoxAdv_Loaded;
    //    base.LostFocus -= ComboBoxAdv_LostFocus;
    //    SelectionChangedEvent = null;
    //    if (base.Items.Count > 0)
    //    {
    //        base.ItemsSource = null;
    //        base.Items.Clear();
    //    }

    //    if (AddedTokenItems != null)
    //    {
    //        AddedTokenItems = null;
    //    }
    //}

    ////
    //// Summary:
    ////     Method used to get selected items of InputView.
    ////
    //// Returns:
    ////     Returns IEnumerable collection, that represents items selected in InputView.
    //IEnumerable ITextInputLayoutSelector.GetSelectedItems()
    //{
    //    return SelectedItems;
    //}
}


