using System.Globalization;

namespace Bank_Project
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Client client = new Client();
			client.AusfüllenNeueKundenInfo();

			Menu menu = new Menu();
			menu.MainMenu(client);
		}
	}
}