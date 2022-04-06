namespace SimpleDictionaryTestFramework;

public class Page : IPage
{
    private IBrowser _browser;

    public Page(IBrowser browser)
    {
        _browser = browser;
    }

    public void Initialize()
    {
        _browser.Create();
    }

    public void GoTo(string url)
    {
        _browser.Request(url);
    }

    public void EndTest()
    {
        _browser.Quit();
    }

    public void Input(string inputId, string data)
    {
        _browser.Input(inputId, data);
    }

    public void Press(string inputValue)
    {
        _browser.Click(inputValue);
    }

    public void Wait()
    {
        _browser.WaitForPage();
    }

    public string? ReadTextByXPath(string xPath)
    {
        return _browser.ReadTextByXPath(xPath);
    }

    public int ReadNumberOfTableRowsByXPath(string xPath)
    {
        return _browser.ReadNumberOfTableRowsByXPath(xPath);
    }

    public string? ReadTextFromTableByXPath(int row, int col, string xPath)
    {
        xPath += $"/tbody/tr[{row}]/td[{col}]";
        return _browser.ReadTextByXPath(xPath);
    }
}
