# C# 6-News
* See template solution in csharp/templates folder as a basis
* Story: Theming of an application, theme is specified in app.config, problem with casing
* Hint: Alternative impementation: String.Compare("AA", "aa", StringComparison.OrdinalIgnoreCase);

## Null-Conditional Operator

```cs
var themeConfig = ConfigurationManager.AppSettings["Theme"];
var theme = themes.FirstOrDefault(p => p.Name.ToLower() == themeConfig.ToLower());

Console.ForegroundColor = theme.ForegroundColor;
Console.BackgroundColor = theme.BackgroundColor;
```

* Problem: NullReferenceException (no Key in app.config)
* still NullReferenceException (one Theme without a name)

```cs
var theme = themes.FirstOrDefault(p => p.Name?.ToLower() == themeConfig?.ToLower());
```

* In combination with Coalesce operator (uncomment app.config):

```cs
var themeConfig = ConfigurationManager.AppSettings["Theme"]?.ToLower() ?? "light";
```                                                        --------------------------

### Chaining of expressions
* the first NULL occuring leads to NULL
* value types are transformed to Nullable<T>

```cs
themes = null;
var theme = themes?.FirstOrDefault(p => p.Name?.ToLower() == themeConfig)?.BackgroundColor;
```

### ? with Indexoperator

```cs
var name = themes?[0].Name;
// equivalent to    (themes != null) ? themes[0] : null;
```

### Invoking delegates
* Change Theme.Name-Property to propfull
* implement INotifyPropertyChanged

```cs
PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
```

## nameof-Operator
* show different parameters you can pass to nameof
  * Main, Program, Theme, Variable

```cs
PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
```

## Dictionary Initializers

```cs
var settings = new Dictionary<string, string>()
            {
                ["Theme"] = themeConfig,
                ["User"] = "Roman"
            };
```

```cs
var json = new JObject
{
    ["x"] = 12,
    ["y"] = 27,
    ["CreationDate"] = DateTime.UtcNow,
    ["User"] = "Roman"
};

Console.WriteLine(json);
```

## Auto-Property Initializers
* what was necessary to implement an immutable property?
* Theme: change Color-Properties to...

```cs
public ConsoleColor BackgroundColor { get; }

public void Foo()
{
    this.BackgroundColor = ConsoleColor.Red;	// compiler error, write access is only allowed from constructor
}
```

```cs
public ConsoleColor BackgroundColor { get; } = ConsoleColor.Black;
```

## Expression Bodied Functions and Properties

```cs
// Properties:
public string FullName => string.Format("Theme: {0}, Background: {1}", this.name, this.BackgroundColor);

// Methods:
public override string ToString() => this.FullName;
```

## Static Using Statements
```cs
// Program.cs:
using static System.Console;
```
* change all WriteLine to WriteLine(..)

## Exception-Handling
```cs
// Add validation to Theme constructor (winter theme throws exception now)
if (backgroundColor == foregroundColor)
{
    throw new TypeInitializationException(nameof(Theme), new ArgumentException("Background color must be different from foreground color."));
}

// try/catch for InitializeThemes
catch (Exception e)
{
    LogException(e); // Strg + ., generate...
}

// Assumption: LogException-Methode is async -> async/await wasn't available in catch/finally before
private static Task LogException(Exception e) => Task.Delay(1000);

catch (Exception e)
{
    await LogException(e); // Strg + ., generate...
//  -----    -> themes-Collection gets null now, code might not work anymore.
}
```

## Exception Filters
```cs
catch (TypeInitializationException e) if (e.InnerException is ArgumentException)
{
    await LogException(e);
}
```

## String Interpolation

* delete Winter-Theme
* correct build errors

```cs
public string FullName => $"Theme: \{this.Name}, Background: \{this.BackgroundColor}";
public string FullName => $"Theme: \{this.Name,20}, Background: \{this.BackgroundColor}";
```

# C# 7
* [What's new in C# 7](https://blogs.msdn.microsoft.com/dotnet/2016/08/24/whats-new-in-csharp-7-0/)
* [Language feature status](https://github.com/dotnet/roslyn/blob/master/docs/Language%20Feature%20Status.md)
* Slide deck: [C# 7 features](csharp/slides/csharp7.pptx)

