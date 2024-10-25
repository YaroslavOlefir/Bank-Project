using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Project
{
	internal class Menu         // Eine Klasse, die verschiedene Aktionen auf einem Konto ermöglicht
	{
		public void MainMenu(Client client)
		{

			while (true)
			{
				int antwort = 0;
				bool check = false;

				Console.WriteLine("Was möchten Sie machen?\n1 - Kundeninformation bekommen\n2 - Einzahlung von Geldern" +
										"\n3 - Abhebungen\n4 - Guthaben prüfen\n5 - Programm schließen");

				while (check != true || antwort < 1 || antwort > 5)     // Überprüfung der Kundenantwort
				{
					check = int.TryParse(Console.ReadLine(), out antwort);

					if (check != true || antwort < 1 || antwort > 5)
					{
						Console.WriteLine("Das ist ein falsches Zeichen, bitte schreiben Sie Zahl von 1 bis 5!");
					}
				}
				Execution executing = new Execution();
				executing.OperationExecution(antwort, client);

				if (antwort == 5)       // Überprüfung, ob der Kunde das Programm schließen möchte
				{
					Console.WriteLine("\nMöchten Sie das Programm schließen? Ja/Nein");
					string durchführenAntwort = Console.ReadLine().ToLower();
					if (durchführenAntwort == "ja")         //schließen, wenn die Antwort „Ja“ 
					{
						client.BankStatement(client.BalanceDruck());
						Console.WriteLine("\nAuf Wiedersehen!");
						break;
					}
				}
			}
		}
	}
}
