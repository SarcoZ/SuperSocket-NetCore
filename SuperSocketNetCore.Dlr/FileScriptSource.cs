using System;
using System.IO;
using System.Text;

namespace SuperSocket.Dlr
{
    class FileScriptSource : ScriptSourceBase
    {
        private string m_FilePath;

        public FileScriptSource(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("filePath");

            m_FilePath = filePath;

            Name = Path.GetFileNameWithoutExtension(filePath);
            LanguageExtension = Path.GetExtension(filePath);
            LastUpdatedTime = File.GetLastWriteTime(filePath);
        }

        public override string GetScriptCode()
        {
            return File.ReadAllText(m_FilePath, Encoding.UTF8);
        }

        public override string Tag
        {
            get { return m_FilePath; }
        }
    }
}
