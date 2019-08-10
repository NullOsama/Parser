namespace Parser
{
    interface IFile
    {
        string Path { get; set; }
        string ParseFile();
    }
}
