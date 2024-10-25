using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Project
{
	internal class BankAccount       // Klasse mit Aktionen auf einem Bankkonto
	{
		public double balance { get; private set; }
		private double amount;

		public double AmountCheck()             // Fordert den Betrag zur Einzahlung oder Abhebung an
		{
			Console.Write("Bitte geben Sie die Summe: ");

			while (!double.TryParse(Console.ReadLine(), out amount) || amount < 0) //Überprüfung der Richtigkeit der Eingabe.
			{
				Console.WriteLine("Das ist ein falsches Zeichen, bitte schreiben Sie Zahl");
			}
			return amount;
		}
		public void Deposit(double amount)      // Führt die Einzahlung durch und zeigt sie auf dem Bildschirm an
		{
			balance += amount;
			string depositDruck = ($"Der Nachschub war erfolgreich, {amount} EUR eingezahlt Ihrem Konto.");
			BankStatement(depositDruck);					//Speichern die Kontoauffüllung in einer Textdatei für den Kontoauszug.
			Console.WriteLine(depositDruck);
		}
		public void Withdraw(double amount)		 // Führt die Abhebung durch und zeigt sie auf dem Bildschirm an
		{
			if (balance >= amount)
			{
				balance -= amount;
				string withdrawDruck = ($"Die Abbuchung war erfolgreich, {amount} EUR wurden von Ihrem Konto abgebucht.");
				BankStatement(withdrawDruck);				 //Speichern die Geldabhebung in einer Textdatei für den Kontoauszug.
				Console.WriteLine(withdrawDruck);
			}
			else
			{
				Console.WriteLine("Unzureichende Mittel.");
			}
		}
		public void CheckBalance()							  // Zeigt den aktuellen Kontostand an
		{
			Console.WriteLine($"Kontostand ist {balance} EUR.");
		}
		public string BalanceDruck()						 // Speichert den Endsaldo für den Kontoauszug
		{
			return ("\n" + new String(' ', 70) + $"Kontostand ist {balance} EUR.\n");
		}
		public void BankStatement(string bankStatement)         // Speichert die Bankvorgänge in einer Textdatei
		{
			try
			{
				FileInfo file = new FileInfo(@"C:\Users\OlefirYaroslav\source\repos\Bank Project\Kontoauszug.txt");
				using (StreamWriter writer = file.AppendText())
				{
					writer.WriteLine(bankStatement);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Es ist ein Fehler aufgetreten: " + e.Message);
				Console.WriteLine();
			}
		}
	}
}
