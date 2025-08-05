using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace sudoku.Services.Loader
{
    public class LoadJSON : ILoadData
    {
        public (SudokuBoardViewModel? board, string error) Load(string fileName)
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Converters.Add(new JavaScriptDateTimeConverter());
                serializer.NullValueHandling = NullValueHandling.Ignore;

                using (StreamReader sr = new StreamReader(fileName))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    var board = serializer.Deserialize<SudokuBoardViewModel>(reader);
                    return (board, "");
                }
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
    }
}
