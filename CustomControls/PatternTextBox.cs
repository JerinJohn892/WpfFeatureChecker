using System;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomControls;

/// <summary>
/// TextBox that restricts input using a regular expression pattern and optional mask formatting.
/// </summary>
[DefaultProperty(nameof(Text))]
public class PatternTextBox : TextBox
{
    private string? _mask;
    private Regex? _regex;
    private bool _isFormatting;

    static PatternTextBox()
    {
    }

    public PatternTextBox()
    {
        DataObject.AddPastingHandler(this, OnPaste);
    }

    /// <summary>
    /// Gets or sets the regular expression pattern that the text must match.
    /// For simple patterns, a mask is derived automatically to format the input.
    /// </summary>
    public string? Pattern
    {
        get => (string?)GetValue(PatternProperty);
        set => SetValue(PatternProperty, value);
    }

    public static readonly DependencyProperty PatternProperty =
        DependencyProperty.Register(nameof(Pattern), typeof(string), typeof(PatternTextBox),
            new PropertyMetadata(null, OnPatternChanged));

    private static void OnPatternChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((PatternTextBox)d).UpdatePattern();
    }

    /// <summary>
    /// Indicates whether the current text matches the <see cref="Pattern"/>. Empty text is considered valid.
    /// </summary>
    public bool IsValid
    {
        get => (bool)GetValue(IsValidProperty);
        private set => SetValue(IsValidPropertyKey, value);
    }

    private static readonly DependencyPropertyKey IsValidPropertyKey =
        DependencyProperty.RegisterReadOnly(nameof(IsValid), typeof(bool), typeof(PatternTextBox), new PropertyMetadata(true));

    public static readonly DependencyProperty IsValidProperty = IsValidPropertyKey.DependencyProperty;

    protected override void OnPreviewTextInput(TextCompositionEventArgs e)
    {
        base.OnPreviewTextInput(e);

        if (_mask is null || string.IsNullOrEmpty(e.Text))
            return;

        // Determine the current position within the mask
        var caret = CaretIndex;
        var rawCaret = GetRawCaretIndex();

        if (caret < _mask.Length && !IsPlaceholder(_mask[caret]))
        {
            // We are at a literal position (e.g. space or hyphen). Always insert the
            // literal and, if the typed character is valid for the next placeholder,
            // insert it as well.
            var literal = _mask[caret];
            Text = Text.Insert(caret, literal.ToString());
            CaretIndex = caret + 1;

            if (e.Text[0] != literal)
            {
                var placeholder = GetPlaceholder(rawCaret);
                if (placeholder.HasValue && IsCharAllowed(e.Text[0], placeholder.Value))
                {
                    Text = Text.Insert(CaretIndex, NormalizeChar(e.Text[0], placeholder.Value).ToString());
                    CaretIndex++;
                }
            }

            e.Handled = true;
            return;
        }

        var nextPlaceholder = GetPlaceholder(rawCaret);
        if (nextPlaceholder is null || !IsCharAllowed(e.Text[0], nextPlaceholder.Value))
            e.Handled = true;
    }

    protected override void OnTextChanged(TextChangedEventArgs e)
    {
        base.OnTextChanged(e);
        FormatText();
    }

    protected override void OnLostFocus(RoutedEventArgs e)
    {
        base.OnLostFocus(e);
        UpdateIsValid();
    }

    private void OnPaste(object sender, DataObjectPastingEventArgs e)
    {
        if (!e.DataObject.GetDataPresent(DataFormats.Text))
        {
            e.CancelCommand();
            return;
        }

        var pasted = (string)e.DataObject.GetData(DataFormats.Text)!;
        var rawCaret = GetRawCaretIndex();
        var raw = GetRawText();
        raw = raw.Insert(rawCaret, Strip(pasted));
        raw = FilterRaw(raw);
        var caretIndex = rawCaret + Strip(pasted).Length;
        if (caretIndex > raw.Length) caretIndex = raw.Length;
        var (formatted, caret) = ApplyMask(raw, caretIndex);
        Text = formatted;
        CaretIndex = caret;
        e.CancelCommand();
        UpdateIsValid();
    }

    private void UpdatePattern()
    {
        var pattern = Pattern;
        _regex = string.IsNullOrEmpty(pattern) ? null : new Regex(pattern);
        _mask = BuildMaskFromPattern(pattern);
        FormatText();
        UpdateIsValid();
    }

    private void FormatText()
    {
        if (_isFormatting)
            return;

        _isFormatting = true;
        var rawCaret = GetRawCaretIndex();
        var raw = GetRawText();
        raw = FilterRaw(raw);
        var (formatted, caret) = ApplyMask(raw, rawCaret);
        Text = formatted;
        CaretIndex = caret;
        _isFormatting = false;
        UpdateIsValid();
    }

    private string GetRawText() => Strip(Text);

    private static string Strip(string? text)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;
        var sb = new StringBuilder();
        foreach (var c in text)
        {
            if (char.IsLetterOrDigit(c))
                sb.Append(c);
        }
        return sb.ToString();
    }

    private string FilterRaw(string raw)
    {
        if (_mask is null)
            return raw;
        var sb = new StringBuilder();
        for (int i = 0; i < raw.Length; i++)
        {
            var placeholder = GetPlaceholder(i);
            if (placeholder is null)
                break;
            var c = raw[i];
            if (IsCharAllowed(c, placeholder.Value))
                sb.Append(NormalizeChar(c, placeholder.Value));
        }
        return sb.ToString();
    }

    private (string formatted, int caret) ApplyMask(string raw, int rawCaret)
    {
        if (_mask is null)
            return (raw, Math.Min(rawCaret, raw.Length));

        var result = new StringBuilder();
        int rawIndex = 0;
        int caret = 0;
        foreach (var m in _mask)
        {
            if (IsPlaceholder(m))
            {
                if (rawIndex < raw.Length)
                {
                    result.Append(NormalizeChar(raw[rawIndex], m));
                    rawIndex++;
                    if (rawIndex == rawCaret)
                        caret = result.Length;
                }
                else
                {
                    break;
                }
            }
            else
            {
                result.Append(m);
                if (rawIndex == rawCaret)
                    caret = result.Length;
            }
        }
        if (rawCaret > rawIndex)
            caret = result.Length;
        return (result.ToString(), caret);
    }

    private int GetRawCaretIndex()
    {
        int raw = 0;
        for (int i = 0; i < CaretIndex && i < Text.Length; i++)
        {
            if (char.IsLetterOrDigit(Text[i]))
                raw++;
        }
        return raw;
    }

    private char? GetPlaceholder(int index)
    {
        if (_mask is null)
            return null;
        int count = 0;
        foreach (var ch in _mask)
        {
            if (IsPlaceholder(ch))
            {
                if (count == index)
                    return ch;
                count++;
            }
        }
        return null;
    }

    private static bool IsPlaceholder(char c) => c == '#' || c == 'A' || c == 'a' || c == 'X';

    private static bool IsCharAllowed(char c, char placeholder) => placeholder switch
    {
        '#' => char.IsDigit(c),
        'A' => char.IsLetter(c),
        'a' => char.IsLetter(c),
        'X' => char.IsLetterOrDigit(c),
        _ => true
    };

    private static char NormalizeChar(char c, char placeholder) => placeholder switch
    {
        'A' => char.ToUpperInvariant(c),
        'a' => char.ToLowerInvariant(c),
        'X' => char.IsDigit(c) ? c : char.ToUpperInvariant(c),
        _ => c
    };

    private void UpdateIsValid()
    {
        bool valid;
        if (string.IsNullOrEmpty(Text))
        {
            valid = true;
        }
        else if (_regex != null)
        {
            valid = _regex.IsMatch(Text);
        }
        else
        {
            valid = true;
        }
        IsValid = valid;
    }

    private static string? BuildMaskFromPattern(string? pattern)
    {
        if (string.IsNullOrEmpty(pattern))
            return null;

        var p = pattern;
        if (p.StartsWith("^"))
            p = p[1..];
        if (p.EndsWith("$"))
            p = p[..^1];

        var sb = new StringBuilder();
        for (int i = 0; i < p.Length;)
        {
            if (p[i] == '\\')
            {
                if (i + 1 < p.Length && p[i + 1] == 'd')
                {
                    i += 2;
                    int count = 1;
                    if (i < p.Length && p[i] == '{')
                    {
                        int end = p.IndexOf('}', i);
                        if (end > i)
                        {
                            var num = p[(i + 1)..end];
                            if (int.TryParse(num, out var n))
                                count = n;
                            i = end + 1;
                        }
                    }
                    sb.Append(new string('#', count));
                    continue;
                }
            }
            else if (p[i] == '[')
            {
                int end = p.IndexOf(']', i);
                if (end > i)
                {
                    var content = p[(i + 1)..end];
                    i = end + 1;
                    int count = 1;
                    if (i < p.Length && p[i] == '{')
                    {
                        int close = p.IndexOf('}', i);
                        if (close > i)
                        {
                            var num = p[(i + 1)..close];
                            if (int.TryParse(num, out var n))
                                count = n;
                            i = close + 1;
                        }
                    }
                    string? placeholder = content switch
                    {
                        "A-Z" => "A",
                        "a-z" => "a",
                        "0-9" => "#",
                        "2-9" => "#",
                        "A-Z0-9" => "X",
                        "0-9A-Z" => "X",
                        _ => null
                    };
                    if (placeholder is null)
                        return null;
                    sb.Append(new string(placeholder[0], count));
                    continue;
                }
            }
            else if (p[i] == ' ' || p[i] == '-' || p[i] == '@' || p[i] == '.')
            {
                sb.Append(p[i]);
                i++;
                continue;
            }
            else
            {
                // treat as literal
                sb.Append(p[i]);
                i++;
                continue;
            }

            return null; // unsupported token
        }

        return sb.ToString();
    }
}

