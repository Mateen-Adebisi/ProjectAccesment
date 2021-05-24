using System;

namespace ScoreRecord
{
    public class ScoreEntity
    {
        public string Name { get; set;}
        public int EnglishGrade { get; set; }
        public int MathGrade { get; set; }
        public int EconomicGrade { get; set; }

        public ScoreEntity(string name, int englishGrade, int mathGrade, int economicGrade)
        {
            this.Name = name;
            this.EnglishGrade = englishGrade;
            this.MathGrade = mathGrade;
            this.EconomicGrade = economicGrade;
        }
        // always
        // aysalw
    }
}