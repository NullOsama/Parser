namespace Parser
{
    abstract class FileFactory
    {
        public abstract IFile CreateFile(string path);
    }
}
