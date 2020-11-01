using System.Collections.Generic;
using LINQtoCSV;

namespace TreasureHunt.Data
{
    public class Questions
    {
        [CsvColumn(Name = "clue",FieldIndex = 1)]
        public string Clue { get; set; }
        [CsvColumn(Name = "answer",FieldIndex = 2)]
        public string Answer { get; set; }

        public static IEnumerable<Questions> GetQuestion(){
            var InputFileDescription = new CsvFileDescription{
                SeparatorChar = ',',
                QuoteAllFields = true,
                FirstLineHasColumnNames = true
            };

            var cc = new CsvContext();
            return cc.Read<Questions>("Data/question.csv",InputFileDescription);
        }
    }
}