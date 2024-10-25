using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Project
{
	internal class Client : BankAccount                   // Klasse mit allen Informationen über die Kunden
	{
		public string Name { get; private set; }
		public DateTime Geburtsdatum { get; private set; }
		public int AccountNumber { get; private set; }

		public void AusfüllenNeueKundenInfo()         // Methode zum Ausfüllen grundlegender Kundeninformationen
		{                                                     //über den Kunden, Namen und Geburtsdatum.
			Console.Write("Bitte geben Sie Ihren Namen ein: ");
			Name = Console.ReadLine();                      //Wir bitten den Kunden, einen Namen einzugeben.

			Console.Write("Bitte geben Sie Ihr Geburtsdatum in diesem Format an (Tag, Monat, Jahr): ");
									//Wir bitten den Kunden, das Geburtsdatum einzugeben.
			bool check = false;
			while (!check)
			{

				try
				{
					CultureInfo cultureInfo = new CultureInfo("de-DE");
					Geburtsdatum = DateTime.Parse(Console.ReadLine(), cultureInfo, DateTimeStyles.NoCurrentDateDefault);
																//Speichern die eingegebenen Daten im richtigen Format.
					DateTime currentDate = DateTime.Now;
					int age = currentDate.Year - Geburtsdatum.Year;     //prüfen, ob der Kunde volljährig ist
					if (age >= 18)
					{
						Console.WriteLine("\nWillkommen bei unserer Bank als Neukunde!\n");
						CreateAccountNumber();					  //erstellen eine Kontonummer für einen neuen Kunden.
						BankStatement(new String('*', 40) + " Kontoauszug " + new String('*', 40));
						BankStatement(ClientInfoDruck());			//Speichern Kundeninformationen zum Bezahlen in einer Textdatei.
						check = true;
					}
					else
					{
						Console.WriteLine("Sie sind zu jung und können kein Konto eröffnen.");
					}
				}
				catch (Exception)           //erkennen einen Fehler, wenn der Kunde das Geburtsdatum falsch eingegeben hat.
				{
					Console.WriteLine("Das eingegebene Datum ist nicht im richtigen Format. " +
								"Bitte verwenden Sie das Format Tag.Monat.Jahr (z.B. 25.12.1995).");
				}
			}
		}
		public int CreateAccountNumber()        // Erstellt eine Kontonummer aus 8 zufälligen Ziffern
		{
			Random rand = new Random();
			int[] accountNumberArr = new int[8];
			for (int i = 0; i < accountNumberArr.Length; i++)
			{
				accountNumberArr[i] = rand.Next(0, 10);
			}
			AccountNumber = int.Parse(string.Concat(accountNumberArr));
			return AccountNumber;
		}

		public void ClientInfo()            // Zeigt die Kundeninformationen auf Wunsch des Benutzers an
		{
			Console.WriteLine($"\nKundename: {Name}, Geburtsdatum: {Geburtsdatum.ToLongDateString()}," +
											$" Bankkontonummer: {AccountNumber}\n");
		}
		public string ClientInfoDruck()         // Speichert die Kundeninformationen für den Kontoauszug
		{
			return ($"\nKundename: {Name}, Geburtsdatum: {Geburtsdatum.ToLongDateString()}," +
									$" Bankkontonummer: {AccountNumber}\n");
		}
	}
}