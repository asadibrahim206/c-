using System;
using System.IO;

class PaymentProcessor
{
    static void Main()
    {
        Console.WriteLine("=== Payment Processor ===");
        
        try
        {
            ProcessPayment();
        }
        catch (Exception ex)
        {
            LogError(ex.Message);
            Console.WriteLine("\nPayment failed. Please try again later.");
        }
        finally
        {
            Console.WriteLine("\nTransaction attempt completed.");
        }
    }

    static void ProcessPayment()
    {
        int retryCount = 0;
        int maxRetries = 3;
        
        Console.WriteLine($"\nStarting payment process (max {maxRetries} attempts)...");
        
        while (retryCount < maxRetries)
        {
            try
            {
                retryCount++;
                Console.WriteLine($"\nAttempt #{retryCount}:");
                SimulatePayment();
                Console.WriteLine("✅ Payment Successful!");
                return;
            }
            catch (TimeoutException)
            {
                LogError("Network timeout occurred.");
                Console.WriteLine("⚠️  Network timeout occurred.");
                
                if (retryCount < maxRetries)
                    Console.WriteLine("Retrying transaction...");
            }
            catch (InvalidOperationException ex)
            {
                LogError(ex.Message);
                Console.WriteLine($"❌ {ex.Message}");
                throw; // Critical error, rethrow
            }
            catch (IOException ex)
            {
                LogError(ex.Message);
                Console.WriteLine($"❌ {ex.Message}");
                throw;
            }
        }
        
        throw new Exception("Payment failed after multiple retries.");
    }

    static void SimulatePayment()
    {
        Random rand = new Random();
        int value = rand.Next(1, 5); // 1 to 4
        
        // Add a successful case
        if (value == 1)
            throw new TimeoutException();
        else if (value == 2)
            throw new InvalidOperationException("Invalid card details.");
        else if (value == 3)
            throw new IOException("Server unavailable.");
        // value == 4 means success - nothing happens
    }

    static void LogError(string message)
    {
        try
        {
            File.AppendAllText("error_log.txt",
                $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}");
        }
        catch
        {
            // If file logging fails, continue without it
            Console.WriteLine($"[Could not write to log: {message}]");
        }
    }
}