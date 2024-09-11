namespace Task_4_2
{
    internal class Program
    {
      
        struct buyer
        {

            public int money;
            public int idcard;
            public int items;
            public int startmoney;
            public buyer(Random rnd)
            {
                this.idcard = rnd.Next(1, 1000);
                this.money = rnd.Next(1000, 10000);
                this.startmoney = money;
                this.items = 0;

            }

        }

        struct product
        {
            public string name;
            public int price;
            public int quantity;


            public product(string name, int price, int quantity)
            {
                this.name = name;
                this.price = price;
                this.quantity = quantity;

            }
        }
        static void Shopping(ref product product, ref buyer buyers, ref int shopProfit)
        {
            if (product.quantity > 0 && buyers.money >= product.price)
            {
                buyers.money -= product.price;
                buyers.items += 1;
                product.quantity -= 1;
                shopProfit += product.price;

            }

        }

        static buyer[] CreateBuyers()
        {
            int countBuyer = int.Parse(Console.ReadLine());
            buyer[] buyers = new buyer[countBuyer];
            Random rnd = new Random();
            for (int i = 0; i < countBuyer; i++)
            {
                buyers[i] = new buyer(rnd);
                Console.WriteLine($"Buyer {i + 1}: ID Card {buyers[i].idcard}, Money {buyers[i].money}");
            }
            return buyers;
        }

        static void Main(string[] args)
        {
            int shopProfit = 0;
            product[] products = new product[]
            {
        new product ("Milk", 50, 20),
        new product ("Yougurt", 30, 20),
        new product ("Apples", 55, 100),
        new product ("Strawberry", 150, 50),
        new product ("bottle of water", 10, 20),
        new product ("Bread", 20, 10),
        new product ("Bottle of juce", 25, 20)

            };
            Console.WriteLine("Welcome to the shop! Please, enter the number of buyer:");
            buyer[] buyers = CreateBuyers();
            Console.WriteLine($"Current shop profit: {shopProfit}");
            for (int i = 0; i < buyers.Length; i++)
            {
                for (int j = 0; j < products.Length; j++)
                {
                    while (buyers[i].money >= products[j].price && products[j].quantity > 0)
                    {
                        Shopping(ref products[j], ref buyers[i], ref shopProfit);
                    }
                }
            }


            buyer maxbuyeritems = buyers[0];
            buyer maxspentmoney = buyers[0];
            int maxitems = buyers[0].items;
            int maxspent = buyers[0].startmoney - buyers[0].money;

            for (int i = 0; i < buyers.Length; i++)
            {
                if (buyers[i].items > maxitems)
                {
                    maxitems = buyers[i].items;
                    maxbuyeritems = buyers[i];
                }

                int spentMoney = buyers[i].startmoney - buyers[i].money;
                if (spentMoney > maxspent)
                {
                    maxspent = spentMoney;
                    maxspentmoney = buyers[i];
                }
            }

            Console.WriteLine($"Shop's final profit: {shopProfit}");
            for (int i = 0; i < buyers.Length; i++)
            {
                Console.WriteLine($"Buyer {i + 1}: ID Card {buyers[i].idcard}, Money {buyers[i].money}, Items bought: {buyers[i].items}");
            }
            Console.WriteLine($"Buyer who bought the most items: ID Card {maxbuyeritems.idcard}, Items: {maxbuyeritems.items}");
            Console.WriteLine($"Buyer who spent the most money: ID Card {maxspentmoney.idcard}, Money Spent: {maxspent}");

        }

    }
}
