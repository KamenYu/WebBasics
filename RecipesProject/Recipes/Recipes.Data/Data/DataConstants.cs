namespace Recipes.Data.Data
{
    public class DataConstants
    {
        public class User
        {
            public const int UsernameMaxLength = 75;
            public const int PasswordMaxLength = 64;
            public const int EmailMaxLength = 220;
        }
        

        public class Recipe
        {
            public const int NameMaxLength = 200;
            public const int UmageUrlMaxLength = 200;
            public const int DirectionsMaxLength = 4000;
            public const int TimeMaxLength = 100;
        }
        

        public class Ingredient
        {
            public const int NameMaxLength = 100;
            public const int MetricValueMaxLength = 30;
            public const int ExtraInformationMaxLength = 100;
        }
    }
}
