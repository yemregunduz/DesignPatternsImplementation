using System;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgorithm scoringAlgorithm;
            Console.WriteLine("Men");
            scoringAlgorithm = new MenScoringAlgorithm();
            Console.WriteLine(scoringAlgorithm.GenerateScore(8,new TimeSpan(0,2,34)));

            Console.WriteLine("Women");
            scoringAlgorithm = new WomenScoringAlgorithm();
            Console.WriteLine(scoringAlgorithm.GenerateScore(8,new TimeSpan(0,2,34)));

            Console.WriteLine("Children");
            scoringAlgorithm = new ChildrenScoringAlgorithm();
            Console.WriteLine(scoringAlgorithm.GenerateScore(8, new TimeSpan(0, 2, 34)));

            Console.ReadLine();
        }
        abstract class ScoringAlgorithm 
        {
            public int GenerateScore(int hits, TimeSpan time)
            {
                int score = CalculateBaseScore(hits);
                int reduction = CalculateReduction(time);
                return CalculateOverallScore(score, reduction);
            }

            public abstract int CalculateReduction(TimeSpan time);
            public abstract int CalculateBaseScore(int hits);
            public abstract int CalculateOverallScore(int score, int reduction);
        }
        class MenScoringAlgorithm : ScoringAlgorithm
        {
            public override int CalculateBaseScore(int hits)
            {
                return hits * 100;
            }
            public override int CalculateReduction(TimeSpan time)
            {
                return (int)time.TotalSeconds / 5;
            }
            public override int CalculateOverallScore(int score, int reduction)
            {
                return score - reduction;
            }
        }
        class WomenScoringAlgorithm : ScoringAlgorithm
        {
            public override int CalculateBaseScore(int hits)
            {
                return hits * 100;
            }
            public override int CalculateReduction(TimeSpan time)
            {
                return (int)time.TotalSeconds / 3;
            }
            public override int CalculateOverallScore(int score, int reduction)
            {
                return score - reduction;
            }
        }
        class ChildrenScoringAlgorithm : ScoringAlgorithm
        {
            public override int CalculateBaseScore(int hits)
            {
                return hits * 80;
            }
            public override int CalculateReduction(TimeSpan time)
            {
                return (int)time.TotalSeconds / 2;
            }
            public override int CalculateOverallScore(int score, int reduction)
            {
                return score - reduction;
            }
        }
    }
}
