using Spectre.Console;

namespace ContactBook.Display;

public class SelectionDisplay
{
    public string SelectionTable(params string[] options)
    {
        var table = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("What's your [green]choice[/]?")
        .PageSize(15)
        .MoreChoicesText("[grey](Move up and down to to choose)[/]")
        .AddChoices(options));

        return table;
    }
}


