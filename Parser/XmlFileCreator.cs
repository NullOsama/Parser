namespace Parser
{
    class XmlFileCreator : FileFactory
    {

        public override IFile CreateFile(string path)
        {
            return new XmlFile(path: path);
        }
    }
}
