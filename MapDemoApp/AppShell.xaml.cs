namespace MapDemoApp
{
    public partial class AppShell : Shell
    {
        public Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public AppShell()
        {
            InitializeComponent();

            routes.Add(nameof(HomePage), typeof(HomePage));

            foreach (var route in routes)
                Routing.RegisterRoute(route.Key, route.Value);
        }
    }
}
