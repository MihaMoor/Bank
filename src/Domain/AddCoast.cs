namespace Domain;

public class AddCoast
{
    public static double Add(DateTime lastAdding, double dailyFinance)
    {
        double finance = 0;

        if (lastAdding.Day != DateTime.Now.Day)
        {
            int daysCount = lastAdding.Day - DateTime.Now.Day;
            finance += dailyFinance * daysCount;
        }

        return finance;
    }
}
