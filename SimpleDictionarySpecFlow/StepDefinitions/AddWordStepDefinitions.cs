using NUnit.Framework;
using SimpleDictionaryTestFramework;
using System;
using TechTalk.SpecFlow;

namespace SimpleDictionarySpecFlow.StepDefinitions;

[Binding]
public class AddWordStepDefinitions
{
    private IPage _page;
    public AddWordStepDefinitions()
    {
        _page = new Page(new Chrome());
    }

    [Before]
    public void Setup()
    {
        _page.Initialize();
    }

    [After]
    public void TearDown()
    {
        _page.EndTest();
    }

    [Given(@"I am on the add word page")]
    public void GivenIAmOnTheAddWordPage()
    {
        _page.GoTo("https://localhost:7190/Home/AddWord");
    }

    [Given(@"I have entered (.*) as the Word")]
    public void GivenIHaveEnteredTriangleAsTheWord(string word)
    {
        _page.Input("Word", word);
    }

    [Given(@"I have entered (.*) as the Meaning")]
    public void GivenIHaveEntered_SidedShapeAsTheMeaning(string meaning)
    {
        _page.Input("Meaning", meaning);
    }

    [When(@"I press Create")]
    public void WhenIPressCreate()
    {
        _page.Press("Create");
    }

    [Then(@"the app should respond with the index page")]
    public void ThenTheAppShouldRespondWithTheIndexPage()
    {
        _page.Wait();
        var xPath = "/html/body/div/main/h1";
        var heading = _page.ReadTextByXPath(xPath);
        Assert.That(heading, Is.EqualTo("Index"));
    }

    [Then(@"I can see (.*) on the page")]
    public void ThenICanSeeTriangleOnThePage(string word)
    {
        int col = 1;
        string xPath = "/html/body/div/main/table";
        var lastRow = _page.ReadNumberOfTableRowsByXPath(xPath);
        var value = _page.ReadTextFromTableByXPath(lastRow, col, xPath);
        Assert.That(value, Is.EqualTo(word));
    }
}
