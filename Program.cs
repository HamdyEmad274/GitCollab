namespace GitCollab
{
    // ============================================
    // SESSION 20: GIT ADVANCED & COLLABORATION
    // Starter file — the instructor will guide you
    // through creating branches, causing conflicts,
    // and resolving them during the session.
    //
    // This file represents the initial state of a
    // shared codebase that two "developers" — Maya
    // and Ben — will both modify, demonstrating
    // fast-forward merges, 3-way merges, and a real
    // merge conflict.
    //
    // GPS-Precision Rule: this file is a TODO guide,
    // not working code. Every method body below is
    // filled in LIVE during the session, typed by
    // hand, never pasted. If the live demo breaks,
    // open ../../BackupProject/GitCollab/Program.cs
    // for the exact final state.
    // ============================================

    public class OrderCalculator
    {
        // TODO (Block 3 — Merge Conflict Demo):
        // Maya's branch (feature/tax-15) changes this to 0.15m.
        // Ben's branch (feature/tax-13) changes this to 0.13m.
        // Both branch from THIS exact line → triggers a real
        // merge conflict when both are merged into main.
        public decimal CalculateTax(decimal amount) => amount * 0.13m;

        // TODO (Your Turn — Block 3):
        // feature/discount-a changes this to 0.08m
        // feature/discount-b changes this to 0.10m (from the SAME
        // starting line) → students reproduce their own conflict here.
        public decimal CalculateDiscount(decimal amount) => amount * 0.05m;

        public decimal CalculateTotal(decimal amount)
        {
            decimal tax = CalculateTax(amount);
            decimal discount = CalculateDiscount(amount);
            return amount + tax - discount;
        }

        // TODO (Guided Practice):
        // Add an ApplyCoupon(decimal amount, decimal percentOff) method here,
        // live, on its own feature branch, reviewed through a real PR.
    }

    public class ProductService
    {
        // TODO (Block 1 — feature/products):
        // Add a small in-memory Dictionary<int, string> of products and a
        // GetProduct(int id) lookup method here. Commit on feature/products.
        // Merge into main in Block 2 — this is the CLEAN FAST-FORWARD demo,
        // since nothing else touches main while this branch is being built.

        private static readonly Dictionary<int, string> _products = new()
        {
            { 1, "Laptop" },
            { 2, "Smartphone" },
            { 3, "Tablet" }
        };

        public string GetProduct(int id)
        {
            return _products.TryGetValue(id, out var product) ? product : "Unknown Product";
        }

    }

    public class OrderService
    {
        // TODO (Block 2 — feature/orders):
        // Add a constructor taking a ProductService, and a
        // ProcessOrder(int orderId) method that looks up the product and
        // prints a confirmation. Commit on feature/orders.
        //
        
        private readonly ProductService _productService;
        public OrderService(ProductService productService)
        {
            _productService = productService;
        }

        public void ProcessOrder(int orderId)
        {
            Console.WriteLine($"[OrderService] Processing order #{orderId}");
            string product = _productService.GetProduct(orderId);
            Console.WriteLine($"[OrderService] Product: {product}");
            Console.WriteLine($"[OrderService] Done processing order #{orderId}");
        }
        // IMPORTANT: while this branch is being built, LoggingService below
        // gets added DIRECTLY to main — that's what forces the 3-WAY MERGE
        // when feature/orders is merged afterward.

        // TODO (Block 4 — Pull Requests, feature/returns):
        // Add a ProcessReturn(int orderId) stub here, pushed on its own
        // branch, opened as a real PR, reviewed, fix-committed, then
        // squash-merged.
    }

    public class LoggingService
    {
        // TODO (Block 2 — committed DIRECTLY to main, NOT on a branch):
        // Add a Log(string message) method that prints a timestamped line.
        // This commit is what makes main move while feature/orders is still
        // in progress elsewhere — the exact setup for a 3-way merge.

        public void Log(string message) 
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] LOG : {message}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("+=======================================+");
            Console.WriteLine("|  SESSION 20: GIT ADVANCED & COLLAB     |");
            Console.WriteLine("+=======================================+\n");

            var calc = new OrderCalculator();
            decimal orderAmount = 1000m;

            Console.WriteLine($"Order Amount:  {orderAmount:C}");
            Console.WriteLine($"Tax (14%):     {calc.CalculateTax(orderAmount):C}");
            Console.WriteLine($"Discount (5%): {calc.CalculateDiscount(orderAmount):C}");
            Console.WriteLine($"Total:         {calc.CalculateTotal(orderAmount):C}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
