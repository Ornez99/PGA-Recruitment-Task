public class WindowOption
{
    public delegate void Option();
    public Option option;
    public string contents;

    public WindowOption(Option option, string contents)
    {
        this.option = option;
        this.contents = contents;
    }
}
