using TenthLabor.Model;

namespace TenthLabor.Persistence
{
    public class TextEditorPersistence
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="text"></param>
        
        public async Task SaveFile(string path, string text)
        {
            using StreamWriter writer = new(path);
            await writer.WriteAsync(text);
        }

        public void LoadFile(string path)
        {
            using StreamReader reader = new(path);
            List<List<char>> text = [];

            for (; !reader.EndOfStream;)
            {
                text.Add([.. reader.ReadLine()!.ToCharArray()]);
            }

            TextEditorModelDraft draft = new()
            {
                Left = 0,
                Top = 0,
                Saved = false,
                Path = path,
                Text = text
            };
        }
    }
}

