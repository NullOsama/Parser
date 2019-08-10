namespace Parser
{
    class JsonFileCreator : FileFactory
    {
        public override IFile CreateFile(string path)
        {
            return new JsonFile(path: path);
        }
    }
}
