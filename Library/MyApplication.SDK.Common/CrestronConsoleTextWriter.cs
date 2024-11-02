using System.Globalization;
using System.Text;
using Crestron.SimplSharp;

namespace MyApplication.SDK.Common;

public sealed class CrestronConsoleTextWriter : TextWriter
{
    public override Encoding Encoding => Encoding.ASCII;

    public override void Write(bool value) => CrestronConsole.Print(value.ToString());

    public override void Write(char value) => CrestronConsole.Print(value.ToString());

    public override void Write(char[]? buffer) => CrestronConsole.Print(new string(buffer));

    public override void Write(decimal value) => CrestronConsole.Print(value.ToString(CultureInfo.InvariantCulture));

    public override void Write(double value) => CrestronConsole.Print(value.ToString(CultureInfo.InvariantCulture));

    public override void Write(float value) => CrestronConsole.Print(value.ToString(CultureInfo.InvariantCulture));

    public override void Write(int value) => CrestronConsole.Print(value.ToString(CultureInfo.InvariantCulture));

    public override void Write(long value) => CrestronConsole.Print(value.ToString(CultureInfo.InvariantCulture));

    public override void Write(object? value) => CrestronConsole.Print(value?.ToString() ?? string.Empty);

    public override void Write(string? value) => CrestronConsole.Print(value ?? string.Empty);

    public override void Write(uint value) => CrestronConsole.Print(value.ToString(CultureInfo.InvariantCulture));

    public override void Write(ulong value) => CrestronConsole.Print(value.ToString(CultureInfo.InvariantCulture));

    public override void Write(string format, object? arg0) => CrestronConsole.Print(format, arg0 ?? string.Empty);

    public override void Write(string format, object? arg0, object? arg1) => CrestronConsole.Print(format, arg0 ?? string.Empty, arg1 ?? string.Empty);

    public override void Write(string format, object? arg0, object? arg1, object? arg2) => CrestronConsole.Print(format, arg0 ?? string.Empty, arg1 ?? string.Empty, arg2 ?? string.Empty);

    public override void Write(string format, params object?[] arg) => CrestronConsole.Print(format, arg.Select(o => o ?? string.Empty));

    public override void Write(char[] buffer, int index, int count) => CrestronConsole.Print(new string(buffer, index, count));

    public override void WriteLine() => CrestronConsole.PrintLine(string.Empty);

    public override void WriteLine(bool value) => CrestronConsole.PrintLine(value.ToString());

    public override void WriteLine(char value) => CrestronConsole.PrintLine(value.ToString());

    public override void WriteLine(char[]? buffer) => CrestronConsole.PrintLine(new string(buffer));

    public override void WriteLine(decimal value) => CrestronConsole.PrintLine(value.ToString(CultureInfo.InvariantCulture));

    public override void WriteLine(double value) => CrestronConsole.PrintLine(value.ToString(CultureInfo.InvariantCulture));

    public override void WriteLine(float value) => CrestronConsole.PrintLine(value.ToString(CultureInfo.InvariantCulture));

    public override void WriteLine(int value) => CrestronConsole.PrintLine(value.ToString(CultureInfo.InvariantCulture));

    public override void WriteLine(long value) => CrestronConsole.PrintLine(value.ToString(CultureInfo.InvariantCulture));

    public override void WriteLine(object? value) => CrestronConsole.PrintLine(value?.ToString() ?? string.Empty);

    public override void WriteLine(string? value) => CrestronConsole.PrintLine(value ?? string.Empty);

    public override void WriteLine(uint value) => CrestronConsole.PrintLine(value.ToString(CultureInfo.InvariantCulture));

    public override void WriteLine(ulong value) => CrestronConsole.PrintLine(value.ToString(CultureInfo.InvariantCulture));

    public override void WriteLine(string format, object? arg0) => CrestronConsole.PrintLine(format, arg0 ?? string.Empty);

    public override void WriteLine(string format, object? arg0, object? arg1) => CrestronConsole.PrintLine(format, arg0 ?? string.Empty, arg1 ?? string.Empty);

    public override void WriteLine(string format, object? arg0, object? arg1, object? arg2) => CrestronConsole.PrintLine(format, arg0 ?? string.Empty, arg1 ?? string.Empty, arg2 ?? string.Empty);

    public override void WriteLine(string format, params object?[] arg) => CrestronConsole.PrintLine(format, arg.Select(o => o ?? string.Empty));

    public override void WriteLine(char[] buffer, int index, int count) => CrestronConsole.PrintLine(new string(buffer, index, count));
}