namespace practic__4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of customers");
            int users = int.Parse(Console.ReadLine());

            Random rnd = new Random();
            int[] userMoney = new int[users];
            int[] cardNum = new int[users];
            int[] goodsBought = new int[users];
            int[] moneySpent = new int[users];

            for (int i = 0; i < users; i++)
            {
                cardNum[i] = rnd.Next(0, 1000);
                userMoney[i] = rnd.Next(1000, 10000);
            }

            int profit = 0;

            Goods[] goods = new Goods[5];
            Goods Game = new Goods(200, 15, "Dead by Daylight");
            Goods Game2 = new Goods(100, 30, "Mafia Trilogy");
            Goods Game3 = new Goods(150, 50, "Payday 2");
            Goods Game4 = new Goods(200, 60, "Borderlands");
            Goods Game5 = new Goods(140, 20, "Terraria");

            goods[0] = Game;
            goods[1] = Game2;
            goods[2] = Game3;
            goods[3] = Game4;
            goods[4] = Game5;

            for (int i = 0; i < users; i++)
            {

                bool canBuy = true;
                while (canBuy)
                {
                    canBuy = false; 

                    for (int j = 0; j < goods.Length; j++)
                    {
                        if (goods[j].count > 0 && userMoney[i] >= goods[j].price)
                        {
                            goods[j].count--;
                            userMoney[i] -= goods[j].price;
                            goodsBought[i]++;
                            moneySpent[i] += goods[j].price;
                            profit += goods[j].price;

                            canBuy = true; 
                        }
                    }
                }
            }
            int maxGoodsIndex = 0;
            int maxSpentIndex = 0;

            for (int i = 1; i < users; i++)
            {
                if (goodsBought[i] > goodsBought[maxGoodsIndex])
                {
                    maxGoodsIndex = i;
                }

                if (moneySpent[i] > moneySpent[maxSpentIndex])
                {
                    maxSpentIndex = i;
                }
            }

            Console.WriteLine($"Total profit of the store: {profit}");
            Console.WriteLine($"Card number of the buyer who bought the most goods: {cardNum[maxGoodsIndex]}, Number of goods purchased: {goodsBought[maxGoodsIndex]}");
            Console.WriteLine($"The card number of the buyer who spent the most money: {cardNum[maxSpentIndex]}, Money spent: {moneySpent[maxSpentIndex]}");
        }
    }
}
