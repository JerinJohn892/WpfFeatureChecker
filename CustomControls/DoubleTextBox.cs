using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace CustomControls;

/// <summary>
/// TextBox that accepts only numeric double values.
/// </summary>
[DefaultProperty(nameof(Text))]
[ContentProperty(nameof(Text))]
public class DoubleTextBox : TextBox
{
    static DoubleTextBox()
    {
        // enable preview text input for numbers
    }

    public DoubleTextBox()
    {
        DataObject.AddPastingHandler(this, OnPaste);
    }

    /// <summary>
    /// Gets or sets whether negative values are allowed.
    /// </summary>
    [DefaultValue(true)]
    public bool AllowNegative
    {
        get => (bool)GetValue(AllowNegativeProperty);
        set => SetValue(AllowNegativeProperty, value);
    }

    public static readonly DependencyProperty AllowNegativeProperty =
        DependencyProperty.Register(nameof(AllowNegative), typeof(bool), typeof(DoubleTextBox), new PropertyMetadata(true));

    /// <summary>
    /// Gets or sets the minimum allowed value.
    /// </summary>
    public double MinValue
    {
        get => (double)GetValue(MinValueProperty);
        set => SetValue(MinValueProperty, value);
    }

    public static readonly DependencyProperty MinValueProperty =
        DependencyProperty.Register(nameof(MinValue), typeof(double), typeof(DoubleTextBox), new PropertyMetadata(double.MinValue));

    /// <summary>
    /// Gets or sets the maximum allowed value.
    /// </summary>
    public double MaxValue
    {
        get => (double)GetValue(MaxValueProperty);
        set => SetValue(MaxValueProperty, value);
    }

    public static readonly DependencyProperty MaxValueProperty =
        DependencyProperty.Register(nameof(MaxValue), typeof(double), typeof(DoubleTextBox), new PropertyMetadata(double.MaxValue));

    /// <summary>
    /// Gets or sets the numeric value represented by the control.
    /// </summary>
    public double Value
    {
        get => (double)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(
            nameof(Value), typeof(double), typeof(DoubleTextBox),
            new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnValueChanged));

    private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (DoubleTextBox)d;
        var newValue = (double)e.NewValue;
        control.Text = newValue.ToString();
    }

    protected override void OnPreviewTextInput(TextCompositionEventArgs e)
    {
        base.OnPreviewTextInput(e);

        var proposed = Text.Insert(CaretIndex, e.Text);
        if (!IsTextValid(proposed))
        {
            e.Handled = true;
        }
    }

    protected override void OnTextChanged(TextChangedEventArgs e)
    {
        base.OnTextChanged(e);
        if (double.TryParse(Text, out var value))
        {
            value = Math.Max(MinValue, Math.Min(MaxValue, value));
            Value = value;
        }
    }

    private bool IsTextValid(string text)
    {
        if (string.IsNullOrEmpty(text))
            return true;

        if (text == "-")
            return AllowNegative;

        if (!AllowNegative && text.Contains("-"))
            return false;

        if (text.StartsWith("."))
            text = "0" + text;

        if (double.TryParse(text, out var value))
        {
            return value >= MinValue && value <= MaxValue;
        }

        return false;
    }

    private void OnPaste(object sender, DataObjectPastingEventArgs e)
    {
        if (e.DataObject.GetDataPresent(DataFormats.Text))
        {
            var pasted = e.DataObject.GetData(DataFormats.Text) as string ?? string.Empty;
            var proposed = Text.Insert(CaretIndex, pasted);
            if (!IsTextValid(proposed))
            {
                e.CancelCommand();
            }
        }
        else
        {
            e.CancelCommand();
        }
    }
}
