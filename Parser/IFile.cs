namespace Parser
{
    interface IFile
    {
        string Path { get; set; }
        string ParsedText { get; }
        string ParseFile();
    }
}
