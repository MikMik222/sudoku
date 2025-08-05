using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace sudoku.Services.Saver
{
    class SaveJson : ISaveData
    {
        public string Save(string fileName, SudokuBoardViewModel board)
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Converters.Add(new JavaScriptDateTimeConverter());
                serializer.NullValueHandling = NullValueHandling.Ignore;

                using (StreamWriter sw = new StreamWriter(fileName))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    writer.Formatting = Formatting.Indented;
                    serializer.Serialize(writer, board);
                    return "";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
