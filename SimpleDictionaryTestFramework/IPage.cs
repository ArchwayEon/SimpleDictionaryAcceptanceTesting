namespace SimpleDictionaryTestFramework;

public interface IPage
{
    void Initialize();
    void GoTo(string url);
    void EndTest();
    void Input(string inputId, string data);
    void Press(string inputValue);
    void Wait();
    string? ReadTextByXPath(string xPath);
    int ReadNumberOfTableRowsByXPath(string xPath);
    string? ReadTextFromTableByXPath(int row, int col, string xPath);
}
