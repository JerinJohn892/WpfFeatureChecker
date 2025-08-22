using CustomControls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using Xunit;

namespace WpfCheckerView.Tests;

public class PatternTextBoxTests
{
    [StaFact]
    public void Backspace_Should_Remove_Character_Before_Literal()
    {
        var tb = new TestPatternTextBox { Pattern = @"^\d{3}-\d{3}$" };
        tb.Type("1234"); // results in 123-4

        tb.PressBackspace(); // remove 4 -> 123-
        tb.PressBackspace(); // remove 3 and hyphen -> 12

        Assert.Equal("12", tb.Text);
    }

    private class TestPatternTextBox : PatternTextBox
    {
        public void Type(string text)
        {
            foreach (var ch in text)
            {
                var composition = new TextComposition(InputManager.Current, this, ch.ToString());
                var args = new TextCompositionEventArgs(InputManager.Current.PrimaryKeyboardDevice, composition)
                {
                    RoutedEvent = TextCompositionManager.PreviewTextInputEvent
                };
                OnPreviewTextInput(args);
                if (!args.Handled)
                {
                    Text = Text.Insert(CaretIndex, ch.ToString());
                    CaretIndex++;
                }
            }
        }

        public void PressBackspace()
        {
            var args = new KeyEventArgs(Keyboard.PrimaryDevice, new TestPresentationSource(), 0, Key.Back)
            {
                RoutedEvent = Keyboard.PreviewKeyDownEvent
            };
            OnPreviewKeyDown(args);
        }
    }

    private class TestPresentationSource : PresentationSource
    {
        public override Visual RootVisual { get => null!; set { } }
        protected override CompositionTarget? GetCompositionTargetCore() => null;
        public override bool IsDisposed => false;
    }
}
