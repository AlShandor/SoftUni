using System;

class PriceChangeAlert
{
    static void Main()
    {
        int numberPrices = int.Parse(Console.ReadLine());
        double treshold = double.Parse(Console.ReadLine());
        double lastPrice = double.Parse(Console.ReadLine());

        for (int i = 0; i < numberPrices - 1; i++)
        {
            double currentPrice = double.Parse(Console.ReadLine());
            double difference = CalcDifferrenceLastCurrentPrice(lastPrice, currentPrice);
            bool isDifferent = IsDifferent(difference, treshold);
            string message = GetMessage(currentPrice, lastPrice, difference, isDifferent);
            Console.WriteLine(message);
            lastPrice = currentPrice;
        }
    }

    static string GetMessage(double currentPrice, double lastPrice, double difference, bool isDifferent)
    {
        string message = "";
        if (difference == 0)
        {
            message = string.Format("NO CHANGE: {0}", currentPrice);
        }
        else if (!isDifferent)
        {
            message = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, difference);
        }
        else if (isDifferent && (difference > 0))
        {
            message = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, difference);
        }
        else if (isDifferent && (difference < 0))
        {
            message = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, difference);
        }
            
        return message;
    }

    static bool IsDifferent(double difference, double treshlod)
    {
        if (Math.Abs(difference) >= treshlod)
        {
            return true;
        }
        return false;
    }

    static double CalcDifferrenceLastCurrentPrice(double lastPrice, double currentPrice)
    {
        double result = (currentPrice - lastPrice) / lastPrice;
        return result;
    }
}
