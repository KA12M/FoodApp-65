
using Models.FoodApp_65;

namespace Data.FoodApp_65
{
    public class FoodList
    {
        public List<Food> Foods = new List<Food>();
        Random rand = new Random();

        public void GenerateData()
        {
            var count = rand.Next(20, 31);
            for (var i = 0; i < count; i++)
            {
                var newFood = new Food
                {
                    Id = i + 1,
                    Name = $"Food_{i + 1}",
                    Type = rand.Next(1, 6),
                    Cost = rand.NextDouble() * (500.00 - 30.00) + 30.00,
                    Cal = rand.NextDouble() * (200.00 - 30.00) + 30.00,
                };
                newFood.CostRate = GetCostRate(newFood.Cost);
                Foods.Add(newFood);
            }
        }

        private string GetCostRate(double cost)
        {
            if (cost >= 30 && cost <= 100) return "*";
            else if (cost >= 100 && cost <= 200) return "**";
            else if (cost >= 300 && cost <= 400) return "***";
            else return "****";
        }

        public void ShowData()
        {
            Console.WriteLine("Id | Name | Type | Cost | Cal | CostRate |");
            foreach (var food in Foods) Console.WriteLine($"{food.Id} | {food.Name} | {food.Type} | {food.Cost.ToString("#.00")} | {food.Cal.ToString("#.00")} | {food.CostRate} |");
            Console.WriteLine();
        }

        public void ShowResult()
        {
            Console.WriteLine("     Cost   | Cal");
            Console.WriteLine($"Max: {Foods.Max(a => a.Cost).ToString("#.00")} | {Foods.Max(a => a.Cal).ToString("#.00")}");
            Console.WriteLine($"Min: {Foods.Min(a => a.Cost).ToString("#.00")} | {Foods.Min(a => a.Cal).ToString("#.00")}");
            Console.WriteLine($"Average: {Foods.Average(a => a.Cost).ToString("#.00")} | {Foods.Average(a => a.Cal).ToString("#.00")}");
            Console.WriteLine();
        }

        public void ShowGroupByType()
        {
            var temp = Foods.GroupBy(a => a.Type).OrderBy(a => a.Key).ToList();

            foreach (var group in temp)
            {
                Console.WriteLine($"Type {group.Key}:");
                Console.WriteLine("Id | Name | Type | Cost | Cal | CostRate |");
                foreach (var food in group) Console.WriteLine($"{food.Id} | {food.Name} | {food.Type} | {food.Cost.ToString("#.00")} | {food.Cal.ToString("#.00")} | {food.CostRate} |");
                Console.WriteLine();
            }
        }
    }
}