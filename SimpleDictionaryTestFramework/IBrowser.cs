namespace SimpleDictionaryTestFramework;

public interface IBrowser
{
    void Create();

    void Request(string url);
    void Quit();
    void WaitForPage();
    void Input(string inputId, string data);
    void Click(string inputValue);
    string? ReadTextByXPath(string xPath);
    int ReadNumberOfTableRowsByXPath(string xPath);
}
