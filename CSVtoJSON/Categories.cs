using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEAScripts
{
    public class Categories
    {
        public List<Dictionary<string, List<string>>> GetCategoriesAsDictionaries()
        {
            List<Dictionary<string, List<string>>> list = new List<Dictionary<string, List<string>>>()
            {
                FoodShops,FoodKeyWords,transportCompanies
            };
            return list;
        }
         
        private Dictionary<string, List<string>> FoodShops = new Dictionary<string, List<string>>() //Reference chat gpt to get all the names
        //GET RID of any the as it can intefer with non food shops
        {
            //First i need a list of names of shops in the uk, then food related key words like deli, pizza, type of food etc..
            //Could use regex 
             { "Food", new List<string> //make it all upper case
                {
                    "Tesco", "Sainsburys", "Asda", "Morrisons", "Waitrose","McDonalds",
                    "Aldi", "Lidl", "Marks & Spencer Foodhall M&S", "Iceland",
                    "Co-op", "Booths", "Budgens", "Spar", "Farmfoods",
                    "Food Warehouse", "Waitrose & Partners", "M&S Simply Food",
                    "Aldi Local", "Lidl Express", "Nisa Local", "Premier Stores",
                    "Costcutter", "Spar Express", "Tesco Express", "Sainsbury's Local",
                    "Co-op Food", "Budgens Local", "Londis", "Best-One",
                    "McColl's", "One Stop", "Jack's", "Booker", "Nisbets",
                    "Planet Organic", "Whole Foods Market", "Daylesford Organic",
                    "Harrods Food Halls", "Fortnum & Mason", "Selfridges Food Hall",
                    "Waitrose Food & Home", "John Lewis Foodhall", "Booths Country",
                    "Aldi Specially Selected", "Lidl Deluxe", "M&S Food to Go",
                    "Iceland Foods", "Heron Foods", "Fulton's Foods", "CoolTrader",
                    "Approved Food", "Musgrave MarketPlace", "AF Blakemore",
                    "Co-operative Wholesale Society (CWS)", "Bestway Wholesale",
                    "East End Foods", "Brakes", "Bidfood", "Makro", "Costco",
                    "Iceland Foods Group", "Spar UK", "Costcutter Supermarkets Group",
                    "Nisa Retail", "Midcounties Co-operative", "Central England Co-operative",
                    "Southern Co-operative", "Scotmid", "East England Co-operative",
                    "Channel Islands Co-operative", "Lincolnshire Co-op", "Chelmsford Star Co-operative",
                    "Midlands Co-operative", "Radstock Co-operative Society", "Co-oplands",
                    "Warrens Bakery", "Greggs", "Pret a Manger", "Subway", "Costa Coffee",
                    "Starbucks", "Caffè Nero", "Poundland", "Poundstretcher", "B&M",
                    "Home Bargains", "Wilko", "Ikea Food", "Primark Food", "TK Maxx Food",
                    "Debenhams Food", "WHSmith Food", "Boots Food", "Superdrug",
                    "Holland & Barrett", "Savers", "Body Shop", "Lush",
                    "Neal's Yard Remedies", "Space NK", "Superdrug Health",
                    "GNC (General Nutrition Centers)", "Holland & Barrett More",
                    "Health Store", "Revital", "As Nature Intended", "Better Food",
                    "Grape Tree", "Wholefoods", "Natural Way", "GreenBay",
                    "Harvest Natural Foods", "Fresh & Wild", "Infinity Foods",
                    "Real Foods", "Suma Wholefoods", "Essential Trading",
                    "Community Foods", "Source Bulk Foods", "Sourced Market",
                    "Oliver's Real Food", "Grocer", "Fine Food Specialist",
                    "British Corner Shop", "Iceland Foods Ltd.", "EAT.", "Itsu",
                    "Wasabi", "YO! Sushi", "Pret A Manger", "Leon", "Wagamama",
                    "GAIL's Bakery", "Paul UK", "Crussh", "Caffe Nero", "Le Pain Quotidien",
                    "Patisserie Valerie", "Gourmet Burger Kitchen (GBK)", "Byron",
                    "PizzaExpress", "Zizzi", "Franco Manca", "Wahaca", "Bella Italia",
                    "Carluccio's", "ASK Italian", "Gino D'Acampo - My Restaurant",
                    "Bills", "Jamie's Italian", "Ivy Collection", "Dishoom",
                    "Flat Iron", "Hawksmoor", "Dabbous", "Sketch", "Duck & Waffle","Deli"
                }
            }
        };

        private Dictionary<string, List<string>> FoodKeyWords = new Dictionary<string, List<string>>()
        {
            { "Food", new List<string>
                {
                    "grocery", "supermarket", "store", "shop", "market", "restaurant",
                    "caffe","cafe", "diner", "eatery", "food", "meal", "snack", "fast food",
                    "takeout", "delivery", "cuisine", "bistro", "bakery", "butcher",
                    "deli", "pizzeria", "grill", "barbecue", "buffet", "catering",
                    "pub", "coffee shop", "tea house", "ice cream", "smoothie",
                    "chicken", "beef", "pork", "fish", "seafood", "vegetarian",
                    "vegan", "gluten-free", "dairy-free", "nut-free", "organic",
                    "local produce", "farmers' market", "food truck", "food stand",
                    "pop-up restaurant", "street food", "burger", "pizza", "sandwich",
                    "sushi", "taco", "noodle", "ramen", "curry", "soup", "salad",
                    "spaghetti", "rice", "pasta", "steak", "grilled chicken",
                    "fried chicken", "roast beef", "BBQ ribs", "fish and chips",
                    "lobster", "shrimp", "crab", "clams", "oysters", "mussels",
                    "scallops", "calamari", "crab cakes", "vegetable stir-fry",
                    "tofu", "quinoa", "avocado toast", "smoothie bowl", "fruit salad",
                    "yogurt parfait", "pancakes", "waffles", "french toast",
                    "omelette", "scrambled eggs", "bacon", "sausage", "hash browns",
                    "grits", "biscuits and gravy", "bagel with lox", "croissant",
                    "danish pastry", "muffin", "cupcake", "cookie", "brownie",
                    "cake", "pie", "ice cream sundae", "gelato", "sorbet", "milkshake",
                    "smoothie", "coffee", "latte", "cappuccino", "espresso",
                    "iced coffee", "tea", "herbal tea", "lemonade", "juice",
                    "soda", "water", "wine", "beer", "cocktail", "whiskey",
                    "vodka", "rum", "tequila", "mocktail", "tapas", "appetizer",
                    "soup", "salad", "main course", "side dish", "dessert",
                    "breakfast", "brunch", "lunch", "dinner", "snack", "foodie",
                    "recipe", "cooking", "baking", "grilling", "roasting", "steaming",
                    "sauteing", "frying", "boiling", "stir-frying", "sous-vide",
                    "marinating", "simmering", "poaching", "smoking", "pickling",
                    "canning", "preserving", "fermenting", "food pairing",
                    "food tasting", "food photography", "food blogger",
                    "food critic", "food trends", "comfort food", "street food",
                    "food truck", "food festival", "culinary", "gastronomy",
                    "meal prep", "grains", "spices", "herbs", "seasonings",
                    "flavours", "taste","tortilla", "drinks", "College","Sixth Form"
                }
            }
        };

        private Dictionary<string, List<string>> transportCompanies = new Dictionary<string, List<string>>()
        {
            {"Transport", new List<string>
                {
                   "Transport for London (TfL)", "National Rail", "London Underground", "London Overground", "Docklands Light Railway (DLR)", "Tramlink", "Merseyrail", "Glasgow Subway", "Edinburgh Trams", "Northern Ireland Railways",
                    "Uber", "Lyft", "Bolt", "Ola", "Taxi", "Panther",
                    "Black Cabs", "Addison Lee", "Green Cabs", "UberTaxi",
                    "Hertz", "Enterprise", "Avis", "Budget", "Europcar", "Thrifty Car Rental",
                    "Royal Mail", "ParcelForce", "DPD", "Hermes", "Yodel", "UPS", "FedEx", "DHL",
                    "CitySprint", "Courier Expert", "eCourier", "Gophr",
                    "Maersk Line", "Mediterranean Shipping Company (MSC)", "CMA CGM Group", "P&O Ferries", "Stena Line", "Brittany Ferries",
                    "British Airways", "EasyJet", "Ryanair", "Virgin Atlantic", "Flybe", "Jet2", "Wizz Air", "Thomas Cook Airlines",
                    "Minicab Services", "Executive Car Services", "Chauffeur Driven Cars", "Helicopter Charter Services",
                    "National Express", "Megabus", "Stagecoach", "Arriva", "First Bus", "Go-Ahead Group",
                    "Virgin Trains", "London North Eastern Railway (LNER)", "Great Western Railway (GWR)", "CrossCountry", "ScotRail", "Southern", "Southeastern", "Northern", "TransPennine Express", "Caledonian Sleeper", "Chiltern Railways", "East Midlands Railway",
                    "Santander Cycles", "Lime", "Jump", "Mobike",
                    "NCP (National Car Parks)", "Q-Park", "Euro Car Parks",
                    "Thomas Cook", "TUI", "Expedia", "Booking.com",
                    "Shell", "BP", "Esso", "Texaco",
                    "Dart Charge", "Mersey Tunnels",
                    "AA (Automobile Association)", "RAC (Royal Automobile Club)",
                    "Heathrow Airport", "Gatwick Airport", "Manchester Airport", "Stansted Airport", "Luton Airport", "Edinburgh Airport", "Glasgow Airport", "Birmingham Airport", "Bristol Airport", "Newcastle Airport", "Liverpool John Lennon Airport",
                    "Dartford Crossing", "Mersey Gateway",
                    "Kapten", "Gett",
                    "BP Chargemaster", "Pod Point", "Shell Recharge", "Tesla Supercharger",
                    "Red Funnel", "Wightlink", "Thames Clippers", "Serco NorthLink Ferries", "DFDS Seaways",
                    "Trainline", "National Rail Enquiries",
                    "Aviva", "Direct Line", "AXA",
                    "Green Flag", "Start Rescue", "AutoAid",
                    "LeasePlan", "ALD Automotive", "Arval",
                    "RAC Vehicle Inspections", "AA Vehicle Inspections",
                    "Balfour Beatty", "Costain", "Kier Group",
                    "Citymapper", "Waze", "Moovit", "Trainline", "UberEats",
                    "TomTom", "Garmin",
                    "Evans Cycles", "Halfords", "Cycle Republic",
                    "Siemens Mobility", "Bombardier Transportation", "Transport Systems Catapult",
                    "Lime", "Bird", "Voi", "Tier",
                    "Emirates Air Line",
                    "Arup", "Mott MacDonald", "Atkins", "Steer",
                    "Cubic Transportation Systems", "HERE Technologies", "Moovel",
                    "No.1 Lounge", "Aspire Lounge", "Escape Lounge",
                    "Network Rail", "HS2 (High-Speed Two)",
                    "Transport Research Laboratory (TRL)", "Centre for Transport Studies (UCL)",
                    "Tesla", "Nissan", "BMW", "Audi", "Jaguar", "Volkswagen",
                    "Virgin Hyperloop", "Elon Musk's The Boring Company",
                    "SpaceX", "Blue Origin",
                    "Hovertravel", "Hoverspeed",
                    "London Transport Museum", "National Railway Museum", "Brooklands Museum",
                    "Tour de France", "Tour of Britain",
                    "Triumph", "Norton", "Royal Enfield",
                    "Alpinestars", "Dainese", "Shoei",
                    "London EV Show", "The Commercial Vehicle Show", "InnoTrans",
                    "Sustrans", "Campaign for Better Transport", "Transport Focus",
                    "Citymapper", "Hyperloop One", "SkyDrive",
                    "BBC Travel", "Top Gear", "TransportXtra",
                }

            }
        };     
    }
}
